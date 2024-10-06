using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CourseWork_V1._0._1
{
    public partial class LevelForm : Form
    {

        PhysicsEngine P = new PhysicsEngine();
        Game_Controller Game = new Game_Controller();

        //Removed Filepath Variable as it was not used
        bool devMode;
        int SpriteSize, LvlID; //> Condensed into 1 Statement

        #region PhysicsValues
        // Removed PhysicsVariables[] as they were not used
        double PYPos = 0, PXPos = 0, PYVelocity = 0, PXVelocity = 0, PXAcceleration = 0, PYAcceleration = 0; //> Condensed into 1 Statement
        bool MoveLeft = false, MoveRight = false, Sprint = false, Jump = false, OnGround = false; //> Condensed into 1 Statement
        int TempBlockTop;
        #endregion
        #region UI
        PictureBox PBox = new PictureBox {Name = "Player",}; //> Condensed from 4 lines to 1
        #endregion
        public LevelForm() {InitializeComponent(); } //Condensed from 4 lines to 1
        public void LevelForm_Load(object sender, EventArgs e) {SpriteSize = (this.Width / 32); ; } //> Condensed from 4 lines to 1
        public void Loader(int LevelID, bool Dev)
        {
            LvlID = LevelID;
            this.Show();
            devMode = Dev;
            #region DevOutput
            Display("Level " + Convert.ToString(LevelID) + " Loaded with devMode: " + devMode);
            #endregion
            LevelProcessing(LevelID, devMode);
        }
        private void Display(string DisplayText) { if (devMode == true) {Console.WriteLine("LevelForm:" + DisplayText);} } //> Condensed from 6 lines to 1

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MapScreen MS = new MapScreen();
            MS.Show();
        }

        //Removed Instantiate Method as it was not used. 

        #region Level Creation
        public struct ObjInfo
        {
        }

        public void LevelProcessing(int LevelID, bool Dev)
        {
            ObjInfo[,] LevelDat = new ObjInfo[31, 17];
            devMode = Dev;
            Display("Recieved Level ID " + LevelID);
            Display("Sending Level ID to Level Create");
            LoadLevel(LevelID, LevelDat);
        }

        private ObjInfo[,] LoadLevel(int LevelID, ObjInfo[,] LevelData)
        {
            Display("Level Loading...");
            string[,] LevelInfo = { { } };
            if (LevelID == 1)
            {

                //Array size is 16:9 Ratio - This is temporary, will most likely be 32:18 by the end
                #region Formatting
                // 2 Char: ObjType_ Colour 
                // ObjType: B - Block (Ground or wall)
                //          G - Gate
                //          S - Switch
                //          P - Player
                //          F - Flag
                //          N - Null
                //
                //
                // Colour:  B - Blue
                //          G - Green
                //          R - Red
                //          O - Orange
                //          N - Null/Nuetral
                // Example: (B_B) is block, blue
                #endregion
                LevelInfo = new[,]     {  { ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("B_R"), ("B_R"), ("B_R"), ("B_R"), ("B_R"), ("B_R"), ("B_R"), ("B_R"), ("B_R"), ("B_R"), ("B_R"), ("B_R"), ("B_R"), ("B_R"), ("B_R"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("S_B"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("F_B"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("S_B"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_R"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("B_B"), ("B_B"), ("B_B"), ("B_B"), ("B_B"), ("B_N"),},
                                          { ("B_N"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_B"), ("B_B"), ("B_B"), ("B_B"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_G"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_G"), ("B_G"), ("N_N"), ("N_N"), ("N_N"), ("G_G"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("G_G"), ("N_N"), ("S_G"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_G"), ("B_G"), ("B_G"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_O"), ("B_O"), ("B_O"), ("B_O"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_O"), ("B_O"), ("B_O"), ("B_O"), ("B_O"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("P_O"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("G_R"), ("N_N"), ("N_N"), ("G_B"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("G_R"), ("S_R"), ("N_N"), ("G_B"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"),}, };
            }
            else if (LevelID == 2)
            {
                LevelInfo = new[,]     {  { ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_O"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_O"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("S_O"), ("N_N"), ("B_O"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_O"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_O"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("G_O"), ("N_N"), ("S_G"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_O"), ("B_O"), ("B_O"), ("B_O"), ("N_N"), ("N_N"), ("N_N"), ("B_R"), ("B_R"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("B_O"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("G_O"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("G_O"), ("N_N"), ("N_N"), ("G_R"), ("N_N"), ("N_N"), ("N_N"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("B_N"), ("B_N"), ("G_G"), ("G_G"), ("G_G"), ("B_G"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("G_O"), ("S_O"), ("N_N"), ("G_R"), ("N_N"), ("N_N"), ("N_N"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("B_O"), ("B_O"), ("B_O"), ("B_O"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_R"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("S_R"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_G"), ("B_G"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_R"), ("B_R"), ("B_R"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("B_B"), ("B_B"), ("B_B"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_O"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("B_B"), ("N_N"), ("N_N"), ("B_G"), ("B_G"), ("B_G"), ("B_G"), ("B_G"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_O"), ("B_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("P_G"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("G_B"), ("N_N"), ("N_N"), ("N_N"), ("G_G"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_O"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("G_B"), ("N_N"), ("S_B"), ("N_N"), ("G_G"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_O"), ("N_N"), ("F_G"), ("B_N"),},
                                          { ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_O"), ("B_N"), ("B_N"), ("B_N"),}, };
            }
            else if (LevelID == 3)
            {
                LevelInfo = new[,]   {    { ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("B_N"), ("B_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("F_G"), ("N_N"), ("P_B"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"),}, };
            }
            else if (LevelID == 4)
            {
                LevelInfo = new[,]   {    { ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"),},
                                          { ("B_N"), ("P_B"), ("N_N"), ("N_N"), ("N_N"), ("S_G"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_G"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_G"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("S_R"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_G"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("B_B"), ("B_B"), ("B_B"), ("B_R"), ("B_R"), ("G_R"), ("G_R"), ("B_G"), ("B_G"), ("B_G"), ("G_G"), ("G_G"), ("B_G"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_R"), ("B_R"), ("B_R"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_B"), ("B_B"), ("B_B"), ("B_B"), ("B_B"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("N_N"), ("B_N"),},
                                          { ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"), ("B_N"),}, };
            }


            string Temp; //For Strings
            char FirstChar, SecondChar; //Obj Type then Colour - Condensed into 1 statement
            Display("Running Array Proccessing");
            string ObjType = "";
            string Colour = "";
            for (int X = 0; X < 32; X++)
            {
                Display("X Loaded As:" + Convert.ToString(X));
                for (int Y = 0; Y < 18; Y++)
                {
                    Display("X Loaded As: " + Convert.ToString(X) + " With Y Loaded As: " + Convert.ToString(Y));
                    Temp = LevelInfo[Y, X];
                    Display(Temp);
                    string[] CharArray = Temp.Split('_');
                    FirstChar = Convert.ToChar(CharArray[0]);
                    SecondChar = Convert.ToChar(CharArray[1]);
                    switch (FirstChar)//> Condensed Switch Statements to around 15 lines as oppose to around 60
                    {
                        case 'B': Display("Block");  ObjType = "Block";  break;
                        case 'G': Display("Gate");   ObjType = "Gate";   break;
                        case 'S': Display("Switch"); ObjType = "Switch"; break;
                        case 'P': Display("Player"); ObjType = "Player"; break;
                        case 'F': Display("Flag");   ObjType = "Flag";   break;
                        case 'N': Display("Null");   ObjType = "Null";   break;
                    }
                    switch (SecondChar)
                    {
                        case 'B': Display("Blue");   Colour = "Blue";   break;
                        case 'G': Display("Green");  Colour = "Green";  break;
                        case 'R': Display("Red");    Colour = "Red";    break;
                        case 'O': Display("Orange"); Colour = "Orange"; break;
                        case 'N': Display("Null");   Colour = "Null";   break;
                    }
                    CreateSprite(ObjType, Colour, X, Y);
                }
            }
            Display("Player Found with Position (" + PXPos + "," + PYPos + ")");
            PTimer.Enabled = true;
            return LevelData;
        }
        #region Summon
        private void CreateSprite(string ObjType, string Colour, int XPos, int YPos)
        {

            Display("Creating Sprite Called");
            switch (ObjType) //> Condensed Switch Statement 
            {
                case "Player": Display("Creating Player With Colour: " + Colour); SummonPlayer(Colour, XPos, YPos);  break;
                case "Block":  Display("Creating Block With Colour:" + Colour);   SummonBlock(Colour, XPos, YPos);  break;
                case "Gate":   Display("Creating Gate With Colour:" + Colour);    SummonGate(Colour, XPos, YPos);   break;
                case "Switch": Display("Creating Switch With Colour:" + Colour);  SummonSwitch(Colour, XPos, YPos); break;
                case "Flag":   Display("Creating Flag With Colour:" + Colour);    SummonFlag(Colour, XPos, YPos);   break;
            }
        }
        #endregion
        #region SummonPlayer
        public void SummonPlayer(string Colour, int XPos, int YPos)
        {
            Game.SendPlayerData(Colour, XPos, YPos);
            PBox.Size = new Size(SpriteSize, SpriteSize);
            PBox.Location = new Point(XPos * SpriteSize, YPos * SpriteSize);           
            PYPos = YPos * SpriteSize; //Moved out of switch statement as was constant
            PXPos = XPos * SpriteSize;
            switch (Colour)
            {
                case "Blue":
                    PBox.Tag = "Blue";
                    PBox.BackColor = Color.Blue;
                    PBox.Image = Image.FromFile("Blue_Player3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Green":
                    PBox.Tag = "Green";
                    PBox.BackColor = Color.Green;
                    PBox.Image = Image.FromFile("Green_Player3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Red":
                    PBox.Tag = "Red";
                    PBox.BackColor = Color.Red;
                    PBox.Image = Image.FromFile("Red_Player3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Orange":
                    PBox.Tag = "Orange";
                    PBox.BackColor = Color.Orange;
                    PBox.Image = Image.FromFile("Orange_Player3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
            }
            this.Controls.Add(PBox);
        }
        #endregion
        #region SummonBlock
        private void SummonBlock(string Colour, int XPos, int YPos)
        {
            PictureBox SBox = new PictureBox
            {
                Name = ("Block_" + XPos + " " + YPos),
                Size = new Size(SpriteSize, SpriteSize),
                Location = new Point(XPos * SpriteSize, YPos * SpriteSize),
            };
            switch (Colour)
            {
                case "Blue":
                    SBox.BackColor = Color.Blue;
                    SBox.Tag = "Blue";
                    SBox.Image = Image.FromFile("Blue_Block3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Green":
                    SBox.BackColor = Color.Green;
                    SBox.Tag = "Green";
                    SBox.Image = Image.FromFile("Green_Block3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Red":
                    SBox.BackColor = Color.Red;
                    SBox.Tag = "Red";
                    SBox.Image = Image.FromFile("Red_Block3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Orange":
                    SBox.BackColor = Color.Orange;
                    SBox.Tag = "Orange";
                    SBox.Image = Image.FromFile("Orange_Block3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Null":
                    SBox.BackColor = Color.Gray;
                    SBox.Tag = "Null";
                    SBox.Image = Image.FromFile("Neutral_Block3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
            }
            this.Controls.Add(SBox);
        }
        #endregion
        #region SummonGate
        private void SummonGate(string Colour, int XPos, int YPos)
        {
            PictureBox GBox = new PictureBox
            {
                Name = ("Gate_" + XPos + "," + YPos),
                Size = new Size(SpriteSize, SpriteSize),
                Location = new Point(XPos * SpriteSize, YPos * SpriteSize),
            };
            switch (Colour)
            {
                case "Blue":
                    GBox.Tag = "Blue"; GBox.Image = Image.FromFile("Blue_Gate3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Green":
                    GBox.Tag = "Green"; GBox.Image = Image.FromFile("Green_Gate3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Red":
                    GBox.Tag = "Red"; GBox.Image = Image.FromFile("Red_Gate3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Orange":
                    GBox.Tag = "Orange"; GBox.Image = Image.FromFile("Orange_Gate3.png"); //Removed Filepath Statement as this now uses data stored in the program.  
                    break;
                case "Null":
                    GBox.Tag = "Null"; GBox.Image = Image.FromFile("Neutral_Gate3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
            }
            this.Controls.Add(GBox);
        }
        #endregion
        #region SummonSwitch
        private void SummonSwitch(string Colour, int XPos, int YPos)
        {
            PictureBox SWBox = new PictureBox
            {
                Name = ("Switch_" + XPos + "," + YPos),
                Size = new Size(SpriteSize / 3, SpriteSize/ 3),
                Location = new Point((XPos * SpriteSize), (YPos * SpriteSize)),
            };

            switch (Colour)
            {
                case "Blue":
                    SWBox.Tag = "Blue"; SWBox.Image = Image.FromFile("Blue_Switch3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    SWBox.SizeMode = PictureBoxSizeMode.CenterImage; break;
                case "Green":
                    SWBox.Tag = "Green"; SWBox.Image = Image.FromFile("Green_Switch3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    SWBox.SizeMode = PictureBoxSizeMode.CenterImage; break;
                case "Red":
                    SWBox.Tag = "Red"; SWBox.Image = Image.FromFile("Red_Switch3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    SWBox.SizeMode = PictureBoxSizeMode.CenterImage; break;
                case "Orange":
                    SWBox.Tag = "Orange"; SWBox.Image = Image.FromFile("Orange_Switch3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    SWBox.SizeMode = PictureBoxSizeMode.CenterImage; break;
            }
            this.Controls.Add(SWBox);
        }
        #endregion
        #region SummonFlag
        private void SummonFlag(string Colour, int XPos, int YPos)
        {
            PictureBox FBox = new PictureBox
            {
                Name = ("Flag_-" + XPos + "," + YPos),
                Size = new Size(SpriteSize, SpriteSize),
                Location = new Point(XPos * SpriteSize, YPos * SpriteSize),
            };
            switch (Colour)
            {
                case "Blue":
                    FBox.Tag = "Blue"; FBox.Image = Image.FromFile("Blue_Flag3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Green":
                    FBox.Tag = "Green"; FBox.Image = Image.FromFile("Green_Flag3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Red":
                    FBox.Tag = "Red"; FBox.Image = Image.FromFile("Red_Flag3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Orange":
                    FBox.Tag = "Orange"; FBox.Image = Image.FromFile("Orange_Flag3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
                case "Null":
                    FBox.Tag = "Null"; FBox.Image = Image.FromFile("Neutral_Flag3.png"); //Removed Filepath Statement as this now uses data stored in the program. 
                    break;
            }
            this.Controls.Add(FBox);
        }
        #endregion
        #endregion
        private void UpdateTimer(object sender, EventArgs e)
        {
            OnGround = false;
            foreach (Control x in this.Controls)
            {
                string temp = x.Name;
                string[] Temp = temp.Split('_');
                #region BlockCollision
                if (x is PictureBox && (string)Temp[0] == "Block")
                {
                    if (PBox.Bounds.IntersectsWith(x.Bounds))
                    {
                            if (PBox.Tag != x.Tag) {if (Convert.ToString(x.Tag) != "Null"){ Die("");}}
                                Rectangle B = x.Bounds;
                            if (PBox.Top >= B.Top + B.Height - 21)
                            {

                                PBox.Top = B.Top + B.Height;
                                PXPos = PBox.Top;
                                if (PYVelocity < 0) { PYVelocity = 1; }
                                if (PYAcceleration < 0) { PYAcceleration = 1; }
                            }
                            else if (PBox.Top <= B.Top - B.Height + 21)
                            {
                                TempBlockTop = B.Top - B.Height;
                                OnGround = true;
                                PBox.Top = B.Top - B.Height;
                                PYPos = PBox.Top;
                                if (PYVelocity < 0) { PYVelocity = 1; }
                                if (PYAcceleration < 0) { PYAcceleration = 1; }
                                OnGround = true;
                            }
                            else if ((B.Left >= PBox.Left))
                            {
                                if (PXVelocity > 0) { PXVelocity = 0; }
                                if (PXAcceleration > 0) { PXAcceleration = 0; }
                                OnGround = false;
                                PBox.Left = B.Left - B.Width;
                                MoveRight = false;
                                PXPos = PBox.Left;
                            }
                            else if (B.Left <= PBox.Left)
                            {
                                PBox.Left = B.Left + B.Width;
                                PXPos = PBox.Left;
                                MoveLeft = false;
                                OnGround = false;
                                if (PXVelocity < 0) { PXVelocity = 0; }
                                if (PXAcceleration < 0) { PYAcceleration = 0; }
                            }
                        
                    }
                }
                #endregion
                #region GateCollision
                if (x is PictureBox && (string)Temp[0] == "Gate")
                {
                    if (PBox.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (x.Tag != PBox.Tag) { Die("Killed by hitting A" + x.Tag + "Gate"); }
                    }
                }
                #endregion
                #region Switch
                if (x is PictureBox && (string)Temp[0] == "Switch")
                {
                    if (PBox.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (x.Tag != PBox.Tag)
                        {
                            PBox.Tag = x.Tag;
                            PBox.Image = Image.FromFile(PBox.Tag + "_Player3.png "); //Removed Filepath Statement as this now uses data stored in the program. 
                        }
                    }
                }
                #endregion
                #region Flag
                if (x is PictureBox && (string)Temp[0] == "Flag") {if (PBox.Bounds.IntersectsWith(x.Bounds)) {if (x.Tag != PBox.Tag) { } else{Win();}}}
                #endregion 
            }

            PXPos = PBox.Left; PYPos = PBox.Top;
            double[] PValues = P.Calculate(PYPos, PXPos, PYVelocity, PXVelocity, PXAcceleration, PYAcceleration, OnGround, Jump, MoveLeft, MoveRight, Sprint);
            PXAcceleration = PValues[0]; PXVelocity = PValues[1]; PXPos = PValues[2];
            PYAcceleration = PValues[3]; PYVelocity = PValues[4]; PYPos = PValues[5];
            Display("X Acceleration: " + PXAcceleration);
            Display("Y Acceleration: " + PYAcceleration);
            Display("X Velocity: " + PXVelocity);
            Display("Y Velocity: " + PYVelocity);
            Display("X Pos: " + PXPos);
            Display("Y Pos: " + PYPos);
            if (OnGround){PYPos = TempBlockTop;}
            PBox.Location = new Point(Convert.ToInt32(PXPos), Convert.ToInt32(PYPos));
        }
        private void KeyDownCheck(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up || e.KeyCode == Keys.Space) {if (Jump == false) {Display("Jump Set To: True"); Jump = true;}}
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) {if (MoveLeft == false) {Display("Left Set To: True"); MoveLeft = true;}}
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) {if (MoveRight == false) {Display("Right Set To: True"); MoveRight = true;}}
            if (e.KeyCode == Keys.LShiftKey) {if (Sprint == false) {Display("Sprint Set To: True"); Sprint = true;}}
        }

        private void KeyUpCheck(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up || e.KeyCode == Keys.Space) {if (Jump == true) {Display("Jump Set To: False"); Jump = false;}}
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) {if (MoveLeft == true) {Display("Left Set To: False"); MoveLeft = false;}}
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) {if (MoveRight == true) { Display("Right Set To: False"); MoveRight = false; }}
            if (e.KeyCode == Keys.LShiftKey){ if (Sprint == true) {Display("Sprint Set To: False"); Sprint = false;}}
        }

        private void Die(string DeathObj)
        {
            PTimer.Enabled = false;
            
            string Colour = Game.GetColour(); int XPos3 = Game.GetXPos(); int YPos3 = Game.GetYPos();
            this.Controls.Remove(PBox);
            PYVelocity = 0; PXVelocity = 0; PXAcceleration = 0; PYAcceleration = 0; PYPos = YPos3 * SpriteSize; PXPos = XPos3 * SpriteSize;
            Respawn(Colour, XPos3, YPos3);
        }
        private void Win()
        {
            this.Close();
            MapScreen Ms = new MapScreen();
            Ms.ReturnToMapScreen(LvlID);
        }

        private void Respawn(string Colour, int XPos4, int YPos4)
        {
            PBox.Tag = Colour;
            PBox.Image = Image.FromFile(PBox.Tag + "_Player3.png ");
            PBox.Location = new Point((XPos4 * SpriteSize), (YPos4 * SpriteSize));
            this.Controls.Add(PBox);
            PTimer.Enabled = true;

        }

    }
}