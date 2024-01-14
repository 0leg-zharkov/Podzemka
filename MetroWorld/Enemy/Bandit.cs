using System;
using MetroWorld.Gamer;
using MetroWorld.Bullet;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MetroWorld.Enemy
{
    class Bandit : IEnemy
    {
        private Texture2D texture;
        private Vector2 position;
        private Vector2 playerPosition;
        private int hp;
        private BanditBullet bullet;
        private bool isChecked;

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public Vector2 Position
        {
            get => position;
        }

        public Bandit()
        {
            texture = null;
            isChecked = false;
            bullet = new BanditBullet();
            playerPosition = Vector2.Zero;
            position = new Vector2(1100, 0);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("DemoBandit-export");
            bullet.LoadContent(content);
        }

        public void Update(Vector2 player)
        {
            playerPosition = player;
            Move();
            CheckPlayer();
            if (isChecked) Shoot();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            if (isChecked) bullet.Draw(spriteBatch);
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            if (!isChecked) --position.X;
        }

        public void Shoot()
        {
            bullet.Update();
        }

        public void CheckPlayer()
        {
            if (!isChecked && position.X - playerPosition.X < 500)
            {
                isChecked = true;
                bullet.Position = position;
            }
        }
    }
}
