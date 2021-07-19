using Engine.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using Engine.Services;

namespace Engine
{

    public class AIService
    {
        private World  world;
        private AStarService astarService;
        private Map map;
        private Player player;
        private ICollection<INPC> npcs;

        private double timestamp = 0;
        private Random rnd = new Random();

        public AIService(World world)
        {
            this.world = world;
            this.map = world.Map;
            this.astarService = map.AStarService;
            this.player = world.Player;
            this.npcs = world.NPCs;
        }

        public void DoIteration()
        {
            var tmpTime = TimeService.Instance.Time;

            if (tmpTime - timestamp < 200) // Логика отрабатывает не чаще чем раз в 200 миллисекунд
                return;

            timestamp = tmpTime;

            foreach(INPC npc in npcs)
            {
                if(npc.Target == null) // Вокруг всё чисто, нпс спокоен
                {
                    DoWaitMoveIteration(npc);
                    DoAgressionIteration(npc);
                    continue;
                }
                // НПС проявил агрессию к кому то
                DoBattleIteration(npc);
            }
        }

        /// <summary>
        /// НПС выполняет мирный обход вокруг точки интереса
        /// </summary>
        private void DoWaitMoveIteration(INPC npc)
        {
            var timestamp = TimeService.Instance.Time;

            if(npc.ToPos() == npc.NextPoint) // НПС достиг следующей точки
            {
                if(timestamp - npc.LastUpdateTime >= npc.NextPointChangeTime) // Пора действовать
                {
                    int posX = npc.IntrestingPoint.X + rnd.Next(npc.MoveRadius) - (npc.MoveRadius / 2); // Вычисляем новую точку в окрестностях точки интереса
                    int posY = npc.IntrestingPoint.Y + rnd.Next(npc.MoveRadius) - (npc.MoveRadius / 2);
                    npc.NextPoint = new Vector2(posX, posY);
                    npc.LastUpdateTime = timestamp;
                    npc.NextPointChangeTime = rnd.Next(5000) + 5000; // На новой точке нпс должен подождать примерно от 5 до 10 секунд, прежде чем искать новое место
                    return;
                }
            }
            else // НПС идёт к точке в окресности точки интереса
            {
                var pathPoint = astarService.FindPathNextPoint(npc.ToPos(), npc.NextPoint); // Ищем путь к точке и получаем следующую точку куда пойти

                if(pathPoint == null) // Путь не удалось найти!
                {
                    npc.NextPoint = npc.ToPos();
                    npc.LastUpdateTime = timestamp;
                    npc.NextPointChangeTime = 0;
                    return;
                }

                npc.Direction = npc.ToPos().LookTo(pathPoint.Position); // Смотрим в точку на пути
                npc.Move(pathPoint.Position); // Двигаемся в новую точку по пути
            }
        }

        /// <summary>
        /// НПС смортит, можно ли набить кому то морду поблизости?
        /// </summary>
        private void DoAgressionIteration(INPC npc)
        {
            foreach(var another in world.Characters) // Смотрим других НПС и персонажа
            {
                if (another == npc) // Не смотрим сами на себя
                    continue;

                if(npc.CharacterType.IsEnemy(another.CharacterType)) // Враждебен для НПС?
                {
                    if(npc.ToPos().Distance(another.ToPos()) <= npc.AgressionRadius) // Чужак находится в зоне агрессии этого НПС
                    {
                        DoCatchTarget(npc, another); // Выставляем чужака целью
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Метод захвата цели
        /// </summary>
        /// <param name="npc">НПС захватывающий цель</param>
        /// <param name="target">Цель</param>
        private void DoCatchTarget(INPC npc, ICharacter target)
        {
            npc.Target = target; // Выставляем чужака целью
            CheckStrategy(npc); // Нужно определить дальнейшую стратегию НПС в бою
        }

        /// <summary>
        /// Определяем наиболее оптимальную стратегию боя, вытаскиваем в руки наиболее подходящее оружие.
        /// В приоритете - держаться на расстоянии, если не получается - идём в ближний бой.
        /// </summary>
        /// <param name="npc">НПС, которому нужно перепроверить стратегию битвы</param>
        private void CheckStrategy(INPC npc)
        {
            if (npc.Weapon != null && npc.Weapon is IWeaponRanged) // У НПС в руках оружие дальнего боя
            {
                IWeaponRanged rangedWeapon = (IWeaponRanged)npc.Weapon;
                if (rangedWeapon.Bullet == null || npc.Inventory.GetFirstByType(rangedWeapon.Bullet) != null)  // Оружие не требует снарядов, или в инвентаре есть снаряды для оружия
                {
                    npc.Strategy = BattleStrategyType.Far; // Стратегия "Держаться на расстоянии"
                    return;
                }
            }
            else // В руках нет оружия дальнего боя
            {
                foreach (IWeaponRanged weaponInInventory in npc.Inventory.GetByType<IWeaponRanged>()) // Ищем в инвентаре оружия дальнего боя
                {
                    if (weaponInInventory.Bullet == null || npc.Inventory.GetFirstByType(weaponInInventory.Bullet) != null)  // Оружие не требует снарядов, или в инвентаре есть снаряды для оружия
                    {
                        var tmpRangedWeapon = npc.Weapon;
                        npc.Weapon = weaponInInventory; // Берём в руки найдённое подходящее оружие дальнего боя
                        npc.Inventory.RemoveItem(weaponInInventory); // Убираем оружие дальнего боя из инвентаря
                        if(tmpRangedWeapon != null)
                            npc.Inventory.TryAddItem(tmpRangedWeapon); // Кладём оружие которое было в руках - в инвентарь
                        npc.Strategy = BattleStrategyType.Far; // Стратегия "Держаться на расстоянии"
                        return;
                    }
                }
            }

            var weapons = npc.Inventory.GetByType<IWeaponMelee>().ToList(); // Ищем в инвентаре оружие ближнего боя
            weapons.Sort((o1, o2) => o1.Damage.CompareTo(o2.Damage)); // Сортируем всё по возрастанию урона

            var tmpWeapon = npc.Weapon;
            var weapon = weapons.LastOrDefault(); // Берём в руки найдённое подходящее оружие (или оставляем руки пустыми)

            if(npc.Weapon != null && weapon == null) // Самое подходящее уже в руках
            {
                npc.Strategy = BattleStrategyType.Near; //Применяем стратегию ближнего боя
                return;
            }

            npc.Weapon = weapon; // Меняем оружие в руках на самое лучшее из тех что есть у НПС
            npc.Inventory.RemoveItem(npc.Weapon); // Убираем то что в руках из инвентаря
            if (tmpWeapon != null)
                npc.Inventory.TryAddItem(tmpWeapon); // Кладём оружие которое было в руках - в инвентарь
            npc.Strategy = BattleStrategyType.Near; // Не осталось никаких вариантов, применяем стратегию ближнего боя
        }

        /// <summary>
        /// НПС нашёл цель и стремится разбить кому-то морду
        /// </summary>
        private void DoBattleIteration(INPC npc)
        {
            var target = npc.Target; // Враждебная цель для НПС
            var distance = target.ToPos().Distance(npc.ToPos());
            
            if(distance > npc.AgressionRadius * 2) // Цель ушла дальше чем на 2 радиуса агрессии, значит потерялась из виду
            {
                npc.Target = null; // Отстаём от цели, так как не можем до неё добраться
                npc.NextPoint = npc.ToPos();
                npc.NextPointChangeTime = 0;
                return;
            }

            // Если это необходимо, выравниваем ось
            if(!IsOneAxis(npc, target)) // НПС не стоит на одной оси с целью
            {
                GoToOneAxis(npc, target);
                return;
            }

            var attackDistance = npc.Strategy == BattleStrategyType.Near ? 1 : ((IWeaponRanged)npc.Weapon).Distance; // Дистанция атаки

            if (distance > attackDistance) // До цели всё ещё нужно идти
            {
                GoToTarget(npc, target);
                return;
            }

            switch (npc.Strategy)
            {
                case BattleStrategyType.Far: // Дальний бой, мы готовы к атакам
                    DoFarStrategy(npc);
                    break;
                case BattleStrategyType.Near: // Ближний бой, мы готовы к атакам
                    DoNearStrategy(npc);
                    break;
            }
        }

        private void DoFarStrategy(INPC npc)
        {
            var weapon = (IWeaponRanged)npc.Weapon;
            var timestamp = TimeService.Instance.Time;

            if (timestamp - npc.LastUseWeaponTime < weapon.UseInterval) // Оружие не готово к использованию, перезаряжаемся...
                return;

            npc.LastUseWeaponTime = timestamp;

            var bulletSet = npc.Inventory.GetFirstByType(weapon.Bullet); // Извлекаем первый попавшийся набор подходящих нашему оружию в руках снарядов из инвентаря

            if(bulletSet == null) // Кончились все снаряды в инвентаре
            {
                CheckStrategy(npc); // Пересматриваем стратегию боя
                return;
            }
            bulletSet.StackSize--; // Расходуем снаряд
            if (bulletSet.StackSize == 0) // Полностью израсходовали пачку?
            {
                npc.Inventory.RemoveItem(bulletSet); // Удаляем пустую пачку из инвентаря
            }

            var bullet = (IBullet)Activator.CreateInstance(bulletSet.GetType());
            bullet.MovePath = 0;
            bullet.MoveMaxPath = weapon.Distance;

            DoRangedAttack(npc, weapon, bullet, npc.Target);
        }

        private void DoNearStrategy(INPC npc)
        {
            var weapon = (IWeaponMelee)npc.Weapon;
            var timestamp = TimeService.Instance.Time;

            if (timestamp - npc.LastUseWeaponTime < (weapon != null ? weapon.UseInterval : npc.HandsInterval)) // Оружие/руки не готовы к использованию, перезаряжаемся...
                return;

            npc.LastUseWeaponTime = timestamp;

            DoMeleeAttack(npc, npc.Target);
        }

        /// <summary>
        /// Определяет, находится ли цель и НПС на одной оси для атаки дальнего действия
        /// </summary>
        private bool IsOneAxis(INPC npc, ICharacter target)
        {
            return npc.PosX == target.PosX || npc.PosY == target.PosY;
        }

        private void GoToTarget(INPC npc, ICharacter target)
        {
            var pathPoint = astarService.FindPathNextPoint(npc.ToPos(), target.ToPos()); // Ищем путь к точке и получаем следующую точку куда пойти
            if (pathPoint == null) // Путь не удалось найти!
            {
                npc.Target = null; // Отстаём от цели, так как не можем до неё добраться
                npc.NextPoint = npc.ToPos();
                npc.NextPointChangeTime = 0;
                return;
            }
            npc.Direction = npc.ToPos().LookTo(pathPoint.Position); // Смотрим в точку на пути
            npc.Move(pathPoint.Position); // Двигаемся в новую точку по пути
        }

        private void GoToOneAxis(INPC npc, ICharacter target)
        {
            var xSum = Math.Abs(npc.PosX - target.PosX);
            var ySum = Math.Abs(npc.PosY - target.PosY);
            if(xSum < ySum) // По X достичь одной линии будет быстрее чем по Y
            {
                if (target.PosX > npc.PosX)
                {
                    npc.PosX++;
                }
                else
                {
                    npc.PosX--;
                }
            }
            else  // По Y достичь одной линии будет быстрее чем по X
            {
                if (target.PosY > npc.PosY)
                {
                    npc.PosY++;
                }
                else
                {
                    npc.PosY--;
                }
            }
        }

        private Vector2 GoToOneAxis(ICharacter source, ICharacter target)
        {
            int posX = source.PosX;
            int posY = source.PosY;

            // Вычисляем положение снаряда от атакующего на + 1 клетку в сторону цели

            if (target.PosX != source.PosX && target.PosX > source.PosX)
                posX++;

            if (target.PosY != source.PosY && target.PosY > source.PosY)
                posY++;

            if (target.PosX != source.PosX && target.PosX < source.PosX)
                posX--;

            if (target.PosY != source.PosY && target.PosY < source.PosY)
                posY--;

            return new Vector2(posX, posY);
        }

        /// <summary>
        /// Выполняет атаку оружием ближнего действия (или же без оружия)
        /// </summary>
        /// <param name="source">Атакующий</param>
        /// <param name="weapon">Оружие, которым атакуют, если null - атакуют руками</param>
        /// <param name="target">Цель, которую атакуют</param>
        public void DoMeleeAttack(ICharacter source, ICharacter target)
        {
            
            CalculationService.Instance.DoDamage(source, target); // Рассчитываем передачу урона
        }

        /// <summary>
        /// Выполняет атаку оружием дальнего действия
        /// </summary>
        /// <param name="source">Атакующий</param>
        /// <param name="weapon">Оружие, которым атакуют</param>
        /// <param name="target">Цель, которую атакуют</param>
        public void DoRangedAttack(ICharacter source, IWeaponRanged weapon, IBullet bullet, ICharacter target)
        {
            if (weapon == null)
                return;

            bullet.Source = source; // Запоминаем кто выпустил снаряд
            bullet.Direction = source.ToPos().LookTo(target.ToPos()); // Поворачиваем снаряд в сторону цели
            bullet.Damage += weapon.Damage; // передаём снаряду урон от оружия
            bullet.Move(GoToOneAxis(source, target)); // Выдвигаем снаряд вперёд, относительно направления атакующего
            world.Bullets.Add(bullet); // Добавляем запущенный снаряд в мир
        }

        /// <summary>
        /// Выполняет атаку оружием дальнего действия
        /// </summary>
        /// <param name="target">Цель, которую атакуют</param>
        public void DoRangedDamage(IBullet bullet, ICharacter target)
        {
            CalculationService.Instance.DoDamage(bullet.Source, bullet, target); // Рассчитываем передачу урона
        }

    }

}
