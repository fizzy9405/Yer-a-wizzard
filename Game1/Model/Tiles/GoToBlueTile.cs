namespace RPG.Model.Tiles
{
    using Microsoft.Xna.Framework;
    using RPG.Controller;
    using RPG.Model.Enumerations;
    using RPG.View;
    using RPG.View.Renderers;

    public class GoToBlueTile : Tile
    {
        public GoToBlueTile(Vector2 position, Rectangle tileRectangle)
            : base(position, tileRectangle)
        {
            this.Type = TypesOfGroundTiles.GoToBlue;
        }

        public override void ActOnPlayer(Character mainCharacter, MonoGameRenderer renderer)
        {
            if (this.TileRectangle.Contains(mainCharacter.Bounds))
            {
                // renderer.FireMap.UnloadContent();
                //
                // renderer.PoisonMap.UnloadContent();
                StateMachine.CurrentState.NextState = StateMachine.IceMap;
                StateMachine.ChangeState();
                StateMachine.CurrentState.Execute(renderer);
            }
        }
    }
}
