namespace RPG.View
{
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using RPG.Model.Enumerations;
    using RPG.Model.Heroes;
    using RPG.Model.Spell;
    using RPG.Model.Tiles;
    using RPG.View.UI;

    public static class UIInitializer
    {
        public static SpellAnimationFactory CreateSpellAnitmationFactory()
        {
            SpellAnimationFactory spellAnimationFactory = new SpellAnimationFactory();
            return spellAnimationFactory;
        }

        public static Background CreateLoserBackground(ContentManager content)
        {
            Texture2D loserImage = content.Load<Texture2D>("LoserBackground");
            Rectangle loserRectangle = new Rectangle(0, 0, 1280, 800);
            Sprite loserSprite = new Sprite(loserRectangle, loserImage);
            Background loser = new Background(loserSprite);
            return loser;
        }

        public static Background CreateBlackBackground(ContentManager content)
        {
            Texture2D blackImage = content.Load<Texture2D>("blackBG");
            Rectangle blackRectangle = new Rectangle(0, 0, 1280, 800);
            Sprite blackSprite = new Sprite(blackRectangle, blackImage);
            Background black = new Background(blackSprite);
            return black;
        }

        public static Background CreateCreditsBackground(ContentManager content)
        {
            Texture2D creditsBackground = content.Load<Texture2D>("creditsBackground");
            Rectangle backgroundRectangle = new Rectangle(0, 0, 1280, 800);
            Sprite creditsBackgroundSprite = new Sprite(backgroundRectangle, creditsBackground);
            Background credits = new Background(creditsBackgroundSprite);
            return credits;
        }

        public static Background CreateRedCastle(ContentManager content)
        {
            Texture2D redCastleImage = content.Load<Texture2D>("RedCastle");
            Rectangle redCastleRectangle = new Rectangle(550, 250, 200, 200);
            Sprite redCastleSprite = new Sprite(redCastleRectangle, redCastleImage);
            Background redCastle = new Background(redCastleSprite);
            return redCastle;
        }

        public static Background CreateBlueCastle(ContentManager content)
        {
            Texture2D blueCastleImage = content.Load<Texture2D>("BlueCastle");
            Rectangle blueCastleRectangle = new Rectangle(200, 250, 200, 200);
            Sprite blueCastleSprite = new Sprite(blueCastleRectangle, blueCastleImage);
            Background blueCastle = new Background(blueCastleSprite);
            return blueCastle;
        }

        public static Background CreateGreenCastle(ContentManager content)
        {
            Texture2D greenCastleImage = content.Load<Texture2D>("GreenCastle");
            Rectangle greenCastleRectangle = new Rectangle(900, 250, 200, 200);
            Sprite greenCastleSprite = new Sprite(greenCastleRectangle, greenCastleImage);
            Background greenCastle = new Background(greenCastleSprite);
            return greenCastle;
        }

        public static Background CreateBattleBackground(ContentManager content)
        {
            Texture2D battleBackgroundImage = content.Load<Texture2D>("BattleBackground");
            Rectangle backgroundRectangle = new Rectangle(0, 0, 1280, 800);
            Sprite backgroundSprite = new Sprite(backgroundRectangle, battleBackgroundImage);
            Background background = new Background(backgroundSprite);
            return background;
        }

        public static Background CreateBackground(ContentManager content)
        {
            Texture2D backgroundImage = content.Load<Texture2D>("MageWarsBackground");
            Rectangle backgroundRectangle = new Rectangle(0, 0, 1280, 800);
            Sprite backgroundSprite = new Sprite(backgroundRectangle, backgroundImage);
            Background background = new Background(backgroundSprite);
            return background;
        }

        public static Button CreateGreenButton(ContentManager content)
        {
            Texture2D startActive = content.Load<Texture2D>("buttonGreen1");
            Texture2D startClicked = content.Load<Texture2D>("buttonGreen3");
            Texture2D startHover = content.Load<Texture2D>("buttonGreen2");
            Rectangle startRectangle = new Rectangle(415, 250, 450, 80);
            Sprite startButtonSprite = new Sprite(startRectangle, startActive);
            Button startButton = new Button(startButtonSprite, startHover, startClicked, startActive);
            return startButton;
        }

        public static Button CreateBlueButton(ContentManager content)
        {
            Texture2D optionsActive = content.Load<Texture2D>("buttonBlue1");
            Texture2D optionsClicked = content.Load<Texture2D>("buttonBlue3");
            Texture2D optionsHover = content.Load<Texture2D>("buttonBlue2");
            Rectangle optionsRectangle = new Rectangle(415, 350, 450, 80);
            Sprite optionsButtonSprite = new Sprite(optionsRectangle, optionsActive);
            Button optionsButton = new Button(optionsButtonSprite, optionsHover, optionsClicked, optionsActive);
            return optionsButton;
        }

        public static Button CreateRedButton(ContentManager content)
        {
            Texture2D exitActive = content.Load<Texture2D>("buttonRed1");
            Texture2D exitClicked = content.Load<Texture2D>("buttonRed3");
            Texture2D exitHover = content.Load<Texture2D>("buttonRed2");
            Rectangle exitRectangle = new Rectangle(415, 450, 450, 80);
            Sprite exitButtonSprite = new Sprite(exitRectangle, exitActive);
            Button exitButton = new Button(exitButtonSprite, exitHover, exitClicked, exitActive);
            return exitButton;
        }

        public static Button CreateGoBackButton(ContentManager content)
        {
            Texture2D gobackActiveTexture = content.Load<Texture2D>("buttonRed1");
            Texture2D gobackClicked = content.Load<Texture2D>("buttonRed3");
            Texture2D gobackHover = content.Load<Texture2D>("buttonRed2");
            Rectangle gobackRectangle = new Rectangle(100, 600, gobackActiveTexture.Width / 2, gobackActiveTexture.Height / 2);
            Sprite gobackSprite = new Sprite(gobackRectangle, gobackActiveTexture);
            Button gobackButton = new Button(gobackSprite, gobackHover, gobackClicked, gobackActiveTexture);
            return gobackButton;
        }

        public static Button CreateFireballButton(ContentManager content)
        {
            Texture2D fireballActive = content.Load<Texture2D>("skills/fire_fireball_active");
            Texture2D fireballClicked = content.Load<Texture2D>("skills/fire_fireball_selected");
            Texture2D fireballHover = content.Load<Texture2D>("skills/fire_fireball_inactive");
            Rectangle fireballRectangle = new Rectangle(100, 700, 50, 50);
            Sprite fireballButtonSprite = new Sprite(fireballRectangle, fireballActive);
            Button fireballButton = new Button(fireballButtonSprite, fireballHover, fireballClicked, fireballActive);
            return fireballButton;
        }

        public static Button CreateFireShieldButton(ContentManager content)
        {
            Texture2D fireActive = content.Load<Texture2D>("skills/fire_fireshield_active");
            Texture2D fireClicked = content.Load<Texture2D>("skills/fire_fireshield_selected");
            Texture2D fireHover = content.Load<Texture2D>("skills/fire_fireshield_inactive");
            Rectangle fireRectangle = new Rectangle(175, 700, 50, 50);
            Sprite fireButtonSprite = new Sprite(fireRectangle, fireActive);
            Button fireButton = new Button(fireButtonSprite, fireHover, fireClicked, fireActive);
            return fireButton;
        }

        public static Button CreateMeteorButton(ContentManager content)
        {
            Texture2D fireActive = content.Load<Texture2D>("skills/fire_meteor_active");
            Texture2D fireClicked = content.Load<Texture2D>("skills/fire_meteor_selected");
            Texture2D fireHover = content.Load<Texture2D>("skills/fire_meteor_inactive");
            Rectangle fireRectangle = new Rectangle(250, 700, 50, 50);
            Sprite fireButtonSprite = new Sprite(fireRectangle, fireActive);
            Button fireButton = new Button(fireButtonSprite, fireHover, fireClicked, fireActive);
            return fireButton;
        }

        public static Button CreateIceboltButton(ContentManager content)
        {
            Texture2D iceActive = content.Load<Texture2D>("skills/ice_icebolt_active");
            Texture2D iceClicked = content.Load<Texture2D>("skills/ice_icebolt_selected");
            Texture2D iceHover = content.Load<Texture2D>("skills/ice_icebolt_inactive");
            Rectangle iceRectangle = new Rectangle(100, 700, 50, 50);
            Sprite iceButtonSprite = new Sprite(iceRectangle, iceActive);
            Button iceButton = new Button(iceButtonSprite, iceHover, iceClicked, iceActive);
            return iceButton;
        }

        public static Button CreateIceBarrierButton(ContentManager content)
        {
            Texture2D iceActive = content.Load<Texture2D>("skills/ice_iceshield_active");
            Texture2D iceClicked = content.Load<Texture2D>("skills/ice_iceshield_selected");
            Texture2D iceHover = content.Load<Texture2D>("skills/ice_iceshield_inactive");
            Rectangle iceRectangle = new Rectangle(175, 700, 50, 50);
            Sprite iceButtonSprite = new Sprite(iceRectangle, iceActive);
            Button iceButton = new Button(iceButtonSprite, iceHover, iceClicked, iceActive);
            return iceButton;
        }

        public static Button CreateHurricaneButton(ContentManager content)
        {
            Texture2D iceActive = content.Load<Texture2D>("skills/ice_hurricane_active");
            Texture2D iceClicked = content.Load<Texture2D>("skills/ice_hurricane_selected");
            Texture2D iceHover = content.Load<Texture2D>("skills/ice_hurricane_inactive");
            Rectangle iceRectangle = new Rectangle(250, 700, 50, 50);
            Sprite iceButtonSprite = new Sprite(iceRectangle, iceActive);
            Button iceButton = new Button(iceButtonSprite, iceHover, iceClicked, iceActive);
            return iceButton;
        }

        public static Button CreatePoisonspitButton(ContentManager content)
        {
            Texture2D poisonActive = content.Load<Texture2D>("skills/poison_poisonbolt_active");
            Texture2D poisonClicked = content.Load<Texture2D>("skills/poison_poisonbolt_selected");
            Texture2D poisonHover = content.Load<Texture2D>("skills/poison_poisonbolt_inactive");
            Rectangle poisonRectangle = new Rectangle(100, 700, 50, 50);
            Sprite poisonButtonSprite = new Sprite(poisonRectangle, poisonActive);
            Button poisonButton = new Button(poisonButtonSprite, poisonHover, poisonClicked, poisonActive);
            return poisonButton;
        }

        public static Button CreatePoisonCloudButton(ContentManager content)
        {
            Texture2D poisonActive = content.Load<Texture2D>("skills/poison_poisonshield_active");
            Texture2D poisonClicked = content.Load<Texture2D>("skills/poison_poisonshield_selected");
            Texture2D poisonHover = content.Load<Texture2D>("skills/poison_poisonshield_inactive");
            Rectangle poisonRectangle = new Rectangle(175, 700, 50, 50);
            Sprite poisonButtonSprite = new Sprite(poisonRectangle, poisonActive);
            Button poisonButton = new Button(poisonButtonSprite, poisonHover, poisonClicked, poisonActive);
            return poisonButton;
        }

        public static Button CreateDecayButton(ContentManager content)
        {
            Texture2D poisonActive = content.Load<Texture2D>("skills/poison_decay_active");
            Texture2D poisonClicked = content.Load<Texture2D>("skills/poison_decay_selected");
            Texture2D poisonHover = content.Load<Texture2D>("skills/poison_decay_inactive");
            Rectangle poisonRectangle = new Rectangle(250, 700, 50, 50);
            Sprite poisonButtonSprite = new Sprite(poisonRectangle, poisonActive);
            Button poisonButton = new Button(poisonButtonSprite, poisonHover, poisonClicked, poisonActive);
            return poisonButton;
        }

        public static Button CreateEndTurnButton(ContentManager content)
        {
            Texture2D endturnActive = content.Load<Texture2D>("buttons/endturn_button_active");
            Texture2D endturnClicked = content.Load<Texture2D>("buttons/endturn_button_inactive");
            Texture2D endturnHover = content.Load<Texture2D>("buttons/endturn_button_hover");
            Rectangle endturnRectangle = new Rectangle(1100, 700, 75, 50);
            Sprite endturnButtonSprite = new Sprite(endturnRectangle, endturnActive);
            Button endturnButton = new Button(endturnButtonSprite, endturnHover, endturnClicked, endturnActive);
            return endturnButton;
        }

        public static Button CreateSpellCastButton(ContentManager content)
        {
            Texture2D spellcastActive = content.Load<Texture2D>("buttons/spell_button_active");
            Texture2D spellcastClicked = content.Load<Texture2D>("buttons/spell_button_inactive");
            Texture2D spellcastHover = content.Load<Texture2D>("buttons/spell_button_hover");
            Rectangle spellcastRectangle = new Rectangle(1000, 700, 75, 50);
            Sprite spellcastButtonSprite = new Sprite(spellcastRectangle, spellcastActive);
            Button spellcastButton = new Button(spellcastButtonSprite, spellcastHover, spellcastClicked, spellcastActive);
            return spellcastButton;
        }

        public static Animation CreateInitialScreenAnimation(ContentManager content)
        {
            Texture2D initialScreenTexture = content.Load<Texture2D>("background3");
            Animation initialScreenAnimation = new Animation(initialScreenTexture, 1, 2);
            return initialScreenAnimation;
        }

        public static Texture2D CreateRedEnemy(ContentManager content)
        {
            Texture2D enemyTexture = content.Load<Texture2D>("RedEnemyTile");
            return enemyTexture;
        }

        public static Texture2D CreateBlueEnemy(ContentManager content)
        {
            Texture2D enemyTexture = content.Load<Texture2D>("BlueEnemyTile");
            return enemyTexture;
        }

        public static Texture2D CreateGreenEnemy(ContentManager content)
        {
            Texture2D enemyTexture = content.Load<Texture2D>("GreenEnemyTile");
            return enemyTexture;
        }

        public static Texture2D LoadBattleMenu(ContentManager content)
        {
            Texture2D battleMenu = content.Load<Texture2D>("BattleSpellsWindow"); // sample //we can always change it
            return battleMenu;
        }

        public static Texture2D LoadSpellInfoWindow(ContentManager content)
        {
            Texture2D spellInfoWindow = content.Load<Texture2D>("SpellInfoWindow");
            return spellInfoWindow;
        }

        public static Texture2D LoadCreditsSprite(ContentManager content)
        {
            Texture2D creditsSprite = content.Load<Texture2D>("CreditsSprite");
            return creditsSprite;
        }

        public static Texture2D LoadWinLogo(ContentManager content)
        {
            Texture2D winLogo = content.Load<Texture2D>("youwin");
            return winLogo;
        }

        public static Map LoadIceMap(ContentManager content)
        {
            Map theMap = new Map();
            StreamReader reader = new StreamReader("IceMap.txt");
            theMap.LoadContent(reader);
            return theMap;
        }

        public static Map LoadFireMap(ContentManager content)
        {
            Map theMap = new Map();
            StreamReader reader = new StreamReader("FireMap.txt");
            theMap.LoadContent(reader);
            return theMap;
        }

        public static Map LoadPoisonMap(ContentManager content)
        {
            Map theMap = new Map();
            StreamReader reader = new StreamReader("PoisonMap.txt");
            theMap.LoadContent(reader);
            return theMap;
        }

        public static Texture2D CreateGrassTile(ContentManager content)
        {
            Texture2D grass = content.Load<Texture2D>("grassTile");
            return grass;
        }

        public static Texture2D CreateRockTile(ContentManager content)
        {
            Texture2D rock = content.Load<Texture2D>("rockTile");
            return rock;
        }

        public static Texture2D CreatePathTile(ContentManager content)
        {
            Texture2D path = content.Load<Texture2D>("pathTile");
            return path;
        }

        public static Texture2D CreateGoToBlueTile(ContentManager content)
        {
            Texture2D gotoBlue = content.Load<Texture2D>("GoToBlue");
            return gotoBlue;
        }

        public static Texture2D CreateGoToGreenTile(ContentManager content)
        {
            Texture2D gotoGreen = content.Load<Texture2D>("GoToGreen");
            return gotoGreen;
        }

        public static Texture2D CreateGoToRedTile(ContentManager content)
        {
            Texture2D gotoRed = content.Load<Texture2D>("GoToRed");
            return gotoRed;
        }

        public static Character CreateMainCharacter(ContentManager content)
        {
            Texture2D mainCharacterTexture = content.Load<Texture2D>("BlueMage");
            Character mainCharacter = new Character(mainCharacterTexture, 4, 4, new Vector2(200, 200));
            return mainCharacter;
        }

        public static Hero CreateHero(ContentManager content)
        {
            Texture2D heroTexture = content.Load<Texture2D>("BigBlueMage");
            Hero hero = new Hero(SpellType.Ice, new Rectangle(50, 450, heroTexture.Bounds.Width, heroTexture.Bounds.Height), heroTexture, 1);
            return hero;
        }

        public static Hero CreateEnemyHero(ContentManager content)
        {
            Texture2D enemyTexture = content.Load<Texture2D>("BigBlueMage");
            Hero enemy = new Hero(SpellType.Ice, new Rectangle(1080, 450, enemyTexture.Bounds.Width, enemyTexture.Bounds.Height), enemyTexture, 1);
            return enemy;
        }

        public static List<Spell> CreateFireSpells(ContentManager content)
        {
            Spell fireballSpell = new Spell("Fireball", SpellType.Fire, 30, 0, 10, 10);
            Spell fireShield = new Spell("Fire Shield", SpellType.Fire, 0, 50, 20, 0);
            Spell meteorSpell = new Spell("Meteor", SpellType.Fire, 100, 0, 60, 100);
            List<Spell> fireSpells = new List<Spell> { fireballSpell, fireShield, meteorSpell };
            return fireSpells;
        }

        public static List<Spell> CreateIceSpells(ContentManager content)
        {
            Spell iceBolt = new Spell("Icebolt", SpellType.Ice, 20, 0, 10, 10);
            Spell iceBarrier = new Spell("Ice Barrier", SpellType.Ice, 0, 60, 20, 0);
            Spell hurricane = new Spell("Hurricane", SpellType.Ice, 80, 0, 50, 100);
            List<Spell> iceSpells = new List<Spell> { iceBolt, iceBarrier, hurricane };
            return iceSpells;
        }

        public static List<Spell> CreatePoisonSpells(ContentManager content)
        {
            Spell poisonSpit = new Spell("PoisonSpit", SpellType.Poison, 15, 0, 10, 25);
            Spell poisonCloud = new Spell("PoisonCloud", SpellType.Poison, 0, 30, 15, 0);
            Spell decaySpell = new Spell("Decay", SpellType.Poison, 50, 0, 30, 100);
            List<Spell> poisonSpells = new List<Spell> { poisonSpit, poisonCloud, decaySpell };
            return poisonSpells;
        }
    }
}
