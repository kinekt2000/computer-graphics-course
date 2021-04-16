using OpenTK;
using System;
using System.Collections.Generic;

namespace BSpline
{

    using Point = Vector2;

    /// <summary>
    /// Class <c>BSplint</c> models a B-Spline curve
    /// using set of points, order (degree in some literature) of Basis function
    /// and sampling of output curve
    ///     <example> Example of use:
    ///         @code
    ///             // 0.1 - sampling (frequency of points on one line polygon)
    ///             // 4 - degree (control points for one polygon)
    ///             var spline = new BSpline(0.1, 4)
    /// 
    ///             Vector2[] controlPoints = new Vector2[] {
    ///                 new Vector2(10, 20),
    ///                 new Vector2(15, 50),
    ///                 new Vector2(30, 10),
    ///                 new Vector2(40, 40),
    ///                 new Vector2(45, 15),
    ///                 new Vector2(55, 100),
    ///                 new Vector2(70, 50)
    ///             }
    ///             spline.AddPoints(controlPoints) // add control points to B-Spline curve
    /// 
    ///             List<Vector2>; curve = spline.Curve() // get curve as list of points;
    ///         @endcode
    ///     </example>
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Sampling interval is (0, 1). Not including borders.
    ///     </para>
    ///     
    ///     <para>
    ///         Order of curve interval is [2, n + 1], where n - number of control points. Including borders
    ///     </para>
    ///     
    ///     <para>
    ///         Can throw <c>ArgumentException</c> on <c>Sampling</c> and <c>Order</c> set
    ///     </para>
    ///     
    ///     <para>
    ///         Curve property will be empty if <c>Order</c> is too big
    ///     </para>
    /// </remarks>
    /// <see href="https://en.wikipedia.org/wiki/B-spline"/>
    class BSpline
    {
        private List<float> weights = new List<float> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };


        /// <summary>
        /// Instance variable <c>sampling</c> represents sampling of one polygon of curve
        /// </summary>
        private float sampling;

        /// <summary>
        /// Instance variable <c>order</c> represents number of control points for one curve polygon
        /// </summary>
        private int order;

        /// <summary>
        /// Instance variable <c>_controlPoints</c> represents list of control points of curve
        /// </summary>
        private readonly List<Point> _controlPoints = new List<Point>();

        /// <summary>
        /// Instance variable <c>knots</c> represents array of knots (breakpoints in some literature) of curve
        /// </summary>
        public float[] knots = new float[0];

        /// <summary>
        /// Instance variable <c>_curve</c> represents list of resulting curve segments
        /// </summary>
        private List<List<Point>> segments = new List<List<Point>>();

        /// <value>Property <c>Sampling</c> represents sampling of one polygon of curve</value>
        /// <exception cref="ArgumentException">Thrown if <c>Sampling</c> goes out of range 0 &lt; <c>Sampling</c> &lt; 1 </exception>
        public float Sampling
        {
            get => sampling;
            set
            {
                if (value <= 0) throw new ArgumentException(String.Format("{0} is less or equal zero", value), "Sampling");
                if (value >= 1) throw new ArgumentException(String.Format("{0} is more or queal one", value), "Sampling");
                sampling = value;
            }
        }

        /// <value>Property <c>Order</c> represents number of control points for one curve polygon</value>
        /// <exception cref="ArgumentException">Thrown if <c>Order</c> &lt; 2</exception>
        public int Order
        { 
            get => order;
            set
            {
                if (value < 2) throw new ArgumentException(String.Format("{0} is less than two", value), "Order");
                order = value;
                BuildCurve();
            } 
        }


        /// <value>Property <c>ControlPoints</c> represents read-only list of control points </value>
        public IReadOnlyList<Point> ControlPoints => _controlPoints.AsReadOnly();


        /// <value>Property <c> Count</c> represents amount of curve segment</value>
        public int Count => segments.Count;


        /// <summary>
        /// Method <c>GetSegment</c> gives access to read-only concrete resulting curve segment
        /// </summary>
        /// <param name="index">Index of segment</param>
        /// <returns>Curve segment represented as list of points</returns>
        public IReadOnlyList<Point> GetSegment(int index)
        {
            return segments[index].AsReadOnly();
        }


        /// <summary>
        /// Operator <c>Spline[index]</c> gives access to read-only concrete resulting curve segment
        /// </summary>
        /// <param name="index">Index of segment</param>
        /// <returns>Curve segment represented as list of points</returns>
        public IReadOnlyList<Point> this[int index]
        {
            get => GetSegment(index);
        }


        /// <summary>
        /// Creates BSpline object with the given <c>Sampling</c> and <c>Order</c>
        /// </summary>
        /// <param name="sampling">Represents sampling of one polygon of curve</param>
        /// <param name="order">Represents number of control points for one curve polygon</param>
        /// <exception cref="ArgumentException">Thrown if <c>Sampling</c> goes out of range 0 &lt; <c>Sampling</c> &lt; 1 </exception>
        /// <exception cref="ArgumentException">Thrown if <c>Order</c> &lt; 2</exception>
        public BSpline(float sampling, int order)
        {
            this.Sampling = sampling;
            this.Order = order;
        }

        /// <summary>
        /// Add control point to curve
        /// </summary>
        /// <param name="point">Two-dimensional point (Vector2 alies)</param>
        /// <seealso cref="AddPoint(float, float)"/>
        /// <seealso cref="AddPoints(List{Point})"/>
        /// <seealso cref="AddPoints(Point[])"/>
        /// <seealso cref="AddPoints(Tuple{float, float}[])"/>
        public void AddPoint(Point point)
        {
            _controlPoints.Add(point);
            BuildCurve();
        }

        /// <summary>
        /// Add control point to curve
        /// </summary>
        /// <param name="x">Represents the point's x-coordinate</param>
        /// <param name="y">Represents the point's y-coordinate</param>
        /// <seealso cref="AddPoint(Point)"/>
        /// <seealso cref="AddPoints(List{Point})"/>
        /// <seealso cref="AddPoints(Point[])"/>
        /// <seealso cref="AddPoints(Tuple{float, float}[])"/>
        public void AddPoint(float x, float y)
        {
            this.AddPoint(new Point(x, y));
        }

        /// <summary>
        /// Add control points to curve
        /// </summary>
        /// <param name="points">Array of two-dimensional points (Vector2 alies)</param>
        /// <seealso cref="AddPoint(Point)"/>
        /// <seealso cref="AddPoint(float, float)"/>
        /// <seealso cref="AddPoints(List{Point})"/>
        /// <seealso cref="AddPoints(Tuple{float, float}[])"/>
        public void AddPoints(Point[] points)
        {
            foreach(var point in points)
            {
                _controlPoints.Add(point);
            }

            BuildCurve();
        }

        /// <summary>
        /// Add control points to curve
        /// </summary>
        /// <param name="points">List of two-dimensional points (Vector2 alies)</param>
        /// <seealso cref="AddPoint(Point)"/>
        /// <seealso cref="AddPoint(float, float)"/>
        /// <seealso cref="AddPoints(Point[])"/>
        /// <seealso cref="AddPoints(Tuple{float, float}[])"/>
        public void AddPoints(List<Point> points)
        {
            AddPoints(points.ToArray());
        }

        /// <summary>
        /// Add control points to curve
        /// </summary>
        /// <param name="points">Array of 2-dimensional float tuples,
        /// where first item is x-coordinate and second item is y-coordinate
        /// </param>
        /// <seealso cref="AddPoint(Point)"/>
        /// <seealso cref="AddPoint(float, float)"/>
        /// <seealso cref="AddPoints(Point[])"/>
        /// <seealso cref="AddPoints(List{Point})"/>
        public void AddPoints(Tuple<float, float>[] points)
        {
            foreach(var point in points)
            {
                _controlPoints.Add(new Point(point.Item1, point.Item2));
            }

            BuildCurve();
        }

        /// <summary>
        /// Removes point with <c>index</c>. All next points shift to zero.
        /// </summary>
        /// <param name="index">Index of point to remove</param>
        public void RemovePoint(int index)
        {
            _controlPoints.RemoveAt(index);

            BuildCurve();
        }

        /// <summary>
        /// Sets new value of point with <c>index</c>
        /// </summary>
        /// <param name="index">Index of point being modified</param>
        /// <param name="point">New value of point</param>
        public void ChangePoint(int index, Point point)
        {
            _controlPoints[index] = point;

            CorrectCurve(index);
            //BuildCurve();
        }


        /// <summary>
        /// Sets new value of point with <c>index</c>
        /// </summary>
        /// <param name="index">Index of point being modified</param>
        /// <param name="x">X-coordinate of new value of point</param>
        /// <param name="y">Y-coordinate of new value of point</param>
        public void ChangePoint(int index, float x, float y)
        {
            ChangePoint(index, new Point(x, y));
        }


        /// <summary>
        /// <para>Contrsuct knots array by next rules:</para>
        /// <para>Size of  knots array: n + order + 1</para>
        /// <para> / 0, &#09; &#09; i &lt; k</para>
        /// <para>&lt; i - k + 1, &#09; &#09; i ≤ n</para>
        /// <para> \ n - k + 2, &#09; &#09; otherwise</para>
        /// <para>
        /// $$
        /// x=\begin{cases}
        /// 0, & \mbox{if }
        /// i \lt order \\
        /// i-k+1, & \mbox{if } i \le n \\
        /// n-k+2, & \mbox{otherwise}
        /// \end{cases}
        /// $$
        /// </para>
        /// <para>Where <c>c = order</c> and <c>n = number of control points - 1</c></para>
        /// </summary>
        private void RecalculateKnotVector()
        {
            //            / 0,          i < order
            // knot[i] = <  i - k + 1,  i ≤ n
            //            \ n - k + 2,  otherwise
            // where n = Number of control points - 1

            int pointCount = _controlPoints.Count - 1;
            int knotCount = pointCount + order + 1;

            knots = new float[knotCount];

            for (int i = 0; i < knotCount; i++)
            {
                if (i < order)
                {
                    knots[i] = 0f;
                }
                else if (i <= pointCount)
                {
                    knots[i] = i - order + 1;
                }
                else
                {
                    knots[i] = pointCount - order + 2;
                }
            }
        }

        
        /// <summary>
        /// Terminate function of de-Boor algorithm
        /// </summary>
        /// <param name="i">Current control point</param>
        /// <param name="t">Current curve position</param>
        /// <returns>Value of basis function</returns>
        private float BasisLinear(int i, float t)
        {
            if(t >= knots[i] && t < knots[i+1])
            {
                return 1f;
            }
            return 0f;
        }


        /// <summary>
        /// Division for de-Boor algorithm, indeterminate of type 0/0 is taken as 0.
        /// In other cases, usual division is used
        /// </summary>
        /// <param name="a">Divident</param>
        /// <param name="b">Divider</param>
        /// <returns>Division result</returns>
        private float Div(float a, float b)
        {
            if (b == 0) {
                return 0;
            }
            return a / b;
        }


        /// <summary>
        /// De-Boor algrithm recursive function
        /// </summary>
        /// <param name="i">Current control point</param>
        /// <param name="k">Order of basis function</param>
        /// <param name="t">Current curve position</param>
        /// <returns>Value of basis function</returns>
        private float Basis(int i, int k, float t)
        {
            if(k <= 1)
            {
                return BasisLinear(i, t);
            }

            var KV = knots;

            float a = Div(
                t - KV[i],
                KV[i + k - 1] - KV[i]
            ) * Basis(i, k - 1, t);

            float b = Div(
                KV[i + k] - t,
                KV[i + k] - KV[i + 1]
            ) * Basis(i + 1, k - 1, t);

            return a + b;
        }


        /// <summary>
        /// Function finds two-dimensional point by curve position
        /// </summary>
        /// <param name="t">Current curve position</param>
        /// <returns>Two-dimensional point of curve</returns>
        /// <remarks>Optimized. All calculation are performed strictly within the influence control points.</remarks>
        private Point BSplineFunction(float t)
        {
            float x = 0;
            float y = 0;

            int firstPointIndex = (int)Math.Floor(t);
            int lastPointIndex = firstPointIndex + order;

            float delimeter = 0;

            for(int i = firstPointIndex; i < lastPointIndex; i++)
            {
                float N = Basis(i, Order, t);
                x += weights[i] * N * _controlPoints[i].X;
                y += weights[i] * N * _controlPoints[i].Y;

                delimeter += weights[i] * N;
            }

            return new Point(x/delimeter, y/delimeter);
        }


        /// <summary>
        /// Builds segment of curve
        /// </summary>
        /// <param name="index">Index of segment</param>
        /// <returns>List of points representing curve segment</returns>
        private List<Point> BuildSegment(int index)
        {
            var segment = new List<Point>();

            for(float t = 0; t < 1 - sampling; t += sampling)
            {
                var point = BSplineFunction(index + t);
                segment.Add(point);
            }

            return segment;
        }


        /// <summary>
        /// Builds discrete curve via all instance parameters
        /// </summary>
        private void BuildCurve()
        {
            var segments = new List<List<Point>>();

            if(Order <= _controlPoints.Count)
            {
                if(_controlPoints.Count + order != knots.Length)
                {
                    RecalculateKnotVector();
                }

                for (int i = 0; i < _controlPoints.Count - order + 1; i++)
                {
                    var segment = BuildSegment(i);
                    segments.Add(segment);
                }
            }

            this.segments = segments;
        }

        /// <summary>
        /// Changes segments near point
        /// </summary>
        /// <param name="point_index">Index of point around which the segments need to be recalculated</param>
        private void CorrectCurve(int point_index)
        {
            int firstKnot = (int) knots[point_index];

            int indexLastKnot = point_index + order + 1;
            int lastKnot = (int) ((indexLastKnot >= knots.Length) ? knots[indexLastKnot - 1] : knots[indexLastKnot]);

            for(int i = firstKnot; i < lastKnot; i++)
            {
                var segment = BuildSegment(i);
                segments[i] = segment;
            }
        }

    }

}
