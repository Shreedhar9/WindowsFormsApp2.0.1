using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GLint = System.Int32;
using GLfloat = System.Single;
using GLdouble = System.Double;
namespace WindowsFormsApp2._0._1
{
    public partial class Form4 : Form
    {
        static GLint[] vertices = {25, 25,
                                    100, 325,
                                    175, 25,
                                    175, 325,
                                    250, 25,
                                    325, 325};
        static GLdouble[] colors = {1.0, 0.2, 0.2,
                                    0.2, 0.2, 1.0,
                                    0.8, 1.0, 0.2,
                                    0.75, 0.75, 0.75,
                                    0.35, 0.35, 0.35,
                                    0.5, 0.5, 0.5};

        static GLdouble[] intertwined =
                                    {1.0, 0.2, 1.0, 100.0, 100.0, 0.0,
                                    1.0, 0.2, 0.2, 0.0, 200.0, 0.0,
                                    1.0, 1.0, 0.2, 100.0, 300.0, 0.0,
                                    0.2, 1.0, 0.2, 200.0, 300.0, 0.0,
                                    0.2, 1.0, 1.0, 300.0, 200.0, 0.0,
                                    0.2, 0.2, 1.0, 200.0, 100.0, 0.0};

         
        public Form4()
        {
            InitializeComponent();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.Enable(EnableCap.ColorArray);
            GL.Enable(EnableCap.VertexArray);

           // GL.ColorPointer(3, (float)GLfloat, 0, colors);

        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            // Clear The Screen And The Depth Buffer
            GL.LoadIdentity();
            GL.Begin(BeginMode.Quads);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 2);
            //GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(Vector3.SizeInBytes * vertices.Length), vertices, BufferUsageHint.DynamicDraw);
            GL.EnableClientState(ArrayCap.VertexArray);
            GL.VertexPointer(2, VertexPointerType.Double, Vector3.SizeInBytes, 0);
            GL.TexCoord2(0.5, 0.5);
            GL.Color3(Color.Black);

            GL.DrawArrays(BeginMode.Quads, 0, 24);
            GL.End();

            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthClamp);//imp line

            GL.PopMatrix();
            glControl1.SwapBuffers();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
