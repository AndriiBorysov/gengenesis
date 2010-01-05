using System;
using System.Drawing;
using System.Windows.Forms;

namespace GenGenesis
{
    public partial class AnalysisNumericUserControl : UserControl
    {
        // Свойства
        private int reSizeCount;        
        public double Value 
        {
            get { return (double)numericUpDown.Value; }
            set
            {
                if (Tag != null)
                {
                    numericUpDown.Value = (decimal)value;
                    Analysis T = (Analysis)Tag;
                    T.analizes_value = value;
                    Tag = T;
                }
                else
                {
                    numericUpDown.Value = (decimal)value;
                }
            } 
        }
        public int Maximum { get { return (int)numericUpDown.Maximum; } set { numericUpDown.Maximum = value; } }
        public int Minimum { get { return (int)numericUpDown.Minimum; } set { numericUpDown.Minimum = value; } }
        public bool Checked { get; set; }       
        // Конструктор
        public AnalysisNumericUserControl(string testName)
        {
            InitializeComponent();                        
            enableCheckBox.Text= testName;            
            this.Name = testName;            
            Init();
            DoResize();            
        }        
        public void Init()// Инициализация
        {            
            Value = 0;           
            enableCheckBox.Checked = false;
            Checked = false;            
        }
        public void Check()// Заменяет клик на отметке
        {
            enableCheckBox.Checked = true;
        }
        public void DoResize()// Изменение размера
        {
            this.SuspendLayout();            
            enableCheckBox.Location = new Point(1, enableCheckBox.Location.Y);
            //numericUpDown.Location = new Point(100, numericUpDown.Location.Y);            
            this.ResumeLayout(false);
            this.PerformLayout();
        }       
        
        #region Обработчики                
        private void enableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Checked = !Checked;
        }        
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Check();
            Analysis T = (Analysis)Tag;
            T.analizes_value = (double)numericUpDown.Value;
            Tag = T;
        }
        #endregion       
    }
}
