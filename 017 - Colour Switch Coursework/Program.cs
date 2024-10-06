using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;



namespace CourseWork_V1._0._1
{
    public partial class Program : Form
    {
        bool devMode;
        public int errorCode = -1;
        #region Variable Declaration; 
        private Button StartGame;
        private Button StartGameDev;
        private Button MultiplayerBtn;
        private Button QuitBtn;
        #endregion
        #region Console Hide/show
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        #endregion
        public static void Main(string[] args)
        {
            var handle = GetConsoleWindow();

            // Hide Console
            ShowWindow(handle, SW_HIDE);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Application Starting");
            // <Open Form>
            Application.EnableVisualStyles(); 
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Program());
            
            // <\Open Form>

            //<Program End>

            //<\Program End> 

        }

        public Program()
        {
            InitializeComponent(); //Run Component Init - this has to be done as it is not a defualt procedure for a console application
        }

        private void InitializeComponent()
        {
            this.StartGame = new System.Windows.Forms.Button();
            this.StartGameDev = new System.Windows.Forms.Button();
            this.MultiplayerBtn = new System.Windows.Forms.Button();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartGame
            // 
            this.StartGame.Location = new System.Drawing.Point(12, 12);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(260, 56);
            this.StartGame.TabIndex = 0;
            this.StartGame.Text = "Start Game";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // StartGameDev
            // 
            this.StartGameDev.Location = new System.Drawing.Point(12, 74);
            this.StartGameDev.Name = "StartGameDev";
            this.StartGameDev.Size = new System.Drawing.Size(260, 56);
            this.StartGameDev.TabIndex = 1;
            this.StartGameDev.Text = "Start as Developer";
            this.StartGameDev.UseVisualStyleBackColor = true;
            this.StartGameDev.Click += new System.EventHandler(this.StartGameAsDev_Click);
            // 
            // MultiplayerBtn
            // 
            this.MultiplayerBtn.Location = new System.Drawing.Point(12, 136);
            this.MultiplayerBtn.Name = "MultiplayerBtn";
            this.MultiplayerBtn.Size = new System.Drawing.Size(260, 56);
            this.MultiplayerBtn.TabIndex = 2;
            this.MultiplayerBtn.Text = "Multiplayer";
            this.MultiplayerBtn.UseVisualStyleBackColor = true;
            this.MultiplayerBtn.Click += new System.EventHandler(this.MultiPlayer_Click);
            // 
            // QuitBtn
            // 
            this.QuitBtn.Location = new System.Drawing.Point(12, 198);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(260, 56);
            this.QuitBtn.TabIndex = 3;
            this.QuitBtn.Text = "Quit";
            this.QuitBtn.UseVisualStyleBackColor = true;
            this.QuitBtn.Click += new System.EventHandler(this.Quit_Click);
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.MultiplayerBtn);
            this.Controls.Add(this.StartGameDev);
            this.Controls.Add(this.StartGame);
            this.Name = "Program";
            this.RightToLeftLayout = true;
            this.Load += new System.EventHandler(this.Program_Load);
            this.ResumeLayout(false);

        } //Component init - automated process

        private void StartGame_Click(object sender, EventArgs e)
        {
            MapScreen MS = new MapScreen();
            this.Hide();
            MS.GameInfo(false, false);
        }

        private void StartGameAsDev_Click(object sender, EventArgs e)
        {
            devMode = true; 
            MapScreen MS = new MapScreen();
            this.Hide();
            MS.GameInfo(true, false);
        }

        private void MultiPlayer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a Work in progress, and is not currently available");
        }

        private void Quit_Click(object sender, EventArgs e)

        {
            Console.Clear();
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_SHOW);
            System.Windows.Forms.Application.ExitThread();
            this.Close();
            errorCode = 0;
            
            Exit();
        }

        private void Exit()
        {
            Console.WriteLine("Exiting With Code: 0");
            Console.WriteLine("You can check the error dictionary by typing in 'Show Error Codes' or hit enter to exit'");
            string temp = Console.ReadLine();
            if (temp == "Show Error Codes")
            {
                SED(errorCode);
                Console.WriteLine("Press Enter To Quit");
            }
        }

        private void SED(int Code)  //Show Error Dictionary
        {
            Console.Clear();
            Console.WriteLine("Your current error is " + Code);
            Console.WriteLine("This means that:");
            Console.ForegroundColor = ConsoleColor.Red;
            switch(Code)
            {
                case 0:
                    
                    Console.WriteLine("The Program was closed by the user"); 
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Type ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("'Other'");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("to see the full dictionary or hit enter to close");
            string temp = Console.ReadLine();
            if (temp == "Other")
            {
                ErrorDictionarDisplay();
            }
        }

        private void ErrorDictionarDisplay()
        {
            Console.Clear();
            Console.WriteLine("Error Code -1: Uknown Error");
            Console.WriteLine("Error Code 0: User Exited the program");
            Console.WriteLine("Error Code 1: Stack Overflow Error");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private void Program_Load(object sender, EventArgs e)
        {

        }
    }
}
