using OpenTK;

namespace WindowsFormsApp2._0._1
{
    partial class Form2
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
        private GLControl gLControl;
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gLControl = new OpenTK.GLControl();
            this.SuspendLayout();
            // 
            // gLControl
            // 
            this.gLControl.BackColor = System.Drawing.Color.Black;
            this.gLControl.Location = new System.Drawing.Point(0, 0);
            this.gLControl.Name = "gLControl";
            this.gLControl.Size = new System.Drawing.Size(725, 500);
            this.gLControl.TabIndex = 0;
            this.gLControl.VSync = false;
            this.gLControl.Load += new System.EventHandler(this.gLControl_Load);
            this.gLControl.Paint += new System.Windows.Forms.PaintEventHandler(this.gLControl_Paint);
            this.gLControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gLControl_KeyDown);
            this.gLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gLControl_MouseDown);
            this.gLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gLControl_MouseMove);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 512);
            this.Controls.Add(this.gLControl);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }
        #endregion
    }
}