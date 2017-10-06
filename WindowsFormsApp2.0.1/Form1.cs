using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace WindowsFormsApp2._0._1
{
    public partial class Form1 : Form
    {
        bool loaded = false;
        public Form1()
        {
            InitializeComponent();
        }
        Stopwatch sw = new Stopwatch();
       
        void Application_Idle(object sender, EventArgs e)
        {
            double milliseconds = ComputeTimeSlice();
            Accumulate(milliseconds);
            Animate(milliseconds);
        }
        float rotation = 0;
        private void Animate(double milliseconds)
        {
            float deltaRotation = (float)milliseconds / 20.0f;
            rotation += deltaRotation;
            glControl.Invalidate();
        }

        double accumulator = 0;
        int idleCounter = 0;
        private void Accumulate(double milliseconds)
        {
            idleCounter++;
            accumulator += milliseconds;
            if (accumulator > 1000)
            {
                label1.Text = idleCounter.ToString();
                accumulator -= 1000;
                idleCounter = 0; // don't forget to reset the counter!
            }
        }

        private double ComputeTimeSlice()
        {
            sw.Stop();
            double timeslice = sw.Elapsed.TotalMilliseconds;
            sw.Reset();
            sw.Start();
            return timeslice;
        }
        private void SetupViewport()
        {
            int w = glControl.Width;
            int h = glControl.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
        }
       int x = 0;
        
       private void glControl_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.SkyBlue); // Yey! .NET Colors can be used directly!
            SetupViewport();
            Application.Idle += new EventHandler(Application_Idle); // press TAB twice after +=
            sw.Start(); // start at application boot
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(x,x,0);
            if (glControl.Focused)
                GL.Color3(Color.Yellow);
            else
                GL.Color3(Color.Blue);
            GL.Rotate(rotation, Vector3.UnitZ); // OpenTK has this nice Vector3 class!
            GL.Begin(BeginMode.Triangles);
            GL.Vertex2(10, 20);
            GL.Vertex2(100, 20);
            GL.Vertex2(100, 50);
            GL.End();
            glControl.SwapBuffers();
        }

        private void glControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                int w = glControl.Width; int h = glControl.Height;
                if (x > w || x > h)
                {
                    x = 1;
                }

                x = x + 10;
                glControl.Invalidate();
            }
        }

        private void glControl_Resize(object sender, EventArgs e)
        {
            SetupViewport();
            glControl.Invalidate();
        }

        private void glControl_MouseClick(object sender, MouseEventArgs e)
        {
            x=x+10;
            glControl.Invalidate();
        }
    }
}
