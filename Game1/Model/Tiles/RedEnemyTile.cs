namespace RPG.Model.Tiles
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RPG.Controller;
    using RPG.Model.Enumerations;
    using RPG.View;
    using RPG.View.Renderers;

    public class RedEnemyTile : EnemyTile
    {
        public RedEnemyTile(Vector2 position, Rectangle tileRectangle)
            : base(position, tileRectangle)
        {
            this.Type = TypesOfGroundTiles.RedEnemyTile;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void ActOnPlayer(Character mainCharacter, MonoGameRenderer renderer)
        {
            if (this.TileRectangle.Intersects(mainCharacter.Bounds))
            {
                renderer.Enemy = this;
                renderer.EnemyHero = UIInitializer.CreateEnemyHero(EntryPoint.Game.Content);
                if (renderer.FireMap.EnemyCounter == 1)
                {
                    renderer.EnemyHero.Level = 3;
                    renderer.EnemyHero.Health = renderer.MainHero.MaxHealth;
                    renderer.EnemyHero.Mana = renderer.MainHero.MaxMana;
                }
                else if (renderer.FireMap.EnemyCounter == 2)
                {
                    renderer.EnemyHero.Level = 2;
                    renderer.EnemyHero.Health = (int)(renderer.MainHero.MaxHealth * 0.75);
                    renderer.EnemyHero.Mana = (int)(renderer.MainHero.MaxMana * 0.75);
                }
                else if (renderer.FireMap.EnemyCounter == 3)
                {
                    renderer.EnemyHero.Level = 1;
                    renderer.EnemyHero.Health = (int)(renderer.MainHero.MaxHealth * 0.60);
                    renderer.EnemyHero.Mana = (int)(renderer.MainHero.MaxMana * 0.60);
                }

                renderer.EnemyHero.Texture = EntryPoint.Game.Content.Load<Texture2D>("BigRedMage");
                renderer.EnemyHero.MagicSchool = SpellType.Fire;
                renderer.EnemyHero.PlayerSpells = renderer.FireSpells;
                renderer.EnemyHero.Update(renderer);

                if (!this.IsDefeated)
                {
                    StateMachine.BattleState.IsInitialized = false;
                    StateMachine.PreviousState = StateMachine.FireMap;
                    StateMachine.CurrentState.NextState = StateMachine.BattleState;
                    StateMachine.BattleState.NextState = StateMachine.EndTurnState;
                    StateMachine.EndTurnState.NextState = StateMachine.EnemyTurnState;
                    StateMachine.EnemyTurnState.NextState = StateMachine.BattleState;
                    StateMachine.ChangeState();
                    StateMachine.CurrentState.Execute(renderer);
                }
            }
        }
    }
}
