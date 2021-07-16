
namespace GameEditor
{
    partial class EditorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.manu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRun = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLayout = new System.Windows.Forms.Label();
            this.lstLayout = new System.Windows.Forms.ComboBox();
            this.toolsPanel = new System.Windows.Forms.Panel();
            this.btnMove = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.RadioButton();
            this.lblBrushSize = new System.Windows.Forms.Label();
            this.brushSize = new System.Windows.Forms.DomainUpDown();
            this.mainMapSplitter = new System.Windows.Forms.SplitContainer();
            this.console = new Engine.Console.GraphicConsole();
            this.tabObjects = new System.Windows.Forms.TabControl();
            this.tabTile = new System.Windows.Forms.TabPage();
            this.treeTiles = new System.Windows.Forms.TreeView();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.treeItems = new System.Windows.Forms.TreeView();
            this.tabNPC = new System.Windows.Forms.TabPage();
            this.treeNPC = new System.Windows.Forms.TreeView();
            this.mainLayout.SuspendLayout();
            this.manu.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.toolsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapSplitter)).BeginInit();
            this.mainMapSplitter.Panel1.SuspendLayout();
            this.mainMapSplitter.Panel2.SuspendLayout();
            this.mainMapSplitter.SuspendLayout();
            this.tabObjects.SuspendLayout();
            this.tabTile.SuspendLayout();
            this.tabItems.SuspendLayout();
            this.tabNPC.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.65005F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.34995F));
            this.mainLayout.Controls.Add(this.manu, 0, 0);
            this.mainLayout.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.mainLayout.Controls.Add(this.mainMapSplitter, 0, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 4;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.Size = new System.Drawing.Size(903, 619);
            this.mainLayout.TabIndex = 2;
            // 
            // manu
            // 
            this.mainLayout.SetColumnSpan(this.manu, 2);
            this.manu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemDebug});
            this.manu.Location = new System.Drawing.Point(0, 0);
            this.manu.Name = "manu";
            this.manu.Size = new System.Drawing.Size(903, 20);
            this.manu.TabIndex = 1;
            this.manu.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNew,
            this.menuItemLoad,
            this.menuItemSave});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(48, 16);
            this.menuItemFile.Text = "Файл";
            // 
            // menuItemNew
            // 
            this.menuItemNew.Name = "menuItemNew";
            this.menuItemNew.Size = new System.Drawing.Size(141, 22);
            this.menuItemNew.Text = "Новая карта";
            this.menuItemNew.Click += new System.EventHandler(this.MenuItemNew_Click);
            // 
            // menuItemLoad
            // 
            this.menuItemLoad.Name = "menuItemLoad";
            this.menuItemLoad.Size = new System.Drawing.Size(141, 22);
            this.menuItemLoad.Text = "Загрузить";
            this.menuItemLoad.Click += new System.EventHandler(this.MenuItemLoad_Click);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.Size = new System.Drawing.Size(141, 22);
            this.menuItemSave.Text = "Сохранить";
            this.menuItemSave.Click += new System.EventHandler(this.MenuItemSave_Click);
            // 
            // menuItemDebug
            // 
            this.menuItemDebug.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRun});
            this.menuItemDebug.Name = "menuItemDebug";
            this.menuItemDebug.Size = new System.Drawing.Size(64, 16);
            this.menuItemDebug.Text = "Отладка";
            // 
            // menuItemRun
            // 
            this.menuItemRun.Name = "menuItemRun";
            this.menuItemRun.Size = new System.Drawing.Size(129, 22);
            this.menuItemRun.Text = "Запустить";
            // 
            // flowLayoutPanel2
            // 
            this.mainLayout.SetColumnSpan(this.flowLayoutPanel2, 2);
            this.flowLayoutPanel2.Controls.Add(this.lblLayout);
            this.flowLayoutPanel2.Controls.Add(this.lstLayout);
            this.flowLayoutPanel2.Controls.Add(this.toolsPanel);
            this.flowLayoutPanel2.Controls.Add(this.lblBrushSize);
            this.flowLayoutPanel2.Controls.Add(this.brushSize);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 23);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(897, 39);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // lblLayout
            // 
            this.lblLayout.Location = new System.Drawing.Point(7, 10);
            this.lblLayout.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblLayout.Name = "lblLayout";
            this.lblLayout.Size = new System.Drawing.Size(49, 23);
            this.lblLayout.TabIndex = 0;
            this.lblLayout.Text = "Слой:";
            this.lblLayout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstLayout
            // 
            this.lstLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstLayout.FormattingEnabled = true;
            this.lstLayout.Location = new System.Drawing.Point(62, 10);
            this.lstLayout.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.lstLayout.Name = "lstLayout";
            this.lstLayout.Size = new System.Drawing.Size(121, 21);
            this.lstLayout.TabIndex = 1;
            // 
            // toolsPanel
            // 
            this.toolsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolsPanel.Controls.Add(this.btnMove);
            this.toolsPanel.Controls.Add(this.btnDelete);
            this.toolsPanel.Controls.Add(this.btnAdd);
            this.toolsPanel.Location = new System.Drawing.Point(189, 7);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Size = new System.Drawing.Size(102, 26);
            this.toolsPanel.TabIndex = 2;
            // 
            // btnMove
            // 
            this.btnMove.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnMove.Image = global::GameEditor.Properties.Resources.tools_move_tile;
            this.btnMove.Location = new System.Drawing.Point(60, 0);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(24, 24);
            this.btnMove.TabIndex = 2;
            this.btnMove.TabStop = true;
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.CheckedChanged += new System.EventHandler(this.BtnMove_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnDelete.Image = global::GameEditor.Properties.Resources.tools_delete_tile;
            this.btnDelete.Location = new System.Drawing.Point(30, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(24, 24);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.TabStop = true;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.CheckedChanged += new System.EventHandler(this.BtnDelete_CheckedChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.CheckedChanged += new System.EventHandler(this.BtnAdd_CheckedChanged);
            // 
            // lblBrushSize
            // 
            this.lblBrushSize.Location = new System.Drawing.Point(297, 10);
            this.lblBrushSize.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblBrushSize.Name = "lblBrushSize";
            this.lblBrushSize.Size = new System.Drawing.Size(81, 23);
            this.lblBrushSize.TabIndex = 4;
            this.lblBrushSize.Text = "Размер кисти:";
            this.lblBrushSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // brushSize
            // 
            this.brushSize.Items.Add("1");
            this.brushSize.Items.Add("2");
            this.brushSize.Items.Add("3");
            this.brushSize.Items.Add("4");
            this.brushSize.Items.Add("5");
            this.brushSize.Items.Add("6");
            this.brushSize.Items.Add("7");
            this.brushSize.Location = new System.Drawing.Point(384, 11);
            this.brushSize.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.brushSize.Name = "brushSize";
            this.brushSize.Size = new System.Drawing.Size(46, 20);
            this.brushSize.TabIndex = 3;
            this.brushSize.Text = "1";
            // 
            // mainMapSplitter
            // 
            this.mainLayout.SetColumnSpan(this.mainMapSplitter, 2);
            this.mainMapSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMapSplitter.Location = new System.Drawing.Point(3, 68);
            this.mainMapSplitter.Name = "mainMapSplitter";
            // 
            // mainMapSplitter.Panel1
            // 
            this.mainMapSplitter.Panel1.Controls.Add(this.console);
            // 
            // mainMapSplitter.Panel2
            // 
            this.mainMapSplitter.Panel2.Controls.Add(this.tabObjects);
            this.mainMapSplitter.Size = new System.Drawing.Size(897, 524);
            this.mainMapSplitter.SplitterDistance = 594;
            this.mainMapSplitter.TabIndex = 5;
            // 
            // console
            // 
            this.console.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.console.BackColor = System.Drawing.Color.Black;
            this.console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console.Font = new System.Drawing.Font("Arial", 9F);
            this.console.Location = new System.Drawing.Point(0, 0);
            this.console.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(594, 524);
            this.console.TabIndex = 0;
            // 
            // tabObjects
            // 
            this.tabObjects.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabObjects.Controls.Add(this.tabTile);
            this.tabObjects.Controls.Add(this.tabItems);
            this.tabObjects.Controls.Add(this.tabNPC);
            this.tabObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabObjects.HotTrack = true;
            this.tabObjects.Location = new System.Drawing.Point(0, 0);
            this.tabObjects.Multiline = true;
            this.tabObjects.Name = "tabObjects";
            this.tabObjects.SelectedIndex = 0;
            this.tabObjects.Size = new System.Drawing.Size(299, 524);
            this.tabObjects.TabIndex = 3;
            this.tabObjects.SelectedIndexChanged += new System.EventHandler(this.TabObjects_SelectedIndexChanged);
            // 
            // tabTile
            // 
            this.tabTile.Controls.Add(this.treeTiles);
            this.tabTile.Location = new System.Drawing.Point(4, 4);
            this.tabTile.Name = "tabTile";
            this.tabTile.Padding = new System.Windows.Forms.Padding(3);
            this.tabTile.Size = new System.Drawing.Size(272, 516);
            this.tabTile.TabIndex = 0;
            this.tabTile.Text = "Тайлы";
            this.tabTile.UseVisualStyleBackColor = true;
            // 
            // treeTiles
            // 
            this.treeTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeTiles.Location = new System.Drawing.Point(3, 3);
            this.treeTiles.Name = "treeTiles";
            this.treeTiles.Size = new System.Drawing.Size(266, 510);
            this.treeTiles.TabIndex = 1;
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.treeItems);
            this.tabItems.Location = new System.Drawing.Point(4, 4);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(272, 516);
            this.tabItems.TabIndex = 1;
            this.tabItems.Text = "Предметы";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // treeItems
            // 
            this.treeItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeItems.Location = new System.Drawing.Point(3, 3);
            this.treeItems.Name = "treeItems";
            this.treeItems.Size = new System.Drawing.Size(266, 510);
            this.treeItems.TabIndex = 1;
            // 
            // tabNPC
            // 
            this.tabNPC.Controls.Add(this.treeNPC);
            this.tabNPC.Location = new System.Drawing.Point(4, 4);
            this.tabNPC.Name = "tabNPC";
            this.tabNPC.Size = new System.Drawing.Size(272, 516);
            this.tabNPC.TabIndex = 2;
            this.tabNPC.Text = "НПС";
            this.tabNPC.UseVisualStyleBackColor = true;
            // 
            // treeNPC
            // 
            this.treeNPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeNPC.Location = new System.Drawing.Point(0, 0);
            this.treeNPC.Name = "treeNPC";
            this.treeNPC.Size = new System.Drawing.Size(272, 516);
            this.treeNPC.TabIndex = 0;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 619);
            this.Controls.Add(this.mainLayout);
            this.MainMenuStrip = this.manu;
            this.Name = "EditorForm";
            this.Text = "Editor";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.manu.ResumeLayout(false);
            this.manu.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.toolsPanel.ResumeLayout(false);
            this.mainMapSplitter.Panel1.ResumeLayout(false);
            this.mainMapSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainMapSplitter)).EndInit();
            this.mainMapSplitter.ResumeLayout(false);
            this.tabObjects.ResumeLayout(false);
            this.tabTile.ResumeLayout(false);
            this.tabItems.ResumeLayout(false);
            this.tabNPC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.MenuStrip manu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoad;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
        private System.Windows.Forms.ToolStripMenuItem menuItemDebug;
        private System.Windows.Forms.ToolStripMenuItem menuItemRun;
        private System.Windows.Forms.TabControl tabObjects;
        private System.Windows.Forms.TabPage tabTile;
        private System.Windows.Forms.TreeView treeNPC;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.TabPage tabNPC;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblLayout;
        private System.Windows.Forms.ComboBox lstLayout;
        private System.Windows.Forms.ToolStripMenuItem menuItemNew;
        private Engine.Console.GraphicConsole console;
        private System.Windows.Forms.SplitContainer mainMapSplitter;
        private System.Windows.Forms.Panel toolsPanel;
        private System.Windows.Forms.RadioButton btnAdd;
        private System.Windows.Forms.TreeView treeItems;
        private System.Windows.Forms.TreeView treeTiles;
        private System.Windows.Forms.RadioButton btnDelete;
        private System.Windows.Forms.RadioButton btnMove;
        private System.Windows.Forms.DomainUpDown brushSize;
        private System.Windows.Forms.Label lblBrushSize;
    }
}

