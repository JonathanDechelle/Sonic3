using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Sonic3
{
    class Menu
    {
        Vector2 Position;
        public bool Delete,Exit;
        string TexteApparent = "";
        

        public Menu(PlayerSonic Joueur,Vector2 Position)
        {
            if(Joueur!=null)
            Joueur.Enabled = true;
            this.Position=new Vector2(Position.X-300,Position.Y-100);
        }

        public void Update(PlayerSonic Joueur)
        {
            if (KeyboardHelper.KeyPressed(Keys.Enter))
            {
                Delete = true;
                if(Joueur!=null)
                Joueur.Enabled = false;
            }
            else if (KeyboardHelper.KeyPressed(Keys.E))
                Exit = true;
            else if (KeyboardHelper.KeyPressed(Keys.M))
            {
                if (MediaPlayer.IsMuted) { MediaPlayer.IsMuted = false; TexteApparent = "Mute OFF"; }
                else { MediaPlayer.IsMuted = true; TexteApparent = "Mute ON"; }
            }
            else if (KeyboardHelper.KeyPressed(Keys.B))
            {
                if (SoundEffect.MasterVolume == 0) { SoundEffect.MasterVolume = 1.0f; TexteApparent = "Bruit ON"; }
                else { SoundEffect.MasterVolume = 0; TexteApparent = "Bruit OFF"; }
            }

            
        }

        public void Draw(SpriteBatch g)
        {
            g.Draw(RessourceSonic3.Test,new Rectangle((int)Position.X,(int)Position.Y+20,550,160),Color.LightSteelBlue);
            g.Draw(RessourceSonic3.CadreAnim, new Rectangle((int)Position.X-175, (int)Position.Y, 1800, 200), Color.White);
            g.Draw(RessourceSonic3.SonicPause, new Rectangle((int)Position.X+340, (int)Position.Y+27, 185, 150), Color.White);
            g.DrawString(RessourceSonic3.EcritureInformative, "E POUR REVENIR AU MENU", new Vector2((int)Position.X+30, (int)Position.Y+30), Color.Red);
            g.DrawString(RessourceSonic3.EcritureInformative, "ENTER POUR REVENIR AU JEU", new Vector2((int)Position.X + 30, (int)Position.Y + 60), Color.Blue);
            g.DrawString(RessourceSonic3.EcritureInformative, "M DESACTIVE LA MUSIQUE", new Vector2((int)Position.X + 30, (int)Position.Y + 90), Color.Yellow);
            g.DrawString(RessourceSonic3.EcritureInformative, "B DESACTIVE LE BRUITAGE", new Vector2((int)Position.X + 30, (int)Position.Y + 120), Color.OrangeRed);
            g.DrawString(RessourceSonic3.EcritureInformative, TexteApparent, new Vector2((int)Position.X + 60, (int)Position.Y + 150), Color.Black);
            
        }
    }
}
