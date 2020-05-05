using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ProjetTrainingTPI;
using System.Threading;
using Microsoft.Xna.Framework.Graphics;

namespace ProjetTrainingTPI.Classes
{
    class Player2 : AnimatedElementGeneric
    {
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;
        float timer = 5f;
        bool fall = true;
        bool jumpingMode = false;
        

        public Player2(mainGame game) : base(game)
        {

        }

        public float Timer { get => timer; set => timer = value; }
        public bool Fall { get => fall; set => fall = value; }
        public bool JumpingMode { get => jumpingMode; set => jumpingMode = value; }
        

        
        public void Update(GameTime gameTime)
        {

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();


            if (currentKeyboardState.IsKeyDown(Keys.Up) && previousKeyboardState.IsKeyUp(Keys.Up) && Timer == 5f)
            {

                Fall = false;
                JumpingMode = true;

            }

            if (JumpingMode == true)
            {
                positionSprite.Y -= 20;
                Timer -= 0.3f;

                if (Timer <= 0)
                {

                    Fall = true;
                    JumpingMode = false;
                }

            }


            if (Fall == true)
            {
                positionSprite.Y += 10;
            }



            if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                positionSprite.X -= 13;
                textureSprite = ReverseSprite;
            }
            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                positionSprite.X += 13;
                textureSprite = Sprite;
            }
            positionSprite.X = MathHelper.Clamp(positionSprite.X, 0, _game.GraphicsDevice.Viewport.Width - textureSprite.Width);
            



            base.Update(gameTime);
        }
    }
}
