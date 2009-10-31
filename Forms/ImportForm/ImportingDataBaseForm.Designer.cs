namespace GenGenesis
{
    partial class ImportingDataBaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.paramGroupBox = new System.Windows.Forms.GroupBox();
            this.importListGroupBox = new System.Windows.Forms.GroupBox();
            this.importListBox = new System.Windows.Forms.ListBox();
            this.processButton = new System.Windows.Forms.Button();
            this.ifCloneGroupBox = new System.Windows.Forms.GroupBox();
            this.askRadioButton = new System.Windows.Forms.RadioButton();
            this.skipRadioButton = new System.Windows.Forms.RadioButton();
            this.replaceRadioButton = new System.Windows.Forms.RadioButton();
            this.openFileButton = new System.Windows.Forms.Button();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.processGroupBox = new System.Windows.Forms.GroupBox();
            this.renamedTextBox = new System.Windows.Forms.TextBox();
            this.ignoredTextBox = new System.Windows.Forms.TextBox();
            this.replasedTextBox = new System.Windows.Forms.TextBox();
            this.labelIgnored = new System.Windows.Forms.Label();
            this.labelRenamed = new System.Windows.Forms.Label();
            this.labelReplased = new System.Windows.Forms.Label();
            this.doneTextBox = new System.Windows.Forms.TextBox();
            this.lastTextBox = new System.Windows.Forms.TextBox();
            this.allTextBox = new System.Windows.Forms.TextBox();
            this.labelLast = new System.Windows.Forms.Label();
            this.labelDone = new System.Windows.Forms.Label();
            this.labelAll = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.messageLabel = new System.Windows.Forms.Label();
            this.messageTimer = new System.Windows.Forms.Timer(this.components);
            this.paramGroupBox.SuspendLayout();
            this.importListGroupBox.SuspendLayout();
            this.ifCloneGroupBox.SuspendLayout();
            this.processGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // paramGroupBox
            // 
            this.paramGroupBox.Controls.Add(this.importListGroupBox);
            this.paramGroupBox.Controls.Add(this.processButton);
            this.paramGroupBox.Controls.Add(this.ifCloneGroupBox);
            this.paramGroupBox.Controls.Add(this.openFileButton);
            this.paramGroupBox.Controls.Add(this.fileNameTextBox);
            this.paramGroupBox.Controls.Add(this.labelFileName);
            this.paramGroupBox.Location = new System.Drawing.Point(12, 12);
            this.paramGroupBox.Name = "paramGroupBox";
            this.paramGroupBox.Size = new System.Drawing.Size(435, 237);
            this.paramGroupBox.TabIndex = 0;
            this.paramGroupBox.TabStop = false;
            this.paramGroupBox.Text = "Параметры импорта";
            // 
            // importListGroupBox
            // 
            this.importListGroupBox.Controls.Add(this.importListBox);
            this.importListGroupBox.Location = new System.Drawing.Point(6, 59);
            this.importListGroupBox.Name = "importListGroupBox";
            this.importListGroupBox.Size = new System.Drawing.Size(194, 162);
            this.importListGroupBox.TabIndex = 5;
            this.importListGroupBox.TabStop = false;
            this.importListGroupBox.Text = "Импортирование базы данных";
            // 
            // importListBox
            // 
            this.importListBox.FormattingEnabled = true;
            this.importListBox.Location = new System.Drawing.Point(6, 19);
            this.importListBox.Name = "importListBox";
            this.importListBox.Size = new System.Drawing.Size(182, 134);
            this.importListBox.TabIndex = 0;
            // 
            // processButton
            // 
            this.processButton.Location = new System.Drawing.Point(354, 208);
            this.processButton.Name = "processButton";
            this.processButton.Size = new System.Drawing.Size(75, 23);
            this.processButton.TabIndex = 4;
            this.processButton.Text = "Выполнить";
            this.processButton.UseVisualStyleBackColor = true;
            this.processButton.Click += new System.EventHandler(this.processButton_Click);
            // 
            // ifCloneGroupBox
            // 
            this.ifCloneGroupBox.Controls.Add(this.askRadioButton);
            this.ifCloneGroupBox.Controls.Add(this.skipRadioButton);
            this.ifCloneGroupBox.Controls.Add(this.replaceRadioButton);
            this.ifCloneGroupBox.Location = new System.Drawing.Point(213, 59);
            this.ifCloneGroupBox.Name = "ifCloneGroupBox";
            this.ifCloneGroupBox.Size = new System.Drawing.Size(216, 90);
            this.ifCloneGroupBox.TabIndex = 3;
            this.ifCloneGroupBox.TabStop = false;
            this.ifCloneGroupBox.Text = "Действие при совпадении номеров:";
            // 
            // askRadioButton
            // 
            this.askRadioButton.AutoSize = true;
            this.askRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.askRadioButton.Location = new System.Drawing.Point(6, 65);
            this.askRadioButton.Name = "askRadioButton";
            this.askRadioButton.Size = new System.Drawing.Size(73, 17);
            this.askRadioButton.TabIndex = 2;
            this.askRadioButton.Text = "Спросить";
            this.askRadioButton.UseVisualStyleBackColor = true;
            // 
            // skipRadioButton
            // 
            this.skipRadioButton.AutoSize = true;
            this.skipRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.skipRadioButton.Location = new System.Drawing.Point(6, 42);
            this.skipRadioButton.Name = "skipRadioButton";
            this.skipRadioButton.Size = new System.Drawing.Size(84, 17);
            this.skipRadioButton.TabIndex = 1;
            this.skipRadioButton.Text = "Пропустить";
            this.skipRadioButton.UseVisualStyleBackColor = true;
            // 
            // replaceRadioButton
            // 
            this.replaceRadioButton.AutoSize = true;
            this.replaceRadioButton.Checked = true;
            this.replaceRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.replaceRadioButton.Location = new System.Drawing.Point(6, 19);
            this.replaceRadioButton.Name = "replaceRadioButton";
            this.replaceRadioButton.Size = new System.Drawing.Size(75, 17);
            this.replaceRadioButton.TabIndex = 0;
            this.replaceRadioButton.TabStop = true;
            this.replaceRadioButton.Text = "Заменить";
            this.replaceRadioButton.UseVisualStyleBackColor = true;
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(354, 30);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 23);
            this.openFileButton.TabIndex = 2;
            this.openFileButton.Text = "Открыть...";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(9, 32);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(339, 20);
            this.fileNameTextBox.TabIndex = 1;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(6, 16);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(67, 13);
            this.labelFileName.TabIndex = 0;
            this.labelFileName.Text = "Имя файла:";
            // 
            // processGroupBox
            // 
            this.processGroupBox.Controls.Add(this.renamedTextBox);
            this.processGroupBox.Controls.Add(this.ignoredTextBox);
            this.processGroupBox.Controls.Add(this.replasedTextBox);
            this.processGroupBox.Controls.Add(this.labelIgnored);
            this.processGroupBox.Controls.Add(this.labelRenamed);
            this.processGroupBox.Controls.Add(this.labelReplased);
            this.processGroupBox.Controls.Add(this.doneTextBox);
            this.processGroupBox.Controls.Add(this.lastTextBox);
            this.processGroupBox.Controls.Add(this.allTextBox);
            this.processGroupBox.Controls.Add(this.labelLast);
            this.processGroupBox.Controls.Add(this.labelDone);
            this.processGroupBox.Controls.Add(this.labelAll);
            this.processGroupBox.Controls.Add(this.progressBar);
            this.processGroupBox.Location = new System.Drawing.Point(12, 255);
            this.processGroupBox.Name = "processGroupBox";
            this.processGroupBox.Size = new System.Drawing.Size(435, 143);
            this.processGroupBox.TabIndex = 1;
            this.processGroupBox.TabStop = false;
            this.processGroupBox.Text = "Процесс импортирования";
            // 
            // renamedTextBox
            // 
            this.renamedTextBox.Location = new System.Drawing.Point(329, 107);
            this.renamedTextBox.Name = "renamedTextBox";
            this.renamedTextBox.ReadOnly = true;
            this.renamedTextBox.Size = new System.Drawing.Size(100, 20);
            this.renamedTextBox.TabIndex = 12;
            this.renamedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ignoredTextBox
            // 
            this.ignoredTextBox.Location = new System.Drawing.Point(329, 81);
            this.ignoredTextBox.Name = "ignoredTextBox";
            this.ignoredTextBox.ReadOnly = true;
            this.ignoredTextBox.Size = new System.Drawing.Size(100, 20);
            this.ignoredTextBox.TabIndex = 11;
            this.ignoredTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // replasedTextBox
            // 
            this.replasedTextBox.Location = new System.Drawing.Point(329, 55);
            this.replasedTextBox.Name = "replasedTextBox";
            this.replasedTextBox.ReadOnly = true;
            this.replasedTextBox.Size = new System.Drawing.Size(100, 20);
            this.replasedTextBox.TabIndex = 10;
            this.replasedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelIgnored
            // 
            this.labelIgnored.AutoSize = true;
            this.labelIgnored.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelIgnored.Location = new System.Drawing.Point(208, 82);
            this.labelIgnored.Name = "labelIgnored";
            this.labelIgnored.Size = new System.Drawing.Size(86, 16);
            this.labelIgnored.TabIndex = 9;
            this.labelIgnored.Text = "Пропущено:";
            // 
            // labelRenamed
            // 
            this.labelRenamed.AutoSize = true;
            this.labelRenamed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRenamed.Location = new System.Drawing.Point(208, 108);
            this.labelRenamed.Name = "labelRenamed";
            this.labelRenamed.Size = new System.Drawing.Size(121, 16);
            this.labelRenamed.TabIndex = 8;
            this.labelRenamed.Text = "Переименовано: ";
            // 
            // labelReplased
            // 
            this.labelReplased.AutoSize = true;
            this.labelReplased.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelReplased.Location = new System.Drawing.Point(208, 56);
            this.labelReplased.Name = "labelReplased";
            this.labelReplased.Size = new System.Drawing.Size(77, 16);
            this.labelReplased.TabIndex = 7;
            this.labelReplased.Text = "Заменено:";
            // 
            // doneTextBox
            // 
            this.doneTextBox.Location = new System.Drawing.Point(102, 106);
            this.doneTextBox.Name = "doneTextBox";
            this.doneTextBox.ReadOnly = true;
            this.doneTextBox.Size = new System.Drawing.Size(100, 20);
            this.doneTextBox.TabIndex = 6;
            this.doneTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lastTextBox
            // 
            this.lastTextBox.Location = new System.Drawing.Point(102, 80);
            this.lastTextBox.Name = "lastTextBox";
            this.lastTextBox.ReadOnly = true;
            this.lastTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastTextBox.TabIndex = 5;
            this.lastTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // allTextBox
            // 
            this.allTextBox.Location = new System.Drawing.Point(102, 54);
            this.allTextBox.Name = "allTextBox";
            this.allTextBox.ReadOnly = true;
            this.allTextBox.Size = new System.Drawing.Size(100, 20);
            this.allTextBox.TabIndex = 4;
            this.allTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelLast
            // 
            this.labelLast.AutoSize = true;
            this.labelLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLast.Location = new System.Drawing.Point(6, 81);
            this.labelLast.Name = "labelLast";
            this.labelLast.Size = new System.Drawing.Size(73, 16);
            this.labelLast.TabIndex = 3;
            this.labelLast.Text = "Осталось:";
            // 
            // labelDone
            // 
            this.labelDone.AutoSize = true;
            this.labelDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDone.Location = new System.Drawing.Point(6, 107);
            this.labelDone.Name = "labelDone";
            this.labelDone.Size = new System.Drawing.Size(88, 16);
            this.labelDone.TabIndex = 2;
            this.labelDone.Text = "Выполнено: ";
            // 
            // labelAll
            // 
            this.labelAll.AutoSize = true;
            this.labelAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAll.Location = new System.Drawing.Point(6, 55);
            this.labelAll.Name = "labelAll";
            this.labelAll.Size = new System.Drawing.Size(52, 16);
            this.labelAll.TabIndex = 1;
            this.labelAll.Text = "Всего: ";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 19);
            this.progressBar.MarqueeAnimationSpeed = 5;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(420, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageLabel.ForeColor = System.Drawing.Color.Red;
            this.messageLabel.Location = new System.Drawing.Point(15, 411);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(101, 16);
            this.messageLabel.TabIndex = 7;
            this.messageLabel.Text = "Уведомление:";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.messageLabel.Visible = false;
            // 
            // messageTimer
            // 
            this.messageTimer.Interval = 2000;
            this.messageTimer.Tick += new System.EventHandler(this.messegeTimer_Tick);
            // 
            // ImportingDataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 435);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.processGroupBox);
            this.Controls.Add(this.paramGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ImportingDataBaseForm";
            this.ShowInTaskbar = false;
            this.Text = "Импорт базы данных";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ImportingDataBaseForm_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportingDataBaseForm_FormClosing);
            this.paramGroupBox.ResumeLayout(false);
            this.paramGroupBox.PerformLayout();
            this.importListGroupBox.ResumeLayout(false);
            this.ifCloneGroupBox.ResumeLayout(false);
            this.ifCloneGroupBox.PerformLayout();
            this.processGroupBox.ResumeLayout(false);
            this.processGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox paramGroupBox;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.GroupBox processGroupBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelAll;
        private System.Windows.Forms.TextBox doneTextBox;
        private System.Windows.Forms.TextBox lastTextBox;
        private System.Windows.Forms.TextBox allTextBox;
        private System.Windows.Forms.Label labelLast;
        private System.Windows.Forms.Label labelDone;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Timer messageTimer;
        private System.Windows.Forms.GroupBox ifCloneGroupBox;
        private System.Windows.Forms.RadioButton skipRadioButton;
        private System.Windows.Forms.RadioButton replaceRadioButton;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.RadioButton askRadioButton;
        private System.Windows.Forms.GroupBox importListGroupBox;
        private System.Windows.Forms.ListBox importListBox;
        private System.Windows.Forms.TextBox renamedTextBox;
        private System.Windows.Forms.TextBox ignoredTextBox;
        private System.Windows.Forms.TextBox replasedTextBox;
        private System.Windows.Forms.Label labelIgnored;
        private System.Windows.Forms.Label labelRenamed;
        private System.Windows.Forms.Label labelReplased;
    }
}