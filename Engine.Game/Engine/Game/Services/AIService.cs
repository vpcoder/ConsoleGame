using Engine.Data;

namespace Engine
{

    public class AIService
    {

        private World world;

        private long timestamp = 0;

        public AIService(World world)
        {
            this.world = world;
        }

        public void DoIteration()
        {
            var tmpTime = TimeService.Instance.Time;

            if (TimeService.Instance.GetMills(tmpTime - timestamp) < 100) // Логика отрабатывает не чаще чем раз в 100 миллисекунд
                return;
            timestamp = tmpTime;



        }

    }

}
