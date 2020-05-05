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
    public class ScreenManager
    {
        #region Variables

        GameScreen currentScreen;
        GameScreen newScreen;

        ContentManager content;

        /// <summary>
        /// ScreenManager Instance
        /// </summary>
        private static ScreenManager instance;

        /// <summary>
        /// Screen stack
        /// </summary>
        Stack<GameScreen> screenStack = new Stack<GameScreen>();

        /// <summary>
        /// Screen width and height
        /// </summary>
        Vector2 dimensions;


        #endregion

        #region Properties

        public static ScreenManager Instance {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;
            }
            set => instance = value;
        }

        public Vector2 Dimensions { get => dimensions; set => dimensions = value; }

        #endregion

        #region Main Methods
        public void AddScreen(GameScreen screen)
        {
            newScreen = screen;
            screenStack.Push(screen);
            currentScreen.UnloadContent();
            currentScreen = newScreen;
            currentScreen.LoadContent(content); 
        }
        public void Initialize()
        {
            currentScreen = new SplashScreen();
        }
        public void LoadContent(ContentManager Content)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content);
        }
        public void Update(GameTime gametime)
        {
            currentScreen.Update(gametime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
        #endregion

    }
}
