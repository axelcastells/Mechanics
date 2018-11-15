using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotController
{
    public class MyRobotController
    {

        public string Hi()
        {


            string s = "hello world from my Robot Controller";
            return s;

        }

        public float addPi(float a) {
            return a + (float) System.Math.PI;

        }


    }
}
