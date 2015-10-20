namespace RPG.View.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Sprite
    {
        public Sprite()
        {
        }

        public Sprite(Rectangle rectangle, Texture2D image)
        {
            this.Rectangle = rectangle;
            this.Image = image;
        }

        public Sprite(Rectangle rectangle, Texture2D image, Vector2 position)
        {
            this.Rectangle = rectangle;
            this.Image = image;
            this.Position = position;
        }

        public Rectangle Rectangle { get; set; }

        public Texture2D Image { get; set; }

        public Vector2 Position { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Image, this.Position, Color.White);
        }
    }
}
