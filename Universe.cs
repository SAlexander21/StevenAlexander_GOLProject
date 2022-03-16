using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StevenAlexander_GOLProject
{

    //Class used to store cell info.
    public class Universe
    {
        static int x;
        static int y;

        //What is the status and size of the universe?
        private bool[,] universe = new bool[x, y];

        //Is the cell alive or dead?
        private bool[,] alive = new bool[x, y];

        //How long has the cell been alive?
        private int[,] genAlive = new int[x, y];

        //Does the cell have any friends?
        private int[,] numAdj = new int[x, y];

        //Getter/Setter for universe Boolean.
        public bool[,] GetUniverse()
        {

            return universe;

        }

        public void SetUniverse(int x, int y, bool a = false)
        {

            universe[x, y] = a;

        }

        //Getter/Setter for alive Boolean.
        public bool[,] GetAlive()
        {

            return alive;

        }

        public void SetAlive(int x, int y, bool a = false)
        {

            alive[x, y] = a; 

        }

        //Getter/Setter for genAlive integer.
        //Need to implement a way to set genAlive to current generation.
        public int[,] GetGen()
        {

            return genAlive;

        }

        public void SetGen(int x, int y, int a = 0)
        {

            genAlive[x, y] = a;
            
        }

        //Getter/Setter for checking how many neighbors a cell has.
        public int[,] GetAdj()
        {

            return numAdj;

        }

        public void SetAdj(int x, int y, int a)
        {

            numAdj[x, y] = a; 

        }
    }
}
