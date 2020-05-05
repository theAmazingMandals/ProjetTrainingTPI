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
    class StaticElementGeneric
    {
        public Texture2D textureSprite;
        public Vector2 positionSprite;
        public Rectangle rectangleSprite;
        protected Game _game;

        public StaticElementGeneric(Game game)
        {
            _game = game;
        }
        public void Initialize(Texture2D texture)
        {
            textureSprite = texture;
            

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(textureSprite, rectangleSprite, Color.White);

        }
    }
}
