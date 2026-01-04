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
        Texture2D greytexture, milkytexture, browntexture, orangetexture, introTexture;
        Rectangle greyrect, milkyrect, brownrect, orangerect;
        Vector2 greyspeed, milkyspeed, brownspeed, orangespeed;
        int milk, hori, vert ;
        MouseState mousestate;
        
        Random generator = new Random();
        int back;
        
        enum Screen
        {
            intro,
            Tribbleyard
            
        }
        Screen screen;
        
        

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
            screen = Screen.intro;
            greyrect = new Rectangle(300, 10, 100, 100);
            milkyrect = new Rectangle(100, 300, 100, 100);
            brownrect = new Rectangle(100, 300,100, 100);
            orangerect = new Rectangle(100, 400, 100, 100);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            greyspeed = new Vector2(2, 2);
            milkyspeed = new Vector2(2, 0);
            brownspeed = new Vector2(0, 2);
            orangespeed = new Vector2(4,1);
            back = generator.Next(10);
            hori = 100;
            vert = 100;
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            greytexture = Content.Load<Texture2D>("grey");
            milkytexture = Content.Load<Texture2D>("Milky");
            browntexture = Content.Load<Texture2D>("brown");
            orangetexture = Content.Load<Texture2D>("orange");
            introTexture = Content.Load<Texture2D>("intro");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mousestate = Mouse.GetState();
            if (screen == Screen.intro)
            {
                if (mousestate.LeftButton == ButtonState.Pressed)
                    screen = Screen.Tribbleyard;
            }
            else if (screen == Screen.Tribbleyard)
            {
                greyrect.X += (int)greyspeed.X;
                greyrect.Y += (int)greyspeed.Y;
                milkyrect.X += (int)milkyspeed.X;
                milkyrect.Y += (int)milkyspeed.Y;
                brownrect.X += (int)brownspeed.X;
                brownrect.Y += (int)brownspeed.Y;
                orangerect.X += (int)orangespeed.X;
                orangerect.Y += (int)orangespeed.Y;
                if (greyrect.Right > 800 || greyrect.Left < 0)
                    greyspeed.X *= -1;
                if (greyrect.Bottom > _graphics.PreferredBackBufferHeight || greyrect.Top < 0)
                    greyspeed.Y *= -1;
                if (milkyrect.Right > 800 || milkyrect.Left < 0)
                    milkyspeed.X *= -1;
                if (brownrect.Bottom > 700)
                    brownrect = new Rectangle(100, -100, 100, 100);
                if (orangerect.Right > 800 || orangerect.Left < 0)
                    orangespeed.X *= -1;
                if (orangerect.Bottom > _graphics.PreferredBackBufferHeight || orangerect.Top < 0)
                    orangespeed.Y *= -1;
            }

               
            
            
                













            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)


        {
            
           

            _spriteBatch.Begin();
            if(screen == Screen.intro)
            {
                _spriteBatch.Draw(introTexture, new Rectangle (0,0, 800,500), Color.White);
            }
            else if (screen == Screen.Tribbleyard)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                if (milkyrect.Right > 800 || milkyrect.Left < 0)
                    GraphicsDevice.Clear(Color.Green);
                if (orangerect.Bottom > _graphics.PreferredBackBufferHeight || orangerect.Top < 0)
                    Console.Beep(800, 50);
                if (orangerect.Right > 800 || orangerect.Left < 0)
                    Console.Beep(800, 50);






                _spriteBatch.Draw(greytexture, greyrect, Color.White);
                _spriteBatch.Draw(milkytexture, milkyrect, Color.White);
                _spriteBatch.Draw(browntexture, brownrect, Color.White);
                _spriteBatch.Draw(orangetexture, orangerect, Color.White);

            }


            _spriteBatch.End();




          

            base.Draw(gameTime);
        }
    }
}
