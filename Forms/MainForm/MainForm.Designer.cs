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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.signsPanel = new System.Windows.Forms.Panel();
            this.signsTabControl = new System.Windows.Forms.TabControl();
            this.illnessesPanel = new System.Windows.Forms.Panel();
            this.diseasesTabControl = new System.Windows.Forms.TabControl();
            this.tcxPanel = new System.Windows.Forms.Panel();
            this.tcxTabControl = new System.Windows.Forms.TabControl();
            this.genesPanel = new System.Windows.Forms.Panel();
            this.genesTabControl = new System.Windows.Forms.TabControl();
            this.scriningPanel = new System.Windows.Forms.Panel();
            this.scriningTabControl = new System.Windows.Forms.TabControl();
            this.biochemPanel = new System.Windows.Forms.Panel();
            this.biochemTabControl = new System.Windows.Forms.TabControl();
            this.classViewControl = new GenGenesis.Controls.StackViewControl();
            this.menuStrip.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.signsPanel.SuspendLayout();
            this.illnessesPanel.SuspendLayout();
            this.tcxPanel.SuspendLayout();
            this.genesPanel.SuspendLayout();
            this.scriningPanel.SuspendLayout();
            this.biochemPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.patientToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statStripMenuItem,
            this.toolStripSeparator1,
            this.exportStripMenuItem,
            this.importStripMenuItem,
            this.toolStripSeparator2,
            this.editorToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "&Файл";
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
            // importStripMenuItem
            // 
            this.importStripMenuItem.Name = "importStripMenuItem";
            this.importStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.importStripMenuItem.Text = "Импортировать...";
            this.importStripMenuItem.Click += new System.EventHandler(this.importStripMenuItem_Click);
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
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.ShowAbouteBox);
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
            this.splitContainerMain.Panel2.Controls.Add(this.classViewControl);
            this.splitContainerMain.Panel2.Controls.Add(this.toolStrip);
            this.splitContainerMain.Panel2.Controls.Add(this.statusStrip);
            this.splitContainerMain.Panel2.Controls.Add(this.signsPanel);
            this.splitContainerMain.Panel2.Controls.Add(this.illnessesPanel);
            this.splitContainerMain.Panel2.Controls.Add(this.tcxPanel);
            this.splitContainerMain.Panel2.Controls.Add(this.genesPanel);
            this.splitContainerMain.Panel2.Controls.Add(this.scriningPanel);
            this.splitContainerMain.Panel2.Controls.Add(this.biochemPanel);
            this.splitContainerMain.Size = new System.Drawing.Size(784, 540);
            this.splitContainerMain.SplitterDistance = 238;
            this.splitContainerMain.TabIndex = 1;
            // 
            // findButton
            // 
            this.findButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.findButton.Location = new System.Drawing.Point(169, 514);
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
            this.searchTextBox.Size = new System.Drawing.Size(156, 20);
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
            this.patientTreeView.Size = new System.Drawing.Size(236, 484);
            this.patientTreeView.TabIndex = 0;
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
            this.toolStrip.Location = new System.Drawing.Point(492, 0);
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
            this.statusStrip.Size = new System.Drawing.Size(542, 22);
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
            this.toolStripProgressBar.Maximum = 6;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // signsPanel
            // 
            this.signsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.signsPanel.BackColor = System.Drawing.SystemColors.Info;
            this.signsPanel.Controls.Add(this.signsTabControl);
            this.signsPanel.Location = new System.Drawing.Point(201, 0);
            this.signsPanel.Name = "signsPanel";
            this.signsPanel.Size = new System.Drawing.Size(292, 518);
            this.signsPanel.TabIndex = 10;
            // 
            // signsTabControl
            // 
            this.signsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.signsTabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.signsTabControl.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.signsTabControl.HotTrack = true;
            this.signsTabControl.Location = new System.Drawing.Point(0, 0);
            this.signsTabControl.Multiline = true;
            this.signsTabControl.Name = "signsTabControl";
            this.signsTabControl.SelectedIndex = 0;
            this.signsTabControl.Size = new System.Drawing.Size(292, 518);
            this.signsTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.signsTabControl.TabIndex = 0;
            // 
            // illnessesPanel
            // 
            this.illnessesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.illnessesPanel.BackColor = System.Drawing.SystemColors.Info;
            this.illnessesPanel.Controls.Add(this.diseasesTabControl);
            this.illnessesPanel.Location = new System.Drawing.Point(201, 0);
            this.illnessesPanel.Name = "illnessesPanel";
            this.illnessesPanel.Size = new System.Drawing.Size(292, 518);
            this.illnessesPanel.TabIndex = 11;
            // 
            // diseasesTabControl
            // 
            this.diseasesTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.diseasesTabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.diseasesTabControl.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.diseasesTabControl.HotTrack = true;
            this.diseasesTabControl.Location = new System.Drawing.Point(0, 0);
            this.diseasesTabControl.Multiline = true;
            this.diseasesTabControl.Name = "diseasesTabControl";
            this.diseasesTabControl.SelectedIndex = 0;
            this.diseasesTabControl.Size = new System.Drawing.Size(292, 518);
            this.diseasesTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.diseasesTabControl.TabIndex = 0;
            // 
            // tcxPanel
            // 
            this.tcxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcxPanel.BackColor = System.Drawing.SystemColors.Info;
            this.tcxPanel.Controls.Add(this.tcxTabControl);
            this.tcxPanel.Location = new System.Drawing.Point(201, 0);
            this.tcxPanel.Name = "tcxPanel";
            this.tcxPanel.Size = new System.Drawing.Size(292, 518);
            this.tcxPanel.TabIndex = 11;
            // 
            // tcxTabControl
            // 
            this.tcxTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcxTabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tcxTabControl.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tcxTabControl.HotTrack = true;
            this.tcxTabControl.Location = new System.Drawing.Point(0, 0);
            this.tcxTabControl.Multiline = true;
            this.tcxTabControl.Name = "tcxTabControl";
            this.tcxTabControl.SelectedIndex = 0;
            this.tcxTabControl.Size = new System.Drawing.Size(292, 518);
            this.tcxTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tcxTabControl.TabIndex = 0;
            // 
            // genesPanel
            // 
            this.genesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.genesPanel.BackColor = System.Drawing.SystemColors.Info;
            this.genesPanel.Controls.Add(this.genesTabControl);
            this.genesPanel.Location = new System.Drawing.Point(201, 0);
            this.genesPanel.Name = "genesPanel";
            this.genesPanel.Size = new System.Drawing.Size(292, 518);
            this.genesPanel.TabIndex = 11;
            // 
            // genesTabControl
            // 
            this.genesTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.genesTabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.genesTabControl.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genesTabControl.HotTrack = true;
            this.genesTabControl.Location = new System.Drawing.Point(0, 0);
            this.genesTabControl.Multiline = true;
            this.genesTabControl.Name = "genesTabControl";
            this.genesTabControl.SelectedIndex = 0;
            this.genesTabControl.Size = new System.Drawing.Size(292, 518);
            this.genesTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.genesTabControl.TabIndex = 0;
            // 
            // scriningPanel
            // 
            this.scriningPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scriningPanel.BackColor = System.Drawing.SystemColors.Info;
            this.scriningPanel.Controls.Add(this.scriningTabControl);
            this.scriningPanel.Location = new System.Drawing.Point(201, 0);
            this.scriningPanel.Name = "scriningPanel";
            this.scriningPanel.Size = new System.Drawing.Size(292, 518);
            this.scriningPanel.TabIndex = 11;
            // 
            // scriningTabControl
            // 
            this.scriningTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scriningTabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.scriningTabControl.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scriningTabControl.HotTrack = true;
            this.scriningTabControl.Location = new System.Drawing.Point(0, 0);
            this.scriningTabControl.Multiline = true;
            this.scriningTabControl.Name = "scriningTabControl";
            this.scriningTabControl.SelectedIndex = 0;
            this.scriningTabControl.Size = new System.Drawing.Size(292, 518);
            this.scriningTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.scriningTabControl.TabIndex = 0;
            // 
            // biochemPanel
            // 
            this.biochemPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.biochemPanel.BackColor = System.Drawing.SystemColors.Info;
            this.biochemPanel.Controls.Add(this.biochemTabControl);
            this.biochemPanel.Location = new System.Drawing.Point(201, 0);
            this.biochemPanel.Name = "biochemPanel";
            this.biochemPanel.Size = new System.Drawing.Size(292, 518);
            this.biochemPanel.TabIndex = 11;
            // 
            // biochemTabControl
            // 
            this.biochemTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.biochemTabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.biochemTabControl.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.biochemTabControl.HotTrack = true;
            this.biochemTabControl.Location = new System.Drawing.Point(0, 0);
            this.biochemTabControl.Multiline = true;
            this.biochemTabControl.Name = "biochemTabControl";
            this.biochemTabControl.SelectedIndex = 0;
            this.biochemTabControl.Size = new System.Drawing.Size(292, 518);
            this.biochemTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.biochemTabControl.TabIndex = 0;
            // 
            // classViewControl
            // 
            this.classViewControl.AutoSize = true;
            this.classViewControl.Location = new System.Drawing.Point(0, 0);
            this.classViewControl.Name = "classViewControl";
            this.classViewControl.Size = new System.Drawing.Size(200, 213);
            this.classViewControl.TabIndex = 12;
            this.classViewControl.CheckedChanget += new System.EventHandler<GenGenesis.Controls.StackViewControl.CheckedChangedEventArgs>(this.classViewControl_CheckedChanget);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 564);
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
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.signsPanel.ResumeLayout(false);
            this.illnessesPanel.ResumeLayout(false);
            this.tcxPanel.ResumeLayout(false);
            this.genesPanel.ResumeLayout(false);
            this.scriningPanel.ResumeLayout(false);
            this.biochemPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;      
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ImageList buttonsImageList;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TabControl signsTabControl;
        private System.Windows.Forms.TreeView patientTreeView;
        private System.Windows.Forms.TabControl diseasesTabControl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabControl tcxTabControl;
        private System.Windows.Forms.TabControl genesTabControl;
        private System.Windows.Forms.TabControl scriningTabControl;
        private System.Windows.Forms.TabControl biochemTabControl;
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
        private System.Windows.Forms.ToolStripMenuItem importStripMenuItem;
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
        private System.Windows.Forms.Panel signsPanel;
        private System.Windows.Forms.Panel scriningPanel;
        private System.Windows.Forms.Panel biochemPanel;
        private System.Windows.Forms.Panel genesPanel;
        private System.Windows.Forms.Panel tcxPanel;
        private System.Windows.Forms.Panel illnessesPanel;
        private GenGenesis.Controls.StackViewControl classViewControl;
        private System.Windows.Forms.ToolStripStatusLabel eventToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;        

    }
}

