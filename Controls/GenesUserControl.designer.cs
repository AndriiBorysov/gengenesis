namespace GenGenesis
{
    partial class GenesUserControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.genNameLabel = new System.Windows.Forms.Label();
            this.minusRadioButton = new System.Windows.Forms.RadioButton();
            this.zeroRadioButton = new System.Windows.Forms.RadioButton();
            this.plusRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // genNameLabel
            // 
            this.genNameLabel.AutoSize = true;
            this.genNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genNameLabel.Location = new System.Drawing.Point(37, 5);
            this.genNameLabel.Name = "genNameLabel";
            this.genNameLabel.Size = new System.Drawing.Size(78, 16);
            this.genNameLabel.TabIndex = 0;
            this.genNameLabel.Text = "Gen name";
            // 
            // minusRadioButton
            // 
            this.minusRadioButton.AutoSize = true;
            this.minusRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minusRadioButton.Location = new System.Drawing.Point(6, 10);
            this.minusRadioButton.Name = "minusRadioButton";
            this.minusRadioButton.Size = new System.Drawing.Size(31, 20);
            this.minusRadioButton.TabIndex = 0;
            this.minusRadioButton.TabStop = true;
            this.minusRadioButton.Text = "-";
            this.minusRadioButton.UseVisualStyleBackColor = true;
            this.minusRadioButton.CheckedChanged += new System.EventHandler(this.minusRadioButton_CheckedChanged);
            // 
            // zeroRadioButton
            // 
            this.zeroRadioButton.AutoSize = true;
            this.zeroRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zeroRadioButton.Location = new System.Drawing.Point(36, 10);
            this.zeroRadioButton.Name = "zeroRadioButton";
            this.zeroRadioButton.Size = new System.Drawing.Size(34, 20);
            this.zeroRadioButton.TabIndex = 1;
            this.zeroRadioButton.TabStop = true;
            this.zeroRadioButton.Text = "0";
            this.zeroRadioButton.UseVisualStyleBackColor = true;
            this.zeroRadioButton.CheckedChanged += new System.EventHandler(this.zeroRadioButton_CheckedChanged);
            // 
            // plusRadioButton
            // 
            this.plusRadioButton.AutoSize = true;
            this.plusRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plusRadioButton.Location = new System.Drawing.Point(69, 10);
            this.plusRadioButton.Name = "plusRadioButton";
            this.plusRadioButton.Size = new System.Drawing.Size(34, 20);
            this.plusRadioButton.TabIndex = 2;
            this.plusRadioButton.TabStop = true;
            this.plusRadioButton.Text = "+";
            this.plusRadioButton.UseVisualStyleBackColor = true;
            this.plusRadioButton.CheckedChanged += new System.EventHandler(this.plusRadioButton_CheckedChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.minusRadioButton);
            this.groupBox.Controls.Add(this.plusRadioButton);
            this.groupBox.Controls.Add(this.zeroRadioButton);
            this.groupBox.Location = new System.Drawing.Point(130, -6);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(107, 35);
            this.groupBox.TabIndex = 3;
            this.groupBox.TabStop = false;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(15, 7);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(15, 14);
            this.checkBox.TabIndex = 4;
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // GenesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.genNameLabel);
            this.Name = "GenesUserControl";
            this.Size = new System.Drawing.Size(316, 30);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label genNameLabel;
        private System.Windows.Forms.RadioButton minusRadioButton;
        private System.Windows.Forms.RadioButton zeroRadioButton;
        private System.Windows.Forms.RadioButton plusRadioButton;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.CheckBox checkBox;
    }
}
