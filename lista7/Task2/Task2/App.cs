using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Task2
{
    public class App : Form
    {
        PrototypeRegistry prototypeRegistry;
        Button circleButton;
        Button squareButton;
        Button rectangleButton;
        Button moveButton;
        Button deleteButton;
        Button undoButton;
        Button redoButton;
        List<Button> listOfButtons = new List<Button>();
        public App ()
        {

            PrototypeRegistry prototypeRegistry = new PrototypeRegistry();
            Circle c = new Circle(10, 10, Color.Red);
            c.Radius = 40;
            Rectangle r = new Rectangle(40, 40, Color.Green);
            r.Width = 100;
            r.Height = 300;
            Square s = new Square(140, 140, Color.Red);
            s.Width = 80;
            prototypeRegistry.AddItem(c);
            prototypeRegistry.AddItem(r);
            prototypeRegistry.AddItem(s);


            InitComponents();

        }

        private void InitComponents()
        {
            circleButton = new Button()     { Text = "Circle" };
            squareButton = new Button()     { Text = "Square" };
            rectangleButton = new Button()  { Text = "Rectangle" };
            moveButton = new Button()       { Text = "Move" };
            deleteButton = new Button()     { Text = "Delete" };
            undoButton = new Button()       { Text = "Undo" };
            redoButton = new Button()       { Text = "Redo" };
            listOfButtons.Add(circleButton);
            listOfButtons.Add(squareButton);
            listOfButtons.Add(rectangleButton);
            listOfButtons.Add(moveButton);
            listOfButtons.Add(deleteButton);
            listOfButtons.Add(undoButton);
            listOfButtons.Add(redoButton);


            circleButton.MouseClick += CircleButton_MouseClick;


            listOfButtons.ForEach(x => Controls.Add(x));
            int i = 0;
            listOfButtons.ForEach(x =>
            {
                x.Location = new System.Drawing.Point(0 + i * 100, 0);
                x.Height = 30;
                i++;
            });
            Width = 800;
            Height = 700;
            Show();




        }

        private void CircleButton_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeCurrentCanvasAction();
        }

        public void ChangeCurrentCanvasAction()
        {
            MouseClick += App_MouseClick;
        }

        private void App_MouseClick(object sender, MouseEventArgs e)
        {

            var rect = prototypeRegistry.getByShapeId(ShapeId.Rectangle);
            var graphics = this.CreateGraphics();
            graphics.FillRectangle(new SolidBrush(Color.Red), (Rectangle)rect);

        }
    }
}