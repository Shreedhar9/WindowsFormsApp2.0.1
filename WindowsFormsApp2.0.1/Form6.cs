using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2._0._1
{
    public partial class Form6 : Form
    {
        bool loaded = false;

        float x = 0;
        float y = 0;
        float z = 0;

        public Form6()
        {
            InitializeComponent();
        }


        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded) // Play nice
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Translate(x, y, 0); // position triangle according to our x variable

            GL.Color3(Color.Yellow);
            GL.Begin(BeginMode.Triangles);
            GL.Vertex2(10, 20);
            GL.Vertex2(100, 20);
            GL.Vertex2(100, 50);
            GL.End();

            glControl1.SwapBuffers();

        }
        private void SetupCursorXYZ()
        {
            x = PointToClient(Cursor.Position).X * (z + 1);
            y = (-PointToClient(Cursor.Position).Y + glControl1.Height) * (z + 1);
        }

        private void OnMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Delta > 0 && z > 0) z -= 0.5f;
            if (e.Delta < 0 && z < 5) z += 0.5f;

            SetupCursorXYZ();

            SetupViewport();
            glControl1.Invalidate();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.SkyBlue); // Yey! .NET Colors can be used directly!

            SetupViewport();
        }

        private void SetupViewport()
        {

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            int w = glControl1.Width;
            int h = glControl1.Height;

            float orthoW = w * (z + 1);
            float orthoH = h * (z + 1);

            GL.Ortho(0, orthoW, 0, orthoH, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
        }
        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
                      SetupCursorXYZ();

            glControl1.Invalidate();
        }
    }
}



