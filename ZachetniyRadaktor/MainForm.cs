using Microsoft.VisualBasic;
using ZachetniyRadaktor.Drawings;

namespace ZachetniyRadaktor
{
    public partial class MainForm : Form
    {
        private DragNDrop dragNDrop;

        private Editor editor = new Editor();

        private List<CheckBox> checkboxesRect = new List<CheckBox>();
        private List<CheckBox> checkboxesEllipse = new List<CheckBox>();
        private List<CheckBox> checkboxesCar = new List<CheckBox>();

        public MainForm()
        {
            InitializeComponent();
            dragNDrop = new(SpawnArea.Bounds);
            dragNDrop.appearanceChanged += (_, _) => Refresh();
            CreateCheckboxes();
            timer1.Start();
        }

        private void CreateCheckboxes()
        {
            if (checkboxesRect.Count > 0 || checkboxesEllipse.Count > 0) throw new Exception("Checkboxes already created");
            const int interval = 20;

            // Rects
            for (int i = 0; i < 10; i++)
            {
                var c = new CheckBox();
                c.Location = new Point(cntRects.Location.X + cntRects.Size.Width + interval * (i + 1), cntRects.Location.Y);
                c.Size = new(18, 17);
                c.Checked = true;
                c.Hide();
                c.CheckedChanged += OnRectCheckboxCheckedChanged;
                Controls.Add(c);
                checkboxesRect.Add(c);
            }

            // Ellipses
            for (int i = 0; i < 10; i++)
            {
                var c = new CheckBox();
                c.Location = new Point(cntEllipses.Location.X + cntEllipses.Size.Width + interval * (i + 1), cntEllipses.Location.Y);
                c.Size = new(18, 17);
                c.Checked = true;
                c.Hide();
                c.CheckedChanged += OnEllipseCheckboxCheckedChanged;
                Controls.Add(c);
                checkboxesEllipse.Add(c);
            }

            // Ellipses
            for (int i = 0; i < 10; i++)
            {
                var c = new CheckBox();
                c.Location = new Point(cntCars.Location.X + cntCars.Size.Width + interval * (i + 1), cntCars.Location.Y);
                c.Size = new(18, 17);
                c.Checked = true;
                c.Hide();
                c.CheckedChanged += OnCarCheckboxCheckedChanged;
                Controls.Add(c);
                checkboxesCar.Add(c);
            }
        }

        private void OnRectCheckboxCheckedChanged(object? sender, EventArgs e)
        {
            CheckBox? c = sender as CheckBox ?? new();
            var index = checkboxesRect.IndexOf(c);
            if (index == -1) throw new Exception("sender not in checkboxesRect");
            if (index >= dragNDrop.RectsNum) return;
            dragNDrop.SetRectEnableAt(index, c.Checked);
        }

        private void OnEllipseCheckboxCheckedChanged(object? sender, EventArgs e)
        {
            CheckBox? c = sender as CheckBox ?? new();
            var index = checkboxesEllipse.IndexOf(c);
            if (index == -1) throw new Exception("sender not in checkboxesEllipse");
            if (index >= dragNDrop.EllipsesNum) return;
            dragNDrop.SetEllipseEnableAt(index, c.Checked);
        }

        private void OnCarCheckboxCheckedChanged(object? sender, EventArgs e)
        {
            CheckBox? c = sender as CheckBox ?? new();
            var index = checkboxesCar.IndexOf(c);
            if (index == -1) throw new Exception("sender not in checkboxesCar");
            if (index >= dragNDrop.CarsNum) return;
            dragNDrop.SetCarEnableAt(index, c.Checked);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            dragNDrop.Draw(e.Graphics);
        }

        private void cntRects_ValueChanged(object sender, EventArgs e)
        {
            var before = dragNDrop.RectsNum;
            var value = (int)cntRects.Value;
            dragNDrop.RectsNum = value;
            if (value < before)
            {
                for (int i = before - 1; i >= value; i--)
                {
                    checkboxesRect[i].Checked = true;
                    checkboxesRect[i].Hide();
                }
            }
            else
            {
                for (int i = before; i < value; i++)
                {
                    checkboxesRect[i].Show();
                }
            }
        }

        private void cntEllipses_ValueChanged(object sender, EventArgs e)
        {
            var before = dragNDrop.EllipsesNum;
            var value = (int)cntEllipses.Value;
            dragNDrop.EllipsesNum = value;
            if (value < before)
            {
                for (int i = before - 1; i >= value; i--)
                {
                    checkboxesEllipse[i].Checked = true;
                    checkboxesEllipse[i].Hide();
                }
            }
            else
            {
                for (int i = before; i < value; i++)
                {
                    checkboxesEllipse[i].Show();
                }
            }
        }

        private void cntCars_ValueChanged(object sender, EventArgs e)
        {
            var before = dragNDrop.CarsNum;
            var value = (int)cntCars.Value;
            dragNDrop.CarsNum = value;
            if (value < before)
            {
                for (int i = before - 1; i >= value; i--)
                {
                    checkboxesCar[i].Checked = true;
                    checkboxesCar[i].Hide();
                }
            }
            else
            {
                for (int i = before; i < value; i++)
                {
                    checkboxesCar[i].Show();
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    dragNDrop.OnMouseDown(sender, e);
                    break;
                case MouseButtons.Right:
                    var figure = dragNDrop.Hitted(e.Location);
                    if (figure == null) break;
                    editor.Show();
                    editor.Figure = figure;
                    break;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    dragNDrop.OnMouseUp(sender, e);
                    break;
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    dragNDrop.OnMouseMove(sender, e);
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dragNDrop.OnTimerTick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dragNDrop.Save();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dragNDrop.Load();

            editor.Hide();

            cntRects.Value = dragNDrop.RectsNum;
            cntEllipses.Value = dragNDrop.EllipsesNum;
            cntCars.Value = dragNDrop.CarsNum;

            for (int i = 0; i < cntRects.Value; i++)
            {
                checkboxesRect[i].Show();
                checkboxesRect[i].Checked = true;

            }
            for (int i = (int)cntRects.Value; i < checkboxesRect.Count; i++)
            {
                checkboxesRect[i].Hide();
                checkboxesRect[i].Checked = true;
            }

            for (int i = 0; i < cntEllipses.Value; i++)
            {
                checkboxesEllipse[i].Show();
                checkboxesEllipse[i].Checked = true;
            }
            for (int i = (int)cntEllipses.Value; i < checkboxesEllipse.Count; i++)
            {
                checkboxesEllipse[i].Hide();
                checkboxesEllipse[i].Checked = true;
            }

            for (int i = 0; i < cntCars.Value; i++)
            {
                checkboxesCar[i].Show();
                checkboxesCar[i].Checked = true;
            }
            for (int i = (int)cntCars.Value; i < checkboxesCar.Count; i++)
            {
                checkboxesCar[i].Hide();
                checkboxesCar[i].Checked = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            if (dragNDrop.unsavedChanges)
                switch (MessageBox.Show("Save?",
                                         "Unsaved changes",
                                         MessageBoxButtons.YesNoCancel,
                                         MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        dragNDrop.Save();
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }

        }
    }
}