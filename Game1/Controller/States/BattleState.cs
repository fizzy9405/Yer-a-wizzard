namespace RPG.Controller.States
{
    using Microsoft.Xna.Framework.Input;
    using RPG.Model.Enumerations;
    using RPG.View.Renderers;

    public class BattleState : State
    {
        private MouseState mouseState;

        public BattleState(State nextState)
            : base(nextState)
        {
            this.IsInitialized = false;
        }

        public int Index { get; set; }

        public bool IsInitialized { get; set; }

        public override void Draw(MonoGameRenderer renderer)
        {
            //// draw backdround
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

            foreach (var spell in renderer.SpellsCasted)
            {
                spell.Draw(EntryPoint.Game.SpriteBatch);
                spell.Update(renderer.GameTime);
            }

            renderer.DrawHero();
            renderer.DrawEnemyHero();

            renderer.MainHero.Update(renderer);
            renderer.EnemyHero.Update(renderer);

            renderer.DrawSpellInfoWindow();
        }

        public override void Execute(MonoGameRenderer renderer)
        {
            if (!this.IsInitialized)
            {
                renderer.BattleStateButtonOne.ChangeToInactiveImage();
                renderer.BattleStateButtonTwo.ChangeToInactiveImage();
                renderer.BattleStateButtonThree.ChangeToInactiveImage();

                this.Index = 3;
                renderer.MainHero.HasBeenAfflicted = false;
                StateMachine.EnemyTurnState.IsInitialized = false;
                this.IsInitialized = true;
            }

            if (renderer.MainHero.Health <= 0)
            {
                StateMachine.CurrentState.NextState = StateMachine.GameOverState;
                StateMachine.ChangeState();
                StateMachine.CurrentState.Execute(renderer);
                return;
            }

            bool mouseOverOne = renderer.BattleStateButtonOne.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            bool mouseOverTwo = renderer.BattleStateButtonTwo.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            bool mouseOverThree = renderer.BattleStateButtonThree.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            bool mouseOverSpellCast = renderer.SpellCastButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            bool mouseOverEndTurn = renderer.EndTurnButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);

            if (this.Index == 3)
            {
                renderer.SpellCastButton.ChangeToClickedImage();
            }
            else
            {
                renderer.SpellCastButton.ChangeToInactiveImage();
                if (mouseOverSpellCast)
                {
                    renderer.SpellCastButton.ChangeToHoverImage();
                }
            }
          
            if (mouseOverEndTurn)
            {
                renderer.EndTurnButton.ChangeToHoverImage();
            }
            else
            {
                renderer.EndTurnButton.ChangeToInactiveImage();
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && this.mouseState.LeftButton == ButtonState.Released && mouseOverEndTurn && renderer.SpellsCasted.Count == 0)
            {
                renderer.EndTurnButton.ChangeToClickedImage();
                AddManaPerTurn(renderer);
                StateMachine.CurrentState.NextState = StateMachine.EnemyTurnState;
                StateMachine.ChangeState();
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverOne && renderer.MainHero.Mana >= renderer.MainHero.PlayerSpells[0].ManaCost)
            {
                renderer.BattleStateButtonOne.ChangeToClickedImage();
                renderer.BattleStateButtonTwo.ChangeToInactiveImage();
                renderer.BattleStateButtonThree.ChangeToInactiveImage();
                this.Index = 0;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverTwo && renderer.MainHero.Mana >= renderer.MainHero.PlayerSpells[1].ManaCost)
            {
                renderer.BattleStateButtonOne.ChangeToInactiveImage();
                renderer.BattleStateButtonTwo.ChangeToClickedImage();
                renderer.BattleStateButtonThree.ChangeToInactiveImage();
                this.Index = 1;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverThree && renderer.MainHero.Mana >= renderer.MainHero.PlayerSpells[2].ManaCost)
            {
                renderer.BattleStateButtonOne.ChangeToInactiveImage();
                renderer.BattleStateButtonTwo.ChangeToInactiveImage();
                renderer.BattleStateButtonThree.ChangeToClickedImage();
                this.Index = 2;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && this.mouseState.LeftButton == ButtonState.Released && mouseOverSpellCast && this.Index != 3)
            {
                renderer.SpellCastButton.ChangeToClickedImage();
                if (this.Index == 0)
                {
                    if (renderer.MainHero.MagicSchool == SpellType.Fire)
                    {
                        renderer.SpellsCasted.Add(renderer.SpellAnimationFactory.Fireball(false));
                    }
                    else if (renderer.MainHero.MagicSchool == SpellType.Ice)
                    {
                        renderer.SpellsCasted.Add(renderer.SpellAnimationFactory.Icebolt(false));
                    }
                    else if (renderer.MainHero.MagicSchool == SpellType.Poison)
                    {
                        renderer.SpellsCasted.Add(renderer.SpellAnimationFactory.Poisonbolt(false));
                    }

                    renderer.MainHero.Mana -= renderer.MainHero.PlayerSpells[0].ManaCost;
                }
                else if (this.Index == 1)
                {
                    if (renderer.MainHero.Armor == 0)
                    {
                        if (renderer.MainHero.MagicSchool == SpellType.Fire)
                        {
                            renderer.ShieldsCasted.Add(renderer.SpellAnimationFactory.FireShield(false));
                        }
                        else if (renderer.MainHero.MagicSchool == SpellType.Ice)
                        {
                            renderer.ShieldsCasted.Add(renderer.SpellAnimationFactory.IceBarrier(false));
                        }
                        else if (renderer.MainHero.MagicSchool == SpellType.Poison)
                        {
                            renderer.ShieldsCasted.Add(renderer.SpellAnimationFactory.PoisonCloud(false));
                        }
                    }

                    renderer.MainHero.Armor = renderer.MainHero.PlayerSpells[1].Armor;
                    renderer.MainHero.Affliction = Affliction.None;
                
                    renderer.MainHero.Mana -= renderer.MainHero.PlayerSpells[1].ManaCost;
                }
                else if (this.Index == 2)
                {
                    if (renderer.MainHero.MagicSchool == SpellType.Fire)
                    {
                        renderer.SpellsCasted.Add(renderer.SpellAnimationFactory.Meteor(false));
                    }
                    else if (renderer.MainHero.MagicSchool == SpellType.Ice)
                    {
                        renderer.SpellsCasted.Add(renderer.SpellAnimationFactory.Hurricane(false));
                    }
                    else if (renderer.MainHero.MagicSchool == SpellType.Poison)
                    {
                        renderer.SpellsCasted.Add(renderer.SpellAnimationFactory.Decay(false));
                    }

                    renderer.MainHero.Mana -= renderer.MainHero.PlayerSpells[2].ManaCost;
                }

                if (renderer.MainHero.Affliction == Affliction.Poisoned)
                {
                    if (renderer.MainHero.Mana > 0)
                    {
                        renderer.MainHero.Mana -= 5;
                    }

                    if (renderer.MainHero.Mana < 0)
                    {
                        renderer.MainHero.Mana = 0;
                    }
                }

                renderer.BattleStateButtonOne.ChangeToHoverImage();
                renderer.BattleStateButtonTwo.ChangeToHoverImage();
                renderer.BattleStateButtonThree.ChangeToHoverImage();
                renderer.EnemyHero.HasBeenHit = false;
                AddManaPerTurn(renderer);
                StateMachine.CurrentState.NextState = StateMachine.EndTurnState;
                StateMachine.ChangeState();
            } 

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
                StateMachine.CurrentState.Execute(renderer);
            }

            this.mouseState = Mouse.GetState();
            //// when battle ends-> go back to game state
        }

        private static void AddManaPerTurn(MonoGameRenderer renderer)
        {
            if (renderer.EnemyHero.Mana < renderer.EnemyHero.MaxMana)
            {
                renderer.EnemyHero.Mana += 10;
                if (renderer.EnemyHero.Mana > renderer.EnemyHero.MaxMana)
                {
                    renderer.EnemyHero.Mana = renderer.EnemyHero.MaxMana;
                }
            }
        }
    }
}
