using System.Drawing;

namespace GameEditor
{
    partial class Editor
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
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tabObjects = new System.Windows.Forms.TabControl();
            this.tabTile = new System.Windows.Forms.TabPage();
            this.objectsTree = new System.Windows.Forms.TreeView();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.tabNPC = new System.Windows.Forms.TabPage();
            this.manu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDebug = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRun = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLayout = new System.Windows.Forms.Label();
            this.lstLayout = new System.Windows.Forms.ComboBox();
            this.mainLayout.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabObjects.SuspendLayout();
            this.tabTile.SuspendLayout();
            this.manu.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.65005F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.34995F));
            this.mainLayout.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.mainLayout.Controls.Add(this.tabObjects, 1, 2);
            this.mainLayout.Controls.Add(this.manu, 0, 0);
            this.mainLayout.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Name = "tableLayoutPanel1";
            this.mainLayout.RowCount = 4;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.mainLayout.Size = new System.Drawing.Size(903, 619);
            this.mainLayout.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.mainLayout.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnLoad);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 579);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(897, 37);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(807, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(726, 9);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.UseVisualStyleBackColor = true;

            // 
            // tabObjects
            // 
            this.tabObjects.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabObjects.Controls.Add(this.tabTile);
            this.tabObjects.Controls.Add(this.tabItems);
            this.tabObjects.Controls.Add(this.tabNPC);
            this.tabObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabObjects.Location = new System.Drawing.Point(649, 63);
            this.tabObjects.Multiline = true;
            this.tabObjects.Name = "tabObjects";
            this.tabObjects.SelectedIndex = 0;
            this.tabObjects.Size = new System.Drawing.Size(251, 510);
            this.tabObjects.TabIndex = 3;
            // 
            // tabTile
            // 
            this.tabTile.Controls.Add(this.objectsTree);
            this.tabTile.Location = new System.Drawing.Point(4, 4);
            this.tabTile.Name = "tabTile";
            this.tabTile.Padding = new System.Windows.Forms.Padding(3);
            this.tabTile.Size = new System.Drawing.Size(224, 502);
            this.tabTile.TabIndex = 0;
            this.tabTile.Text = "Тайлы";
            this.tabTile.UseVisualStyleBackColor = true;
            // 
            // objectsTree
            // 
            this.objectsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectsTree.Location = new System.Drawing.Point(3, 3);
            this.objectsTree.Name = "objectsTree";
            this.objectsTree.Size = new System.Drawing.Size(218, 496);
            this.objectsTree.TabIndex = 0;
            // 
            // tabItems
            // 
            this.tabItems.Location = new System.Drawing.Point(4, 4);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(224, 502);
            this.tabItems.TabIndex = 1;
            this.tabItems.Text = "Предметы";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // tabNPC
            // 
            this.tabNPC.Location = new System.Drawing.Point(4, 4);
            this.tabNPC.Name = "tabNPC";
            this.tabNPC.Size = new System.Drawing.Size(224, 502);
            this.tabNPC.TabIndex = 2;
            this.tabNPC.Text = "НПС";
            this.tabNPC.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.mainLayout.SetColumnSpan(this.manu, 2);
            this.manu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemDebug});
            this.manu.Location = new System.Drawing.Point(0, 0);
            this.manu.Name = "menuStrip1";
            this.manu.Size = new System.Drawing.Size(903, 20);
            this.manu.TabIndex = 1;
            this.manu.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLoad,
            this.menuItemSave,
            this.menuItemNew});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(48, 16);
            this.menuItemFile.Text = "Файл";
            // 
            // menuItemLoad
            // 
            this.menuItemLoad.Name = "menuItemLoad";
            this.menuItemLoad.Size = new System.Drawing.Size(141, 22);
            this.menuItemLoad.Text = "Загрузить";
            // 
            // menuItemSave
            // 
            this.menuItemSave.Name = "menuItemSave";
            this.menuItemSave.Size = new System.Drawing.Size(141, 22);
            this.menuItemSave.Text = "Сохранить";
            // 
            // menuItemNew
            // 
            this.menuItemNew.Name = "menuItemNew";
            this.menuItemNew.Size = new System.Drawing.Size(141, 22);
            this.menuItemNew.Text = "Новая карта";
            this.menuItemNew.Click += new System.EventHandler(this.MenuItemNew_Click);
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
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 23);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(897, 34);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // lblLayout
            // 
            this.lblLayout.Location = new System.Drawing.Point(7, 4);
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
            this.lstLayout.Location = new System.Drawing.Point(62, 7);
            this.lstLayout.Name = "lstLayout";
            this.lstLayout.Size = new System.Drawing.Size(121, 21);
            this.lstLayout.TabIndex = 1;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 619);
            this.Controls.Add(this.mainLayout);
            this.MainMenuStrip = this.manu;
            this.Name = "Editor";
            this.Text = "Editor";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tabObjects.ResumeLayout(false);
            this.tabTile.ResumeLayout(false);
            this.manu.ResumeLayout(false);
            this.manu.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.MenuStrip manu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoad;
        private System.Windows.Forms.ToolStripMenuItem menuItemSave;
        private System.Windows.Forms.ToolStripMenuItem menuItemDebug;
        private System.Windows.Forms.ToolStripMenuItem menuItemRun;
        private System.Windows.Forms.TabControl tabObjects;
        private System.Windows.Forms.TabPage tabTile;
        private System.Windows.Forms.TreeView objectsTree;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.TabPage tabNPC;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblLayout;
        private System.Windows.Forms.ComboBox lstLayout;
        private System.Windows.Forms.ToolStripMenuItem menuItemNew;
    }
}

