using OpenTK;

namespace WindowsFormsApp2._0._1
{
    partial class Form1
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
            this.glControl = new OpenTK.GLControl();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Location = new System.Drawing.Point(36, 12);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(358, 312);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl_KeyDown);
            this.glControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.glControl_MouseClick);
            this.glControl.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 404);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.glControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private GLControl glControl;
        #endregion

        private System.Windows.Forms.Label label1;
    }
}

