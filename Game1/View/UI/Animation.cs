namespace RPG.View.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RPG.Model.Heroes;

    public class Animation
    {
        private int totalFrames;
        private int timeSinceLastFrame = 0;

        public Animation(Texture2D texture, int row, int col)
        {
            this.Texture = texture;
            this.Row = row;
            this.Col = col;
            this.CurrentFrame = 0;
            this.totalFrames = row * col;
            this.MillisecondsPerFrame = 300;
        }

        public int MillisecondsPerFrame { get; set; }

        public Texture2D Texture { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }
        
        protected int CurrentFrame { get; set; }

        public virtual void Update(GameTime gametime)
        {
            this.timeSinceLastFrame += gametime.ElapsedGameTime.Milliseconds;
            if (this.timeSinceLastFrame > this.MillisecondsPerFrame)
            {
                ////timeSinceLastFrame -= MillisecondsPerFrame;
                ////increment current frame
                this.CurrentFrame++;
                this.timeSinceLastFrame = 0;
                if (this.CurrentFrame == this.totalFrames)
                {
                    this.CurrentFrame = 0;
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = this.Texture.Width / this.Col;
            int height = this.Texture.Height / this.Row;
            int row = (int)((float)this.CurrentFrame / this.Col);
            int col = this.CurrentFrame % this.Col;

            Rectangle sourceRectangle = new Rectangle(width * col, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
