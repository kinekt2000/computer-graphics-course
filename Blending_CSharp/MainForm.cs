using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace Blending
{

    using Alpha = AlphaFunction;
    using blendFactor = BlendingFactor;

    public partial class MainForm : Form
    {
        public class Point
        {
            private Vector2 _pos;
            private Color _color;

            public Color Color { get => _color; set => _color = value; }
            public float X { get => _pos.X; set => _pos.X = value; }
            public float Y { get => _pos.Y; set => _pos.Y = value; }

            public Point(float x, float y, Color color)
            {
                _pos = new Vector2(x, y);
                _color = color;
            }
        }

        public enum Type
        {
            GL_POINTS,
            GL_LINES,
            GL_LINE_STRIP,
            GL_LINE_LOOP,
            GL_TRIANGLES,
            GL_TRIANGLE_STRIP,
            GL_TRIANGLE_FAN,
            GL_QUADS,
            GL_QUAD_STRIP,
            GL_POLYGON
        }



        private System.Timers.Timer _timer;
        List<Point> points = new List<Point>();

        private Type type = Type.GL_LINES; // Choose any one instead POINTS, because app initiates with POINTS itself later

        private int pointSize = 1;
        private int lineStroke = 1;
        private Color color = Color.White;

        private Rectangle scissors = new Rectangle(0, 0, 10, 10);

        private Alpha _alphaProperty = Alpha.Never;
        private float _alpha = 0;
        private blendFactor _sfactor = blendFactor.Zero;
        private blendFactor _dfactor = blendFactor.Zero;


        public MainForm()
        {
            InitializeComponent();

            this._timer = new System.Timers.Timer(10.0);
            this._timer.Elapsed += TimerElapsed;
            this._timer.Start();


            scissorX.ValueChanged += (sender, e) =>
            {
                this.scissors.X = (int) ((float) scissorX.Value / (float) scissorX.Maximum * glControl.Width);
            };

            scissorY.ValueChanged += (sender, e) =>
            {
                this.scissors.Y = (int) ((float) scissorY.Value / (float) scissorY.Maximum * glControl.Height);
            };

            scissorW.ValueChanged += (sender, e) =>
            {
                this.scissors.Width = (int) ((float) scissorW.Value / (float) scissorW.Maximum * glControl.Width);
            };

            scissorH.ValueChanged += (sender, e) =>
            {
                this.scissors.Height = (int) ((float) scissorH.Value / (float) scissorH.Maximum * glControl.Height);
            };

            alphaProperty.SelectedValueChanged += (sender, e) =>
            {
                _alphaProperty = (Alpha)System.Enum.Parse(typeof(Alpha), alphaProperty.Text, true);
            };

            alpha.ValueChanged += (sender, e) =>
            {
                _alpha = (float) alpha.Value / (float) alpha.Maximum;
            };

            sfactor.SelectedValueChanged += (sender, e) =>
            {
                _sfactor = (blendFactor)System.Enum.Parse(typeof(blendFactor), sfactor.Text, true);
            };

            dfactor.SelectedValueChanged += (sender, e) =>
            {
                _dfactor = (blendFactor)System.Enum.Parse(typeof(blendFactor), dfactor.Text, true);
            };
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            UpdateModel();
            glControl.Invalidate();
        }

        private void UpdateModel()
        {
            // nothing there
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {

            scissors.Width = scissorW.Value / 10 * glControl.Width;
            scissors.Height = scissorH.Value / 10 * glControl.Height;

            glControl.MakeCurrent();
            primitiveType.DataSource = System.Enum.GetValues(typeof(Type));
            primitiveType.Text = System.Enum.GetName(typeof(Type), type);

            alphaProperty.DataSource = System.Enum.GetValues(typeof(Alpha));
            sfactor.DataSource = System.Enum.GetValues(typeof(blendFactor));
            dfactor.DataSource = System.Enum.GetValues(typeof(blendFactor));
        }

        private void glControl_Load(object sender, System.EventArgs e)
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

        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Enable(EnableCap.ScissorTest);
            GL.Scissor(scissors.X, scissors.Y, scissors.Width, scissors.Height);
            
            GL.Enable(EnableCap.AlphaTest);
            GL.AlphaFunc(_alphaProperty, _alpha);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(_sfactor, _dfactor);

            switch (type)
            {
                case Type.GL_POINTS:
                    DrawPoints();
                    break;
                case Type.GL_LINES:
                    DrawLines();
                    break;
                case Type.GL_LINE_STRIP:
                    DrawLineStrip();
                    break;
                case Type.GL_LINE_LOOP:
                    DrawLineLoop();
                    break;
                case Type.GL_TRIANGLES:
                    DrawTriangles();
                    break;
                case Type.GL_TRIANGLE_STRIP:
                    DrawTriangleStrip();
                    break;
                case Type.GL_TRIANGLE_FAN:
                    DrawTriangleFan();
                    break;
                case Type.GL_QUADS:
                    DrawQuads();
                    break;
                case Type.GL_QUAD_STRIP:
                    DrawQuadStrip();
                    break;
                case Type.GL_POLYGON:
                    DrawPolygon();
                    break;
            }

            GL.Disable(EnableCap.ScissorTest);
            GL.Disable(EnableCap.AlphaTest);
            GL.Disable(EnableCap.Blend);

            glControl.SwapBuffers();
        }


        private void DrawPoints()
        {
            GL.PointSize(1);

            GL.PointSize(pointSize);
            GL.Begin(PrimitiveType.Points);

            foreach (var point in points)
            {
                GL.Color4(point.Color);
                GL.Vertex2(point.X, point.Y);
            }

            GL.End();
        }

        private void DrawLines()
        {
            GL.LineWidth(lineStroke);
            GL.Begin(PrimitiveType.Lines);

            foreach (var point in points)
            {
                GL.Color4(point.Color);
                GL.Vertex2(point.X, point.Y);
            }

            GL.End();
        }


        private void DrawLineStrip()
        {
            GL.LineWidth(lineStroke);
            GL.Begin(PrimitiveType.LineStrip);

            foreach (var point in points)
            {
                GL.Color4(point.Color);
                GL.Vertex2(point.X, point.Y);
            }

            GL.End();
        }


        private void DrawLineLoop()
        {
            GL.LineWidth(lineStroke);
            GL.Begin(PrimitiveType.LineLoop);

            foreach (var point in points)
            {
                GL.Color4(point.Color);
                GL.Vertex2(point.X, point.Y);
            }

            GL.End();
        }

        private void DrawTriangles()
        {
            GL.Begin(PrimitiveType.Triangles);

            foreach (var point in points)
            {
                GL.Color4(point.Color);
                GL.Vertex2(point.X, point.Y);
            }

            GL.End();
        }

        private void DrawTriangleStrip()
        {
            GL.Begin(PrimitiveType.TriangleStrip);

            foreach (var point in points)
            {
                GL.Color4(point.Color);
                GL.Vertex2(point.X, point.Y);
            }

            GL.End();
        }


        private void DrawTriangleFan()
        {
            GL.Begin(PrimitiveType.TriangleFan);

            foreach (var point in points)
            {
                GL.Color4(point.Color);
                GL.Vertex2(point.X, point.Y);
            }

            GL.End();
        }


        private void DrawQuads()
        {
            GL.Begin(PrimitiveType.Quads);

            foreach (var point in points)
            {
                GL.Color4(point.Color);
                GL.Vertex2(point.X, point.Y);
            }

            GL.End();
        }


        private void DrawQuadStrip()
        {
            GL.Begin(PrimitiveType.QuadStrip);

            foreach (var point in points)
            {
                GL.Color4(point.Color);
                GL.Vertex2(point.X, point.Y);
            }

            GL.End();
        }


        private void DrawPolygon()
        {
            GL.Begin(PrimitiveType.Polygon);

            foreach (var point in points)
            {
                GL.Color4(point.Color);
                GL.Vertex2(point.X, point.Y);
            }

            GL.End();
        }

        private void glControl_MouseDown(object sender, MouseEventArgs e)
        {
            int translatedX = e.X;
            int translatedY = glControl.Height - 1 - e.Y;

            points.Add(new Point(translatedX, translatedY, color));


            System.Console.WriteLine(this.color);
            // System.Console.WriteLine("scissors x:{0} y:{1} w:{2} h:{3}", scissors.X, scissors.Y, scissors.Width, scissors.Height);
            // System.Console.WriteLine("aprop: {0}, alpha: {1}", _alphaProperty, _alpha);
            // System.Console.WriteLine("sfactor: {0}; dfactor: {1}", _sfactor, _dfactor);
        }

        private void primitiveType_SelectedValueChanged(object sender, System.EventArgs e)
        {
            var newType = (Type) System.Enum.Parse(typeof(Type), primitiveType.Text, true);
            if(type == newType)
            {
                return;
            }
            type = newType;

            points.Clear();

            CleanTools();

            switch (type)
            {
                case Type.GL_POINTS:
                    AddPointSize();
                    AddColor();
                    break;

                case Type.GL_LINES:
                    AddLineStroke();
                    AddColor();
                    break;

                case Type.GL_LINE_STRIP:
                    AddLineStroke();
                    AddColor();
                    break;

                case Type.GL_LINE_LOOP:
                    AddLineStroke();
                    AddColor();
                    break;

                case Type.GL_TRIANGLES:
                    AddColor();
                    break;

                case Type.GL_TRIANGLE_STRIP:
                    AddColor();
                    break;

                case Type.GL_TRIANGLE_FAN:
                    AddColor();
                    break;

                case Type.GL_QUADS:
                    AddColor();
                    break;
                case Type.GL_QUAD_STRIP:
                    AddColor();
                    
                    break;
                case Type.GL_POLYGON:
                    AddColor();
                    break;
            }

            // System.Console.WriteLine("point size: {0}", this.pointSize);
            // System.Console.WriteLine("line stroke: {0}", this.lineStroke);
            // System.Console.WriteLine("color: {0} {1} {2}", this.color.R, this.color.G, this.color.B);
            // System.Console.WriteLine("rows: {0}", SettingsLayout.RowCount);
        }


        private void CleanTools()
        {
            pointSize = 1;
            lineStroke = 1;
            color = Color.White;

            while(SettingsLayout.RowCount > 3)
            {
                RemoveRow(2);
            }
        }


        private void RemoveRow(int index)
        {
            if (index >= SettingsLayout.RowCount)
            {
                return;
            }

            // delete all controls of row that we want to delete
            for (int i = 0; i < SettingsLayout.ColumnCount; i++)
            {
                var control = SettingsLayout.GetControlFromPosition(i, index);
                SettingsLayout.Controls.Remove(control);
            }

            // move up row controls that comes after row we want to remove
            for (int i = index + 1; i < SettingsLayout.RowCount; i++)
            {
                for (int j = 0; j < SettingsLayout.ColumnCount; j++)
                {
                    var control = SettingsLayout.GetControlFromPosition(j, i);
                    if (control != null)
                    {
                        SettingsLayout.SetRow(control, i - 1);
                    }
                }
            }

            var removeStyle = SettingsLayout.RowCount - 1;

            if (SettingsLayout.RowStyles.Count > removeStyle)
                SettingsLayout.RowStyles.RemoveAt(removeStyle);

            SettingsLayout.RowCount--;
        }


        private void AddPointSize()
        {
            var pointSizeLabel = new Label
            {
                Text = "Point size",
                Font = new Font("Microsoft Sans Serif", 10.25f),
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Right
            };

            var pointSize = new NumericUpDown()
            {
                Minimum = 1,
                Value = 1
            };

            pointSize.ValueChanged += (sender, e) =>
            {
                this.pointSize = (int) pointSize.Value;
            };

            SettingsLayout.Controls.Add(pointSizeLabel, 0, SettingsLayout.RowCount - 1);
            SettingsLayout.Controls.Add(pointSize, 1, SettingsLayout.RowCount - 1);

            RowStyle temp = SettingsLayout.RowStyles[SettingsLayout.RowCount - 1];
            SettingsLayout.RowCount++;
            SettingsLayout.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));

        }

        private void AddLineStroke()
        {
            var lineStrokeLabel = new Label
            {
                Text = "line stroke",
                Font = new Font("Microsoft Sans Serif", 10.25f),
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Right
            };

            var lineStroke = new NumericUpDown()
            {
                Minimum = 1,
                Value = 1
            };

            lineStroke.ValueChanged += (sender, e) =>
            {
                this.lineStroke= (int)lineStroke.Value;
            };

            SettingsLayout.Controls.Add(lineStrokeLabel, 0, SettingsLayout.RowCount - 1);
            SettingsLayout.Controls.Add(lineStroke, 1, SettingsLayout.RowCount - 1);

            RowStyle temp = SettingsLayout.RowStyles[SettingsLayout.RowCount - 1];
            SettingsLayout.RowCount++;
            SettingsLayout.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
        }

        private void AddColor()
        {
            var colorSquareLabel = new Label
            {
                Text = "Color",
                Font = new Font("Microsoft Sans Serif", 10.25f),
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Right,
            };

            var colorSquare = new Button
            {
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
            };

            colorSquare.Click += (sender, e) =>
            {
                colorDialog.ShowDialog();
                colorSquare.BackColor = colorDialog.Color;
                this.color = colorDialog.Color;
            };

            var colorAlphaLabel = new Label
            {
                Text = "Alpha",
                Font = new Font("Microsoft Sans Serif", 10.25f),
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Right
            };

            var colorAlpha = new TrackBar
            {
                Width = 142,
                Minimum = 0,
                Maximum = 100,
                Value = 100,
                TickFrequency = 10
            };

            colorAlpha.ValueChanged += (sender, e) =>
            {
                byte alpha = (byte)((float)colorAlpha.Value / (float)colorAlpha.Maximum * 255);
                this.color = Color.FromArgb(alpha, this.color);
            };


            SettingsLayout.Controls.Add(colorSquareLabel, 0, SettingsLayout.RowCount - 1);
            SettingsLayout.Controls.Add(colorSquare, 1, SettingsLayout.RowCount - 1);

            RowStyle temp = SettingsLayout.RowStyles[SettingsLayout.RowCount - 1];
            SettingsLayout.RowCount++;
            SettingsLayout.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));

            SettingsLayout.Controls.Add(colorAlphaLabel, 0, SettingsLayout.RowCount - 1);
            SettingsLayout.Controls.Add(colorAlpha, 1, SettingsLayout.RowCount - 1);

            SettingsLayout.RowCount++;
            SettingsLayout.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
        }

        private void glControl_Resize(object sender, System.EventArgs e)
        {
            int w = glControl.Width;
            int h = glControl.Height;

            this.scissors.X = (int)((float)scissorX.Value / (float)scissorX.Maximum * w);
            this.scissors.Y = (int)((float)scissorY.Value / (float)scissorY.Maximum * h);
            this.scissors.Width = (int)((float)scissorW.Value / (float)scissorW.Maximum * w);
            this.scissors.Height = (int)((float)scissorH.Value / (float)scissorH.Maximum * h);

            GL.Viewport(0, 0, w, h);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1.0, 1.0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }
    }
}
