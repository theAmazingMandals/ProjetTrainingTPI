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
    public class SplashScreen : GameScreen
    {
        KeyboardState keyState;
        SpriteFont font;

        public override void LoadContent(ContentManager Content)
        {
            
            base.LoadContent(Content);
            if (font == null)
            {
                font = content.Load<SpriteFont>("test");
            }
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gametime)
        {
            keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Space))
            {
                ScreenManager.Instance.AddScreen(new TitleScreen());
            }
            base.Update(gametime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "SplashScreen", new Vector2(100, 100), Color.Black);
            base.Draw(spriteBatch);
        }
    }
}
