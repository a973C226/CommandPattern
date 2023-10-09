using System.Drawing;

namespace DrawingApp
{
    public class BrushCommand : ICommand
    {
        private Canvas canvas;
        private Point startPoint;
        private Point endPoint;

        public BrushCommand(Canvas canvas, Point startPoint, Point endPoint)
        {
            this.canvas = canvas;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        public void Execute()
        {
            canvas.DrawLine(startPoint, endPoint);
        }

        public void Undo()
        {
            canvas.RemoveLine(startPoint, endPoint);
        }
    }
}
