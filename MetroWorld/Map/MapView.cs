using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MetroWorld.Map
{
    class MapView
    {
        private Texture2D texture;

        public MapView()
        {
            texture = null;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("DemoMap");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Vector2.Zero, Color.White);
        }
    }
}
