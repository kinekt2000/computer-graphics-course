using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{


    static class Fractal
    {
        private static List<ValueTuple<int, int, int, int>> generator;
        private static int root_family;
        private static double family_angle;

        private static double TriangleDirection(ValueTuple<int, int, int, int> segment)
        {
            int xd = segment.Item1; // x-direction
            int yd = segment.Item2; // y-direction

            if (xd == 1 && yd == 0)
            {
                return 0;
            }
            else if (xd == 0 && yd == 1)
            {
                return 60;
            }
            else if (xd == -1 && yd == 1)
            {
                return 120;
            }
            else if (xd == -1 && yd == 0)
            {
                return 180;
            }
            else if (xd == 0 && yd == -1)
            {
                return 240;
            }
            else if (xd == 1 && yd == -1)
            {
                return 300;
            }
            else
            {
                throw new ArgumentException(
                    String.Format("segment is ({0}, {1}). Accepted values - (1,0); (0,1); (-1,1); (-1,0); (0,-1); (1,-1)", xd, yd),
                    "segment"
                );
            }
        }


        private static List<ValueTuple<Vector2d, Vector2d>> BuildTriangleGridLine(Vector2d start, Vector2d finish, int flipX, int flipY)
        {
            if (flipX == -1)
            {
                var tmp = start;
                start = finish;
                finish = tmp;
                flipY *= -1;
            }


            double distance = Vector2d.Distance(start, finish);
            double a = distance / Math.Sqrt(root_family); // length of one segment

            double angle = Math.Atan2(finish.Y - start.Y, finish.X - start.X) - flipY * family_angle;

            double PI_over_180 = Math.PI / 180;

            var line = new List<ValueTuple<Vector2d, Vector2d>>();

            var prev = start;

            int i = 0;
            foreach(var segment in generator)
            {
                double segment_angle = flipY * TriangleDirection(segment);

                double x = prev.X + a * Math.Cos(segment_angle * PI_over_180 + angle);
                double y = prev.Y + a * Math.Sin(segment_angle * PI_over_180 + angle);

                var next = new Vector2d(x, y);

                line.Add((prev, next));

                prev = next;

                i++;
            }

            if (flipX == -1)
            {
                line.Reverse();
                line = line.ConvertAll(obj => (obj.Item2, obj.Item1));
            }

            return line;
        }

        public static List<Vector2d> TriangleGrid(List<ValueTuple<int, int, int, int>> generator, Vector2d start, Vector2d finish, int generation)
        {
            // set generator
            Fractal.generator = generator;

            // calculate family
            double x = 0;
            double y = 0;

            double PI_over_180 = Math.PI / 180;

            foreach (var segment in generator)
            {
                double a = TriangleDirection(segment);

                x += Math.Cos(a * PI_over_180);
                y += Math.Sin(a * PI_over_180);
            }

            root_family = (int)Math.Round(x * x + y * y);

            // calculate family angle
            Fractal.family_angle = Math.Atan2(y, x);

            // build fractal

            var line = BuildTriangleGridLine(start, finish, 1, 1);
            while(generation > 1)
            {
                var new_line = new List<ValueTuple<Vector2d, Vector2d>>();
                for(int i = 0; i < line.Count; i++)
                {
                    int segment = i % generator.Count();
                    var subline = BuildTriangleGridLine(line[i].Item1, line[i].Item2, generator[segment].Item3, generator[segment].Item4);
                    new_line.AddRange(subline);
                }
                line = new_line;
                generation--;
            }

            //

            // convert list of lines into list of points

            var points = new List<Vector2d>();
            points.Add(line[0].Item1);
            foreach(var part in line)
            {
                points.Add(part.Item2);
            }

            //

            return points;
        }


        public static void SqiareGrid()
        {

        }

    }
}
