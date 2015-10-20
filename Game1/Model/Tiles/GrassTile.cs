namespace RPG.Model.Tiles
{
    using Microsoft.Xna.Framework;
    using RPG.Model.Enumerations;

    public class GrassTile : Tile
    {
        public GrassTile(Vector2 position, Rectangle tileRectangle)
            : base(position, tileRectangle)
        {
            this.Type = TypesOfGroundTiles.Grass;
        }
    }
}
