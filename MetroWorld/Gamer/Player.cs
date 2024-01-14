using Microsoft.Xna.Framework;
using MetroWorld.Bullet;
using MetroWorld.MyInput;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace MetroWorld.Gamer
{
    class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private KeyboardState keyState;
        private Rectangle collision;
        Dictionary<PlayerBullet, bool> bullets = new Dictionary<PlayerBullet, bool>();

        private bool isShoot;
        private int hp;
        private int speed;

        public Vector2 Position
        {
            get => position;
        }

        public Rectangle Collision
        {
            get => collision;
        }

        public Player()
        {
            texture = null;
            position = new Vector2(0, 450);
            for (int i = 0; i < 30; i++) bullets.Add(new PlayerBullet(position), false);
            hp = 10;
            speed = 10;
            isShoot = false;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("RandomGirl");
            foreach (var bullet in bullets.Keys.ToList()) bullet.LoadContent(content);
        }

        public void Update()
        {
            CheckBorders();
            keyState = MyKeyboard.GetState();
            CheckKeyboard(keyState);
            Shoot(keyState);

            foreach (var bullet in bullets.Keys.ToList()) if (bullets[bullet]) bullet.Update();

            collision = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);

            foreach (var bullet in bullets.Keys.ToList())
            {
                if (bullets[bullet]) bullet.Draw(spriteBatch);
            }
        }

        private void Shoot(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.Space) && MyKeyboard.hasNotBeenPressed(Keys.Space)) //&& bullet.IsAbroad)
            {
                foreach (var bullet in bullets.Keys.ToList())
                {
                    if (!bullets[bullet])
                    { 
                        bullets[bullet] = true;
                        bullet.Position = position;
                        bullet.IsAbroad = false;
                        break;
                    }
                }
                isShoot = true;
            }       
        }

        private void CheckBorders()
        {
            int width = 1200;
            int height = 800;
            if (position.X >= width - texture.Width) position.X = width - texture.Width;
            if (position.X <= 0) position.X = 0;
            if (position.Y <= 0) position.Y = 0;
            if (position.Y >= height - texture.Height) position.Y = height - texture.Height;
        }

        private void CheckKeyboard(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.D)) position.X += speed;
            else if (keyState.IsKeyDown(Keys.A)) position.X -= speed;
            else if (keyState.IsKeyDown(Keys.W)) position.Y -= speed;
            else if (keyState.IsKeyDown(Keys.S)) position.Y += speed;
        }
    }
}
