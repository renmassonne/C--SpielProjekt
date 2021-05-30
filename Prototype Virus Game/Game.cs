using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Prototype_Virus_Game
{

    public partial class Game : Form
    {
        public static Game instance;
        Point SpawnPoint;

        public Bitmap hinterbmp;   //Handle für Hintergrund, der im Konstruktor geladen wird.
        public Bitmap hinterbmp1;
        public Bitmap anzeige;        
        public Bitmap characterRight;
        public Bitmap characterLeft;
        public Bitmap character;
        
       
        public Bitmap platform;
        
        public int x, y;    //Koordinaten des Balls

        

        public Game()
        {
            InitializeComponent();
            instance = this;
            StartLevel();

            hinterbmp = new Bitmap("lvl1.bmp"); //Hintergrundbild laden (liegt in bin\Debug\... bei der exe)
            hinterbmp1 = new Bitmap(hinterbmp, 1280, 720);
            Bitmap chaRight = new Bitmap("characterRight.png");
            characterRight = new Bitmap(chaRight, 103, 167);
            Bitmap chaLeft = new Bitmap("characterLeft.png");
            characterLeft = new Bitmap(chaLeft, 103, 167);
            anzeige = new Bitmap(1280, 720);
            platform = new Bitmap("platform.png");        
            pbBackGround.ClientSize = hinterbmp1.Size; // Größe der PictureBox an die Größe des Hintergrunds anpassen
            pbBackGround.Image = hinterbmp1;    //Hintergrund anzeigen lassen
            x = 350;            //Der Ball startet in der Bildmitte
            y = 520;
            DoubleBuffered = true;

            character = characterRight;
            Graphics gb = Graphics.FromImage(anzeige);  //Im Bitmap anzeige wird die aktuelle ansicht zusammengesetzt
            gb.DrawImage(hinterbmp1, 0, 0, 1280, 720); //Bisherige ansicht mit Hintergrund überdecken (löschen)
            gb.DrawImage(platform, x, y, 326, 95);  // Unseren Ball als roten Kreis an seine Koordinaten setzen
            gb.DrawImage(platform, 550, 350, 326, 95);  // Unseren Ball als roten Kreis an seine Koordinaten setzen
            gb.DrawImage(character, 100, GameState.GroundLevel, 103, 167);
            gb.Dispose(); //Ressourcen des lokalen Graphics-Objekts wieder feigeben
            
            // 2. Nun lassen wir die aktuelle Ansicht anzeigen
            pbBackGround.Image = anzeige; // Die aktuelle Ansicht auf den Bitmap anzeige in der PictureBox anzeigen lassen
        }


        private void Game_Load(object sender, EventArgs e)
        {
            pbCharacter.BackColor = Color.Transparent;
          //pbCharacter.Parent = pbBackGround;
            pbCharacter.Location = SpawnPoint;           
            pbCharacter.BringToFront();
           

            pbPlatform.BackColor = Color.Transparent;
            pbPlatform.Location = new Point(350, 450);
            pbPlatform.BringToFront();


            pbCharacterBounds.Size = new Size(103, 167);
            pbCharacterBounds.Location = new Point(100, 495);
            //pbCharacterBounds.BringToFront();
            pbCharacterBounds.Visible = false;

           
            pbPlatform1.Size = new Size(326, 95);
            pbPlatform1.Location = new Point(350, 520);
            pbPlatform1.BringToFront();
            pbPlatform1.Visible = false;

           
            pbPlatform2.Size = new Size(326, 95);
            pbPlatform2.Location = new Point(550, 350);
            pbPlatform2.BringToFront();
            pbPlatform2.Visible = false;


            for (int i = 0; i < 10; i++)
            {
                var virus = new Virus();
                UiComponents.AddVirus(virus);
                ((System.ComponentModel.ISupportInitialize)(virus)).BeginInit();
                this.Controls.Add(virus);
                ((System.ComponentModel.ISupportInitialize)(virus)).EndInit();
            }

            foreach (var virus in UiComponents.Viruses)
            {
                virus.BackColor = Color.Transparent;
                virus.Parent = pbBackGround;
            }


        }

        private void StartLevel()
        {
            ClientSize = new Size(1280, 720);
            GameState.GroundLevel = 495;
            FormBorderStyle = FormBorderStyle.None;               
            DoubleBuffered = true;
            SpawnPoint = new Point(100, 485);
        }

        public void ChangeResolution()
        {
            (int, int) currentLocation = (pbCharacter.Location.X, pbCharacter.Location.Y);
            if (GameState.Fullscreen == false)
            {

                instance.ClientSize = new Size(1920, 1080);
                instance.WindowState = FormWindowState.Normal;
                instance.CenterToScreen();
                GameState.GroundLevel = 850;
                GameState.Fullscreen = true;
                pbCharacter.Location = new Point((int)Math.Round(currentLocation.Item1 * 1.5), GameState.GroundLevel);

            }
            else
            {
                instance.ClientSize = new Size(1280, 720);
                instance.WindowState = FormWindowState.Normal;
                instance.CenterToScreen();
                GameState.GroundLevel = 515;
                GameState.Fullscreen = false;
                pbCharacter.Location = new Point((int)Math.Round(currentLocation.Item1 / 1.5), GameState.GroundLevel);
            }
        }

       
    }
}
