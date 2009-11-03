namespace GenGenesis
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.dataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.openPatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.deletePatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonsImageList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.findButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.collapseButton = new System.Windows.Forms.Button();
            this.expandButton = new System.Windows.Forms.Button();
            this.patientTreeView = new System.Windows.Forms.TreeView();
            this.currentTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newPatientButton = new System.Windows.Forms.ToolStripButton();
            this.loadPatientButton = new System.Windows.Forms.ToolStripButton();
            this.savePatientButton = new System.Windows.Forms.ToolStripButton();
            this.changePatientButton = new System.Windows.Forms.ToolStripButton();
            this.deletePatientButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.addPropertyButton = new System.Windows.Forms.ToolStripButton();
            this.cancelButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.eventToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControlPanel = new System.Windows.Forms.Panel();
            this.classPaneBar = new BarTender.GroupPaneBar();
            this.menuStrip.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.currentTabControl.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classPaneBar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataBaseToolStripMenuItem,
            this.patientToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(1020, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // dataBaseToolStripMenuItem
            // 
            this.dataBaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statStripMenuItem,
            this.toolStripSeparator1,
            this.exportStripMenuItem,
            this.toolStripSeparator2,
            this.editorToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.dataBaseToolStripMenuItem.Name = "dataBaseToolStripMenuItem";
            this.dataBaseToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.dataBaseToolStripMenuItem.Text = "&База данных";
            // 
            // statStripMenuItem
            // 
            this.statStripMenuItem.Name = "statStripMenuItem";
            this.statStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.statStripMenuItem.Text = "Статистика...";
            this.statStripMenuItem.Click += new System.EventHandler(this.statStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // exportStripMenuItem
            // 
            this.exportStripMenuItem.Name = "exportStripMenuItem";
            this.exportStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.exportStripMenuItem.Text = "Экспортировать...";
            this.exportStripMenuItem.Click += new System.EventHandler(this.exportStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.editorToolStripMenuItem.Text = "Редактор...";
            this.editorToolStripMenuItem.Click += new System.EventHandler(this.editorToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.exitToolStripMenuItem.Text = "В&ыход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPatientToolStripMenuItem,
            this.toolStripSeparator4,
            this.openPatientToolStripMenuItem,
            this.savePatientToolStripMenuItem,
            this.changePatientToolStripMenuItem,
            this.toolStripSeparator5,
            this.deletePatientToolStripMenuItem});
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.patientToolStripMenuItem.Text = "&Пациент";
            // 
            // newPatientToolStripMenuItem
            // 
            this.newPatientToolStripMenuItem.Name = "newPatientToolStripMenuItem";
            this.newPatientToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.newPatientToolStripMenuItem.Text = "Новый...";
            this.newPatientToolStripMenuItem.Click += new System.EventHandler(this.newPatientToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(134, 6);
            // 
            // openPatientToolStripMenuItem
            // 
            this.openPatientToolStripMenuItem.Name = "openPatientToolStripMenuItem";
            this.openPatientToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.openPatientToolStripMenuItem.Text = "Открыть...";
            this.openPatientToolStripMenuItem.Click += new System.EventHandler(this.openPatientToolStripMenuItem_Click);
            // 
            // savePatientToolStripMenuItem
            // 
            this.savePatientToolStripMenuItem.Name = "savePatientToolStripMenuItem";
            this.savePatientToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.savePatientToolStripMenuItem.Text = "Сохранить";
            this.savePatientToolStripMenuItem.Click += new System.EventHandler(this.savePatientToolStripMenuItem_Click);
            // 
            // changePatientToolStripMenuItem
            // 
            this.changePatientToolStripMenuItem.Name = "changePatientToolStripMenuItem";
            this.changePatientToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.changePatientToolStripMenuItem.Text = "Изменить...";
            this.changePatientToolStripMenuItem.Click += new System.EventHandler(this.changePatientToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(134, 6);
            // 
            // deletePatientToolStripMenuItem
            // 
            this.deletePatientToolStripMenuItem.Name = "deletePatientToolStripMenuItem";
            this.deletePatientToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.deletePatientToolStripMenuItem.Text = "Удалить";
            this.deletePatientToolStripMenuItem.Click += new System.EventHandler(this.deletePatientToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem.Text = "&Справка";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.aboutToolStripMenuItem.Text = "О программе...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.ShowAboutBox);
            // 
            // buttonsImageList
            // 
            this.buttonsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("buttonsImageList.ImageStream")));
            this.buttonsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.buttonsImageList.Images.SetKeyName(0, "New");
            this.buttonsImageList.Images.SetKeyName(1, "Load");
            this.buttonsImageList.Images.SetKeyName(2, "Save");
            this.buttonsImageList.Images.SetKeyName(3, "Add");
            this.buttonsImageList.Images.SetKeyName(4, "Cancel");
            this.buttonsImageList.Images.SetKeyName(5, "Delete");
            this.buttonsImageList.Images.SetKeyName(6, "Change");
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.findButton);
            this.splitContainerMain.Panel1.Controls.Add(this.searchTextBox);
            this.splitContainerMain.Panel1.Controls.Add(this.collapseButton);
            this.splitContainerMain.Panel1.Controls.Add(this.expandButton);
            this.splitContainerMain.Panel1.Controls.Add(this.patientTreeView);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainerMain.Panel2.Controls.Add(this.tabControlPanel);
            this.splitContainerMain.Panel2.Controls.Add(this.classPaneBar);
            this.splitContainerMain.Panel2.Controls.Add(this.toolStrip);
            this.splitContainerMain.Panel2.Controls.Add(this.statusStrip);
            this.splitContainerMain.Size = new System.Drawing.Size(1020, 540);
            this.splitContainerMain.SplitterDistance = 309;
            this.splitContainerMain.TabIndex = 1;
            // 
            // findButton
            // 
            this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.findButton.Location = new System.Drawing.Point(240, 514);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(56, 23);
            this.findButton.TabIndex = 4;
            this.findButton.Text = "Найти";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTextBox.Location = new System.Drawing.Point(3, 517);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(227, 20);
            this.searchTextBox.TabIndex = 3;
            // 
            // collapseButton
            // 
            this.collapseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.collapseButton.Location = new System.Drawing.Point(84, 490);
            this.collapseButton.Name = "collapseButton";
            this.collapseButton.Size = new System.Drawing.Size(75, 23);
            this.collapseButton.TabIndex = 2;
            this.collapseButton.Text = "Свернуть";
            this.collapseButton.UseVisualStyleBackColor = true;
            this.collapseButton.Click += new System.EventHandler(this.collapseButton_Click);
            // 
            // expandButton
            // 
            this.expandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.expandButton.Location = new System.Drawing.Point(3, 490);
            this.expandButton.Name = "expandButton";
            this.expandButton.Size = new System.Drawing.Size(75, 23);
            this.expandButton.TabIndex = 1;
            this.expandButton.Text = "Развернуть";
            this.expandButton.UseVisualStyleBackColor = true;
            this.expandButton.Click += new System.EventHandler(this.expandButton_Click);
            // 
            // patientTreeView
            // 
            this.patientTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.patientTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.patientTreeView.Location = new System.Drawing.Point(0, 0);
            this.patientTreeView.Name = "patientTreeView";
            this.patientTreeView.Size = new System.Drawing.Size(307, 484);
            this.patientTreeView.TabIndex = 0;
            // 
            // currentTabControl
            // 
            this.currentTabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.currentTabControl.Controls.Add(this.tabPage1);
            this.currentTabControl.Controls.Add(this.tabPage2);
            this.currentTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentTabControl.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentTabControl.HotTrack = true;
            this.currentTabControl.Location = new System.Drawing.Point(0, 0);
            this.currentTabControl.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.currentTabControl.Multiline = true;
            this.currentTabControl.Name = "currentTabControl";
            this.currentTabControl.SelectedIndex = 0;
            this.currentTabControl.Size = new System.Drawing.Size(451, 518);
            this.currentTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.currentTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(443, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(442, 486);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(45, 45);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPatientButton,
            this.loadPatientButton,
            this.savePatientButton,
            this.changePatientButton,
            this.deletePatientButton,
            this.toolStripSeparator6,
            this.addPropertyButton,
            this.cancelButton});
            this.toolStrip.Location = new System.Drawing.Point(657, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(50, 518);
            this.toolStrip.TabIndex = 9;
            // 
            // newPatientButton
            // 
            this.newPatientButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newPatientButton.Image = ((System.Drawing.Image)(resources.GetObject("newPatientButton.Image")));
            this.newPatientButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newPatientButton.Name = "newPatientButton";
            this.newPatientButton.Size = new System.Drawing.Size(47, 49);
            this.newPatientButton.Text = "toolStripButton1";
            this.newPatientButton.Click += new System.EventHandler(this.newPatientButton_Click);
            // 
            // loadPatientButton
            // 
            this.loadPatientButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.loadPatientButton.Image = ((System.Drawing.Image)(resources.GetObject("loadPatientButton.Image")));
            this.loadPatientButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.loadPatientButton.Name = "loadPatientButton";
            this.loadPatientButton.Size = new System.Drawing.Size(47, 49);
            this.loadPatientButton.Text = "toolStripButton1";
            this.loadPatientButton.Click += new System.EventHandler(this.loadPatientButton_Click);
            // 
            // savePatientButton
            // 
            this.savePatientButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.savePatientButton.Image = ((System.Drawing.Image)(resources.GetObject("savePatientButton.Image")));
            this.savePatientButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.savePatientButton.Name = "savePatientButton";
            this.savePatientButton.Size = new System.Drawing.Size(47, 49);
            this.savePatientButton.Text = "toolStripButton1";
            this.savePatientButton.Click += new System.EventHandler(this.savePatientButton_Click);
            // 
            // changePatientButton
            // 
            this.changePatientButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.changePatientButton.Image = ((System.Drawing.Image)(resources.GetObject("changePatientButton.Image")));
            this.changePatientButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.changePatientButton.Name = "changePatientButton";
            this.changePatientButton.Size = new System.Drawing.Size(47, 49);
            this.changePatientButton.Text = "toolStripButton1";
            this.changePatientButton.Click += new System.EventHandler(this.changePatientButton_Click);
            // 
            // deletePatientButton
            // 
            this.deletePatientButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deletePatientButton.Image = ((System.Drawing.Image)(resources.GetObject("deletePatientButton.Image")));
            this.deletePatientButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deletePatientButton.Name = "deletePatientButton";
            this.deletePatientButton.Size = new System.Drawing.Size(47, 49);
            this.deletePatientButton.Text = "toolStripButton1";
            this.deletePatientButton.Click += new System.EventHandler(this.deletePatientButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(47, 6);
            // 
            // addPropertyButton
            // 
            this.addPropertyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addPropertyButton.Image = ((System.Drawing.Image)(resources.GetObject("addPropertyButton.Image")));
            this.addPropertyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addPropertyButton.Name = "addPropertyButton";
            this.addPropertyButton.Size = new System.Drawing.Size(47, 49);
            this.addPropertyButton.Text = "toolStripButton1";
            this.addPropertyButton.Click += new System.EventHandler(this.addPropertyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
            this.cancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(47, 49);
            this.cancelButton.Text = "toolStripButton1";
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventToolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 518);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(707, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 8;
            // 
            // eventToolStripStatusLabel
            // 
            this.eventToolStripStatusLabel.Name = "eventToolStripStatusLabel";
            this.eventToolStripStatusLabel.Size = new System.Drawing.Size(26, 17);
            this.eventToolStripStatusLabel.Text = "test";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.MarqueeAnimationSpeed = 10;
            this.toolStripProgressBar.Maximum = 4;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // tabControlPanel
            // 
            this.tabControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlPanel.Controls.Add(this.currentTabControl);
            this.tabControlPanel.Location = new System.Drawing.Point(204, 0);
            this.tabControlPanel.Name = "tabControlPanel";
            this.tabControlPanel.Size = new System.Drawing.Size(451, 518);
            this.tabControlPanel.TabIndex = 14;
            // 
            // classPaneBar
            // 
            this.classPaneBar.AutoScroll = true;
            this.classPaneBar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.classPaneBar.BorderWidth = 2;
            this.classPaneBar.CanResize = false;
            this.classPaneBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.classPaneBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.classPaneBar.HeaderColor1 = System.Drawing.Color.SkyBlue;
            this.classPaneBar.HeaderGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.classPaneBar.HeaderHeight = 22;
            this.classPaneBar.ImagesEnabled = false;
            this.classPaneBar.Location = new System.Drawing.Point(0, 0);
            this.classPaneBar.MinimumExpandedHeight = 42;
            this.classPaneBar.Name = "classPaneBar";
            this.classPaneBar.Padding = new System.Windows.Forms.Padding(1);
            this.classPaneBar.ShowExpandCollapseButton = false;
            this.classPaneBar.Size = new System.Drawing.Size(202, 518);
            this.classPaneBar.TabIndex = 13;
            this.classPaneBar.GroupPaneExpanding += new BarTender.GroupPaneCancelEventHandler(this.classPaneBar_GroupPaneExpanding);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 564);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "GenGenesis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.doExit);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            this.splitContainerMain.ResumeLayout(false);
            this.currentTabControl.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.classPaneBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem dataBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;      
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ImageList buttonsImageList;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TreeView patientTreeView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePatientToolStripMenuItem;
        private System.Windows.Forms.Button collapseButton;
        private System.Windows.Forms.Button expandButton;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exportStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem statStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newPatientButton;
        private System.Windows.Forms.ToolStripButton loadPatientButton;
        private System.Windows.Forms.ToolStripButton savePatientButton;
        private System.Windows.Forms.ToolStripButton changePatientButton;
        private System.Windows.Forms.ToolStripButton deletePatientButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton addPropertyButton;
        private System.Windows.Forms.ToolStripButton cancelButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.ToolStripStatusLabel eventToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private BarTender.GroupPaneBar classPaneBar;
        private System.Windows.Forms.TabControl currentTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel tabControlPanel;        

    }
}

