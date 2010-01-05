using System;
using System.Drawing;
using System.Windows.Forms;

namespace GenGenesis
{
    public partial class AnalysisNumericUpDownControl : UserControl
    {
        // Свойства        
        private double _value;
        public double Value 
        { 
            get{return _value;}
            set
            {
                if (Tag != null)
                {
                    _value = value;
                    Analysis T = (Analysis)Tag;
                    T.analizes_value = value;
                    Tag = T;
                }
                else
                {
                    _value = value;
                }
            } 
        }
        public int Maximum { get; set; }
        public int Minimum { get; set; }
        public bool Checked { get; set; }       
        // Конструктор
        public AnalysisNumericUpDownControl(string testName)
        {
            InitializeComponent();
            enableCheckBox.MouseEnter += new EventHandler(enableCheckBox_MouseEnter);
            enableCheckBox.MouseLeave += new EventHandler(enableCheckBox_MouseLeave);
            outTextBox.MouseEnter += new EventHandler(enableCheckBox_MouseEnter);
            outTextBox.MouseLeave += new EventHandler(enableCheckBox_MouseLeave);
            minusButton.MouseEnter += new EventHandler(enableCheckBox_MouseEnter);
            minusButton.MouseLeave += new EventHandler(enableCheckBox_MouseLeave);
            plusButton.MouseEnter += new EventHandler(enableCheckBox_MouseEnter);
            plusButton.MouseLeave += new EventHandler(enableCheckBox_MouseLeave);
            enableCheckBox.Text= testName;            
            this.Name = testName;            
            Init();
            DoResize();
            PrintText();
        }
        void enableCheckBox_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Info);
        }

        void enableCheckBox_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Highlight);
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
            outTextBox.Location = new Point(100, outTextBox.Location.Y);
            outTextBox.Size = new Size(60, outTextBox.Size.Height);
            plusButton.Size = new Size(outTextBox.Size.Height - 1, outTextBox.Size.Height - 1);
            minusButton.Location = new Point(minusButton.Location.X - 10, minusButton.Location.Y);
            minusButton.Size = new Size(outTextBox.Size.Height - 1, outTextBox.Size.Height - 1);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        public void PrintText()// Отрисовка текста
        {
            string outString = "";
            char outChar;
            if (Value < 0)
            {
                if (Environment.OSVersion.Version.Build >= 6000)
                    outChar = '\u2193';
                else
                    outChar = '-';
                for (double i = Math.Abs(Value); i > 0; i--)
                    outString += outChar;
            }
            else
            {
                if (Value == 0)
                {
                    outTextBox.Text = "0";
                    return;
                }
                if (Environment.OSVersion.Version.Build >= 6000)
                    outChar = '\u2191';
                else
                    outChar = '+';
                for (double i = Math.Abs(Value); i > 0; i--)
                    outString += outChar;
            }
            outTextBox.Text = outString;
        }
        private void minusOne()// Минус один
        {
            if (Value > Minimum)
            {
                Value -= 1;
                PrintText();
            }
            else
            {
                Value = Minimum;                
            }
        }
        private void plusOne()// Плюс один
        {
            if (Value < Maximum)
            {
                Value += 1;
                PrintText();
            }
            else
            {
                Value = Maximum;
            }
        }
        
        #region Обработчики        
        private void plusButton_Click(object sender, EventArgs e)
        {
            plusOne();
            Check();
        }
        private void minusButton_Click(object sender, EventArgs e)
        {
            minusOne();
            Check();
        }
        private void enableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Checked = !Checked;
        }        
        #endregion

        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Highlight);
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromKnownColor(KnownColor.Info);
            base.OnMouseLeave(e);
        }     
    }
}
