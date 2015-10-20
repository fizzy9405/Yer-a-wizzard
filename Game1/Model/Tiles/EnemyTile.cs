namespace RPG.Model.Tiles
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RPG.View;

    public class EnemyTile : Tile
    {
        public EnemyTile(Vector2 position, Rectangle tileRectangle)
            : base(position, tileRectangle)
        {
            this.IsDefeated = false;
        }

        public bool IsDefeated { get; set; }

        public Texture2D Texture { get; set; }

        public override void ActOnPlayer(Character mainCharacter, View.Renderers.MonoGameRenderer renderer)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.TileRectangle, Color.White);
        }
    }
}
