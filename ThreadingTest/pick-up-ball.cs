using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadingTest
{
    class pick_up_ball_DISPLAY
    {
        char[,] theGrid;
        const int floorLevel = 4;
        displayObject floor;
        displayObject ball;
        displayObject man;

        pick_up_ball_DISPLAY(int x, int y) //size of grid x by y
        {
            theGrid = new char[x, y];
            InitalizeObjects();
        }

        public void InitalizeObjects()
        {
            floor = new displayObject(0, theGrid.GetLength(0), theGrid.GetLength(1));
            for (int i = floorLevel; i > 0; i--)
            {
                char valueOfIndex = 'X';
                if (i == floorLevel)
                    valueOfIndex = '=';
                for (int x = 0; x < theGrid.GetLength(0); x++)
                    floor.setValues(ref theGrid, new displayObject.index(valueOfIndex, x, i));
            }
            int j = 0;
        }
        class displayObject //Base class for Objects to Draw
        {
            public int layer;
            int[,] picValues;

            public displayObject(int l, int x, int y)
            {
                layer = l;
                picValues = new int[x, y];
            }
            public void setValues(ref char[,] TheGrid, params index[] indexList)
            {
                foreach (index ind in indexList)
                {
                    if (ind.x >= 0 && ind.x <= TheGrid.GetLength(0))
                        TheGrid[ind.x, ind.y] = ind.value;
                    else if (ind.y >= 0 && ind.y <= TheGrid.GetLength(1))
                        TheGrid[ind.x, ind.y] = ind.value;
                }
            }
            public class index
            {
                public char value;
                public int  x, y;
                public index(char _value, int _x,int _y)
                {
                    value = _value;
                    x = _x;
                    y = _y;
                }
            }
        }
        
        static void Main(string[] args)
        {
            pick_up_ball_DISPLAY display = new pick_up_ball_DISPLAY(15,15);
        }
    }
}
