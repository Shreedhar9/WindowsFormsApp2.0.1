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
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
