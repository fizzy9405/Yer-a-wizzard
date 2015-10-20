namespace RPG.View.UI
{
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

    public class TileImage
    {
        public TileImage(Sprite sprite)
        {
            this.Sprite = sprite;
        }

        public Sprite Sprite { get; set; }

        public Texture2D GrassTile { get; set; }

        public Texture2D RockTile { get; set; }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.Sprite.Image, this.Sprite.Rectangle, Color.White);
        }
    }
}
