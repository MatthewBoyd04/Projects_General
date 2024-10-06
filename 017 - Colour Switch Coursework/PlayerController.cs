using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_V1._0._1
{
    class PlayerController
    {
        bool devMode;
        #region PhysicsValues
        //Player Controlled
        bool MoveLeft = false;
        bool MoveRight = false;
        bool Sprint = false;
        bool Jump = false;
        //Conditional Variables
        bool OnGround = false;
        //Computer Controlled
        double Xpos;
        double YPos;
        double XVelocity;
        double YVelocity;
        double XAcceleration;
        double YAcceleration;
        #endregion

        public void calculate(char playerColour, bool Right, bool Left, bool Sprint, bool Jump)
        {
            Console.WriteLine("Your mother is large");
        }

        public void ObtainFirstValues(double PlayerX, double PlayerY, bool Dev)
        {
            devMode = Dev;
            Xpos = PlayerX;
            YPos = PlayerY;
            Display("Dev Mode Set To: " + Convert.ToString(devMode));
            Display("XPos Set To: " + Convert.ToString(PlayerX));
            Display("YPos Set To: " + Convert.ToString(PlayerY));
        }

        #region DisplayFunction
        private void Display(string DisplayText)
        {
            if (devMode == true)
            {
                Console.WriteLine("Player Controller: " + DisplayText);
            }
        }
        #endregion
    }
}
