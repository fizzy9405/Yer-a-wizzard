namespace RPG.Model.Tiles
{
    using Microsoft.Xna.Framework;
    using RPG.Model.Enumerations;
    using RPG.View;
    using RPG.View.Renderers;

    public abstract class Tile 
    {
        public const int BUG_VALUE = 15; // ?????

        public Tile(Vector2 position, Rectangle tileRectangle)
        {
            this.X = position.X + 32;
            this.Y = position.Y + 32;
            this.Position = new Vector2(this.X, this.Y);
            this.TileRectangle = tileRectangle;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public TypesOfGroundTiles Type { get;  set; }

        public Vector2 Position { get; set; }

        public Rectangle TileRectangle { get; set; }
       
        public virtual void ActOnPlayer(Character mainCharacter, MonoGameRenderer renderer)
        {            
        }

        public void LoadContent(Vector2 position, Rectangle tileRectangle)
        {
            this.Position = position;
            this.TileRectangle = tileRectangle;
        }
    }
}
