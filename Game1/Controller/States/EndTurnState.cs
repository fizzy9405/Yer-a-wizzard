namespace RPG.Controller.States
{
    using Microsoft.Xna.Framework.Input;
    using RPG.Model.Enumerations;
    using RPG.View.Renderers;
    using RPG.View.UI;

    public class EndTurnState : State
    {
        private MouseState mouseState;

        public EndTurnState(State nextState)
            : base(nextState)
        {
        }

        public override void Draw(MonoGameRenderer renderer)
        {
            renderer.DrawBattleBackground();
            renderer.DrawBattleMenu();
            renderer.DrawBattleStateButtons();
            renderer.DrawHeroMenuText();
            renderer.DrawEnemyMenuText();

            for (int i = 0; i < renderer.ShieldsCasted.Count; i++)
            {
                if (renderer.ShieldsCasted[i].IsVisible)
                {
                    renderer.ShieldsCasted[i].Draw(EntryPoint.Game.SpriteBatch);
                }
                else
                {
                    renderer.ShieldsCasted.Remove(renderer.ShieldsCasted[i]);
                }
            }

            for (int i = 0; i < renderer.SpellsCasted.Count; i++)
            {
                if (!renderer.SpellsCasted[i].IsVisible)
                {
                    renderer.SpellsCasted.Remove(renderer.SpellsCasted[i]);
                }
            }

            foreach (var spell in renderer.SpellsCasted)
            {
                spell.Draw(EntryPoint.Game.SpriteBatch);
                spell.Update(renderer.GameTime);
            }

            renderer.DrawHero();
            renderer.DrawEnemyHero();
            renderer.MainHero.Update(renderer);
            renderer.EnemyHero.Update(renderer);
        }

        public override void Execute(MonoGameRenderer renderer)
        {
            if (renderer.EnemyHero.Health <= 0 || Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                renderer.MainHero.Experiecnce += renderer.EnemyHero.Level * 100;
                if (renderer.MainHero.Experiecnce >= renderer.MainHero.ExperienceNeeded)
                {
                    renderer.MainHero.Experiecnce = renderer.MainHero.Experiecnce - renderer.MainHero.ExperienceNeeded;
                    renderer.MainHero.ExperienceNeeded = renderer.MainHero.ExperienceNeeded * 2;
                    renderer.MainHero.Level = renderer.MainHero.Level + 1;
                }

                renderer.MainHero.Affliction = Affliction.None;
                renderer.EnemyHero.Affliction = Affliction.None;
                renderer.MainHero.Health = renderer.MainHero.MaxHealth;
                renderer.MainHero.Mana = renderer.MainHero.MaxMana;
                renderer.MainHero.Armor = 0;
                renderer.Enemy.IsDefeated = true;
                renderer.EnemyCounter--;
                if (StateMachine.PreviousState == StateMachine.IceMap)
                {
                    renderer.IceMap.EnemyCounter--;
                }
                else if (StateMachine.PreviousState == StateMachine.FireMap)
                {
                    renderer.FireMap.EnemyCounter--;
                }
                else if (StateMachine.PreviousState == StateMachine.PoisonMap)
                {
                    renderer.PoisonMap.EnemyCounter--;
                }

                StateMachine.CurrentState.NextState = StateMachine.PreviousState;
                StateMachine.ChangeState();
                StateMachine.BattleState.NextState = StateMachine.EndTurnState;
                StateMachine.CurrentState.Execute(renderer);
            }

            Button endTurnButton = renderer.EndTurnButton;
            endTurnButton.ChangeToInactiveImage();

            bool mouseOverEndTurn = endTurnButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);

            if (mouseOverEndTurn)
            {
                endTurnButton.ChangeToHoverImage();
            }
            else
            {
                endTurnButton.ChangeToInactiveImage();
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && this.mouseState.LeftButton == ButtonState.Released && mouseOverEndTurn && renderer.SpellsCasted.Count == 0)
            {
                endTurnButton.ChangeToClickedImage();
                StateMachine.ChangeState();
                StateMachine.CurrentState.Execute(renderer);
            }

            this.mouseState = Mouse.GetState();
        }
    }
}
