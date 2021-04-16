using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace BSpline
{
    public partial class MainForm : Form
    {
        private float _pointRadius = 15;

        private Color[] colors = new Color[]
        {
            Color.FromArgb(0xFF, 0xFF, 0x00, 0x00),
            Color.FromArgb(0xFF, 0x00, 0xFF, 0x00),
            Color.FromArgb(0xFF, 0x00, 0x00, 0xFF),
            Color.FromArgb(0xFF, 0x00, 0xFF, 0xFF),
            Color.FromArgb(0xFF, 0xFF, 0xFF, 0x00),
            Color.FromArgb(0xFF, 0xFF, 0x00, 0xFF),
        };

        private System.Timers.Timer _timer;

        private BSpline spline = new BSpline(0.01f, 4);

        private int indexOfSelctedPoint = -1;

        public MainForm()
        {
            InitializeComponent();

            this._timer = new System.Timers.Timer(10.0);
            this._timer.Elapsed += TimerElapsed;
            this._timer.Start();

            orderWarningLabel.Text = String.Format("Number of points must be greater than {0}", spline.Order - 1);
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            UpdateModel();
            glControl.Invalidate();
        }

        private void UpdateModel()
        {
            // unused
        }

        private void glControl_Load(object sender, EventArgs e)
        {
            glControl.MakeCurrent();

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        }

        private void glControl_Paint(object sender, PaintEventArgs ev)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Connect control points
            GL.Enable(EnableCap.LineSmooth);
            GL.LineWidth(2);
            GL.Color4(Color.FromArgb(0x88, 0x88, 0x88, 0x88));
            GL.Begin(PrimitiveType.LineStrip);
            foreach(var point in spline.ControlPoints)
            {
                GL.Vertex2(point);
            }
            GL.End();
            //

            // Draw control points
            // point outer
            GL.Enable(EnableCap.PointSmooth);
            GL.PointSize(_pointRadius);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(Color.Blue);
            for(int index = 0; index < spline.ControlPoints.Count; index++)
            {
                var point = spline.ControlPoints[index];
                // highlight selected point
                if(index == indexOfSelctedPoint)
                {
                    GL.Color3(Color.Green);
                    GL.Vertex2(point);
                    GL.Color3(Color.Blue);
                }
                else
                {
                    GL.Vertex2(point);
                }
            }
            GL.End();

            // point inner
            GL.PointSize(_pointRadius * 0.65f);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(Color.White);
            foreach (var point in spline.ControlPoints)
            {
                GL.Vertex2(point);
            }
            GL.End();
            //

            // Draw curve
            GL.Begin(PrimitiveType.LineStrip);
            for(int i = 0; i < spline.Count; i++)
            {
                GL.Color3(colors[i % colors.Length]);
                foreach (var point in spline[i])
                {
                    GL.Vertex2(point);
                }
            }
            GL.End();
            //


            glControl.SwapBuffers();
        }

        private void glControl_Resize(object sender, EventArgs e)
        {
            int w = glControl.Width;
            int h = glControl.Height;

            GL.Viewport(0, 0, w, h);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1.0, 1.0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.ClearColor(Color.Black);
        }

        private void glControl_MouseMove(object sender, MouseEventArgs e)
        {
            float x = (float)e.X;
            float y = glControl.Height - (float)e.Y - 1;

            mousePositionLabel.Text = String.Format("({0}; {1})", x, y);


            if(e.Button == MouseButtons.Left && indexOfSelctedPoint != -1)
            {
                spline.ChangePoint(indexOfSelctedPoint, x, y);
                statusLabel.Text = String.Format("Moving point with index {0}", indexOfSelctedPoint);
                return;
            }


            for(int index = 0; index < spline.ControlPoints.Count; index++)
            {
                var point = spline.ControlPoints[index];
                if((x - point.X)*(x - point.X) + (y - point.Y)*(y - point.Y) <= _pointRadius * _pointRadius * 0.49f)
                {
                    indexOfSelctedPoint = index;
                    statusLabel.Text = String.Format("Selected point width index {0}", index);
                    return;
                }
            }

            indexOfSelctedPoint = -1;
            statusLabel.Text = "Left click - create point; Right click - delete point";
        }

        private void glControl_MouseClick(object sender, MouseEventArgs e)
        {
            float x = (float)e.X;
            float y = glControl.Height - (float)e.Y - 1;

            if(e.Button == MouseButtons.Left && indexOfSelctedPoint == -1)
            {
                spline.AddPoint(x, y);
            } else if (e.Button == MouseButtons.Right && indexOfSelctedPoint != -1)
            {
                spline.RemovePoint(indexOfSelctedPoint);
            }

            if(spline.Count == 0)
            {
                orderWarningLabel.Visible = true;
            } else
            {
                orderWarningLabel.Visible = false;
            }
        }
    }
}
