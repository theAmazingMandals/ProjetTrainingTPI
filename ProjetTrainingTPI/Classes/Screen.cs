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
    public class Screen
    {
        protected ContentManager content;
        public virtual void Initialize(mainGame game)
        {
        }
        public virtual void LoadContent(ContentManager Content, mainGame game)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
        }
        public virtual void UnloadContent()
        {
            content.Unload();
        }
        public virtual void Update(GameTime gametime, mainGame game)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch, Rectangle dimensions, mainGame game)
        {

        }
    }
}
