namespace RPG.View.UI
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using RPG.Controller;
    using RPG.Model.Enumerations;
    using RPG.Model.Spell;

    public class SpellAnimationFactory
    {
        private Vector2 location;
        private Rectangle rect;
        private Vector2 velocity;

        public SpellAnimation Fireball(bool isRotated)
        {
            Texture2D fireballTexture = EntryPoint.Game.Content.Load<Texture2D>("FireBoltSprite");
            if (isRotated)
            {
                this.location = new Vector2(1000, 450);
                this.rect = new Rectangle(1000, 450, fireballTexture.Width, fireballTexture.Height);
                this.velocity = new Vector2(-10, 0);
            }
            else
            {
                this.location = new Vector2(230, 450);
                this.rect = new Rectangle(230, 450, fireballTexture.Width, fireballTexture.Height);
                this.velocity = new Vector2(10, 0);
            }

            Spell fireballSpell = new Spell("Fireball", SpellType.Fire, 30, 0, 10, 10);
            SpellAnimation fireball = new SpellAnimation(fireballTexture, this.velocity, 1, 4, this.location, this.rect, isRotated, fireballSpell);
            fireball.MillisecondsPerFrame = 50;
            return fireball;
        }

        public SpellAnimation Icebolt(bool isRotated)
        {
            Texture2D iceBoltTexture = EntryPoint.Game.Content.Load<Texture2D>("IceBoltSprite");
            if (isRotated)
            {
                this.location = new Vector2(1000, 450);
                this.rect = new Rectangle(1000, 450, iceBoltTexture.Width, iceBoltTexture.Height);
                this.velocity = new Vector2(-10, 0);
            }
            else
            {
                this.location = new Vector2(200, 450);
                this.rect = new Rectangle(200, 450, iceBoltTexture.Width, iceBoltTexture.Height);
                this.velocity = new Vector2(10, 0);
            }

            Spell iceBoltSpell = new Spell("Icebolt", SpellType.Ice, 20, 0, 10, 10);
            
            SpellAnimation icebolt = new SpellAnimation(iceBoltTexture, this.velocity, 1, 4, this.location, this.rect, isRotated, iceBoltSpell);
            icebolt.MillisecondsPerFrame = 50;

            return icebolt;
        }

        public SpellAnimation Poisonbolt(bool isRotated)
        {
            Texture2D poisonBoltTexture = EntryPoint.Game.Content.Load<Texture2D>("PoisonBoltSprite");
            if (isRotated)
            {
                this.location = new Vector2(1000, 450);
                this.rect = new Rectangle(1000, 450, poisonBoltTexture.Width, poisonBoltTexture.Height);
                this.velocity = new Vector2(-10, 0);
            }
            else
            {
                this.location = new Vector2(200, 450);
                this.rect = new Rectangle(200, 450, poisonBoltTexture.Width, poisonBoltTexture.Height);
                this.velocity = new Vector2(10, 0);
            }

            Spell poisonSpitSpell = new Spell("Poisonspit", SpellType.Poison, 15, 0, 10, 25);

            SpellAnimation poisonbolt = new SpellAnimation(poisonBoltTexture, this.velocity, 1, 4, this.location, this.rect, isRotated, poisonSpitSpell);
            poisonbolt.MillisecondsPerFrame = 50;

            return poisonbolt;
        }

        public SpellAnimation FireShield(bool isRotated)
        {
            Texture2D fireShieldTexture = EntryPoint.Game.Content.Load<Texture2D>("FireShield");
            if (isRotated)
            {
                this.location = new Vector2(1050, 450);
                this.rect = new Rectangle(1050, 450, fireShieldTexture.Width, fireShieldTexture.Height);
                this.velocity = new Vector2(0, 0);
            }
            else
            {
                this.location = new Vector2(25, 450);
                this.rect = new Rectangle(25, 450, fireShieldTexture.Width, fireShieldTexture.Height);
                this.velocity = new Vector2(0, 0);
            }
       
            Spell fireShieldSpell = new Spell("Fire Shield", SpellType.Fire, 0, 50, 20, 0);
       
            SpellAnimation fireShield = new SpellAnimation(fireShieldTexture, this.velocity, 1, 1, this.location, this.rect, isRotated, fireShieldSpell);
            fireShield.IsVisible = true;
            fireShield.StaysAfterEndTurn = true;
            return fireShield;
        }

        public SpellAnimation IceBarrier(bool isRotated)
        {
            Texture2D iceBarrierTexture = EntryPoint.Game.Content.Load<Texture2D>("IceShield");
            if (isRotated)
            {
                this.location = new Vector2(1050, 450);
                this.rect = new Rectangle(1050, 450, iceBarrierTexture.Width, iceBarrierTexture.Height);
                this.velocity = new Vector2(0, 0);
            }
            else
            {
                this.location = new Vector2(25, 450);
                this.rect = new Rectangle(25, 450, iceBarrierTexture.Width, iceBarrierTexture.Height);
                this.velocity = new Vector2(0, 0);
            }

            Spell iceBarrierSpell = new Spell("Ice Barrier", SpellType.Ice, 0, 60, 20, 0);

            SpellAnimation iceBarrier = new SpellAnimation(iceBarrierTexture, this.velocity, 1, 1, this.location, this.rect, isRotated, iceBarrierSpell);
            iceBarrier.IsVisible = true;
            iceBarrier.StaysAfterEndTurn = true;
            return iceBarrier;
        }

        public SpellAnimation PoisonCloud(bool isRotated)
        {
            Texture2D poisonCloudTexture = EntryPoint.Game.Content.Load<Texture2D>("PoisonShield");
            if (isRotated)
            {
                this.location = new Vector2(1050, 450);
                this.rect = new Rectangle(1050, 450, poisonCloudTexture.Width, poisonCloudTexture.Height);
                this.velocity = new Vector2(0, 0);
            }
            else
            {
                this.location = new Vector2(25, 450);
                this.rect = new Rectangle(25, 450, poisonCloudTexture.Width, poisonCloudTexture.Height);
                this.velocity = new Vector2(0, 0);
            }

            Spell poisonCloudSpell = new Spell("Ice Barrier", SpellType.Ice, 0, 60, 20, 0);

            SpellAnimation poisonCloud = new SpellAnimation(poisonCloudTexture, this.velocity, 1, 1, this.location, this.rect, isRotated, poisonCloudSpell);
            poisonCloud.IsVisible = true;
            poisonCloud.StaysAfterEndTurn = true;
            return poisonCloud;
        }

        public SpellAnimation Hurricane(bool isRotated)
        {
            Texture2D hurricaneTexture = EntryPoint.Game.Content.Load<Texture2D>("TornadoSprite");
            if (isRotated)
            {
                this.location = new Vector2(900, 350);
                this.rect = new Rectangle(900, 350, hurricaneTexture.Width, hurricaneTexture.Height);
                this.velocity = new Vector2(-10, 0);
            }
            else
            {
                this.location = new Vector2(230, 350);
                this.rect = new Rectangle(230, 350, hurricaneTexture.Width, hurricaneTexture.Height);
                this.velocity = new Vector2(10, 0);
            }

            Spell hurricaneSpell = new Spell("Hurricane", SpellType.Ice, 80, 0, 50, 100);

            SpellAnimation hurricane = new SpellAnimation(hurricaneTexture, this.velocity, 1, 5, this.location, this.rect, isRotated, hurricaneSpell);
            hurricane.MillisecondsPerFrame = 50;

            return hurricane;
        }

        public SpellAnimation Meteor(bool isRotated)
        {
            Texture2D meteorTexture = EntryPoint.Game.Content.Load<Texture2D>("MeteorSprite");
            if (isRotated)
            {
                this.location = new Vector2(850, 350);
                this.rect = new Rectangle(850, 350, meteorTexture.Width, meteorTexture.Height);
                this.velocity = new Vector2(-7, 0);
            }
            else
            {
                this.location = new Vector2(230, 350);
                this.rect = new Rectangle(230, 350, meteorTexture.Width, meteorTexture.Height);
                this.velocity = new Vector2(8, 0);
            }

            Spell meteorSpell = new Spell("Meteor", SpellType.Fire, 100, 0, 60, 100);

            SpellAnimation meteor = new SpellAnimation(meteorTexture, this.velocity, 1, 6, this.location, this.rect, isRotated, meteorSpell);
            meteor.MillisecondsPerFrame = 50;

            return meteor;
        }

        public SpellAnimation Decay(bool isRotated)
        {
            Texture2D decayTexture = EntryPoint.Game.Content.Load<Texture2D>("DecaySprite");
            if (isRotated)
            {
                this.location = new Vector2(900, 450);
                this.rect = new Rectangle(900, 450, decayTexture.Width, decayTexture.Height);
                this.velocity = new Vector2(-10, 0);
            }
            else
            {
                this.location = new Vector2(230, 450);
                this.rect = new Rectangle(230, 450, decayTexture.Width, decayTexture.Height);
                this.velocity = new Vector2(10, 0);
            }

            Spell decaySpell = new Spell("Meteor", SpellType.Poison, 50, 0, 30, 100);

            SpellAnimation decay = new SpellAnimation(decayTexture, this.velocity, 1, 6, this.location, this.rect, isRotated, decaySpell);
            decay.MillisecondsPerFrame = 50;

            return decay;
        }
    }
}
