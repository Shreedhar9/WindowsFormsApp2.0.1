using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;

using System.Windows.Forms;

namespace WindowsFormsApp2._0._1
{
    public partial class Form9 : Form
    {
        private bool loaded; bool changed = false;
        private int width, height;
        private double angle;
        private double newx, newy, newz, dx, dy, dz, oldx, oldy, oldz;
        private double Zoom = 0.25d;
        Matrix4d matrix = new Matrix4d();
        Matrix4d invertMatrix = new Matrix4d();
       
        private int[] viewport = new int[4];
        double[] zprReferencePoint = { 0, 0, 0, 0 };
        double ax, ay, az;
        double bx, by, bz;

        public Form9() => InitializeComponent();

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //write your code for cube between clear() and swapbuffers()
            GL.LoadIdentity();
            GL.PushMatrix();
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            LoadOrthoMatrix();

            IsomatricView();

            GL.PushMatrix();
            GL.Rotate(angle, bx, by, bz);
            GL.PopMatrix();
            GL.Begin(BeginMode.Quads);
            DrawCube();
            GL.End();
            
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthClamp);//imp line

            GL.PopMatrix();
            glControl1.SwapBuffers();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;

            angle = 45;
            width = glControl1.Width;
            height = glControl1.Height;
            
            GL.ClearColor(Color.Gray);
            SetupViewport();
           // IsomatricView();
        }

        private void IsomatricView()
        {
            GL.Rotate(-angle, 1, 0, 0);
            GL.Rotate(-angle, 0, 1, 0);
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthClamp);
            glControl1.Invalidate();
        }

        double Vlen(double x, double y, double z)
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        private void SetupViewport()
        {
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            //GL.Ortho(-width * Zoom, width * Zoom, -height * Zoom, height * Zoom, -1, 1);
            LoadOrthoMatrix();
            GL.Viewport(0, 0, width, height);
        }



        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            changed = false;

    
            //newx =  e.X;
            //newy =  e.Y;
            //dx = (newx - oldx);
            //dy = (newy - oldy);

            dx += (e.X - oldx);
            dy += (e.Y - oldy);

            //oldx = e.X;oldy = e.Y;
            //dx = glControl1.Width - e.X;
            //dy = glControl1.Height - e.Y;

            GL.GetInteger(GetPName.Viewport, viewport);

            if (dx == 0 && dy == 0)
                return;


            if (e.Button== MouseButtons.Left)
            {
                ax = dy; ay = dx; az = 0.0;
                angle = Vlen(ax, ay, az) / (double)(viewport[2] + 1) * (180.0);

                /* Use inverse matrix to determine local axis of rotation */

                bx = invertMatrix.M11 * ax + invertMatrix.M21 * ay + invertMatrix.M31 * az;
                by = invertMatrix.M12 * ax + invertMatrix.M22 * ay + invertMatrix.M32 * az;
                bz = invertMatrix.M13 * ax + invertMatrix.M23 * ay + invertMatrix.M33 * az;

                /*comment out from loadidentity to last translate call*/
                //GL.LoadIdentity();
                //LoadOrthoMatrix();

                //GL.Translate(zprReferencePoint[0], zprReferencePoint[1], zprReferencePoint[2]);
                //GL.Rotate(angle, bx, by, bz);
                //GL.Translate(-zprReferencePoint[0], -zprReferencePoint[1], -zprReferencePoint[2]);
                //  IsomatricView();
                

                changed = true;
            }
             oldx = dx;oldy = dy;
            if (changed)
                getMatrix();

            glControl1.Invalidate();

        }
        void getMatrix()
        {
            GL.GetDouble(GetPName.ModelviewMatrix, out matrix);
            invertMatrix = matrix;
            invertMatrix.Invert();
        }
        private void LoadOrthoMatrix()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref matrix);
            GL.LoadIdentity();
            GL.Ortho(-width * Zoom, width * Zoom, -height * Zoom, height * Zoom, -1, 1);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            changed = false;

            if (e.Delta > 0)
            {
                if (Zoom < 0.5)
                    Zoom = 0.25d;
                else Zoom = Zoom - 0.25d;
            }
            else
                Zoom = Zoom + 0.25d;

            Console.WriteLine(Zoom + "\t" + e.Delta);
/*comment loadortho and isomatricview*/
            
            //LoadOrthoMatrix();
            //IsomatricView();

            changed = true;
            if (changed)
                getMatrix();
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
            GL.Vertex3(-80, 80, 80);
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
    }
}
