namespace RPG.Controller.States
{
    using Microsoft.Xna.Framework;
    using RPG.View.Renderers;

    public class PoisonMapState : GameState
    {
        public PoisonMapState(State nextState)
            : base(nextState)
        {
        }

        public override void Draw(MonoGameRenderer renderer)
        {
            renderer.DrawMap(renderer.PoisonMap);
            renderer.UpdateMap(renderer.PoisonMap);

            renderer.GreenCastle.Sprite.Rectangle = new Rectangle(360, 68, renderer.BlueCastle.Sprite.Rectangle.Width, renderer.BlueCastle.Sprite.Rectangle.Height);
            renderer.DrawGreenCastle();

            renderer.DrawMainCharacter();
            renderer.UpdateMainCharacter();
        }

        public override void Execute(MonoGameRenderer renderer)
        {
            base.Execute(renderer);
            foreach (var tile in renderer.PoisonMap.TileMap)
            {
                tile.ActOnPlayer(renderer.MainCharacter, renderer);
            }

            renderer.MainHero.Health = renderer.MainHero.MaxHealth;
            renderer.MainHero.Mana = renderer.MainHero.MaxMana;
            renderer.MainHero.Update(renderer);
        }
    }
}
