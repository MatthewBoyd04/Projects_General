using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_V1._0._1
{
    class Game_Controller
    {
        string PlayerColour;
        int PlayerX;
        int PlayerY;
        public void SendPlayerData(string Colour, int x, int y)
        {
            PlayerColour = Colour;
            PlayerX = x;
            PlayerY = y;
        }

        public int GetXPos()
        {
            return PlayerX;
        }

        public int GetYPos()
        {
            return PlayerY;
        }
        public string GetColour()
        {
            return PlayerColour;
        }

    }
}
