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

        Screen currentScreen;
        Screen newScreen;

        ContentManager content;

        /// <summary>
        /// ScreenManager Instance
        /// </summary>
        private static ScreenManager instance;

        /// <summary>
        /// Screen stack
        /// </summary>
        Stack<Screen> screenStack = new Stack<Screen>();

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
        public void AddScreen(Screen screen, mainGame game)
        {
            newScreen = screen;
            screenStack.Push(screen);
            currentScreen.UnloadContent();
            currentScreen = newScreen;
            currentScreen.Initialize(game);
            currentScreen.LoadContent(content, game);
           
        }
        public void Initialize(mainGame game)
        {
            
                currentScreen = new SplashScreen();
                      
        }
        public void LoadContent(ContentManager Content, mainGame game)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content, game);
        }
        public void Update(GameTime gametime, mainGame game)
        {
            currentScreen.Update(gametime, game);
        }
        public void Draw(SpriteBatch spriteBatch, Rectangle dimensions, mainGame game)
        {
            currentScreen.Draw(spriteBatch, dimensions, game);
        }
        #endregion

    }
}
