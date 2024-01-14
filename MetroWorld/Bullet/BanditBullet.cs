using System;
using MetroWorld.Gamer;
using MetroWorld.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MetroWorld.Bullet
{
    class BanditBullet : IBullet
    {
        private Texture2D texture;
        private Vector2 position;
        private Player player;
        private bool isInjured;

        public Vector2 Position
        {
            get => position;
            set => position = value;
        }

        public BanditBullet()
        {
            texture = null;
            position = new Vector2(-1000, 0);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("DemoBullet-export");
        }

        public void Update()
        {
            --position.X;
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
