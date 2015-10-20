namespace RPG.Controller.States
{
    using Microsoft.Xna.Framework.Input;
    using RPG.Model.Enumerations;
    using RPG.View.Renderers;

    public class EnemyTurnState : State
    {
        public EnemyTurnState(State nextState)
            : base(nextState)
        {
            this.IsInitialized = false;
        }

        public bool IsInitialized { get; set; }

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
            if (!this.IsInitialized)
            {
                StateMachine.BattleState.NextState = StateMachine.EndTurnState;
                renderer.EnemyHero.HasBeenAfflicted = false;
                this.IsInitialized = true;
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
                StateMachine.BattleState.NextState = StateMachine.EndTurnState;
                StateMachine.CurrentState.Execute(renderer);
            }

            if (renderer.EnemyHero.Level >= 3)
            {
                if (renderer.EnemyHero.Health > renderer.EnemyHero.MaxHealth / 2)
                {
                    CastBigSpell(renderer);
                    return;
                }
            }

            if (renderer.EnemyHero.Level >= 2)
            {
                if (renderer.EnemyHero.Armor <= 0)
                {
                    if (renderer.EnemyHero.Mana >= renderer.EnemyHero.PlayerSpells[1].ManaCost)
                    {
                        if (renderer.EnemyHero.Armor == 0)
                        {
                            if (renderer.EnemyHero.MagicSchool == SpellType.Fire)
                            {
                                renderer.ShieldsCasted.Add(renderer.SpellAnimationFactory.FireShield(true));
                            }
                            else if (renderer.EnemyHero.MagicSchool == SpellType.Ice)
                            {
                                renderer.ShieldsCasted.Add(renderer.SpellAnimationFactory.IceBarrier(true));
                            }
                            else if (renderer.EnemyHero.MagicSchool == SpellType.Poison)
                            {
                                renderer.ShieldsCasted.Add(renderer.SpellAnimationFactory.PoisonCloud(true));
                            }
                        }

                        renderer.EnemyHero.Armor = renderer.EnemyHero.PlayerSpells[1].Armor;
                        renderer.EnemyHero.Mana -= renderer.EnemyHero.PlayerSpells[1].ManaCost;
                        renderer.EnemyHero.Affliction = Affliction.None;

                        renderer.MainHero.HasBeenHit = false;
                        AddManaPerTurn(renderer);
                        StateMachine.BattleState.IsInitialized = false;
                        StateMachine.ChangeState();
                        StateMachine.CurrentState.Execute(renderer);
                        return;
                    }
                    else
                    {
                        CastSmallSpell(renderer);
                    }
                }
                else
                {
                    if (renderer.EnemyHero.Mana >= renderer.EnemyHero.PlayerSpells[2].ManaCost && renderer.EnemyHero.Level >= 3)
                    {
                        CastBigSpell(renderer);
                        return;
                    }
                    else
                    {
                        CastSmallSpell(renderer);
                    }
                }
            }
            else if (renderer.EnemyHero.Level >= 1)
            {
                CastSmallSpell(renderer);
            }

            if (renderer.MainHero.Health <= 0)
            {
                StateMachine.CurrentState.NextState = StateMachine.GameOverState;
                StateMachine.ChangeState();
                StateMachine.CurrentState.Execute(renderer);
                return;
            }
        }

        private static void CastBigSpell(MonoGameRenderer renderer)
        {
            if (renderer.EnemyHero.MagicSchool == SpellType.Fire)
            {
                renderer.SpellsCasted.Add(renderer.SpellAnimationFactory.Meteor(true));
            }
            else if (renderer.EnemyHero.MagicSchool == SpellType.Ice)
            {
                renderer.SpellsCasted.Add(renderer.SpellAnimationFactory.Hurricane(true));
            }
            else if (renderer.EnemyHero.MagicSchool == SpellType.Poison)
            {
                renderer.SpellsCasted.Add(renderer.SpellAnimationFactory.Decay(true));
            }

            renderer.EnemyHero.Mana -= renderer.EnemyHero.PlayerSpells[2].ManaCost;
            if (renderer.EnemyHero.Affliction == Affliction.Poisoned)
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

            renderer.MainHero.HasBeenHit = false;
            AddManaPerTurn(renderer);
            StateMachine.BattleState.IsInitialized = false;
            StateMachine.ChangeState();
            StateMachine.CurrentState.Execute(renderer);
            return;
        }

        private static void CastSmallSpell(MonoGameRenderer renderer)
        {
            if (renderer.EnemyHero.MagicSchool == SpellType.Fire)
            {
                renderer.SpellsCasted.Add(renderer.SpellAnimationFactory.Fireball(true));
            }
            else if (renderer.EnemyHero.MagicSchool == SpellType.Ice)
            {
                renderer.SpellsCasted.Add(renderer.SpellAnimationFactory.Icebolt(true));
            }
            else if (renderer.EnemyHero.MagicSchool == SpellType.Poison)
            {
                renderer.SpellsCasted.Add(renderer.SpellAnimationFactory.Poisonbolt(true));
            }

            renderer.EnemyHero.Mana -= renderer.EnemyHero.PlayerSpells[0].ManaCost;
            if (renderer.EnemyHero.Affliction == Affliction.Poisoned)
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

            renderer.MainHero.HasBeenHit = false;
            AddManaPerTurn(renderer);
            StateMachine.BattleState.IsInitialized = false;
            StateMachine.ChangeState();
            StateMachine.CurrentState.Execute(renderer);
            return;
        }

        private static void AddManaPerTurn(MonoGameRenderer renderer)
        {
            if (renderer.MainHero.Mana < renderer.MainHero.MaxMana)
            {
                renderer.MainHero.Mana += 10;
                if (renderer.MainHero.Mana > renderer.MainHero.MaxMana)
                {
                    renderer.MainHero.Mana = renderer.MainHero.MaxMana;
                }
            }
        }
    }
}
