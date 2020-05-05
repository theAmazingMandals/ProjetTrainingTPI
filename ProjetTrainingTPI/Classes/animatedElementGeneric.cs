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
    class AnimatedElementGeneric : StaticElementGeneric
    {
        bool visible = true;
        Texture2D reverseSprite;
        Texture2D sprite;

        public bool Visible { get => visible; set => visible = value; }
        public Texture2D ReverseSprite { get => reverseSprite; set => reverseSprite = value; }
        public Texture2D Sprite { get => sprite; set => sprite = value; }

        public AnimatedElementGeneric(Game game) : base(game)
        {

        }
        public void Initialize(Texture2D texture, Vector2 position)
        {
            textureSprite = texture;
            positionSprite = position;
            Sprite = texture;

        }

        public void Update(GameTime gameTime)
        {
                rectangleSprite = new Rectangle((int)positionSprite.X, (int)positionSprite.Y, textureSprite.Width, textureSprite.Height);     
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                spriteBatch.Draw(textureSprite, rectangleSprite, Color.White);
            }
        }
        
    }
}
