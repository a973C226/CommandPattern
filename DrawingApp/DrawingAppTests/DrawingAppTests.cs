using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace DrawingApp.Tests
{
    [TestClass()]
    public class DrawingAppTests
    {
        [TestMethod()]
        public void EraserCommandExecuteTest()
        {
            // Arrange
            Canvas canvas = new Canvas();
            ICommand eraserCommand = new EraserCommand(canvas, new Point(0, 0), new Point(10, 10));

            // Act
            eraserCommand.Execute();

            // Assert
            Assert.AreEqual(0, canvas.GetPointsCount());
        }

        [TestMethod()]
        public void BrushCommandExecuteTest1()
        {
            // Arrange
            Canvas canvas = new Canvas();
            ICommand brushCommand = new BrushCommand(canvas, new Point(0, 0), new Point(10, 10));

            // Act
            brushCommand.Execute();

            // Assert
            Assert.AreEqual(2, canvas.GetPointsCount());
        }

        [TestMethod()]
        public void AppExecuteCommandsTest()
        {
            // Arrange
            App app = new App();
            Canvas canvas = new Canvas();
            ICommand brushCommand = new BrushCommand(canvas, new Point(0, 0), new Point(10, 10));
            ICommand eraserCommand = new EraserCommand(canvas, new Point(0, 0), new Point(10, 10));
            app.AddCommand(brushCommand);
            app.AddCommand(eraserCommand);

            // Act
            app.ExecuteCommands();

            // Assert
            Assert.AreEqual(0, canvas.GetPointsCount());
        }

        [TestMethod()]
        public void AppUndoCommandsTest()
        {
            // Arrange
            App app = new App();
            Canvas canvas = new Canvas();
            ICommand brushCommand = new BrushCommand(canvas, new Point(0, 0), new Point(10, 10));
            ICommand eraserCommand = new EraserCommand(canvas, new Point(0, 0), new Point(10, 10));
            app.AddCommand(brushCommand);
            app.AddCommand(eraserCommand);

            // Act
            app.ExecuteCommands();
            app.UndoCommands();

            // Assert
            Assert.AreEqual(0, canvas.GetPointsCount());
        }
    }
}