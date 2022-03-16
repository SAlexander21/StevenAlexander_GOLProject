using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        //X and Y for picking size of array
        int x;
        int y;

        //Last filename used and last comment entered
        string lastFileName;
        string lastComment;

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

                // Toggle the cell's state if cell exists
                if(e.X <= (cellWidth * universe.GetUniverse().GetLength(0) - 1) && e.Y <= (cellHeight * universe.GetUniverse().GetLength(1) - 1))
                {
                    
                    universe.GetUniverse()[x, y] = !universe.GetUniverse()[x, y];

                }
                else
                {



                }

                // Toggle cell alive or dead
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

        //Generate universe with random seed
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

        //Generate universe from seed
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

        //Save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(lastFileName != null)
            {

                //Overwrites last opened/saved file
                StreamWriter writer = new StreamWriter(lastFileName);

                //Default Comment
                //Going to add ability to change comment when user saves the file.
                writer.WriteLine("!This is the default comment.");

                //Used when implementing custom comments
                //lastComment

                //Iterates through the rows
                for (int y = 0; y < universe.GetUniverse().GetLength(1); y++)
                {
                    //Create a string to represent the current row.
                    String currentRow = string.Empty;

                    //Iterates through the columns
                    for (int x = 0; x < universe.GetUniverse().GetLength(0); x++)
                    {
                        //If the universe[x,y] is alive then append 'O' (capital O)
                        //to the row string.

                        if (universe.GetAlive()[x, y])
                        {

                            currentRow += "O";

                        }

                        //Else if the universe[x,y] is dead then append 'X' (capital X)
                        //to the row string.

                        else
                        {

                            currentRow += "X";

                        }
                    }

                    //Writes the Xs and Os to the .cells file
                    writer.WriteLine(currentRow);

                }

                //Closes the file.
                writer.Close();

            }
            else
            {

                //Creates new instance of a Save dialog window
                SaveFileDialog dlg = new SaveFileDialog();

                //Enables the option to filter out all files except those with the .cells extention.
                dlg.Filter = "All Files|*.*|Cells|*.cells";
                dlg.FilterIndex = 2; dlg.DefaultExt = "cells";


                if (DialogResult.OK == dlg.ShowDialog())
                {

                    //Creates file with name based on user input
                    StreamWriter writer = new StreamWriter(dlg.FileName);

                    //Sets lastFileName variable to user input
                    lastFileName = dlg.FileName;

                    //Default Comment
                    //Going to add ability to change comment when user saves the file.
                    writer.WriteLine("#This is the default comment.");

                    //Used when implementing custom comments
                    //lastComment

                    //Iterates through the rows
                    for (int y = 0; y < universe.GetUniverse().GetLength(1); y++)
                    {
                        //Create a string to represent the current row.
                        String currentRow = string.Empty;

                        //Iterates through the columns
                        for (int x = 0; x < universe.GetUniverse().GetLength(0); x++)
                        {
                            //If the universe[x,y] is alive then append 'O' (capital O)
                            //to the row string.

                            if (universe.GetAlive()[x, y])
                            {

                                currentRow += "O";

                            }

                            //Else if the universe[x,y] is dead then append 'X' (capital X)
                            //to the row string.

                            else
                            {

                                currentRow += "X";

                            }
                        }

                        //Writes the Xs and Os to the .cells file
                        writer.WriteLine(currentRow);

                    }

                    //Closes the file.
                    writer.Close();
                }
            }
        }

        //Save As
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Creates new instance of a Save dialog window
            SaveFileDialog dlg = new SaveFileDialog();

            //Enables the option to filter out all files except those with the .cells extention.
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";


            if (DialogResult.OK == dlg.ShowDialog())
            {

                //Creates file with name based on user input
                StreamWriter writer = new StreamWriter(dlg.FileName);

                //Sets lastFileName variable to user input
                lastFileName = dlg.FileName;

                //Default Comment
                //Going to add ability to change comment when user saves the file.
                writer.WriteLine("#This is the default comment.");

                //Used when implementing custom comments
                //lastComment

                //Iterates through the rows
                for (int y = 0; y < universe.GetUniverse().GetLength(1); y++)
                {
                    //Create a string to represent the current row.
                    String currentRow = string.Empty;

                    //Iterates through the columns
                    for (int x = 0; x < universe.GetUniverse().GetLength(0); x++)
                    {
                        //If the universe[x,y] is alive then append 'O' (capital O)
                        //to the row string.

                        if (universe.GetAlive()[x, y])
                        {

                            currentRow += "O";

                        }

                        //Else if the universe[x,y] is dead then append 'X' (capital X)
                        //to the row string.

                        else
                        {

                            currentRow += "X";

                        }
                    }

                    //Writes the Xs and Os to the .cells file
                    writer.WriteLine(currentRow);

                }

                //Closes the file.
                writer.Close();
            }
        }

        //Open file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                //Variables used to calculate max width, max height, and what row the streamreader is on
                int maxWidth = 0;
                int maxHeight = 0;
                int currentRow = 0;

                //Goes through the file to determine size of the universe
                while (!reader.EndOfStream)
                {
                    //Reads the rows one at a time
                    string row = reader.ReadLine();

                    //Used to ignore comments that start with '#'
                    if (row.StartsWith("#"))
                    {

                        continue;

                    }

                    //If the row is not a comment increment maxHeight variable
                    if (!row.StartsWith("#"))
                    {

                        maxHeight++;

                    }
                    
                    //If the width is not the same as the row length it changes them to be the same
                    if(maxWidth != row.Length)
                    {

                        maxWidth = row.Length;

                    }
                }

                //Resizes universe to saved files config
                universe.SetUniverse(maxWidth, maxHeight);

                //Sets pointer to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                //Runs through the file reading cells and setting them to alive or dead
                while (!reader.EndOfStream)
                {
                  
                    //Reads one row at a time.
                    string row = reader.ReadLine();

                    currentRow++;

                    //Used to ignore comments that start with '#'
                    if (row.StartsWith("#"))
                    {

                        continue;

                    }

                    //Iterate through cells to see what to make active
                    for (int xPos = 0; xPos < row.Length; xPos++)
                    {
                        //If the current position is an 'O' set it to active and alive
                        if(row[xPos] == 'O')
                        {

                            universe.SetUniverse(xPos, currentRow, true);
                            universe.SetAlive(xPos, currentRow, true);

                        }
                    }
                }

                //Closes the file.
                reader.Close();
            }
        }
    }
}
