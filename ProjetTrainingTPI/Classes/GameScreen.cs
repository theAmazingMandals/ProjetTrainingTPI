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
    class GameScreen : Screen
    {
        #region Variables
        Player1 player1;
        Player2 player2;
        BasicEnemy basicEnemy;

        List<BasicEnemy> enemyPool = new List<BasicEnemy>();

        Background mainBackGround;
        Plateform ground;
        #endregion

        public override void Initialize(mainGame game)
        {
            player1 = new Player1(game);
            player2 = new Player2(game);
            basicEnemy = new BasicEnemy(game);

            mainBackGround = new Background(game);
            ground = new Plateform(game);

            base.Initialize(game);
        }
        public override void LoadContent(ContentManager Content, mainGame game)
        {
            

            Texture2D player1Texture = Content.Load<Texture2D>("sprites/feu");
            Vector2 player1Position = new Vector2(0, game.GraphicsDevice.Viewport.Height - 300);
            player1.ReverseSprite = Content.Load<Texture2D>("sprites/feuInverse");

            Texture2D player2Texture = Content.Load<Texture2D>("sprites/glace");
            Vector2 player2Position = new Vector2(0, game.GraphicsDevice.Viewport.Height - 300);
            player2.ReverseSprite = Content.Load<Texture2D>("sprites/glaceInverse");

            Vector2 enemyPosition = new Vector2(game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height - 120);
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
            mainBackGround.rectangleSprite = new Rectangle(0, 0, game.GraphicsDevice.Viewport.Width, game.GraphicsDevice.Viewport.Height);

            Texture2D groundTexture = Content.Load<Texture2D>("textures/sol");

            ground.rectangleSprite = new Rectangle(-10, game.GraphicsDevice.Viewport.Height - 93, game.GraphicsDevice.Viewport.Width + 10, 300);

            // TODO: use this.Content to load your game content here
            mainBackGround.Initialize(mainbackgroundTexture);
            ground.Initialize(groundTexture);

            player1.Initialize(player1Texture, player1Position);
            player2.Initialize(player2Texture, player2Position);
            basicEnemy.Initialize(enemyPosition);

            base.LoadContent(Content, game);     
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gametime, mainGame game)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                game.Exit();


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

            basicEnemy.Update(gametime);
            player1.Update(gametime);
            player2.Update(gametime);
            base.Update(gametime, game);
        }
        public override void Draw(SpriteBatch spriteBatch, Rectangle dimensions, mainGame game)
        {
            mainBackGround.Draw(spriteBatch);
            ground.Draw(spriteBatch);

            basicEnemy.Draw(spriteBatch);
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            base.Draw(spriteBatch, dimensions, game);
        }
    }
}
