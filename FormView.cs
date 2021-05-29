using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjektPoRadar
{
    public partial class FormView : Form
    {
        private int _x;
        private int _y;
        private int xSizePlane, ySizePlane;

        public FormView()
        {
            InitializeComponent();

            _x = 50;
            _y = 50;
            xSizePlane = 20;
            ySizePlane = 20;
        }

        private void FormView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Blue, _x, _y, xSizePlane, ySizePlane);
            // e.Graphics.FillRectangle(Brushes.Red, 250, 250, 10, 10);
            AirPort(e, 250, 250, 10, 10);

            Pen redPen = new Pen(Color.Blue, 5);
            e.Graphics.DrawLine(redPen, _x + (xSizePlane / 2), _y + (ySizePlane / 2), 255.0F, 255.0F);

            AirPort(e, 200, 150, 10, 10);
            AirPort(e, 400, 20, 10, 10);

            e.Graphics.DrawLine(redPen, 205.0F, 155.0F, 405.0F, 24.0F);
        }

        private void timerMoving_Tick(object sender, EventArgs e)
        {
            if (_x != 245 && _y != 245)
            {
                _x += 5;
                _y += 5;
            }


            Invalidate();
        }

        private void AirPort(PaintEventArgs e, int xAxis, int yAxis, int width, int height)
        {
            e.Graphics.FillRectangle(Brushes.Red, xAxis, yAxis, width, height);
        }

        private void FormView_Load(object sender, EventArgs e)
        {

        }

        public Point MovePointTowards(Point a, Point b, double distance)
        {
            var vector = new Point(b.X - a.X, b.Y - a.Y);
            var length = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            // var unitVector = new Point(vector.X / length, vector.Y / length);
            // return new Point(a.X + (unitVector.X * distance), a.Y + unitVector.Y * distance);
            return a;
        }


    }
}
