namespace GenGenesis
{
    partial class ReplaseAskForm
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
            this.textLabel = new System.Windows.Forms.Label();
            this.replaseButton = new System.Windows.Forms.Button();
            this.ignoreButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLabel.Location = new System.Drawing.Point(12, 9);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(68, 16);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "TextLabel";
            // 
            // replaseButton
            // 
            this.replaseButton.Location = new System.Drawing.Point(284, 124);
            this.replaseButton.Name = "replaseButton";
            this.replaseButton.Size = new System.Drawing.Size(82, 23);
            this.replaseButton.TabIndex = 1;
            this.replaseButton.Text = "Заменить";
            this.replaseButton.UseVisualStyleBackColor = true;
            this.replaseButton.Click += new System.EventHandler(this.replaseButton_Click);
            // 
            // ignoreButton
            // 
            this.ignoreButton.Location = new System.Drawing.Point(196, 124);
            this.ignoreButton.Name = "ignoreButton";
            this.ignoreButton.Size = new System.Drawing.Size(82, 23);
            this.ignoreButton.TabIndex = 2;
            this.ignoreButton.Text = "Не заменять";
            this.ignoreButton.UseVisualStyleBackColor = true;
            this.ignoreButton.Click += new System.EventHandler(this.ignoreButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(13, 109);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(120, 38);
            this.renameButton.TabIndex = 3;
            this.renameButton.Text = "Сохранить под номером";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown.Location = new System.Drawing.Point(13, 83);
            this.numericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown.TabIndex = 4;
            this.numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ReplaseAskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(380, 159);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.ignoreButton);
            this.Controls.Add(this.replaseButton);
            this.Controls.Add(this.textLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaseAskForm";
            this.Text = "Выберите требуемое действие";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Button replaseButton;
        private System.Windows.Forms.Button ignoreButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.NumericUpDown numericUpDown;
    }
}