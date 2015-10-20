namespace RPG.Model.Tiles
{
    using Microsoft.Xna.Framework;
    using RPG.Model.Enumerations;
    using RPG.View;
    using RPG.View.Renderers;

    public class RockTile : Tile
    {
        public RockTile(Vector2 position, Rectangle tileRectangle)
            : base(position, tileRectangle)
        {
            this.Type = TypesOfGroundTiles.Rock;
        }

        public override void ActOnPlayer(Character mainCharacter, MonoGameRenderer renderer)
        {
            bool isMainCharacterXInRectangleWhenPressingLeft = mainCharacter.Bounds.Left + mainCharacter.Velocity.X <= TileRectangle.Right &&
                      mainCharacter.Bounds.Left + mainCharacter.Velocity.X >= TileRectangle.Left;

            bool isMainCharacterXInRectangleWhenPressingRight = mainCharacter.Bounds.Right + mainCharacter.Velocity.X >= TileRectangle.Left &&
                 mainCharacter.Bounds.Right + mainCharacter.Velocity.X <= TileRectangle.Right;

            bool isMainCharacterYInRectangleWhenPressingDown = mainCharacter.Bounds.Bottom + mainCharacter.Velocity.Y >= TileRectangle.Top &&
                 mainCharacter.Bounds.Bottom + mainCharacter.Velocity.Y <= TileRectangle.Bottom;

            bool isMainCharacterYInRectangleWhenPressingUp = mainCharacter.Bounds.Top + mainCharacter.Velocity.Y <= TileRectangle.Bottom &&
                 mainCharacter.Bounds.Top + mainCharacter.Velocity.Y >= TileRectangle.Top;

            if (isMainCharacterXInRectangleWhenPressingLeft)
            {
                if (isMainCharacterYInRectangleWhenPressingDown)
                {
                    Vector2 velocity = new Vector2(0, 0);
                    mainCharacter.Velocity = velocity;
                }
                else if (isMainCharacterYInRectangleWhenPressingUp)
                {
                    Vector2 velocity = new Vector2(0, 0);
                    mainCharacter.Velocity = velocity;
                }
            }

            if (isMainCharacterXInRectangleWhenPressingRight)
            {
                if (isMainCharacterYInRectangleWhenPressingDown)
                {
                    Vector2 velocity = new Vector2(0, 0);
                    mainCharacter.Velocity = velocity;
                }
                else if (isMainCharacterYInRectangleWhenPressingUp)
                {
                    Vector2 velocity = new Vector2(0, 0);
                    mainCharacter.Velocity = velocity;
                }
            }
        }
    }
}
