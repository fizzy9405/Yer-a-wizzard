namespace RPG.Model.Tiles
{
    using Microsoft.Xna.Framework;
    using RPG.Controller;
    using RPG.Model.Enumerations;
    using RPG.View;
    using RPG.View.Renderers;

    public class GoToGreenTile : Tile
    {
        public GoToGreenTile(Vector2 position, Rectangle tileRectangle)
            : base(position, tileRectangle)
        {
            this.Type = TypesOfGroundTiles.GoToGreen;
        }

        public override void ActOnPlayer(Character mainCharacter, MonoGameRenderer renderer)
        {
            if (this.TileRectangle.Contains(mainCharacter.Bounds))
            {
                StateMachine.CurrentState.NextState = StateMachine.PoisonMap;
                StateMachine.ChangeState();
                StateMachine.CurrentState.Execute(renderer);
            }
        }
    }
}
