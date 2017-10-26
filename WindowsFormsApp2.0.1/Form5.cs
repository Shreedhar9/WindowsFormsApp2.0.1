using OpenTK.Graphics.OpenGL;
using OpenTK;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp2._0._1
{
    public partial class Form5 : Form
    {
        double scale = 1, rotation = 45;
        double x = 0, y = 0, z = 0;
        double currentXPosition = 0, currentYPosition = 0;
        float zoom = 0;
        bool loaded = false;
        float width, height, top, bottom, left, right;
        private double[] matrix=new double[16];

        public Form5() => InitializeComponent();

       

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            //glControl1.Width = 450; glControl1.Height = 450;
            width = glControl1.Width;
            height = glControl1.Height;
            left = 10; bottom = 10;

            GL.ClearColor(Color.Black);
            SetupViewport();
            IsomatricView();
        }
        private void IsomatricView()
        {

            GL.Translate(-20, -20, -20);
            GL.Rotate(rotation, 1.0, 0, 0);
            GL.Rotate(rotation, 0, 1.0, 0);
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthClamp);
            glControl1.Invalidate();
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

        private void SetupViewport()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(left, width, bottom, height, -1, 1);
            //GL.Ortho(left - zoom, width + zoom, bottom - zoom, height + zoom, -10, 10);
            //GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
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
            //  GL.Translate(currentXPosition, currentYPosition, 1);

            //GL.Translate(0, 0, 0);
            //GL.Scale(scale, scale, scale);
            //GL.Translate(-0, -0, -0);

            //GL.Translate(width / 2, height / 2, 1);
           // GL.Translate(-20, -20, -20);

            GL.Begin(BeginMode.Quads);
            DrawCube();
            GL.End();

            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthClamp);//imp line

            GL.PopMatrix();
            glControl1.SwapBuffers();
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    SetupCursorXYZ();
            //    glControl1.Invalidate();
            //}
        }

        private void SetupCursorXYZ()
        {
            currentXPosition = PointToClient(Cursor.Position).X *(z + 1);
            currentYPosition = (-PointToClient(Cursor.Position).Y + glControl1.Height) *(z + 1);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            //if (e.Delta < 0)
            //{
            //    left++;bottom++;height++;width++;
            //}
            //else
            //{
            //    left--;bottom--;height--;width--;
            //}

            //if (e.Delta > 0)
            //{
            //    zoom -= 10;
            //    GL.Ortho(left - zoom, width + zoom, bottom - zoom, height + zoom, -10, 10);
            //}
            //else
            //{
            //    zoom += 10;
            //    GL.Ortho(left - zoom, width + zoom, bottom - zoom, height + zoom, -10, 10);
            //}


            //******one more attemt***
            //Matrix4 matrix4 = Matrix4.LookAt(0, 0, 0, -width, -height, -1, e.X, e.Y, 0);

            ////Matrix4 matrix4 = Matrix4.CreateOrthographic(width, height, -10, 10);
            //GL.MatrixMode(MatrixMode.Modelview);
            //GL.LoadMatrix(ref matrix4);

            //Console.WriteLine(e.Delta);
            if (e.Delta > 0)
            {
                //scale += 10;
                zoom--;

                //Matrix4 matrix = Matrix4.CreateOrthographic(glControl1.Width, glControl1.Height, -1, 1);
                //GL.MatrixMode(MatrixMode.Projection);
                //GL.LoadMatrix(ref matrix);
                //GL.Ortho(left*zoom, width * zoom, bottom * zoom, height * zoom, -1, 1);
                //IsomatricView();
            }
            else if (e.Delta < 0)
            {
                //if (scale<2)
                //{
                //    scale = 2;
                //}
                //else
                //{
                // scale -= 10;
                zoom++;
                //Matrix4 matrix = Matrix4.CreateOrthographic(glControl1.Width, glControl1.Height, -1, 1);
                //GL.MatrixMode(MatrixMode.Projection);
                //GL.LoadMatrix(ref matrix);
                //GL.Ortho(left * zoom, width * zoom, bottom * zoom, height * zoom, -1, 1);
                //IsomatricView();
                // Pan camera on modelview
                // GL.MatrixMode(MatrixMode.Modelview);
                //// GL.LoadIdentity();
                // GL.Translate(glControl1.Width, glControl1.Height, 0);
                //}
            }
            //***this piece of code is giving illusion of the zooming********************
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-width * 0.5f * zoom, width * 0.5f * zoom, -height * 0.5f * zoom, height * 0.5f * zoom, 1, -1);
            ////*************************************************************
            IsomatricView();
            glControl1.Invalidate();
        }

    }
}

