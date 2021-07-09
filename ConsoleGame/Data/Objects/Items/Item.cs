using System;


namespace Engine.Data
{

    public class Item : Sprite
    {

        public bool IsQuestItem { get; set; }
        public int StackSize { get; set; }
        public int MaxStackSize { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

    }

}
