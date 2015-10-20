namespace RPG.Controller.States
{
    using Microsoft.Xna.Framework;
    using RPG.View.Renderers;

    public class IceMapState : GameState
    {
        public IceMapState(State nextState)
            : base(nextState)
        {
        }

        public override void Draw(MonoGameRenderer renderer)
        {
            renderer.DrawMap(renderer.IceMap);
            renderer.UpdateMap(renderer.IceMap);

            renderer.BlueCastle.Sprite.Rectangle = new Rectangle(65, 0, renderer.BlueCastle.Sprite.Rectangle.Width, renderer.BlueCastle.Sprite.Rectangle.Height);
            renderer.DrawBlueCastle();

            renderer.DrawMainCharacter();
            renderer.UpdateMainCharacter();
        }

        public override void Execute(MonoGameRenderer renderer)
        {
            base.Execute(renderer);
            foreach (var tile in renderer.IceMap.TileMap)
            {
                tile.ActOnPlayer(renderer.MainCharacter, renderer);
            }

            renderer.MainHero.Health = renderer.MainHero.MaxHealth;
            renderer.MainHero.Mana = renderer.MainHero.MaxMana;
            renderer.MainHero.Update(renderer);
        }
    }
}
