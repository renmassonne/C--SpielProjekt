﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_Virus_Game
{
    public static class UiComponents
    {
        public static List<PictureBox> Components { get; internal set; }

        private static PictureBox character;
        public static PictureBox Character {
            get
            {
                return character;
            }
            internal set
            {
                character = value; 
                Components.Add(value); 
            }
        }

        private static PictureBox platform;
        public static PictureBox Platform {
            get
            {
                return platform;
            }
            internal set
            {
                platform = value; 
                Components.Add(value); 
            }
        }

        private static PictureBox backGround;
        public static PictureBox BackGround
        {
            get
            {
                return backGround;
            }
            internal set
            {
                backGround = value;
                Components.Add(value);
            }
        }
        private static PictureBox virus;
        public static PictureBox Virus 
           {
            get
            {
                return virus;
            }
            internal set
            {
                virus = value;
                Components.Add(value);
            }
        }
    }
}
