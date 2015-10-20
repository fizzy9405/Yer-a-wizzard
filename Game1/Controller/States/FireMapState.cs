namespace RPG.Controller.States
{
    using Microsoft.Xna.Framework;
    using RPG.View.Renderers;

    public class FireMapState : GameState
    {
        public FireMapState(State nextState)
            : base(nextState)
        {
        }

        public override void Draw(MonoGameRenderer renderer)
        {
            renderer.DrawMap(renderer.FireMap);
            renderer.UpdateMap(renderer.FireMap);

            renderer.RedCastle.Sprite.Rectangle = new Rectangle(666, 35, renderer.BlueCastle.Sprite.Rectangle.Width, renderer.BlueCastle.Sprite.Rectangle.Height);
            renderer.DrawRedCastle();

            renderer.DrawMainCharacter();
            renderer.UpdateMainCharacter();
        }

        public override void Execute(MonoGameRenderer renderer)
        {
            base.Execute(renderer);
            foreach (var tile in renderer.FireMap.TileMap)
            {
                tile.ActOnPlayer(renderer.MainCharacter, renderer);
            }

            renderer.MainHero.Health = renderer.MainHero.MaxHealth;
            renderer.MainHero.Mana = renderer.MainHero.MaxMana;
            renderer.MainHero.Update(renderer);
        }
    }
}
