namespace RPG.Model.Tiles
{
    using Microsoft.Xna.Framework;
    using RPG.Model.Enumerations;

    public class PathTile : Tile
    {
        public PathTile(Vector2 position, Rectangle tileRectangle)
            : base(position, tileRectangle)
        {
            this.Type = TypesOfGroundTiles.Path;
        }
    }
}
