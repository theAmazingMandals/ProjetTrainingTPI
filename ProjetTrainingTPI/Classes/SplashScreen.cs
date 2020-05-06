using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace ProjetTrainingTPI.Classes
{
    public class SplashScreen : Screen
    {
        KeyboardState keyState;
        Texture2D background;

        public override void LoadContent(ContentManager Content, mainGame game)
        {
            
            base.LoadContent(Content, game);
            background = Content.Load<Texture2D>("backgrounds/splashScreen");
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gametime, mainGame game)
        {
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Space))
            {
                ScreenManager.Instance.AddScreen(new TitleScreen(), game);
            }
            base.Update(gametime, game);
        }
        public override void Draw(SpriteBatch spriteBatch, Rectangle dimensions, mainGame game)
        {
            spriteBatch.Draw(background, dimensions, Color.White);
            base.Draw(spriteBatch, dimensions, game);
        }
    }
}
