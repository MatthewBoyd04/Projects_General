using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CourseWork_V1._0._1
{
    class Level_Create
    {
        bool devMode;




        private void Display(string DisplayText)
        {
            if (devMode == true)
            {
                Console.WriteLine("Level Create: " + DisplayText);
            }

        }



    }
}
