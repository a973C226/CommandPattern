using System.Drawing;

namespace DrawingApp
{
    public class EraserCommand : ICommand
    {
        private Canvas canvas;
        private Point startPoint;
        private Point endPoint;

        public EraserCommand(Canvas canvas, Point startPoint, Point endPoint)
        {
            this.canvas = canvas;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        public void Execute()
        {
            canvas.RemoveLine(startPoint, endPoint);
        }

        public void Undo()
        {
            canvas.DrawLine(startPoint, endPoint);
        }
    }
}
