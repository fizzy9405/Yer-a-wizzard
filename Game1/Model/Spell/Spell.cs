namespace RPG.Model.Spell
{
    using RPG.Model.Enumerations;

    public class Spell
    {
        public Spell(string name, SpellType type, int damage, int armor, int manaCost, int chance)
        {
            this.Name = name;
            this.Type = type;
            this.Damage = damage;
            this.Armor = armor;
            this.ManaCost = manaCost;
            this.ChanceToCauseAffliction = chance;
        }

        public string Name { get; private set; }

        public int Damage { get; private set; }

        public int Armor { get; private set; }

        public int ManaCost { get; private set; }

        public SpellType Type { get; private set; }

        public int ChanceToCauseAffliction { get; private set; }

        public void AddAllSpells()
        {
           /* Spell Fireball = new Spell("Fireball", SpellType.Fire, 60, 0, 40, 10);
            Spell Firedash = new Spell("Firedash", SpellType.Fire, 40, 0, 10, 20);
            Spell MeteorFall = new Spell("Meteor Fall", SpellType.Fire, 80, 0, 100, 0);
            Spell Explosion = new Spell("Explosion", SpellType.Fire, 40, 0, 60, 40);
            Spell Pyrokinesis = new Spell("Pyrokinesis", SpellType.Fire, 35, 0, 10, 90);
            Spell ShieldBomb= new Spell("Shield Bomb", SpellType.Fire, 10, 30, 0, 10);
            Spell PhoenixFlight = new Spell("Phoenix Flight", SpellType.Fire, 75.5, 0, 50, 0); // Deals 30 damage to self
            Spell FlameWheel = new Spell("Flame Wheel", SpellType.Fire, 60, 0, 40, 50);
            Spell FlameGuard = new Spell("Flame Guard", SpellType.Fire, 0, 80, 0, 0);

            Spell FrostBolt = new Spell("Frost Bolt", SpellType.Ice, 40, 0, 10, 50);
            Spell IceBarrier = new Spell("Ice Barrier", SpellType.Ice, 0, 60, 0, 0);
            Spell IcyMist = new Spell("Icy Mist", SpellType.Ice, 45, 0, 15, 40);
            Spell ColdSnap = new Spell("Cold Snap", SpellType.Ice, 30, 5, 30, 0); //double damage if enemy is frozen
            Spell ShellSmash = new Spell("Shell Smash", SpellType.Ice, 0, 0, 0, 0); // damage equals to armor. Armor then becomes 0
            Spell IceTornado = new Spell("IceTornado", SpellType.Ice, 30, 0, 0, 25);
            Spell WindsOfWinter = new Spell("Winds of Winter", SpellType.Ice, 60, 0, 50, 100);
            Spell IceWall = new Spell("Ice Wall", SpellType.Ice, 0, 100, 45, 20);
            Spell SubzeroTouch = new Spell("SubZero Touch", SpellType.Ice, 40, 10, 20, 100);

            Spell Toxins = new Spell("Toxins", SpellType.Poison, 5, 0, 15, 100);
            Spell Suffer = new Spell("Suffer", SpellType.Poison, 20, 0, 25, 20);
            Spell BadBlood = new Spell("Bad Blood", SpellType.Poison, 30, 0, 0, 0);
            Spell DeadlyPoison = new Spell("Deadly Poison", SpellType.Poison, 15, 0, 30, 100);
            Spell MeltBones = new Spell("Melt Bones", SpellType.Poison, 30, 0, 40, 20);
            Spell PainfulJab = new Spell("Panful Jab", SpellType.Poison, 40, 0, 50, 0);
            Spell ShadowMeld = new Spell("ShadowMeld", SpellType.Poison, 10, 30, 10, 0);
            Spell Horror = new Spell("Horror", SpellType.Poison, 30, 0, 25, 30);
            Spell CullTheMeek = new Spell("Cull the Meek", SpellType.Poison, 65, 0, 100, 100); */
        }
    }
}
