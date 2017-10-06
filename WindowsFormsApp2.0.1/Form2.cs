using System;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;

namespace WindowsFormsApp2._0._1
{
    
    public partial class Form2 : Form
    {
        int scale = 1, rotation = 0, x=0, y=0;
        bool loaded = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void gLControl_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.Black);
            SetupViewport();
            rotation = 20;
            
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthClamp);
            gLControl.Invalidate();
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
            GL.Translate(x, y, 0);
            GL.Rotate(rotation, 10, 10, 10);
            
            GL.Scale(scale, scale, scale);

            GL.Begin(BeginMode.Quads);
            
            DrawCube();
            GL.End();
            
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthClamp);//imp line

            GL.PopMatrix();
            gLControl.SwapBuffers();
        }

        private void DrawCube()
        {
           // GL.Color3(105 , 105 , 105);
            GL.Color3(Color.White);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(50, 0, 0);
            GL.Vertex3(50, 50, 0);
            GL.Vertex3(0, 50, 0);

            GL.Color3(Color.Red);
            GL.Vertex3(50, 0, 0);
            GL.Vertex3(50, 0, -50);
            GL.Vertex3(50, 50, -50);
            GL.Vertex3(50, 50, 0);

            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, -50);
            GL.Vertex3(50, 0, -50);
            GL.Vertex3(50, 0, 0);

            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, -50);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 50, 0);
            GL.Vertex3(0, 50, -50);

            GL.Color3(Color.HotPink);
            GL.Vertex3(0, 50, 0);
            GL.Vertex3(50, 50, 0);
            GL.Vertex3(50, 50, -50);
            GL.Vertex3(0, 50, -50);

            GL.Color3(Color.Blue);
            GL.Vertex3(50, 0, -50);
            GL.Vertex3(0, 0, -50);
            GL.Vertex3(0, 50, -50);
            GL.Vertex3(50, 50, -50);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.Black);
           // int x = 1, t = 10;
        }

        private void gLControl_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X;y = e.Y;
            gLControl.Invalidate();
        }

        private void gLControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Space)
            {
                rotation = rotation + 20;
                gLControl.Invalidate();
            }
        }

        private void gLControl_MouseDown(object sender, MouseEventArgs e)
        {
           rotation = rotation + 20;
           gLControl.Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (scale>gLControl.Width || scale > gLControl.Height)
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

