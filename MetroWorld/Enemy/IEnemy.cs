using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MetroWorld.Gamer;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetroWorld.Enemy
{
    interface IEnemy
    {
        void LoadContent(ContentManager content);

        void Update(Vector2 player);

        void Draw(SpriteBatch spriteBatch);

        void CheckPlayer();

        void Shoot();

        void Move();

        void Die();

        int Hp { get; set; }

        Vector2 Position { get; }
    }
}
