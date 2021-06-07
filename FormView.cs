using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProjektPoRadar
{
    public partial class FormView : Form
    {
        Map map = new Map();

        private List<Position> positionRoute = new List<Position>();

        private List<Position> temporaryPositionRoute = new List<Position>();

        private bool drawRoute = false;

        public FormView()
        {
            InitializeComponent();

            for(int i = 0; i < 10 ; i++)
            {
                map.AddRandomMovingObject();
            }
            foreach (MovingMapObject obj in map.GetMovingObjects())
            {
                listBox1.Items.Add(obj.GetName().ToString());
            }
        }

        private void FormView_Paint(object sender, PaintEventArgs e)
        {
            map.Simulate(0.05);

            List<String> movingObjtoRemove = new List<String>();

            foreach (String str in listBox1.Items)
            {
                bool exist=false;
                foreach (MovingMapObject obj in map.GetMovingObjects())
                {
                    if (str == obj.GetName().ToString()) {
                        exist = true;
                    }
                }
                if (!exist) {
                    movingObjtoRemove.Add(str);
                }
            }
            foreach (String str in movingObjtoRemove) {
                listBox1.Items.Remove(str);
            }



        

            foreach (MovingMapObject obj in map.GetMovingObjects())
            {
                Brush Color;

                if (obj.GetStatus() == Status.Safe)
                {
                    Color = Brushes.Green;          
                }
                else if (obj.GetStatus() == Status.InDanger)
                {
                    Color = Brushes.Yellow;
                }
                else
                {                 
                    Color = Brushes.Red;
                }
                if(obj is Glider)
                {
                    e.Graphics.FillEllipse(Color, (float)obj.GetPosition().GetXPosition() * 5, (float)obj.GetPosition().GetYPosition() * 5, 15, 15);
                }
                if (obj is Balloon)
                {
                    e.Graphics.FillRectangle(Color, (float)obj.GetPosition().GetXPosition() * 5, (float)obj.GetPosition().GetYPosition() * 5, 15, 15);
                }
                if (obj is Helicopter)
                {
                    e.Graphics.FillEllipse(Color, (float)obj.GetPosition().GetXPosition() * 5, (float)obj.GetPosition().GetYPosition() * 5, 10, 15);
                }
                if (obj is Airplane)
                {
                    e.Graphics.FillRectangle(Color, (float)obj.GetPosition().GetXPosition() * 5, (float)obj.GetPosition().GetYPosition() * 5, 10, 15);
                }

            }

            foreach (MovingMapObject obj in map.GetMovingObjects())
            {
                if (listBox1.SelectedItem != null)
                {
                    if (obj.GetName() == listBox1.SelectedItem.ToString())
                    {
                        richTextBox1.Text = "Name: " + obj.GetName() + "\nX:\n" + obj.GetPosition().GetXPosition() + "\nY:\n" + obj.GetPosition().GetYPosition() + "\nStatus: " + obj.GetStatus();
                    }
                }
            }
        }

        private void timerMoving_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void FormView_MouseMove(object sender, MouseEventArgs e)
        {
            //listBox1.Text = " X: " + e.X + " Y: " + e.Y;
        }

        private void FormView_MouseUp(object sender, MouseEventArgs e)
        {
            //listBox1.Text = " X: " + e.X + " Y: " + e.Y;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormView_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Change_direction_Click(object sender, EventArgs e)
        {
            positionRoute = temporaryPositionRoute;

            foreach (MovingMapObject obj in map.GetMovingObjects())
            {
                if (listBox1.SelectedItem != null)
                {
                    if (obj.GetName() == listBox1.SelectedItem.ToString())
                    {
                        obj.SetNewRoute(positionRoute);
                    }
                }
            }

            Change_direction.Enabled = false;

            newRouteList.Items.Clear();
        }

        private void FormView_MouseClick(object sender, MouseEventArgs e)
        {
            if(drawRoute == true)
            {
                Position listNewRoutes = new Position(e.X/5, e.Y/5);

                temporaryPositionRoute.Add(listNewRoutes);

                newRouteList.Items.Add("X: " + listNewRoutes.GetXPosition() + "Y: " + listNewRoutes.GetYPosition());
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            drawRoute = true;

            drawingBoxOnOf.Visible = true;

            temporaryPositionRoute.Clear();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            drawRoute = false;

            Change_direction.Enabled = true;

            drawingBoxOnOf.Visible = false;
        }

        private void newRouteList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Change_direction_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
    }
}
