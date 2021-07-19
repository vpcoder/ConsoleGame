using Engine.Data;
using System.Collections.Generic;

namespace Engine
{

    public class BattleService
    {

        private World world;
        private AIService aiService;

        private IList<IBullet> removeList = new List<IBullet>(50);

        private double timestamp = 0;

        public BattleService(World world, AIService aiService)
        {
            this.world = world;
            this.aiService = aiService;
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

                foreach (var character in world.Characters)
                {
                    if (character.ToPos() == bullet.ToPos())
                    {
                        aiService.DoRangedDamage(bullet, character);
                        removeList.Add(bullet);
                        break;
                    }
                }
            }

            // Чистим память
            foreach(var bullet in removeList)
                world.Bullets.Remove(bullet);

            removeList.Clear();
        }

    }

}
