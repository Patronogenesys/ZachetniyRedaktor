namespace ZachetniyRadaktor
{
    partial class Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DrawArea = new Panel();
            cntHeight = new NumericUpDown();
            lbHeight = new Label();
            lbWidth = new Label();
            cntWidth = new NumericUpDown();
            btnColor = new Button();
            ((System.ComponentModel.ISupportInitialize)cntHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cntWidth).BeginInit();
            SuspendLayout();
            // 
            // DrawArea
            // 
            DrawArea.Location = new Point(12, 12);
            DrawArea.Name = "DrawArea";
            DrawArea.Size = new Size(328, 328);
            DrawArea.TabIndex = 0;
            DrawArea.Visible = false;
            // 
            // cntHeight
            // 
            cntHeight.Location = new Point(74, 350);
            cntHeight.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            cntHeight.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            cntHeight.Name = "cntHeight";
            cntHeight.Size = new Size(55, 27);
            cntHeight.TabIndex = 1;
            cntHeight.Value = new decimal(new int[] { 20, 0, 0, 0 });
            cntHeight.ValueChanged += cntHeight_ValueChanged;
            // 
            // lbHeight
            // 
            lbHeight.AutoSize = true;
            lbHeight.Location = new Point(14, 352);
            lbHeight.Name = "lbHeight";
            lbHeight.Size = new Size(54, 20);
            lbHeight.TabIndex = 3;
            lbHeight.Text = "Height";
            // 
            // lbWidth
            // 
            lbWidth.AutoSize = true;
            lbWidth.Location = new Point(230, 352);
            lbWidth.Name = "lbWidth";
            lbWidth.Size = new Size(49, 20);
            lbWidth.TabIndex = 4;
            lbWidth.Text = "Width";
            // 
            // cntWidth
            // 
            cntWidth.Location = new Point(285, 350);
            cntWidth.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            cntWidth.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            cntWidth.Name = "cntWidth";
            cntWidth.Size = new Size(55, 27);
            cntWidth.TabIndex = 1;
            cntWidth.Value = new decimal(new int[] { 20, 0, 0, 0 });
            cntWidth.ValueChanged += cntWidth_ValueChanged;
            // 
            // btnColor
            // 
            btnColor.Location = new Point(135, 346);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(95, 31);
            btnColor.TabIndex = 5;
            btnColor.Text = "COLOR";
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 443);
            Controls.Add(btnColor);
            Controls.Add(lbWidth);
            Controls.Add(lbHeight);
            Controls.Add(cntWidth);
            Controls.Add(cntHeight);
            Controls.Add(DrawArea);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Editor";
            Text = "Editor";
            Paint += Editor_Paint;
            ((System.ComponentModel.ISupportInitialize)cntHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)cntWidth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel DrawArea;
        private NumericUpDown cntHeight;
        private Label lbHeight;
        private Label lbWidth;
        private NumericUpDown cntWidth;
        private Button btnColor;
    }
}