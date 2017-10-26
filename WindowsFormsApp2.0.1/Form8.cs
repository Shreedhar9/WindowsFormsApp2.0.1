using System;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK;

namespace WindowsFormsApp2._0._1
{
    public partial class Form8 : Form
    {
        private bool loaded;
        private int width;
        private int height;
        private int left;
        private int right;
        private int bottom;
        private double rotation;
        int minx, miny, minz, maxx, maxy, maxz;

        private double Zoom=0.25d;
        public Form8() => InitializeComponent();//init values

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;

          //  minx = -width; maxx = width; miny = -height; maxy = height; minz = -1; maxz = 1;

            //left = -10; bottom = -10;
            rotation = 45;

            width = glControl1.Width;
            height = glControl1.Height;

            GL.ClearColor(Color.Gray);
            SetupViewport();
            IsomatricView();
        }

        private void IsomatricView()
        {
            //GL.Translate((minx + maxx) / 2, (miny + maxy) / 2, (minz + maxz) / 2);
            GL.Rotate(-rotation, 1, 0, 0);
            GL.Rotate(-rotation, 0, 1, 0);
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthClamp);
            glControl1.Invalidate();
        }

        private void SetupViewport()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            // GL.Ortho(left, width, bottom, height, -1, 1);
            //GL.Ortho(-width, width,-height, height, -1, 1);
            GL.Ortho(-width * Zoom, width * Zoom, -height * Zoom, height * Zoom, -1, 1);
            GL.Viewport(0, 0, width, height);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //write your code for cube between clear() and swapbuffers()

            GL.PushMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
       
            //IsomatricView();
          //  GL.Translate(glControl1.Width/2,glControl1.Height/2,-1);
            GL.Begin(BeginMode.Quads);
            DrawCube();
            GL.End();

            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthClamp);//imp line

            GL.PopMatrix();
            glControl1.SwapBuffers();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (Zoom == 0)
            {
                Zoom = 0.25d;
            }

            else //(Zoom >=1)
            {
                Console.WriteLine(Zoom + "\t" + e.Delta);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.Ortho(-width * 0.5f * Zoom, width * 0.5f * Zoom, -height * 0.5f * Zoom, height * 0.5f * Zoom, -1, 1);
                IsomatricView();
                if (e.Delta > 0)
                    Zoom = Zoom + 0.25d;
                if (e.Delta < 0)
                    Zoom = Zoom - 0.25d;
                
            }
            glControl1.Invalidate();
        }

        private void DrawCube()
        {

            GL.Color3(Color.White);//front
            GL.Vertex3(-80, 80, -80);
            GL.Vertex3(-80, -80, -80);
            GL.Vertex3(80, -80, -80);
            GL.Vertex3(80, 80, -80);

            GL.Color3(Color.Red);//back
            GL.Vertex3(80, 80, 80);
            GL.Vertex3(80, -80, 80);
            GL.Vertex3(-80, -80, 80);
            GL.Vertex3(-80, 80, 80);


            GL.Color3(Color.Yellow);//bottom
            GL.Vertex3(-80, -80, -80);
            GL.Vertex3(-80, -80, 80);
            GL.Vertex3(80, -80, 80);
            GL.Vertex3(80, -80, -80);

            GL.Color3(Color.Green);//left
            GL.Vertex3(-80,80, 80);
            GL.Vertex3(-80, -80, 80);
            GL.Vertex3(-80, -80, -80);
            GL.Vertex3(-80, 80, -80);

            GL.Color3(Color.DarkViolet);//top
            GL.Vertex3(-80, 80, 80);
            GL.Vertex3(-80, 80, -80);
            GL.Vertex3(80, 80, -80);
            GL.Vertex3(80, 80, 80);

            GL.Color3(Color.Blue);//right
            GL.Vertex3(80, 80, -80);
            GL.Vertex3(80, -80, -80);
            GL.Vertex3(80, -80, 80);
            GL.Vertex3(80, 80, 80);
        }

        private void DrawCube2()
        {
            GL.Color3(Color.White);//front
            GL.Vertex3(-40, 40, -40);
            GL.Vertex3(-40, -40, -40);
            GL.Vertex3(40, -40, -40);
            GL.Vertex3(40, 40, -40);

            GL.Color3(Color.Red);//back
            GL.Vertex3(40, 40, 40);
            GL.Vertex3(40, -40, 40);
            GL.Vertex3(-40, -40, 40);
            GL.Vertex3(-40, 40, 40);


            GL.Color3(Color.Yellow);//bottom
            GL.Vertex3(-40, -40, -40);
            GL.Vertex3(-40, -40, 40);
            GL.Vertex3(40, -40, 40);
            GL.Vertex3(40, -40, -40);

            GL.Color3(Color.Green);//left
            GL.Vertex3(-40, 40, 40);
            GL.Vertex3(-40, -40, 40);
            GL.Vertex3(-40, -40, -40);
            GL.Vertex3(-40, 40, -40);

            GL.Color3(Color.DarkViolet);//top
            GL.Vertex3(-40, 40, 40);
            GL.Vertex3(-40, 40, -40);
            GL.Vertex3(40, 40, -40);
            GL.Vertex3(40, 40, 40);

            GL.Color3(Color.Blue);//right
            GL.Vertex3(40, 40, -40);
            GL.Vertex3(40, -40, -40);
            GL.Vertex3(40, -40, 40);
            GL.Vertex3(40, 40, 40);
        }

    }
}
