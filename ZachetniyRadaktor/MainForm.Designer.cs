namespace ZachetniyRadaktor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cntRects = new NumericUpDown();
            cntEllipses = new NumericUpDown();
            lbRects = new Label();
            lbEllipses = new Label();
            SpawnArea = new Panel();
            cntCars = new NumericUpDown();
            lbCars = new Label();
            ((System.ComponentModel.ISupportInitialize)cntRects).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cntEllipses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cntCars).BeginInit();
            SuspendLayout();
            // 
            // cntRects
            // 
            cntRects.Location = new Point(77, 28);
            cntRects.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            cntRects.Name = "cntRects";
            cntRects.Size = new Size(46, 27);
            cntRects.TabIndex = 0;
            cntRects.ValueChanged += cntRects_ValueChanged;
            // 
            // cntEllipses
            // 
            cntEllipses.Location = new Point(77, 61);
            cntEllipses.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            cntEllipses.Name = "cntEllipses";
            cntEllipses.Size = new Size(46, 27);
            cntEllipses.TabIndex = 1;
            cntEllipses.ValueChanged += cntEllipses_ValueChanged;
            // 
            // lbRects
            // 
            lbRects.AutoSize = true;
            lbRects.Location = new Point(12, 30);
            lbRects.Name = "lbRects";
            lbRects.Size = new Size(44, 20);
            lbRects.TabIndex = 2;
            lbRects.Text = "Rects";
            // 
            // lbEllipses
            // 
            lbEllipses.AutoSize = true;
            lbEllipses.Location = new Point(12, 63);
            lbEllipses.Name = "lbEllipses";
            lbEllipses.Size = new Size(58, 20);
            lbEllipses.TabIndex = 2;
            lbEllipses.Text = "Ellipses";
            // 
            // SpawnArea
            // 
            SpawnArea.Location = new Point(12, 125);
            SpawnArea.Name = "SpawnArea";
            SpawnArea.Size = new Size(776, 422);
            SpawnArea.TabIndex = 3;
            SpawnArea.Visible = false;
            // 
            // cntCars
            // 
            cntCars.Location = new Point(77, 94);
            cntCars.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            cntCars.Name = "cntCars";
            cntCars.Size = new Size(46, 27);
            cntCars.TabIndex = 1;
            cntCars.ValueChanged += cntCars_ValueChanged;
            // 
            // lbCars
            // 
            lbCars.AutoSize = true;
            lbCars.Location = new Point(12, 96);
            lbCars.Name = "lbCars";
            lbCars.Size = new Size(37, 20);
            lbCars.TabIndex = 2;
            lbCars.Text = "Cars";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 559);
            Controls.Add(SpawnArea);
            Controls.Add(lbCars);
            Controls.Add(lbEllipses);
            Controls.Add(cntCars);
            Controls.Add(lbRects);
            Controls.Add(cntEllipses);
            Controls.Add(cntRects);
            DoubleBuffered = true;
            Name = "MainForm";
            Text = "Form1";
            Paint += Form1_Paint;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            ((System.ComponentModel.ISupportInitialize)cntRects).EndInit();
            ((System.ComponentModel.ISupportInitialize)cntEllipses).EndInit();
            ((System.ComponentModel.ISupportInitialize)cntCars).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown cntRects;
        private NumericUpDown cntEllipses;
        private Label lbRects;
        private Label lbEllipses;
        private Panel SpawnArea;
        private NumericUpDown cntCars;
        private Label lbCars;
    }
}