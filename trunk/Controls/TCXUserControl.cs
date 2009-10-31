using System;
using System.Drawing;
using System.Windows.Forms;

namespace GenGenesis
{
    public partial class TCXUserControl : UserControl
    {
        // Свойства
        private int reSizeCount;
        private int _value;
        public int Value 
        { 
            get{return _value;}
            set
            {
                if (Tag != null)
                {
                    _value = value;
                    var T = (TCX)Tag;
                    T.tcx_value = value;
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
        public TCXUserControl(string testName)
        {
            InitializeComponent();            
            testNameLabel.Text = testName;
            this.Name = testName;
            reSizeCount = 0;
            Init();
            DoResize();
            PrintText();
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
            testNameLabel.Location = new Point(enableCheckBox.ClientSize.Width + 1, testNameLabel.Location.Y);
            outTextBox.Location = new Point(testNameLabel.ClientSize.Width + testNameLabel.Location.X + 5, outTextBox.Location.Y);
            outTextBox.Size = new Size(75,outTextBox.Size.Height);            
            plusButton.Location = new Point(outTextBox.Location.X + outTextBox.ClientSize.Width + 5, plusButton.Location.Y);
            plusButton.Size = new Size(outTextBox.Size.Height+2, outTextBox.Size.Height+2);
            
            minusButton.Location = new Point(plusButton.Location.X + plusButton.ClientSize.Width + 3, minusButton.Location.Y);
            minusButton.Size = new Size(outTextBox.Size.Height+2, outTextBox.Size.Height+2);

            this.Size = new Size(minusButton.Location.X + minusButton.ClientSize.Width + 3, this.Size.Height);
            
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        public void PrintText()// Отрисовка текста
        {
            string outString = "";
            char outChar;
            if (Value < 0)
            {
                outChar = '\u2193';
                //outChar = '-';
                for (int i = Math.Abs(Value); i > 0; i--)
                    outString += outChar;
            }
            else
            {
                if (Value == 0)
                {
                    outTextBox.Text = "0";
                    return;
                }
                outChar = '\u2191';
                //outChar = '+';
                for (int i = Math.Abs(Value); i > 0; i--)
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
        protected override void OnPaint(PaintEventArgs e)
        {
            if (reSizeCount < 3)
            {
                DoResize();
                reSizeCount++;
            }
            base.OnPaint(e);
        }
        #endregion

    }
}
