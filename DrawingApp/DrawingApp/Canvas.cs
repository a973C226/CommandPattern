using System.Drawing;

namespace DrawingApp
{
    public class Canvas
    {
        private List<Point> points = new List<Point>();

        private void AddPoint(Point point)
        {
            points.Add(point);
        }

        private void RemovePoint(Point point)
        {
            points.Remove(point);
        }

        public int GetPointsCount()
        {
            return points.Count;
        }

        public void DrawLine(Point startPoint, Point endPoint)
        {
            this.AddPoint(startPoint);
            this.AddPoint(endPoint);
            Console.WriteLine($"Draw line from {startPoint} to {endPoint}");
        }

        public void RemoveLine(Point startPoint, Point endPoint)
        {
            this.RemovePoint(startPoint);
            this.RemovePoint(endPoint);
            Console.WriteLine($"Remove line from {startPoint} to {endPoint}");
        }

        public void Redraw()
        {
            Console.WriteLine("Redraw canvas:");
            if (points.Count != 0)
                foreach (var point in points)
                    Console.WriteLine($"Point: {point}");
            else
                Console.WriteLine($"The canvas is clean");
        }
    }
}
