using ZachetniyRadaktor.Drawings;

namespace ZachetniyRadaktor
{
    public partial class Editor : Form
    {
        private Figure? figure;
        private ColorDialog colorDialog = new ColorDialog();
        public Figure? Figure
        {
            get => figure;
            set
            {
                if (figure != null && figure != value) figure.appearanceChanged -= (_, _) => Refresh();
                figure = value;
                if (figure == null) return;
                figure.appearanceChanged += (_, _) => Refresh();
                btnColor.BackColor = figure.Color;
                cntHeight.Value = figure.Size.Height;
                cntWidth.Value = figure.Size.Width;
                Refresh();
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
            if (Figure == null) return;
            Figure.Size = new(Figure.Size.Width, (int)cntHeight.Value);
            SetMaxMin();
        }

        private void cntWidth_ValueChanged(object sender, EventArgs e)
        {
            if (Figure == null) return;
            Figure.Size = new((int)cntWidth.Value, Figure.Size.Height);
            SetMaxMin();
        }

        private void SetMaxMin()
        {
            if (Figure is Car c)
            {
                cntWidth.Minimum = c.MinWidth;
                cntHeight.Maximum = c.MinWidth;
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
    }
}
