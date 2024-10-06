
namespace CourseWork_V1._0._1
{
    class PhysicsEngine
    {
        #region Constants
        const double gravity = 9.81;
        const double AirResistance = 2;
        const double SprintConstant = 4;
        const double WalkConstant = 2.4;
        const double FrictionCoeffecient = -0.1;
        const double ObjectWeight = 2.1;
        const int MaxYSpeed = 20;
        #endregion
        #region Vairables
        double FinalXPos;
        double FinalYPos;
        double FinalXVelocity;
        double FinalYVelocity;
        double FinalXAcceleration;
        double FinalYAcceleration;
        #endregion
        #region SUVAT info
        //to run 100 times per second - this will affect time
        ////SUVAT: 
        // v = u + at 
        // v^2 = u^2 + 2as
        // s = ut + 1/2at^2
        // s = vt - 1/2at^2
        // s = 1/2(u + v)t 
        #endregion
        double[] FinalVariables = {0,0,0,0,0,0 };
        
        public double[] Calculate(double InitYPos, double InitXPos, double InitYVelocity, double InitXVelocity, double XAcceleration, double YAcceleration, 
                                 bool OnGround, bool Jump, bool WalkLeft, bool WalkRight, bool Sprint)
        {
            #region XValues
            //XVariables - Done as accelearation then velocity then pos.
            //XAcceleration
            FinalXAcceleration = CalculateXAcceleration(XAcceleration, WalkLeft, WalkRight, Sprint);
            //XVelocity
            FinalXVelocity = CalculateXFinalVelocity(FinalXAcceleration, InitXVelocity, WalkLeft, WalkRight);
            //XObjectPos
            FinalXPos = CalculateXFinalPos(FinalXVelocity, InitXPos);
            #endregion
            #region YValues
            //YVariables - Done as accelearation then velocity then pos. 
            //YAcceleration
            FinalYAcceleration = CalculateYAcceleration(YAcceleration, Jump, OnGround);
            //YVelocity
            FinalYVelocity = CalculateYFinalVelocity(FinalYAcceleration, InitYVelocity, OnGround);
            //YPos
            FinalYPos = CalculateYFinalPos(FinalYVelocity, InitYPos);
            #endregion
            #region FinalVariables
            //Final Variables Structure
            //X Acceleration
            //X Velocity
            //X Pos
            //Y Acceleration
            //Y Velocity
            //Y Pos
            FinalVariables[0] = FinalXAcceleration; FinalVariables[1] = FinalXVelocity; FinalVariables[2] = FinalXPos;
            FinalVariables[3] = FinalYAcceleration; FinalVariables[4] = FinalYVelocity; FinalVariables[5] = FinalYPos;
            #endregion
            return FinalVariables;
        }

        #region XValueSubs
        private double CalculateXAcceleration(double XAcceleration, bool WalkLeft, bool WalkRight, bool Sprint)
        {
            #region Acceleration
            if (WalkLeft == true)
            {
                if (Sprint == true) { XAcceleration = XAcceleration - SprintConstant; } // This takes away the sprint constant from the acceleration so that it will start moving left
                else if (Sprint == false) { XAcceleration = XAcceleration - WalkConstant; }// This takes away the walk constant from the acceleration so that it will start moving left
            }
            else if (WalkRight == true)
            {
                if (Sprint == true) { XAcceleration = XAcceleration + SprintConstant; }
                else if (Sprint == false) { XAcceleration = XAcceleration + WalkConstant; }
            }
            #endregion 
            #region Air Resistance
            if (XAcceleration > 0 && XAcceleration <= 2) { XAcceleration = XAcceleration - XAcceleration; }
            else if (XAcceleration > 2) { XAcceleration = XAcceleration - AirResistance; }
            else if (XAcceleration < 0 && XAcceleration >= -2) { XAcceleration = XAcceleration - XAcceleration; }
            else if (XAcceleration < -2) { XAcceleration = XAcceleration + AirResistance; }
            #endregion
            #region MaxAcceleration 
            if (XAcceleration > 12.5) {XAcceleration = 12.5f;}
            else if (XAcceleration < -12.5) {XAcceleration = -12.5f;}
            
            #endregion
            //Although there is not typicall friction calculate for acceleration, this isnt actually 'friction' its just more of a way to keep the acceleration slowed
            return XAcceleration;
        }
        private double CalculateXFinalVelocity(double XAcceleration, double XVelocity, bool WalkLeft, bool WalkRight)
        {
            double friction = 0;
            #region Accelerate 
            double temp;
            temp = XVelocity + (XAcceleration); //Acceleration is divided by 100 as it runs 100 times per second. 
            #endregion 
            #region MaxSpeedCheck
            if (temp > 50) {temp = 50; }
            else if (temp < -50) {temp = -50;}
            #endregion
            #region Friction
            friction = FrictionCoeffecient * -temp; //Friction is calculated by friction = Friction Coeffecient * Normal Reaction, this is temporarily the X Velocity as it makes sense
            temp = temp - friction;                 //Temp is negative as the normal is usually the reaction which pushshes in the other direction in the response to force. 
            #endregion
            XVelocity = temp;
            if ((WalkLeft = false) && (WalkRight = false) && (XVelocity < 1))  { XVelocity = 0; }
            if ((WalkLeft = false) && (WalkRight = false) && (XVelocity > -1)) { XVelocity = 0; }
            if (XVelocity > MaxYSpeed) { XVelocity = MaxYSpeed;}
            else if (XVelocity < -MaxYSpeed) { XVelocity = -MaxYSpeed; }
            return XVelocity;

        }
        private double CalculateXFinalPos(double XVelocity, double XPos)
        {
            XPos = XPos + XVelocity;
            return XPos;
        }
        #endregion

        #region YValueSubs
        private double CalculateYAcceleration(double YAcceleration, bool Jump, bool OnGround)
        {
            #region Jump
            if (Jump == true && OnGround == true) { YAcceleration = YAcceleration - 2.7; }
            #endregion
            #region gravity
            if (OnGround == false) {YAcceleration = YAcceleration + ((gravity / 100) * ObjectWeight);}//gravity is divided by 100 as its 9.8m/s and this runs 100 times a second
            
            #endregion
            #region Groundcheck
            if (OnGround == true && YAcceleration > 0) { YAcceleration = 0; }
            if (YAcceleration > 12.5) { YAcceleration = 12.5f; }
            else if (YAcceleration < -12.5) { YAcceleration = -12.5f; }
            #endregion
            return YAcceleration;
        }
        private double CalculateYFinalVelocity(double YAcceleration, double YVelocity, bool OnGround)
        {
            #region Accelerate
            YVelocity = YVelocity + YAcceleration;
            #endregion
            #region GroundCheck
            if (OnGround == true && YVelocity > 0) { YVelocity = 0; }
            #endregion
            if (YVelocity > MaxYSpeed) { YVelocity = MaxYSpeed; }
            else if (YVelocity < -MaxYSpeed) { YVelocity = -MaxYSpeed; }
            return YVelocity;
        }
        private double CalculateYFinalPos(double YVelocity, double YPos) { YPos = YPos + YVelocity; return YPos; }
        #endregion
    }
}
