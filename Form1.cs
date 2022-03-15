using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StevenAlexander_GOLProject
{
    public partial class Form1 : Form
    {
        // The universe array
        //bool[,] universe = new bool[100, 50];
        Universe universe = new Universe();

        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Red;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        //Stores number of neighbors
        string neighbors;

        //Generates new Random
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();

            // Setup the timer
            timer.Interval = 100; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running
        }

        // Calculate the next generation of cells
        private void NextGeneration()
        {
            RulesOfTheGame();

            // Increment generation count
            generations++;

            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {

            //Font used for number of neighbors indicator
            FontFamily fontF = new FontFamily("Calibri");

            System.Drawing.Font font = new System.Drawing.Font(fontF, 12);

            //Brush for the number of neighbors indicator
            Brush numBrush = new SolidBrush(Color.Black);

            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetUniverse().GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetUniverse().GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetUniverse().GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetUniverse().GetLength(0); x++)
                {
                    
                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with a brush if alive
                    if (universe.GetAlive()[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                        neighbors = CountAdjacent(x, y).ToString();
                        e.Graphics.DrawString(neighbors, font, numBrush, new PointF(x * cellWidth + 2, y * cellHeight - 2));
                    }

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
            numBrush.Dispose();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {

            //Activates when clicking left mouse button
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetUniverse().GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetUniverse().GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                if(e.X <= (cellWidth * universe.GetUniverse().GetLength(0) - 1) && e.Y <= (cellHeight * universe.GetUniverse().GetLength(1) - 1))
                {
                    
                    universe.GetUniverse()[x, y] = !universe.GetUniverse()[x, y];

                }
                else
                {



                }

                if(e.X <= (cellWidth * universe.GetUniverse().GetLength(0) - 1) && e.Y <= (cellHeight * universe.GetUniverse().GetLength(1) - 1) && universe.GetUniverse()[x, y])
                {

                    universe.SetAlive(x, y, true);

                }
                else if(e.X <= (cellWidth * universe.GetUniverse().GetLength(0) - 1) && e.Y <= (cellHeight * universe.GetUniverse().GetLength(1) - 1) && !universe.GetUniverse()[x, y])
                {

                    universe.SetAlive(x, y);

                }
                else
                {



                }

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();

            }
        }

        private void RulesOfTheGame()
        {

            for (int y = 0; y < universe.GetUniverse().GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetUniverse().GetLength(0); x++)
                {

                    universe.SetAdj(x, y, CountAdjacent(x, y));

                }
            }

            // Sets the rules for the Game of Life
            for (int y = 0; y < universe.GetUniverse().GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetUniverse().GetLength(0); x++)
                {

                    int adj = universe.GetAdj()[x, y];
                    bool alive = universe.GetAlive()[x, y];

                    if (adj < 2 && alive)
                    {

                        universe.SetAlive(x, y, false);
                        universe.SetUniverse(x, y, false);

                    }

                    if (adj > 3 && alive)
                    {

                        universe.SetAlive(x, y, false);
                        universe.SetUniverse(x, y, false);
                    }

                    if ((adj == 2 || adj == 3) && alive)
                    {

                        universe.SetAlive(x, y, true);
                        universe.SetUniverse(x, y, true);

                    }

                    if (adj == 3 && !alive)
                    {

                        universe.SetAlive(x, y, true);
                        universe.SetUniverse(x, y, true);

                    }
                }
            }

            // Tell Windows you need to repaint
            graphicsPanel1.Invalidate();

        }

        private int CountAdjacent(int x, int y)
        {

            //Number of Adjacent cells
            int adjCells = 0;
            //Length of universe on X axis
            int xLen = universe.GetUniverse().GetLength(0);
            //Length of universe on Y axis
            int yLen = universe.GetUniverse().GetLength(1);
            //Stores the universe in a variable
            bool[,] theUniverse = universe.GetUniverse();

            //Cycle through Y
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {

                //Cycle through X
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {

                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    if (xOffset == 0 && yOffset == 0)
                    {

                        continue;

                    }

                    if (xCheck < 0)
                    {

                        xCheck = xLen - 1;

                    }
                    
                    if (yCheck < 0)
                    {

                        yCheck = yLen - 1;

                    }

                    if (xCheck >= xLen)
                    {

                        xCheck = 0;

                    }
                    
                    if (yCheck >= yLen)
                    {

                        yCheck = 0;

                    }

                    if (theUniverse[xCheck, yCheck] == true) adjCells++;
                }
            }

            return adjCells;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //New File Button
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            timer.Enabled = false;
            generations = 0;
            toolStripStatusLabelGenerations.Text = "Generations = 0";

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetUniverse().GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetUniverse().GetLength(0); x++)
                {

                    universe.SetAlive(x, y, false);
                    universe.SetUniverse(x, y, false);

                }
            }

            // Tell Windows you need to repaint
            graphicsPanel1.Invalidate();

        }

        //Exit Button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Exit Program.
            this.Close();

        }

        //Stop Button
        private void Stop_Click(object sender, EventArgs e)
        {

            if (timer.Enabled == true)
            {

                timer.Enabled = false;

                // Iterate through the universe in the y, top to bottom
                for (int y = 0; y < universe.GetUniverse().GetLength(1); y++)
                {
                    // Iterate through the universe in the x, left to right
                    for (int x = 0; x < universe.GetUniverse().GetLength(0); x++)
                    {

                        universe.SetAlive(x, y, false);
                        universe.SetUniverse(x, y, false);

                    }
                }
                
                generations = 0;
                toolStripStatusLabelGenerations.Text = "Generations = 0";

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();

            }
            else
            {



            }
        }

        //Play Button
        private void Play_Click(object sender, EventArgs e)
        {

            if (timer.Enabled == false)
            {

                timer.Enabled = true;

            }
            else
            {



            }

        }

        //Pause Button
        private void Pause_Click(object sender, EventArgs e)
        {

            if (timer.Enabled == true)
            {

                timer.Enabled = false;

            }
            else
            {



            }
        }

        //About Button
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.Show();

        }

        //Step Button - Move 1 generation
        private void Step_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == false)
            {

                NextGeneration();

            }
            else
            {



            }
        }

        //Leap Button - Move 5 generations
        private void Leap_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == false)
            {
                for (int i = 0; i < 5; i++)
                {

                    NextGeneration();

                }
            }
            else
            {



            }
        }

        //Generate universe at random button
        private void generateRandomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == false)
            {
                // Iterate through the universe in the y, top to bottom
                for (int y = 0; y < universe.GetUniverse().GetLength(1); y++)
                {
                    // Iterate through the universe in the x, left to right
                    for (int x = 0; x < universe.GetUniverse().GetLength(0); x++)
                    {

                        if (rand.Next(1, 301) % 2 == 0)
                        {

                            universe.SetAlive(x, y, true);
                            universe.SetUniverse(x, y, true);

                        }
                        else
                        {

                            universe.SetAlive(x, y, false);
                            universe.SetUniverse(x, y, false);

                        }
                    }
                }
            }
            else
            {



            }

            // Tell Windows you need to repaint
            graphicsPanel1.Invalidate();

        }

        private void generateFromSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form2 seedbox = new Form2();

            if (seedbox.ShowDialog() == DialogResult.OK)
            {

                Random random = new Random(Form2.seedInt);

                // Iterate through the universe in the y, top to bottom
                for (int y = 0; y < universe.GetUniverse().GetLength(1); y++)
                {
                    // Iterate through the universe in the x, left to right
                    for (int x = 0; x < universe.GetUniverse().GetLength(0); x++)
                    {

                        if (random.Next() % 2 == 0)
                        {

                            universe.SetAlive(x, y, true);
                            universe.SetUniverse(x, y, true);

                        }
                        else
                        {

                            universe.SetAlive(x, y, false);
                            universe.SetUniverse(x, y, false);

                        }
                    }
                }

                //Tell Windows you need to repaint
                graphicsPanel1.Invalidate();

                //Closes the seed menu
                seedbox.Close();
            }
            else
            {



            }
        }
    }
}
