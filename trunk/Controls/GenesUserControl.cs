using System;
using System.Drawing;
using System.Windows.Forms;

namespace GenGenesis
{
    public partial class GenesUserControl : UserControl
    {
        // Значение
        private int _value;
        private int reSizeCount;
        public int Value
        {
            set
            {
                if (value < 0)
                    _value = -1;
                else
                    if (value == 0)
                        _value = 0;
                    else
                        _value = 1;
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
        private bool _checked;
        public bool Checked
        {
            set { checkBox.Checked = value; _checked = value; }
            get { return _checked; }
        }
        public GenesUserControl(string genName)
        {
            InitializeComponent();
            Value = 0;
            reSizeCount = 0;
            Checked = false;
            genNameLabel.Text = genName;
            this.Name = genName;
            DoResize();
        }
        public void UncheckAll()// Отмена всех установок
        {
            minusRadioButton.Checked = false;
            zeroRadioButton.Checked = false;
            plusRadioButton.Checked = false;
            _value = 0;
            Checked = false;
        }
        public void DoResize()// Утановка новых значений
        {
            this.SuspendLayout();
            checkBox.Location = new Point(1, checkBox.Location.Y + 1);
            genNameLabel.Location = new Point(checkBox.Size.Width + 2, genNameLabel.Location.Y + 1);
            groupBox.Location = new Point(genNameLabel.Location.X + genNameLabel.Size.Width + 1, groupBox.Location.Y);
            groupBox.Size = new Size(groupBox.Size.Width, groupBox.Size.Height + 1);

            minusRadioButton.Location = new Point(2, minusRadioButton.Location.Y);
            zeroRadioButton.Location = new Point(minusRadioButton.Size.Width + 2, zeroRadioButton.Location.Y);
            plusRadioButton.Location = new Point(zeroRadioButton.Location.X + zeroRadioButton.Size.Width, plusRadioButton.Location.Y);

            groupBox.Size = new Size(minusRadioButton.Size.Width + zeroRadioButton.Size.Width + plusRadioButton.Size.Width + 3, this.groupBox.Size.Height - 2);
            this.Size = new Size(groupBox.Location.X + groupBox.Size.Width + 3, this.Size.Height + 1);
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
            _value = -1;
            Checked = true;
        }
        private void zeroRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _value = 0;
            Checked = true;
        }
        private void plusRadioButton_CheckedChanged(object sender, EventArgs e)
        {
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
    }
}
