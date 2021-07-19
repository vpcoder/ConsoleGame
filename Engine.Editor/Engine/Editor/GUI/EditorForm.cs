using Engine.Data;
using Engine.Editor;
using Engine.Services;
using GameEditor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameEditor
{

    /// <summary>
    /// Текущий режим работы с редактором
    /// </summary>
    public enum Mode : int
    {

        /// <summary>
        /// Ничего не происходит
        /// </summary>
        None   = 0x00,

        /// <summary>
        /// Хотим перемещаться по карте
        /// </summary>
        Move   = 0x01,

        /// <summary>
        /// Хотим добавлять объекты на карту
        /// </summary>
        Add    = 0x02,

        /// <summary>
        /// Хоим удалять объекты на карте
        /// </summary>
        Delete = 0x03,

    };

    public partial class EditorForm : Form
    {
        private IDictionary<string, int> idToImageIndex = new Dictionary<string, int>();
        private ImageList images = new ImageList();
        private World world;

        private Vector2 mouseDownPoint = Vector2.Empty;

        /// <summary>
        /// Текущий выбранный тип объектов
        /// </summary>
        private ObjectType selectedType = ObjectType.Tile;

        /// <summary>
        /// Что мы сейчас делаем
        /// </summary>
        private Mode Mode = Mode.None;

        /// <summary>
        /// Последняя нажатая клавиша
        /// </summary>
        private KeyEventArgs keyDown = new KeyEventArgs(Keys.D0);

        /// <summary>
        /// Текущий выбранный объект в дереве справа
        /// </summary>
        private ISprite selected = null;

        private int CurrentLayout
        {
            get
            {
                return lstLayout.SelectedIndex;
            }
        }

        private int BrushSize
        {
            get
            {
                return int.Parse(brushSize.Text);
            }
        }

        public EditorForm()
        {
            InitializeComponent();
            LoadObjectTreeList();
            world = new World();
            world.Map.Resize(50, 50);

            Resize += ResizeMethod;
            mainMapSplitter.SplitterMoved += ResizeMethod;

            console.MouseDown += Console_MouseDown;
            console.MouseUp   += Console_MouseUp;
            console.MouseMove += Console_MouseMove;
            console.KeyDown += Console_KeyDown;
            console.KeyUp += Console_KeyUp;

            treeTiles.Click += UpdateSelect;
            treeItems.Click += UpdateSelect;
            treeNPC.Click += UpdateSelect;

            treeTiles.AfterSelect += AfterSelect;
            treeItems.AfterSelect += AfterSelect;
            treeNPC.AfterSelect += AfterSelect;

            InitEditor();
        }

        private void UpdateSelect(object sender, EventArgs e)
        {
            string selected = null;
            switch(selectedType)
            {
                case ObjectType.Tile:
                    selected = treeTiles.SelectedNode?.Text;
                    break;
                case ObjectType.Item:
                    selected = treeItems.SelectedNode?.Text;
                    break;
                case ObjectType.NPC:
                    selected = treeNPC.SelectedNode?.Text;
                    break;
            }
            if (selected == null)
            {
                this.selected = null;
                return;
            }
            this.selected = ObjectProviderService.Instance.GetByName<ISprite>(selected);
        }

        private void ResizeMethod(object sender, EventArgs e)
        {
            MapService.Instance.DrawMap(world, console);
        }

        private void Console_KeyUp(object sender, KeyEventArgs e)
        {
            keyDown = null;
        }

        private void Console_KeyDown(object sender, KeyEventArgs e)
        {
            keyDown = e;
        }

        private void AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selected = e.Node.Text;
            if (selected == null)
            {
                this.selected = null;
                return;
            }
            this.selected = ObjectProviderService.Instance.GetByName<ISprite>(selected);
        }

        private void AddToMatrix(int layout, Vector2 pos, ISprite obj, int brushSize)
        {
            if (obj == null)
                return;

            switch(selectedType)
            {
                case ObjectType.Tile:
                case ObjectType.Item:
                    if (brushSize == 1)
                    {
                        // Добавляем объект на карту
                        world.Map.Set(obj, layout, pos.X, pos.Y);
                    }
                    else
                    {
                        brushSize -= 1;
                        for (int x = -brushSize; x <= brushSize; x++)
                        {
                            for (int y = -brushSize; y <= brushSize; y++)
                            {
                                // Добавляем объект на карту
                                world.Map.Set(obj, layout, pos.X + x, pos.Y + y);
                            }
                        }
                    }
                    break;
                case ObjectType.NPC:
                    if(GetNPC(pos) == null) // В этой точке ещё нет НПС
                    {
                        var newNpc = (INPC)Activator.CreateInstance(obj.GetType());
                        newNpc.Move(pos);
                        newNpc.Direction = Direction.Down;
                        world.NPCs.Add(newNpc);
                    }
                    break;
            }

            MapService.Instance.DrawMap(world, console);
        }

        private INPC GetNPC(Vector2 pos)
        {
            foreach (var npc in world.NPCs)
            {
                if (npc.PosX == pos.X && npc.PosY == pos.Y)
                    return npc;
            }
            return null;
        }

        private void DeleteFromMatrix(int layout, Vector2 pos, int brushSize)
        {
            switch (selectedType)
            {

                case ObjectType.Tile:
                case ObjectType.Item:
                    if (brushSize == 1)
                    {
                        // Убираем объект с карту
                        world.Map.Set(null, layout, pos.X, pos.Y);
                    }
                    else
                    {
                        brushSize -= 1;
                        for (int x = -brushSize; x <= brushSize; x++)
                        {
                            for (int y = -brushSize; y <= brushSize; y++)
                            {
                                // Убираем объект с карту
                                world.Map.Set(null, layout, pos.X + x, pos.Y + y);
                            }
                        }
                    }
                    break;
                case ObjectType.NPC:
                    var npc = GetNPC(pos);
                    if(npc != null)
                        world.NPCs.Remove(npc);
                    break;
            }
            MapService.Instance.DrawMap(world, console);
        }

        private void MoveMatrixView(Vector2 posStart, Vector2 pos)
        {
            world.View.PosX += posStart.X - pos.X;
            world.View.PosY += posStart.Y - pos.Y;
            MapService.Instance.DrawMap(world, console);
        }

        private Vector2 GetPosition(MouseEventArgs e)
        {
            var posInConsole = console.GetPosition(e);
            var posX = posInConsole.X + world.View.PosX;
            var posY = posInConsole.Y + world.View.PosY;
            return new Vector2(posX, posY);
        }

        private void Console_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var layout = CurrentLayout;
            if (layout < 0 || layout >= world.Map.LayoutCount)
                return;

            var pos = GetPosition(e);
            var brushSize = keyDown != null && keyDown.Control ? 4 : BrushSize;

            var mode = Mode;
            if (keyDown != null && keyDown.Alt)
                Mode = Mode.Move;

            // Определяем, в каком режиме сейчас находимся
            switch(Mode)
            {
                case Mode.Add:
                    AddToMatrix(layout, pos, selected, brushSize);
                    break;
                case Mode.Delete:
                    DeleteFromMatrix(layout, pos, brushSize);
                    break;
                case Mode.Move:
                    MoveMatrixView(mouseDownPoint, pos);
                    break;
            }

            Mode = mode;
        }

        private void Console_MouseUp(object sender, MouseEventArgs e)
        {
            var layout = CurrentLayout;
            if (layout < 0 || layout >= world.Map.LayoutCount)
                return;

            var pos = GetPosition(e);

        }

        private void Console_MouseDown(object sender, MouseEventArgs e)
        {
            var layout = CurrentLayout;
            if (layout < 0 || layout >= world.Map.LayoutCount)
                return;

            var pos = GetPosition(e);
            mouseDownPoint = pos;
        }

        private void InitEditor()
        {
            lstLayout.Items.Clear();

            if (world.Map == null)
                return;

            for (int i = 0; i < world.Map.LayoutCount; i++)
                lstLayout.Items.Add(i);

            lstLayout.SelectedIndex = 0;

            MapService.Instance.DrawMap(world, console);
        }


        private void MenuItemNew_Click(object sender, System.EventArgs e)
        {
            var dialog = new NewMapDialog();

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            var size = dialog.MapSize;
            world.Map.Resize(size.Width, size.Height);
            world.Map.Name = dialog.MapName;

            MapService.Instance.DrawMap(world, console);
        }

        /// <summary>
        /// Загружает еревья объектов
        /// </summary>
        private void LoadObjectTreeList()
        {
            var globalImageIndex = 0;
            var emptyImage = Resources.empty;
            images.Images.Clear();

            treeTiles.Nodes.Clear();
            treeTiles.ImageList = images;
            var tilesList = ObjectProviderService.Instance.Get<IObject>(ObjectType.Tile);
            foreach(var tile in tilesList)
            {
                images.Images.Add(tile.ID, ImageFactory.Instance.Get(tile.ID) ?? emptyImage);
                treeTiles.Nodes.Add(new TreeNode(tile.GetType().FullName, globalImageIndex, globalImageIndex));
                idToImageIndex.Add(tile.ID, globalImageIndex++);
            }

            treeItems.Nodes.Clear();
            treeItems.ImageList = images;
            var itemsList = ObjectProviderService.Instance.Get<IItem>(ObjectType.Item);
            foreach (var item in itemsList)
            {
                images.Images.Add(item.ID, ImageFactory.Instance.Get(item.ID) ?? emptyImage);
                treeItems.Nodes.Add(new TreeNode(item.GetType().FullName, globalImageIndex, globalImageIndex));
                idToImageIndex.Add(item.ID, globalImageIndex++);
            }

            treeNPC.Nodes.Clear();
            treeNPC.ImageList = images;
            var npcList = ObjectProviderService.Instance.Get<INPC>(ObjectType.NPC);
            foreach (var npc in npcList)
            {
                images.Images.Add(npc.ID, ImageFactory.Instance.Get(npc.ID, Direction.Down) ?? emptyImage);
                treeNPC.Nodes.Add(new TreeNode(npc.GetType().FullName, globalImageIndex, globalImageIndex));
                idToImageIndex.Add(npc.ID, globalImageIndex++);
            }
        }

        private void BtnAdd_CheckedChanged(object sender, System.EventArgs e)
        {
            Mode = btnAdd.Checked ? Mode.Add : Mode.None;
        }

        private void BtnDelete_CheckedChanged(object sender, System.EventArgs e)
        {
            Mode = btnDelete.Checked ? Mode.Delete : Mode.None;
        }

        private void BtnMove_CheckedChanged(object sender, System.EventArgs e)
        {
            Mode = btnMove.Checked ? Mode.Move : Mode.None;
        }

        private void MenuItemSave_Click(object sender, System.EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Файл карты (*.dat)|*.dat";
            dialog.FileName = "../../../Engine.Game/Maps/";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Engine.Services.MapService.Instance.Save(world, dialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItemLoad_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Файл карты (*.dat)|*.dat";
            dialog.FileName = "../../../Engine.Game/Maps/";

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Engine.Services.MapService.Instance.Load(dialog.FileName, world);
                MapService.Instance.DrawMap(world, console);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TabObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = null;
            switch (tabObjects.SelectedIndex)
            {
                case 0:
                    selectedType = ObjectType.Tile;
                    break;
                case 1:
                    selectedType = ObjectType.Item;
                    break;
                case 2:
                    selectedType = ObjectType.NPC;
                    break;
                default:
                    selectedType = ObjectType.Unknown;
                    break;
            }
        }

    }

}
