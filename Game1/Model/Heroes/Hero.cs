namespace RPG.Model.Heroes
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RPG.Model.Enumerations;
    using RPG.Model.Spell;
    using RPG.View.Renderers;

    public class Hero
    {
        private const int STARTING_HEALTH = 180;
        private const int STARTING_MANA = 80;
        private const int STARTING_ARMOR = 0;

        public Hero(SpellType magicSchool, Rectangle rect, Texture2D image, int level)
        {
            this.Health = STARTING_HEALTH;
            this.Mana = STARTING_MANA;
            this.Armor = STARTING_ARMOR;
            this.MaxHealth = STARTING_HEALTH;
            this.MaxMana = STARTING_MANA;
            this.MagicSchool = magicSchool;
            this.Affliction = Enumerations.Affliction.None;
            this.ExperienceNeeded = 200;
            this.Bounds = rect;
            this.Texture = image;
            this.Level = level;
            this.HasBeenHit = false;
            this.HasWon = false;
            this.Turns = 2;
            this.HasBeenAfflicted = false;
        }

        public int Level { get; set; }

        public int ExperienceNeeded { get; set; }

        public int MaxHealth { get; private set; }

        public int MaxMana { get; private set; }

        public int Health { get; set; } // will start with 200 hp

        public int Mana { get; set; } // will start with 100 mp

        public int Armor { get; set; }

        public int Experiecnce { get; set; }

        public SpellType MagicSchool { get; set; }

        public Affliction Affliction { get; set; }

        public List<Spell> PlayerSpells { get; set; }

        public Rectangle Bounds { get; set; }

        public Texture2D Texture { get; set; }

        public int Turns { get; set; }

        public int DamageIncrease { get; set; }

        public bool HasBeenHit { get; set; }

        public bool HasWon { get; set; }

        public bool HasBeenAfflicted { get; set; }

        public virtual void Update(MonoGameRenderer renderer)
        {
            this.MaxHealth = STARTING_HEALTH + (this.Level * 20);
            this.MaxMana = STARTING_MANA + (this.Level * 20);

            for (int i = 0; i < renderer.ShieldsCasted.Count; i++)
            {
                if (renderer.ShieldsCasted[i].Bounds.Intersects(this.Bounds))
                {
                    if (this.Armor <= 0)
                    {
                        renderer.ShieldsCasted[i].IsVisible = false;
                    }
                }
            }

            if (this.Affliction == Enumerations.Affliction.None)
            {
                 this.DamageIncrease = 0;
            }

            if (this.Turns == 0)
            {
                this.Affliction = Enumerations.Affliction.None;
                this.DamageIncrease = 0;
            }

            if (!this.HasBeenAfflicted)
            {
                if (this.Affliction == Enumerations.Affliction.Burning)
                {
                    if (this.Turns == 0)
                    {
                        this.Affliction = Enumerations.Affliction.None;
                    }
                    else
                    {
                        this.Health = this.Health - 10;
                        this.Turns--;
                    }
                }

                if (this.Affliction == Enumerations.Affliction.Frozen)
                {
                    if (this.Turns == 0)
                    {
                        this.Affliction = Enumerations.Affliction.None;
                        this.DamageIncrease = 0;
                    }
                    else
                    {
                        this.DamageIncrease = 10;
                        this.Turns--;
                    }
                }
                else if (this.Affliction == Enumerations.Affliction.Poisoned)
                {
                    if (this.Turns == 0)
                    {
                        this.Affliction = Enumerations.Affliction.None;
                    }
                    else
                    {
                        this.Health = this.Health - 5;
                        this.Turns--;
                    }
                }

                this.HasBeenAfflicted = true;
            }

            if (!this.HasBeenHit)
            {
                Random rng = new Random();

                for (int i = 0; i < renderer.SpellsCasted.Count; i++)
                {
                    if (renderer.SpellsCasted[i].Bounds.Intersects(this.Bounds) && renderer.SpellsCasted[i].MySpell.Armor == 0)
                    {
                        bool isFireAgainstIce = this.MagicSchool == SpellType.Ice && renderer.SpellsCasted[i].MySpell.Type == SpellType.Fire;
                        bool isPoisonAgainstFire = this.MagicSchool == SpellType.Fire && renderer.SpellsCasted[i].MySpell.Type == SpellType.Poison;
                        bool isIceAgainstPoison = this.MagicSchool == SpellType.Poison && renderer.SpellsCasted[i].MySpell.Type == SpellType.Ice;

                        if (this.Armor > 0)
                        {
                            if (isFireAgainstIce || isPoisonAgainstFire || isIceAgainstPoison)
                            {
                                int damage = (renderer.SpellsCasted[i].MySpell.Damage + this.DamageIncrease) - (int)(this.Armor / 2);
                                if (damage > 0)
                                {
                                    this.Health = this.Health - damage;
                                    this.Armor = 0;
                                }
                                else
                                {
                                    this.Armor = Math.Abs(damage) * 2;
                                }
                            }
                            else
                            {
                                this.Armor = this.Armor - (renderer.SpellsCasted[i].MySpell.Damage + this.DamageIncrease);
                                if (this.Armor < 0)
                                {
                                    this.Health = this.Health + this.Armor;
                                    this.Armor = 0;
                                }
                            }
                        }
                        else
                        {
                            int number = rng.Next(1, 101);
                            if (number < renderer.SpellsCasted[i].MySpell.ChanceToCauseAffliction)
                            {
                                if (renderer.SpellsCasted[i].MySpell.Type == SpellType.Ice)
                                {
                                    this.Affliction = Enumerations.Affliction.Frozen;
                                    this.Turns = 2;
                                }
                                else if (renderer.SpellsCasted[i].MySpell.Type == SpellType.Fire)
                                {
                                    this.Affliction = Enumerations.Affliction.Burning;
                                    this.Turns = 2;
                                }
                                else
                                {
                                    this.Affliction = Enumerations.Affliction.Poisoned;
                                    this.Turns = 2;
                                }
                            }

                            this.Health = this.Health - (renderer.SpellsCasted[i].MySpell.Damage + this.DamageIncrease);
                        }

                        renderer.SpellsCasted.Remove(renderer.SpellsCasted[i]);
                        this.HasBeenHit = true;
                    }
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Bounds, Color.White);
        }
    }
}
