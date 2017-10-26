using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2._0._1
{

    public partial class Form2 : Form
    {
        int scale = 1, rotation = 0, x_position = 300, y_position = 300;
        bool loaded = false;

        int width, height, top = 0, bottom = 0;
        //private int mouse_x=0;
        //private int mouse_y=0;
        //private Point loc;

        public Form2() => InitializeComponent();

        private void gLControl_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.Black);
            SetupViewport();
        }

        private void SetupViewport()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, gLControl.Width, 0, gLControl.Height, -1, 1);
            GL.Viewport(0, 0, gLControl.Width, gLControl.Height);
        }

        private void gLControl_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //write your code for cube between clear() and swapbuffers()

            GL.PushMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            Translate();

            RotateCube();
            ScaleCube();

            GL.Begin(BeginMode.Quads);
            DrawCube();
            GL.End();

            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthClamp);//imp line

            GL.PopMatrix();
            gLControl.SwapBuffers();
        }

        private void Translate() => GL.Translate(x_position, y_position, 1);

        private void RotateCube() => GL.Rotate(rotation, 10, 10, 10);

        private void ScaleCube() => GL.Scale(scale, scale, scale);

        private void DrawCube()
        {

            GL.Color3(Color.White);//front
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(50, 0, 0);
            GL.Vertex3(50, 50, 0);
            GL.Vertex3(0, 50, 0);

            GL.Color3(Color.Red);//back
            GL.Vertex3(50, 0, 0);
            GL.Vertex3(50, 0, -50);
            GL.Vertex3(50, 50, -50);
            GL.Vertex3(50, 50, 0);

            GL.Color3(Color.Yellow);//bottom
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, -50);
            GL.Vertex3(50, 0, -50);
            GL.Vertex3(50, 0, 0);

            GL.Color3(Color.Green);//left
            GL.Vertex3(0, 0, -50);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 50, 0);
            GL.Vertex3(0, 50, -50);

            GL.Color3(Color.HotPink);//top
            GL.Vertex3(0, 50, 0);
            GL.Vertex3(50, 50, 0);
            GL.Vertex3(50, 50, -50);
            GL.Vertex3(0, 50, -50);

            GL.Color3(Color.Blue);//righta
            GL.Vertex3(50, 0, -50);
            GL.Vertex3(0, 0, -50);
            GL.Vertex3(0, 50, -50);
            GL.Vertex3(50, 50, -50);
        }

        private void Form2_Load(object sender, EventArgs e) => GL.ClearColor(Color.Black);

        private void gLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                x_position = e.X;
                y_position = (gLControl.Height - e.Y);
                gLControl.Invalidate();
            }
        }

        private void gLControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                rotation = rotation + 20;
                gLControl.Invalidate();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (scale > gLControl.Width || scale > gLControl.Height)
            {
                scale = 1;
            }
            else
            {
                if (e.Delta > 0)
                    scale++;
                else if (e.Delta < 0)
                {
                    if (scale < 2)
                    {
                        scale = 1;
                    }
                    else
                        scale--;
                }
            }
            gLControl.Invalidate();

        }
    }
}

