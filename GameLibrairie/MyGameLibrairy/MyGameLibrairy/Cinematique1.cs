using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MyGameLibrairy
{
    public class Cinematique1
    {
        Texture2D[] images;
        string[] textes;
        int currentSlide;
        Color TexteColor,ColorBackGround;
        SpriteFont font;
        public bool display;

        public Cinematique1()
        {
            currentSlide = 0;
            TexteColor = Color.White;
            ColorBackGround = Color.BlueViolet;
            display = false;
            images = new Texture2D[4];
            textes = new string[4] { 
 
                "Donald se reposait tranquillement sur\n l'île de Cuba, avec son journal quotidien.", 
 
                "Dans son journal, on parlait d'une rumeur\n qu'un méchant scientifique voudrait détruire la \n planète et en reconstruire une autre.", 
 
                "Donald : Encore un autre fou !! ... \n(il continua de lire) il serait caché dans une base \n militaire non loin de l'île de Cuba \n Donald: C'est sur mon île !! .", 
 
                "Il décida de mener sa petite enquête lui-même,\n sous le nom de code LOXI pour ne pas dévoiler\n                                               son identité ." };

        }

        public void LoadContent(ContentManager content)
        {

            //images[0] = content.Load<Texture2D>("slide1");
            //images[1] = content.Load<Texture2D>("slide2");
            //images[2] = content.Load<Texture2D>("slide3");
            //images[3] = content.Load<Texture2D>("slide4");
            images[0] = content.Load<Texture2D>("Plage");
            images[1] = content.Load<Texture2D>("NewsPaper");
            images[2] = content.Load<Texture2D>("Bunker");
            images[3] = content.Load<Texture2D>("DebutEnquete");
            font = RessourcesLoxi.Texte;

        }



        public void Play()
        {
            currentSlide = 0;
            display = true;
        }

        public void Update()
        {
             if (display && KeyboardHelper.KeyPressed (Keys.Space)) 
            currentSlide++;

            if (currentSlide > textes.Length - 1)
                display = false;

            switch (currentSlide)
            {
                case 1: ColorBackGround = Color.Red;
                    TexteColor = Color.Black;
                    break;
                case 2:TexteColor = Color.DarkMagenta;
                    break;
                case 3: ColorBackGround = Color.Bisque;
                    TexteColor = Color.Blue;
                    break;

            }
        }



        public void Draw(SpriteBatch g, GameTime gameTime)
        {
             g.GraphicsDevice.Clear(ColorBackGround);

            if (display)
            {
                g.Draw(images[currentSlide], new Rectangle(0, 0, 800, 500), Color.White);
                g.DrawString(font, textes[currentSlide], new Vector2(30,30), TexteColor);
                g.DrawString(font, "Appuyer \n sur \n Espace", new Vector2(670,200), TexteColor);
            }

        }

    }

} 


