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

        private bool drawRoute = false;

        private bool isPaused = false;

        public FormView()
        {
            InitializeComponent();
            generateNewMap();
        }

        private void FormView_Paint(object sender, PaintEventArgs e)
        {
            if (!isPaused) {
                
                map.Simulate(0.05f);
                
            }

            List<String> movingObjtoRemove = new List<String>();

            //Aktualizowanie listy obiektów na mapie
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

            //Rysowanie obiektów statycznych
            foreach (MapObject obj in map.GetStaticObject())
            {
                e.Graphics.FillRectangle(Brushes.Black, (float)obj.GetPosition().GetXPosition() * 5 + 18, (float)obj.GetPosition().GetYPosition() * 5 + 18, 3, 3);
                e.Graphics.DrawString(obj.GetName(), SystemFonts.DefaultFont, Brushes.Black, (float)obj.GetPosition().GetXPosition() * 5 + 20, (float)obj.GetPosition().GetYPosition() * 5 + 20);
            }

            //Rysowanie obiektów dynamicznych
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
                    e.Graphics.FillEllipse(Color, (float)obj.GetPosition().GetXPosition() * 5+18, (float)obj.GetPosition().GetYPosition() * 5 + 18, 15, 15);
                }
                if (obj is Balloon)
                {
                    e.Graphics.FillRectangle(Color, (float)obj.GetPosition().GetXPosition() * 5 + 18, (float)obj.GetPosition().GetYPosition() * 5 + 18, 15, 15);
                }
                if (obj is Helicopter)
                {
                    e.Graphics.FillEllipse(Color, (float)obj.GetPosition().GetXPosition() * 5 + 18, (float)obj.GetPosition().GetYPosition() * 5 + 18, 10, 15);
                }
                if (obj is Airplane)
                {
                    e.Graphics.FillRectangle(Color, (float)obj.GetPosition().GetXPosition() * 5 + 18, (float)obj.GetPosition().GetYPosition() * 5 + 18, 10, 15);
                }
                e.Graphics.DrawString(obj.GetName(), SystemFonts.DefaultFont, Color, (float)obj.GetPosition().GetXPosition() * 5 + 34, (float)obj.GetPosition().GetYPosition() * 5 + 12);
            }

            //Wyświetlanie informacji o wybranym obiekcie 
            foreach (MovingMapObject obj in map.GetMovingObjects())
            {
                if (listBox1.SelectedItem != null)
                {
                    if (obj.GetName() == listBox1.SelectedItem.ToString())
                    {
                        richTextBox1.Text = "Name: " + obj.GetName() + "\nX:" + obj.GetPosition().GetXPosition() + "\nY:" + obj.GetPosition().GetYPosition() + "\nStatus: " + obj.GetStatus()+"\nAltitiude: "+obj.GetAltitude();
                    }
                }
            }
        }

        private void timerMoving_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void FormView_MouseClick(object sender, MouseEventArgs e)
        {
            //Odczytywanie pozycji na którą klikną użytkownik  
            if (drawRoute == true)
            {
                if (e.X<18||e.X>518||e.Y<18||e.Y>518) {
                    return;
                }

                Position listNewRoutes = new Position((e.X-18)/5, (e.Y - 18) / 5);

                positionRoute.Add(listNewRoutes);

                newRouteList.Items.Add("X: " + listNewRoutes.GetXPosition() + "Y: " + listNewRoutes.GetYPosition());
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        { 
            //wyświetlanie okienka do otwarcia pliku
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "map";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                map.Load(openFileDialog.FileName);
                listBox1.Items.Clear();
                foreach (MovingMapObject obj in map.GetMovingObjects())
                {
                    listBox1.Items.Add(obj.GetName().ToString());
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //wyświetlanie okienka do zapisu pliku
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "map";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                map.Save(saveFileDialog.FileName);

            }
        }

        private void startNewRouteButton_Click(object sender, EventArgs e)
        {
            //zaczęcie tworzenia nowej trasy
            if (listBox1.SelectedItem == null)
            {
                return;
            }
            
            drawRoute = true;

            drawingBoxOnOf.Visible = true;

            positionRoute.Clear();
        }

        private void applyNewRouteButton_Click(object sender, EventArgs e)
        {
            //zapisywanie nowo wybranej trasy
            drawRoute = false;


            drawingBoxOnOf.Visible = false;


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

            positionRoute = new List<Position>();
            newRouteList.Items.Clear();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            isPaused = true;
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            isPaused = false;
        }

        private void generateNewMapButton_Click(object sender, EventArgs e)
        {
            generateNewMap();
        }

        private void generateNewMap() {
            //generowanie nowej mapy
            map = new Map();
            for (int i = 0; i < 10; i++)
            {
                map.AddRandomMovingObject();
            }

            for (int i = 0; i < 4; i++)
            {
                map.AddRandomStaticObject();
            }
            listBox1.Items.Clear();
            foreach (MovingMapObject obj in map.GetMovingObjects())
            {
                listBox1.Items.Add(obj.GetName().ToString());
            }

        }

       
    }
}
