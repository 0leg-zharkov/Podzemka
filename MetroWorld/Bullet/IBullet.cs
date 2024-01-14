using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetroWorld.Bullet
{
    interface IBullet
    {
        void LoadContent(ContentManager content);

        void Update();
        
        void Draw(SpriteBatch spriteBatch);

        void Fly();

        void CheckCollision();
    }
}
