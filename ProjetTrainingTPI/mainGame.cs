using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Xml;
using System;
using ProjetTrainingTPI.Classes;
using System.Collections.Generic;

namespace ProjetTrainingTPI
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class mainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player1 player1;
        Player2 player2;

        BasicEnemy basicEnemy;

        List<BasicEnemy> enemyPool = new List<BasicEnemy>();
        
        Background mainBackGround;
        Plateform ground;

        
        

        public mainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player1 = new Player1(this);
            player2 = new Player2(this);
            basicEnemy = new BasicEnemy(this);

            ScreenManager.Instance.Initialize();
            ScreenManager.Instance.Dimensions = new Vector2(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            
            //Paramètres pour le plein écran
            graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            mainBackGround = new Background(this);
            ground = new Plateform(this);
            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D player1Texture = Content.Load<Texture2D>("sprites/feu");
            Vector2 player1Position = new Vector2(0, GraphicsDevice.Viewport.Height - 300);
            player1.ReverseSprite = Content.Load<Texture2D>("sprites/feuInverse");

            Texture2D player2Texture = Content.Load<Texture2D>("sprites/glace");
            Vector2 player2Position = new Vector2(0, GraphicsDevice.Viewport.Height - 300);
            player2.ReverseSprite = Content.Load<Texture2D>("sprites/glaceInverse");

            Vector2 enemyPosition = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height - 120);
            Texture2D enemyTexture1 = Content.Load<Texture2D>("sprites/insecteVertInverse");   
            Texture2D ReverseSpriteEnemy1 = Content.Load<Texture2D>("sprites/insecteVert");

            Texture2D enemyTexture2 = Content.Load<Texture2D>("sprites/insecteRoseInverse");
            Texture2D ReverseSpriteEnemy2 = Content.Load<Texture2D>("sprites/insecteRose");

            Texture2D enemyTexture3 = Content.Load<Texture2D>("sprites/insecteBleuInverse");
            Texture2D ReverseSpriteEnemy3 = Content.Load<Texture2D>("sprites/insecteBleu");

            basicEnemy.DictionarySpritesEnemy.Add(enemyTexture1, ReverseSpriteEnemy1);
            basicEnemy.DictionarySpritesEnemy.Add(enemyTexture2, ReverseSpriteEnemy2);
            basicEnemy.DictionarySpritesEnemy.Add(enemyTexture3, ReverseSpriteEnemy3);


            Texture2D mainbackgroundTexture = Content.Load<Texture2D>("backgrounds/volcan");
            mainBackGround.rectangleSprite = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            Texture2D groundTexture = Content.Load<Texture2D>("textures/sol");

            ScreenManager.Instance.LoadContent(Content);
            ground.rectangleSprite = new Rectangle(-10, GraphicsDevice.Viewport.Height - 93, GraphicsDevice.Viewport.Width + 10, 300);

            // TODO: use this.Content to load your game content here
            mainBackGround.Initialize(mainbackgroundTexture);
            ground.Initialize(groundTexture);

            player1.Initialize(player1Texture, player1Position);
            player2.Initialize(player2Texture, player2Position);
            basicEnemy.Initialize(enemyPosition);
        }

        
        
        protected override void Update(GameTime gameTime)
        {
            

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
            if (player1.rectangleSprite.Intersects(ground.rectangleSprite))
            {
                player1.positionSprite.Y = player1.positionSprite.Y - 10;

                player1.Timer = 5f;
            }
            if (player2.rectangleSprite.Intersects(ground.rectangleSprite))
            {
                player2.positionSprite.Y = player2.positionSprite.Y - 10;

                player2.Timer = 5f;
            }
            if (player1.rectangleSprite.Intersects(basicEnemy.rectangleSprite))
            {
                player1.Visible = false;
                
            }
            if (player2.rectangleSprite.Intersects(basicEnemy.rectangleSprite))
            {
                player2.Visible = false;
            }
            // TODO: Add your update logic here
            ScreenManager.Instance.Update(gameTime);

            basicEnemy.Update(gameTime);
            player1.Update(gameTime);
            player2.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);

            

            mainBackGround.Draw(spriteBatch);
            ground.Draw(spriteBatch);

            basicEnemy.Draw(spriteBatch);
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            ScreenManager.Instance.Draw(spriteBatch);
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
