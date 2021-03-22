using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Lab4
{
    public partial class MainForm : Form
    {
        private List<ValueTuple<int, int, int, int>> generator = new List<ValueTuple<int, int, int, int>>
        {
            ( 1,  0, -1, -1),
            ( 1,  0, -1, -1),
            (-1,  1,  1,  1),
            (-1,  0, -1, -1),
            ( 1, -1, -1, -1),
            ( 0,  1,  1,  1),
            ( 1,  0, -1, -1),
        };

        private Vector2d start = new Vector2d(-1.2, 0);
        private Vector2d finish = new Vector2d(1.2, 0); 


        private List<Vector2d> line;


        System.Timers.Timer timer;

        public MainForm()
        {
            InitializeComponent();

            timer = new System.Timers.Timer(1000.0/60.0);
            timer.Elapsed += (sender, e) =>
            {
                glControl.Invalidate();
            };
            timer.Start();

            line = Fractal.TriangleGrid(generator, start, finish, 1);

            line = SmoothLine(line);
        }

        private List<Vector2d> SmoothLine(List<Vector2d> line)
        {
            var new_line = new List<Vector2d>();
            for(int i = 0; i < line.Count - 1; i++)
            {
                var segment = (line[i], line[i + 1]);

                var splitted = SplitLine(segment);
                if(i != 0)
                {
                    splitted.RemoveAt(0);
                }

                if(i != line.Count - 2)
                {
                    splitted.RemoveAt(splitted.Count-1);
                }

                new_line.AddRange(splitted);

            }
            return new_line;
        }


        private List<Vector2d> SplitLine(ValueTuple<Vector2d, Vector2d> line)
        {
            double diff_x = line.Item2.X - line.Item1.X;
            double diff_y = line.Item2.Y - line.Item1.Y;

            double diff_x_over_3 = diff_x / 3;
            double diff_y_over_3 = diff_y / 3;

            double start_x = line.Item1.X;
            double start_y = line.Item1.Y;

            var splitted = new List<Vector2d>();

            splitted.Add(line.Item1);
            splitted.Add(new Vector2d(start_x + diff_x_over_3, start_y + diff_y_over_3));
            splitted.Add(new Vector2d(start_x + diff_x_over_3 * 2, start_y + diff_y_over_3 * 2));
            splitted.Add(line.Item2);

            return splitted;
        }

        private void glControl_Load(object sender, EventArgs e)
        {
            glControl.MakeCurrent();

            GL.ClearColor(Color.White);

            GL.Enable(EnableCap.LineSmooth);
            GL.Enable(EnableCap.PointSmooth);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);


            GL.Color3(Color.Black);
            GL.LineWidth(1);

            GL.Begin(PrimitiveType.LineStrip);
            foreach(var point in line)
            {
                GL.Vertex2(point);
            }
            GL.End();


            //GL.Color3(Color.Red);

            //GL.PointSize(8);
            //GL.Begin(PrimitiveType.Points);
            //GL.Vertex2(start);
            //GL.Vertex2(finish);
            //GL.End();

            //GL.Begin(PrimitiveType.LineStrip);
            //GL.Vertex2(start);
            //GL.Vertex2(finish);
            //GL.End();

            glControl.SwapBuffers();
        }

        private void glControl_Resize(object sender, EventArgs e)
        {
            double aspect_ratio = (double)glControl.Width / (double)glControl.Height;

            GL.Viewport(0, 0, glControl.Width, glControl.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-aspect_ratio, aspect_ratio, -1, 1, -1, 1);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }

        private void genDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int generation = Convert.ToInt32(e.ClickedItem.Text);

            genDropDownButton.Text = String.Format("Generation: {0}", generation);

            line = Fractal.TriangleGrid(generator, start, finish, generation);

            line = SmoothLine(line);
        }
    }
}
