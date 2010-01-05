namespace GenGenesis
{
    partial class TCXUserControl
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
            this.outTextBox = new System.Windows.Forms.TextBox();
            this.plusButton = new System.Windows.Forms.Button();
            this.enableCheckBox = new System.Windows.Forms.CheckBox();
            this.minusButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // outTextBox
            // 
            this.outTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.outTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outTextBox.Location = new System.Drawing.Point(115, 6);
            this.outTextBox.Name = "outTextBox";
            this.outTextBox.ReadOnly = true;
            this.outTextBox.Size = new System.Drawing.Size(57, 21);
            this.outTextBox.TabIndex = 0;
            this.outTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // plusButton
            // 
            this.plusButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.plusButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.plusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plusButton.Location = new System.Drawing.Point(178, 5);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(25, 25);
            this.plusButton.TabIndex = 1;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // enableCheckBox
            // 
            this.enableCheckBox.AutoSize = true;
            this.enableCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.enableCheckBox.Location = new System.Drawing.Point(3, 8);
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Size = new System.Drawing.Size(64, 20);
            this.enableCheckBox.TabIndex = 3;
            this.enableCheckBox.Text = "Name";
            this.enableCheckBox.UseVisualStyleBackColor = true;
            this.enableCheckBox.CheckedChanged += new System.EventHandler(this.enableCheckBox_CheckedChanged);
            // 
            // minusButton
            // 
            this.minusButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.minusButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.minusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minusButton.Location = new System.Drawing.Point(209, 5);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(25, 25);
            this.minusButton.TabIndex = 2;
            this.minusButton.Text = "-";
            this.minusButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            // 
            // TCXUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.enableCheckBox);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.outTextBox);
            this.Name = "TCXUserControl";
            this.Size = new System.Drawing.Size(246, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outTextBox;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.CheckBox enableCheckBox;
        private System.Windows.Forms.Button minusButton;
    }
}
