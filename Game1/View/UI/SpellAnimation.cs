namespace RPG.View.UI
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RPG.Model.Spell;

    public class SpellAnimation : Animation
    {
        public SpellAnimation(Texture2D texture, Vector2 velocity, int row, int col, Vector2 location, Rectangle bounds, bool isRotated, Spell spell)
            : base(texture, row, col)
        {
            this.Location = location;
            this.Bounds = bounds;
            this.IsVisible = true;
            this.Velocity = velocity;
            this.IsRotated = isRotated;
            this.MySpell = spell;
        }

        public Vector2 Location { get; set; }

        public Rectangle Bounds { get; set; }

        public Vector2 Velocity { get; set; }

        public bool IsRotated { get; set; }

        public bool IsVisible { get; set; }

        public bool StaysAfterEndTurn { get;  set; }

        public Spell MySpell { get; set; }

        public override void Update(GameTime gametime)
        {
            int width = this.Texture.Width / this.Col;
            int height = this.Texture.Height / this.Row;

            this.Location += this.Velocity;

            this.Bounds = new Rectangle((int)this.Location.X, (int)this.Location.Y, width, height);

            if (this.Bounds.X > 1300 || this.Bounds.X < 0)
            {
                this.IsVisible = false;
            }

            base.Update(gametime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.IsVisible)
            {
                if (this.IsRotated)
                {
                    int width = this.Texture.Width / this.Col;
                    int height = this.Texture.Height / this.Row;
                    int row = (int)((float)this.CurrentFrame / this.Col);
                    int col = this.CurrentFrame % this.Col;

                    Rectangle sourceRectangle = new Rectangle(width * col, height * row, width, height);
                    Rectangle destinationRectangle = new Rectangle((int)this.Location.X, (int)this.Location.Y, width, height);

                    spriteBatch.Draw(this.Texture, destinationRectangle, sourceRectangle, Color.White, 0.0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0.0f);
                }
                else
                {
                    base.Draw(spriteBatch, this.Location);
                }
            }
        }
    }
}
