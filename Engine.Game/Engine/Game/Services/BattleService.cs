using Engine.Data;
using Engine.Services;
using System.Collections.Generic;

namespace Engine
{

    /// <summary>
    /// Сервис выполняющий основные функции боя
    /// </summary>
    public class BattleService
    {

        private World world;

        private IList<IBullet> removeList = new List<IBullet>(50);

        private double timestamp = 0;

        public BattleService(World world)
        {
            this.world = world;
        }

        public void DoIteration()
        {
            var tmpTime = TimeService.Instance.Time;

            if (tmpTime - timestamp < 200) // Логика отрабатывает не чаще чем раз в 100 миллисекунд
                return;
            timestamp = tmpTime;

            foreach (var bullet in world.Bullets)
            {
                var move = bullet.Direction.ToVector(); // Перемещаем все снаряды в мире, согласно их направлению движения
                bullet.PosX += move.X;
                bullet.PosY += move.Y;
                if (bullet.MovePath++ >= bullet.MoveMaxPath)
                {
                    removeList.Add(bullet);
                    continue;
                }

                if (CheckBullets(bullet))
                    removeList.Add(bullet);
            }

            // Чистим память
            foreach(var bullet in removeList)
                world.Bullets.Remove(bullet);

            removeList.Clear();
        }

        private bool CheckBullets(IBullet bullet)
        {
            foreach (var character in world.Characters)
            {
                if (character.ToPos() == bullet.ToPos() && !character.Characteristics.IsDead)
                {
                    DoBulletDamage(bullet, character);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Выполняет атаку оружием ближнего действия (или же без оружия)
        /// </summary>
        /// <param name="source">Атакующий</param>
        /// <param name="weapon">Оружие, которым атакуют, если null - атакуют руками</param>
        /// <param name="target">Цель, которую атакуют</param>
        public void DoMeleeAttack(ICharacter source, ICharacter target)
        {
            if (target is INPC)
            {
                var npc = (INPC)target;
                npc.Target = source; // Заставляем сменить цель агрессии на ту, которая била по нам
            }
            CalculationService.Instance.DoDamage(source, target); // Рассчитываем передачу урона
        }

        /// <summary>
        /// Выполняет атаку оружием дальнего действия - выпускает снаряд
        /// </summary>
        /// <param name="source">Атакующий</param>
        /// <param name="weapon">Оружие, которым атакуют</param>
        /// <param name="bullet">Снаряд</param>
        public void DoRangedAttack(ICharacter source, IWeaponRanged weapon, IBullet bullet)
        {
            if (weapon == null)
                return;

            bullet.MovePath = 0;
            bullet.MoveMaxPath = weapon.Distance;
            bullet.Source = source; // Запоминаем кто выпустил снаряд
            bullet.Direction = source.Direction; // Поворачиваем снаряд в сторону цели
            bullet.Damage += weapon.Damage; // передаём снаряду урон от оружия
            bullet.Move(source.ToPos() + source.Direction.ToVector()); // Выдвигаем снаряд вперёд, относительно направления атакующего
            
            if (!CheckBullets(bullet))
                world.Bullets.Add(bullet); // Добавляем запущенный снаряд в мир
        }

        /// <summary>
        /// Выполняет атаку оружием дальнего действия - передаёт урон от снаряда
        /// </summary>
        /// <param name="target">Цель, которую атакуют</param>
        private void DoBulletDamage(IBullet bullet, ICharacter target)
        {
            if (target is INPC)
            {
                var npc = (INPC)target;
                npc.Target = bullet.Source; // Заставляем сменить цель агрессии на ту, которая стреляля по нам
            }
            CalculationService.Instance.DoDamage(bullet.Source, bullet, target); // Рассчитываем передачу урона
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

    }

}
