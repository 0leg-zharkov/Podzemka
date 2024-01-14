using System;
using MetroWorld.Gamer;
using MetroWorld.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MetroWorld.Bullet
{
    class PlayerBullet : IBullet
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle collision;

        private bool isInjured;
        private bool isAbroad;

        public Vector2 Position
        {
            get => position;
            set => position = value;
        }

        public Rectangle Collision
        {
            get => collision;
        }

        public bool IsAbroad
        {
            get => isAbroad;
            set => isAbroad = value;
        }

        public PlayerBullet(Vector2 position)
        {
            texture = null;
            isInjured = false;
            isAbroad = true;
            this.position = position;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("PlayerBullet");
        }

        public void Update()
        {
            ++position.X;
            collision = new Rectangle((int) position.X, (int) position.Y, texture.Width, texture.Height);

            if (position.X > 1200) isAbroad = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void CheckCollision()
        {
            throw new NotImplementedException();
        }

    }
}
