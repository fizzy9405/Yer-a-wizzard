namespace RPG.View.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Background
    {
        public Background(Sprite sprite)
        {
            this.Sprite = sprite;
        }

        public Sprite Sprite { get; set; }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Sprite.Image, this.Sprite.Rectangle, Color.White);
        }
    }
}
