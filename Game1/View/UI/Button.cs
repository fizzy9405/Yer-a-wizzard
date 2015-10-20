namespace RPG.View.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Button
    {
        public Button(Sprite sprite, Texture2D hoverImage, Texture2D clickedImage, Texture2D inactiveImage)
        {
            this.Sprite = sprite;
            this.HoverImage = hoverImage;
            this.ClickedImage = clickedImage;
            this.InactiveImage = inactiveImage;
        }

        public Sprite Sprite { get; set; }

        private Texture2D HoverImage { get; set; }

        private Texture2D ClickedImage { get; set; }

        private Texture2D InactiveImage { get; set; }

        public void ChangeToHoverImage()
        {
            this.Sprite.Image = this.HoverImage;
        }

        public void ChangeToClickedImage()
        {
            this.Sprite.Image = this.ClickedImage;
        }

        public void ChangeToInactiveImage()
        {
            this.Sprite.Image = this.InactiveImage;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.Sprite.Image, this.Sprite.Rectangle, Color.White);
        }
    }
}
