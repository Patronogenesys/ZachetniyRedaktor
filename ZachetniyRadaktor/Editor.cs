using ZachetniyRadaktor.Drawings;

namespace ZachetniyRadaktor
{
    public partial class Editor : Form
    {
        private Figure? figure;
        private ColorDialog colorDialog = new ColorDialog();
        private bool cntEnable = false;
        public Figure? Figure
        {
            get => figure;
            set
            {
                cntEnable = false;
                if (figure != null && figure != value) figure.appearanceChanged -= (_, _) => Refresh();
                figure = value;
                if (figure == null) return;

                btnDrive.Visible = figure is Car;

                figure.appearanceChanged += (_, _) => Refresh();
                btnColor.BackColor = figure.Color;
                SetMaxMin();
                cntHeight.Value = figure.Size.Height;
                cntWidth.Value = figure.Size.Width;
                Refresh();
                cntEnable = true;
            }
        }

        public Editor()
        {
            InitializeComponent();
        }

        private void Editor_Paint(object sender, PaintEventArgs e)
        {
            Figure?.DrawInEditor(e.Graphics, DrawArea.Bounds);
        }

        private void cntHeight_ValueChanged(object sender, EventArgs e)
        {
            if (Figure == null || !cntEnable) return;
            Figure.Size = new(Figure.Size.Width, (int)cntHeight.Value);
            SetMaxMin();
        }

        private void cntWidth_ValueChanged(object sender, EventArgs e)
        {
            if (Figure == null || !cntEnable) return;
            Figure.Size = new((int)cntWidth.Value, Figure.Size.Height);
            SetMaxMin();
        }

        private void SetMaxMin()
        {
            if (Figure is Car c)
            {
                cntWidth.Minimum = Math.Max(c.MinWidth, 20);
                cntHeight.Maximum = Math.Min(c.Size.Width, 120);
            }
            else
            {
                cntWidth.Minimum = 20;
                cntHeight.Maximum = 120;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            e.Cancel = true;
            Hide();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog.AllowFullOpen = true;
            colorDialog.Color = figure.Color;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorDialog.Color;
                figure.Color = colorDialog.Color;
            }
        }

        private void Editor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && Figure is Car c)
            {
                Figure? f = c.ChildTouchedInEditor(e.Location, DrawArea.Bounds);
                if (f == null) return;

                colorDialog.AllowFullOpen = true;
                colorDialog.Color = f.Color;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                    f.Color = colorDialog.Color;
            }
        }

        private void btnDrive_Click(object sender, EventArgs e)
        {
            if (figure is Car c)
            {
                c.IsDriving = !c.IsDriving;
            }
        }
    }
}
