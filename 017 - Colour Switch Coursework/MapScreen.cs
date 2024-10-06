using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace CourseWork_V1._0._1
{
    public partial class MapScreen : Form
    {
        bool Lvl1Completed;
        bool Lvl2Completed;
        bool Lvl3Completed;
        bool Lvl4Completed;
        private bool devMode;
        #region Console Hide/Show
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        #endregion
        public MapScreen() { InitializeComponent();}
        public void GameInfo(bool Dev, bool Multiplayer)
        {
            devMode = Dev;
            this.Show();
            if (devMode == true)
            {
                // Show Console Window
                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_SHOW);
                Display("Loaded with DevMode" + devMode);
            }
        }
        private void MoveToMenu(object sender, EventArgs e)
        {
            Display("Going back to main menu");
            Program p = new Program();
            p.Show();
            this.Close();
        }
        private void Display(string DisplayText) {if (devMode == true) {Console.WriteLine("MapScreen:" + DisplayText);}}

        private void LoadLvl1(object sender, EventArgs e)
        {
            LevelForm L = new LevelForm();
            Display("Going to Level 1 with devMode set to: " + devMode);
            this.Close();
            L.Loader(1, devMode);
        }
        private void LoadLvl2(object sender, EventArgs e)
        {
            LevelForm L = new LevelForm();
            Display("Going to Level 2 with devMode set to: " + devMode);
            this.Close();
            L.Loader(2, devMode);
        }
        private void LoadLvl3(object sender, EventArgs e)
        {
            LevelForm L = new LevelForm();
            Display("Going to Level 3 with devMode set to: " + devMode);
            this.Close();
            L.Loader(3, devMode);
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            LevelForm L = new LevelForm();
            Display("Going to Level 4 with devMode set to: " + devMode);
            this.Close();
            L.Loader(4, devMode);
        }
        public void ReturnToMapScreen(int LevelID)
        {
            this.Show();

            switch (LevelID)
            {
                case 1: Lvl1Completed = true; break;
                case 2: Lvl2Completed = true; break;
                case 3: Lvl3Completed = true; break;
                case 4: Lvl4Completed = true; break;
            }
        }

        private void MapScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
