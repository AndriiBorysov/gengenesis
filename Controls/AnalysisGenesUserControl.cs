using System;
using System.Drawing;
using System.Windows.Forms;

namespace GenGenesis
{
    public partial class AnalysisGenesUserControl : UserControl
    {
        // Значение
        private double _value;
        private bool _checked;
        private int reSizeCount;
        public double Value
        {
            set
            {
                if (Tag != null)
                {
                    Analysis T = (Analysis)Tag;
                    if (value < 0)
                    {
                        _value = -1;
                        T.analizes_value = -1;
                    }
                    else
                    {
                        _value = 1;
                        T.analizes_value = 1;
                    }
                    if (value == 0)
                    {
                        _value = 0;
                        T.analizes_value = 0;
                    }
                    Tag = T;
                }
                if (value < 0)
                    _value = -1;
                else
                    _value = 1;
                if (value == 0)
                    _value = 0;
                // Установка значения радиобатона
                SetRadioButton();
            }
            get
            {
                if (minusRadioButton.Checked)
                    return -1;
                if (zeroRadioButton.Checked)
                    return 0;
                if (plusRadioButton.Checked)
                    return 1;
                MessageBox.Show("Не выбрано значение!", "Ошибка");
                return 0;
            }
        }        
        public bool Checked
        {
            set { checkBox.Checked = value; _checked = value; }
            get { return _checked; }
        }
        public AnalysisGenesUserControl(string genName)
        {
            InitializeComponent();
            Value = 0;
            reSizeCount = 0;
            Checked = false;
            checkBox.Text = genName;
            this.Name = genName;
            DoResize();
        }
        public void UncheckAll()// Отмена всех установок
        {
            minusRadioButton.Checked = false;
            zeroRadioButton.Checked = false;
            plusRadioButton.Checked = false;
            _value = 0;
            if (Tag != null)
            {
                Analysis T = (Analysis)Tag;                
                T.analizes_value = 0;
                Tag = T;
            }
            Checked = false;
        }
        public void DoResize()// Утановка новых значений
        {
            this.SuspendLayout();
            checkBox.Location = new Point(1, checkBox.Location.Y);
            groupBox.Location = new Point(100, groupBox.Location.Y);
            groupBox.Size = new Size(groupBox.ClientSize.Width, groupBox.ClientSize.Height-2);                        
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void SetRadioButton()// Установка значения радиобатона
        {
            if (_value == -1)
            {
                minusRadioButton.Checked = true;
                return;
            }
            if (_value == 0)
            {
                zeroRadioButton.Checked = true;
                return;
            }
            if (_value == 1)
            {
                plusRadioButton.Checked = true;
                return;
            }
        }

        #region Обработчики
        private void minusRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Tag != null)
            {
                Analysis T = (Analysis)Tag;
                T.analizes_value = -1;
                Tag = T;
            }
            _value = -1;
            Checked = true;
        }
        private void zeroRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Tag != null)
            {
                Analysis T = (Analysis)Tag;
                T.analizes_value = 0;
                Tag = T;
            }
            _value = 0;
            Checked = true;
        }
        private void plusRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Tag != null)
            {
                Analysis T = (Analysis)Tag;
                T.analizes_value = 1;
                Tag = T;
            }
            _value = 1;
            Checked = true;
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            _checked = !_checked;
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
