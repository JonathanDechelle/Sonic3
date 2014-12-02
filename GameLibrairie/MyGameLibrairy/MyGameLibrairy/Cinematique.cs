using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace MyGameLibrairy
{
    /// <summary>
    /// Classe servant a crée un se,blant de cinematique
    /// </summary>
   public class Cinematique
    {

       // Texture2D[] images;

        string[] textes;

        int currentSlide;
        SpriteFont font;
        bool display;
        Vector2 Position;
        
        public  Cinematique(Vector2 NewPosition,SpriteFont NewFont)
        {
            currentSlide = 0;
            display = false;
            textes = new string[4] { 
 
                "C'est l'histoire d'un peuple de chats vivant fièrement et\npaisiblement sur la coline du mont Shizen.", 
 
                "Mais un jour, la divinité d'un clan jaloux se réveilla, lui permettant\nde rassembler une armée de cadavres afin d'exterminer les\nautres clans.", 
 
                "Toute la tribu fut rapidement dévastée par cette armée malfaisante.", 
 
                "C'est ainsi que commenca la longue quête d'Aneiko, héro des Shizen,\nqui espère sauver son peuple grâce au pouvoir de la nature." };

            Position = NewPosition;
            font = NewFont;

        }

        public void Play()
        {
            currentSlide = 0;
            display = true;
        }

        public void Update()
        {
            if (display && KeyboardHelper.KeyPressed (Keys.L)) 
            currentSlide++;

            if (currentSlide > textes.Length - 1)
                display = false;
        }



        public void Draw(SpriteBatch g, GameTime gameTime)
        {

            if (display)
            {
                g.DrawString(font, textes[currentSlide],Position, Color.White);
            }

        }

    }


}

