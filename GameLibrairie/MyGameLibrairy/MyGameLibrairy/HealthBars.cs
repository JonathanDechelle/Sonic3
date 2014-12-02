using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyGameLibrairy
{
    /// <summary>
    /// Classe servant à crée des progress bar ou bien des
    /// barres de vie
    /// </summary>
    public class HealthBars
    {
        Texture2D Texture;
        Vector2 Position;
        Rectangle Rectangle;
        Player Joueur;
        bool Centrer,barEnnemy;
        String TexteDeMort;
        Color CouleurTMort;
        public bool GameOver;

        public HealthBars(Texture2D Texture,Vector2 Position,bool Centrer,Player Joueur,bool Ennemybar)
        {
            this.Texture = Texture;
            this.Position = Position;
            this.Centrer = Centrer;
            this.Joueur = Joueur;
            Rectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            barEnnemy = Ennemybar;
            if (barEnnemy) { TexteDeMort = "Win"; CouleurTMort = Color.Green; } else { TexteDeMort = "Game Over"; CouleurTMort = Color.Red; }
            GameOver = false;
        }

        public void Update(bool Detection,int Force)
        {
            if (Centrer)
            {
                Position.X = Joueur.Position.X - 260;
                Position.Y = Joueur.Position.Y - 220;
            }

            //if (KeyboardHelper.KeyHold(Keys.P))
            if(Detection)
                Rectangle.Width -= Force;

            if (Rectangle.Width <= 0)
                GameOver = true;
        }

        public void Draw(SpriteBatch g)
        {
            g.Draw(Texture, Position, Rectangle, Color.White);
            if (GameOver)
                g.DrawString(RessourcesLoxi.Texte, TexteDeMort, Position, CouleurTMort);

        }
    }
}
