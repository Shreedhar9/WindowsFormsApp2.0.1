using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GLint = System.Int32;
using GLdouble = System.Double;
using GLfloat = System.Single;
namespace WindowsFormsApp2._0._1
{
    public partial class Form3 : Form
    {
        GLfloat rtri;                       // Angle For The Triangle ( NEW )
        GLfloat rquad;
        private bool loaded=false;
        int[] vbo1= { };
        int vbo=0;

        public Form3()
        {
            InitializeComponent();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.Wheat);
            SetupViewport();
        }

        private void SetupViewport()
        {
            int w = glControl1.Width;
            int h = glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            float FOVradians =MathHelper.DegreesToRadians(50);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(FOVradians, w/h, 1, 4000);
            GL.MultMatrix(ref perspective);
            GL.Ortho(0, glControl1.Width, 0, glControl1.Height, -1, 1);
            GL.Viewport(0, 0, w, h);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
            {
                return;
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            // Clear The Screen And The Depth Buffer
            GL.LoadIdentity();                   // Reset The View
            GL.Translate(-1.5f, 0.0f, -6.0f);             // Move Left And Into The Screen

            GL.Rotate(rtri, 0.0f, 1.0f, 0.0f);             // Rotate The Pyramid On It's Y Axis

            GL.Begin(BeginMode.Quads);

            //Vector3[] vertices = new Vector3[24]
            //{
            //    //front
            //    new Vector3(0, 0, 0),
            //    new Vector3(50, 0, 0),
            //    new Vector3(50, 50, 0),
            //    new Vector3(50, 50, 0),

            //    new Vector3(50, 0, 0),
            //    new Vector3(50, 0, -50),
            //    new Vector3(50, 50, -50),
            //    new Vector3(50, 50, 0),

            //    new Vector3(0, 0, 0),
            //    new Vector3(0, 0, -50),
            //    new Vector3(-50, 0, -50),
            //    new Vector3(-50, 0, 0),

            //    new Vector3(0, 0, -50),
            //    new Vector3(0, 0, 0),
            //    new Vector3(0, 50, 0),
            //    new Vector3(0, 50, -50),

            //    new Vector3(0, 50, 0),
            //    new Vector3(50, 50, 0),
            //    new Vector3(50, 50, -50),
            //    new Vector3(0, 50, -50),

            //    new Vector3(-50, 0, -50),
            //    new Vector3(0, 0, -50),
            //    new Vector3(0, -50, -50),
            //    new Vector3(-50, -50, -50)
            //};
            //vbo1 = GL.GenBuffers(1, vbo1);
            //GL.BindBuffer(BufferTarget.ArrayBuffer, 2);
            //GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(Vector3.SizeInBytes * vertices.Length), vertices, BufferUsageHint.DynamicDraw);
            //GL.EnableClientState(ArrayCap.VertexArray);
            //GL.VertexPointer(2, VertexPointerType.Double, Vector3.SizeInBytes, 0);
            //GL.TexCoord2(0.5, 0.5);
            //GL.Color3(Color.Black);

            //GL.DrawArrays(BeginMode.Quads, 0, 24);

            GL.Color3(0.0f, 1.0f, 0.0f);          // Set The Color To Green
            GL.Vertex3(1.0f, 1.0f, -1.0f);          // Top Right Of The Quad (Top)
            GL.Vertex3(-1.0f, 1.0f, -1.0f);          // Top Left Of The Quad (Top)
            GL.Vertex3(-1.0f, 1.0f, 1.0f);          // Bottom Left Of The Quad (Top)
            GL.Vertex3(1.0f, 1.0f, 1.0f);

            GL.Color3(1.0f, 0.5f, 0.0f);          // Set The Color To Orange
            GL.Vertex3(1.0f, -1.0f, 1.0f);          // Top Right Of The Quad (Bottom)
            GL.Vertex3(-1.0f, -1.0f, 1.0f);          // Top Left Of The Quad (Bottom)
            GL.Vertex3(-1.0f, -1.0f, -1.0f);          // Bottom Left Of The Quad (Bottom)
            GL.Vertex3(1.0f, -1.0f, -1.0f);          // Bottom Right Of The Quad (Bottom)

            GL.Color3(1.0f, 0.0f, 0.0f);          // Set The Color To Red
            GL.Vertex3(1.0f, 1.0f, 1.0f);          // Top Right Of The Quad (Front)
            GL.Vertex3(-1.0f, 1.0f, 1.0f);          // Top Left Of The Quad (Front)
            GL.Vertex3(-1.0f, -1.0f, 1.0f);          // Bottom Left Of The Quad (Front)
            GL.Vertex3(1.0f, -1.0f, 1.0f);          // Bottom Right Of The Quad (Front)

            GL.Color3(1.0f, 1.0f, 0.0f);          // Set The Color To Yellow
            GL.Vertex3(1.0f, -1.0f, -1.0f);          // Bottom Left Of The Quad (Back)
            GL.Vertex3(-1.0f, -1.0f, -1.0f);          // Bottom Right Of The Quad (Back)
            GL.Vertex3(-1.0f, 1.0f, -1.0f);          // Top Right Of The Quad (Back)
            GL.Vertex3(1.0f, 1.0f, -1.0f);          // Top Left Of The Quad (Back)

            GL.Color3(0.0f, 0.0f, 1.0f);          // Set The Color To Blue
            GL.Vertex3(-1.0f, 1.0f, 1.0f);          // Top Right Of The Quad (Left)
            GL.Vertex3(-1.0f, 1.0f, -1.0f);          // Top Left Of The Quad (Left)
            GL.Vertex3(-1.0f, -1.0f, -1.0f);          // Bottom Left Of The Quad (Left)
            GL.Vertex3(-1.0f, -1.0f, 1.0f);          // Bottom Right Of The Quad (Left)

            GL.Color3(1.0f, 0.0f, 1.0f);          // Set The Color To Violet
            GL.Vertex3(1.0f, 1.0f, -1.0f);          // Top Right Of The Quad (Right)
            GL.Vertex3(1.0f, 1.0f, 1.0f);          // Top Left Of The Quad (Right)
            GL.Vertex3(1.0f, -1.0f, 1.0f);          // Bottom Left Of The Quad (Right)
            GL.Vertex3(1.0f, -1.0f, -1.0f);          // Bottom Right Of The Quad (Right)
            GL.End();                        // Done Drawing The Quad

            rtri += 0.2f;                     // Increase The Rotation Variable For The Triangle
            rquad -= 0.15f;                       // Decrease The Rotation Variable For The Quad
                                  // Keep Going

            glControl1.SwapBuffers();
        }

        private void glControl1_MouseClick(object sender, MouseEventArgs e)
        {
            glControl1.SwapBuffers();
            glControl1.Invalidate();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.Wheat);
            SetupViewport();
        }
    }
}
