using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjetTrainingTPI;

namespace ProjetTrainingTPI.Classes
{
    class BasicEnemy : AnimatedElementGeneric
    {
        string direction = "gauche";
        Dictionary<Texture2D, Texture2D> dictionarySpritesEnemy = new Dictionary<Texture2D, Texture2D>();
        
        public BasicEnemy(Game game) : base(game)
        {
            
        }

        public Dictionary<Texture2D, Texture2D> DictionarySpritesEnemy { get => dictionarySpritesEnemy; set => dictionarySpritesEnemy = value; }

        public void Initialize(Vector2 position)
        {
            Random rnd = new Random();
            int spriteEnemy = rnd.Next(0, 3);

            textureSprite = DictionarySpritesEnemy.ElementAt(spriteEnemy).Value;
            positionSprite = position;
            Sprite = DictionarySpritesEnemy.ElementAt(spriteEnemy).Key;
            ReverseSprite = textureSprite;
            
            
        }
        public void Update(GameTime gameTime)
        {
            if (positionSprite.X == _game.GraphicsDevice.Viewport.Width - textureSprite.Width)
            {
                textureSprite = Sprite;
                direction = "gauche";
            }
            if (positionSprite.X == 0)
            {
                textureSprite = ReverseSprite;
                direction = "droite";
            }

            if (direction == "gauche")
            {
                positionSprite.X -= 10;
            }
            else
            {
                positionSprite.X += 10;
            }
            

           
            
            base.Update(gameTime);
        }
    }
}
