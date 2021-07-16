using Engine.Data;
using System.Collections.Generic;

namespace Engine
{

    public class BattleService
    {

        private World world;

        private IList<IBullet> removeList = new List<IBullet>(50);

        private long timestamp = 0;

        public BattleService(World world)
        {
            this.world = world;
        }

        public void DoIteration()
        {
            var tmpTime = TimeService.Instance.Time;

            if (TimeService.Instance.GetMills(tmpTime - timestamp) < 100) // Логика отрабатывает не чаще чем раз в 100 миллисекунд
                return;
            timestamp = tmpTime;

            foreach (var bullet in world.Bullets)
            {
                var move = bullet.Direction.ToVector(); // Перемещаем все снаряды в мире, согласно их направлению движения
                bullet.PosX += move.X;
                bullet.PosY += move.Y;
                if(bullet.MovePath++ >= bullet.MoveMaxPath)
                    removeList.Add(bullet);
            }

            // Чистим память
            foreach(var bullet in removeList)
                world.Bullets.Remove(bullet);
            removeList.Clear();
        }

    }

}
