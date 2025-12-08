using System;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace animation_tut
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D greytexture, milkytexture;
        Rectangle greyrect, milkyrect;
        Vector2 greyspeed, milkyspeed;
        int milk;
        Random generator = new Random();
        int back;
        
        
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            greyrect = new Rectangle(300, 10, 100, 100);
            milkyrect = new Rectangle(100, 300, 100, 100);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            greyspeed = new Vector2(2, 2);
            milkyspeed = new Vector2(2, 0);
            back = generator.Next(10);
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            greytexture = Content.Load<Texture2D>("grey");
            milkytexture = Content.Load<Texture2D>("Milky");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            greyrect.X += (int)greyspeed.X;
            greyrect.Y += (int)greyspeed.Y;
            milkyrect.X += (int)milkyspeed.X;
            milkyrect.Y += (int)milkyspeed.Y;
            if (greyrect.Right > 800 || greyrect.Left < 0)
                greyspeed.X *= -1;
            if (greyrect.Bottom > _graphics.PreferredBackBufferHeight || greyrect.Top < 0)
                greyspeed.Y *= -1;
            if (milkyrect.Right > 800 || milkyrect.Left < 0)
                milkyspeed.X *= -1;
           











            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
           

            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (milkyrect.Right > 800 || milkyrect.Left < 0)
                GraphicsDevice.Clear(Color.Green);
            


            _spriteBatch.Draw(greytexture, greyrect, Color.White);
            _spriteBatch.Draw(milkytexture, milkyrect, Color.White);


            _spriteBatch.End();




          

            base.Draw(gameTime);
        }
    }
}
