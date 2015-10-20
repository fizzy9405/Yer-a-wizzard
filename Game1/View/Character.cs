namespace RPG.View
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RPG.Model.Enumerations;

    public class Character
    {
        private int currentFrame;
        private int totalFrames;

        ////slowdown frame animations
        private int timeSinceLastFrame = 0;

        public Character(Texture2D texture, int row, int col, Vector2 location)
        {
            this.Texture = texture;
            this.Row = row;
            this.Col = col;
            this.currentFrame = 0;
            this.totalFrames = row * col;
            this.Location = location;
            this.MillisecondsPerFrame = 100;
            this.CharacterMovement = CharacterMovement.Stationary;
            this.Bounds = new Rectangle((int)location.X, (int)location.Y, texture.Width / col, texture.Height / row);
        }

        public CharacterMovement CharacterMovement { get; set; }

        public int MillisecondsPerFrame { get; set; }

        public Texture2D Texture { get; set; }

        public Vector2 Location { get; set; }

        public Vector2 Velocity { get; set; }

        public Rectangle Bounds { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }

        public void Update(GameTime gametime)
        {
            int width = this.Texture.Width / this.Col;
            int height = this.Texture.Height / this.Row;

            this.Location += this.Velocity;

            this.Bounds = new Rectangle((int)this.Location.X, (int)this.Location.Y, width, height);

            if (this.Bounds.Top < 0)
            {
                Vector2 newLocation = new Vector2(this.Location.X, 0);
                this.Location = newLocation;
            }

            if (this.Bounds.Bottom > 800)
            {
                Vector2 newLocation = new Vector2(this.Location.X, 800 - this.Bounds.Height);
                this.Location = newLocation;
            }

            if (this.Bounds.Right > 1280)
            {
                Vector2 newLocation = new Vector2(1280 - this.Bounds.Width, this.Location.Y);
                this.Location = newLocation;
            }

            if (this.Bounds.Left < 0)
            {
                Vector2 newLocation = new Vector2(0, this.Location.Y);
                this.Location = newLocation;
            }

            this.timeSinceLastFrame += gametime.ElapsedGameTime.Milliseconds;
            if (this.timeSinceLastFrame > this.MillisecondsPerFrame)
            {
                //// this.timeSinceLastFrame -= this.MillisecondsPerFrame;

                //// increment current frame
                this.currentFrame++;
                this.timeSinceLastFrame = 0;
                if (this.currentFrame == this.totalFrames)
                {
                    this.currentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = this.Texture.Width / this.Col;
            int height = this.Texture.Height / this.Row;
            int row = 0;
            int col = 0;
            if (this.CharacterMovement == CharacterMovement.Stationary)
            {
                row = 0;
                col = 0;
            }
            else if (this.CharacterMovement == CharacterMovement.Left)
            {
                row = 1;
                col = this.currentFrame % this.Col;
            }
            else if (this.CharacterMovement == CharacterMovement.Right)
            {
                row = 2;
                col = this.currentFrame % this.Col;
            }
            else if (this.CharacterMovement == CharacterMovement.Up)
            {
                row = 3;
                col = this.currentFrame % this.Col;
            }
            else if (this.CharacterMovement == CharacterMovement.Down)
            {
                row = 0;
                col = this.currentFrame % this.Col;
            }

            Rectangle sourceRectangle = new Rectangle(width * col, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)this.Location.X, (int)this.Location.Y, width, height);

            spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
