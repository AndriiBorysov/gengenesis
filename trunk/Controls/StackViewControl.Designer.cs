namespace GenGenesis.Controls
{
    partial class StackViewControl
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
        /// 
        private void InitializeComponent()
        {
            this.stackStrip = new System.Windows.Forms.ToolStrip();
            this.signStackButton = new System.Windows.Forms.ToolStripButton();
            this.illnessStackButton = new System.Windows.Forms.ToolStripButton();
            this.tcxStackButton = new System.Windows.Forms.ToolStripButton();
            this.genesStackButton = new System.Windows.Forms.ToolStripButton();
            this.scriningStackButton = new System.Windows.Forms.ToolStripButton();
            this.biochemStackButton = new System.Windows.Forms.ToolStripButton();

            this.stackStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // stackStrip
            // 
            this.stackStrip.CanOverflow = false;
            this.stackStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stackStrip.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.stackStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.stackStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signStackButton,
            this.illnessStackButton,
            this.tcxStackButton,
            this.genesStackButton,
            this.scriningStackButton,
            this.biochemStackButton});
            this.stackStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;            
            this.stackStrip.Name = "stackStrip";
            this.stackStrip.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.stackStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;            
            this.stackStrip.TabIndex = 0;            
            // 
            // signStackButton
            // 
            this.signStackButton.CheckOnClick = true;
            this.signStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.signStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.signStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.signStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.signStackButton.Name = "signStackButton";
            this.signStackButton.Padding = new System.Windows.Forms.Padding(3);            
            this.signStackButton.Text = " Признаки";
            this.signStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.signStackButton.Click += new System.EventHandler(this.stackButton_Click);
            // 
            // illnessStackButton
            // 
            this.illnessStackButton.CheckOnClick = true;
            this.illnessStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.illnessStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.illnessStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.illnessStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.illnessStackButton.Name = "illnessStackButton";
            this.illnessStackButton.Padding = new System.Windows.Forms.Padding(3);            
            this.illnessStackButton.Text = " Болезни";
            this.illnessStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.illnessStackButton.Click += new System.EventHandler(this.stackButton_Click);
            // 
            // tcxStackButton
            // 
            this.tcxStackButton.CheckOnClick = true;
            this.tcxStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tcxStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tcxStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.tcxStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.tcxStackButton.Name = "tcxStackButton";
            this.tcxStackButton.Padding = new System.Windows.Forms.Padding(3);            
            this.tcxStackButton.Text = " Пробы ТСХ";
            this.tcxStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tcxStackButton.Click += new System.EventHandler(this.stackButton_Click);
            // 
            // genesStackButton
            // 
            this.genesStackButton.CheckOnClick = true;
            this.genesStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.genesStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.genesStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.genesStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.genesStackButton.Name = "genesStackButton";
            this.genesStackButton.Padding = new System.Windows.Forms.Padding(3);            
            this.genesStackButton.Text = " Состояния генов";
            this.genesStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.genesStackButton.Click += new System.EventHandler(this.stackButton_Click);
            // 
            // scriningStackButton
            // 
            this.scriningStackButton.CheckOnClick = true;
            this.scriningStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scriningStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scriningStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.scriningStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.scriningStackButton.Name = "scriningStackButton";
            this.scriningStackButton.Padding = new System.Windows.Forms.Padding(3);
            this.scriningStackButton.Text = " Скрининг тесты";
            this.scriningStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scriningStackButton.Click += new System.EventHandler(this.stackButton_Click);
            // 
            // biochemStackButton
            // 
            this.biochemStackButton.CheckOnClick = true;
            this.biochemStackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.biochemStackButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.biochemStackButton.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.biochemStackButton.Margin = new System.Windows.Forms.Padding(0);
            this.biochemStackButton.Name = "biochemStackButton";
            this.biochemStackButton.Padding = new System.Windows.Forms.Padding(3);
            this.biochemStackButton.Text = " Биохимия";
            this.biochemStackButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.biochemStackButton.Click += new System.EventHandler(this.stackButton_Click);
            // 
            // StackViewControl
            // 
            // this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stackStrip);
            this.Name = "StackViewControl";
            this.Load += new System.EventHandler(this.StackView_Load);
            this.stackStrip.ResumeLayout(false);
            this.stackStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


    }
}
