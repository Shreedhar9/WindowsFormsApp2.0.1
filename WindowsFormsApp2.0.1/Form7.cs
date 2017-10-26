using System;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using GLint = System.Int64;

namespace WindowsFormsApp2._0._1
{
    public partial class Form7 : Form
    {
        bool loaded = false;
        int rotation = 45;

        double dragposx = 0, dragposy = 0, dragposz = 0;
        double px, py, pz, left, right;

        double currentX = 100, currentY = 100;
        public Form7() => InitializeComponent();

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.DarkGray);
            SetupViewport();
            IsomatricView();
        }

        private void SetupViewport()
        {
            int width = glControl1.Width;
            int height = glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0,width,0,height, -1, 1);
            GL.Viewport(0, 0, width, height);
        }

      
        
        private void IsomatricView()
        {
            GL.Rotate(rotation, 1.0, 0, 0);
            GL.Rotate(rotation, 0, 1.0, 0);
            //GL.Translate(width / 2, height / 2, 1);
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthClamp);
            glControl1.Invalidate();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
            {
                return;
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.PushMatrix();

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            //GL.Translate(currentX, currentY, -1);
            GL.Begin(BeginMode.Quads);
            
            DrawCube();
            GL.End();

            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthClamp);//imp line

            GL.PopMatrix();
            glControl1.SwapBuffers();
        }

        private void DrawCube()
        {

            GL.Color3(Color.White);//front
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(80, 0, 0);
            GL.Vertex3(80, 80, 0);
            GL.Vertex3(0, 80, 0);

            GL.Color3(Color.Red);//back
            GL.Vertex3(80, 0, 0);
            GL.Vertex3(80, 0, -80);
            GL.Vertex3(80, 80, -80);
            GL.Vertex3(80, 80, 0);

            GL.Color3(Color.Yellow);//bottom
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, -80);
            GL.Vertex3(80, 0, -80);
            GL.Vertex3(80, 0, 0);

            GL.Color3(Color.Green);//left
            GL.Vertex3(0, 0, -80);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 80, 0);
            GL.Vertex3(0, 80, -80);

            GL.Color3(Color.HotPink);//top
            GL.Vertex3(0, 80, 0);
            GL.Vertex3(80, 80, 0);
            GL.Vertex3(80, 80, -80);
            GL.Vertex3(0, 80, -80);

            GL.Color3(Color.Blue);//righta
            GL.Vertex3(80, 0, -80);
            GL.Vertex3(0, 0, -80);
            GL.Vertex3(0, 80, -80);
            GL.Vertex3(80, 80, -80);
        }
    }
}
