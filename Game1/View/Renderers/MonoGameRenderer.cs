namespace RPG.View.Renderers
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using RPG.Controller;
    using RPG.Model.Enumerations;
    using RPG.Model.Heroes;
using RPG.Model.Spell;
    using RPG.Model.Tiles;
    using RPG.View.UI;

    public class MonoGameRenderer : AbstractRenderer
    {
        private ContentManager content = EntryPoint.Game.Content;
        private SpriteBatch spriteBatch;
        private Background background;
        private Background battleBackground;
        private Background blackBackground;
        private Background creditsBackground;
        private Background loserBackground;
        private Sprite winLogo;
        private Sprite battleMenuDown;
        private Sprite battleMenuUp;
        private Sprite spellInfoOne;
        private Sprite spellInfoTwo;
        private Sprite spellInfoThree;
        private Sprite creditsSprite;
        private SpriteFont font;
        private string startGameText;
        private string creditsText;
        private string exitText;
        private string iceMagicSchool;
        private string fireMagicSchool;
        private string poisonMagicSchool;
        private string heath;
        private string mana;
        private string armor;
        private string level;
        private string spellName;
        private string spellDamage;
        private string gobackText;
        private string afflictionText;

        public MonoGameRenderer()
        {
            this.creditsBackground = UIInitializer.CreateCreditsBackground(this.content);
            this.battleBackground = UIInitializer.CreateBattleBackground(this.content);
            this.background = UIInitializer.CreateBackground(this.content);
            this.blackBackground = UIInitializer.CreateBlackBackground(this.content);
            this.loserBackground = UIInitializer.CreateLoserBackground(this.content);
            this.RedCastle = UIInitializer.CreateRedCastle(this.content);
            this.BlueCastle = UIInitializer.CreateBlueCastle(this.content);
            this.GreenCastle = UIInitializer.CreateGreenCastle(this.content);
            this.RedButton = UIInitializer.CreateRedButton(this.content);
            this.GreenButton = UIInitializer.CreateGreenButton(this.content);
            this.BlueButton = UIInitializer.CreateBlueButton(this.content);
            this.GoBackButton = UIInitializer.CreateGoBackButton(this.content);
            this.FireballButton = UIInitializer.CreateFireballButton(this.content);
            this.FireShieldButton = UIInitializer.CreateFireShieldButton(this.content);
            this.MeteorButton = UIInitializer.CreateMeteorButton(this.content);
            this.IceboltButton = UIInitializer.CreateIceboltButton(this.content);
            this.IceBarrierButton = UIInitializer.CreateIceBarrierButton(this.content);
            this.HurricaneButton = UIInitializer.CreateHurricaneButton(this.content);
            this.PoisonspitButton = UIInitializer.CreatePoisonspitButton(this.content);
            this.PoisonCloudButton = UIInitializer.CreatePoisonCloudButton(this.content);
            this.DecayButton = UIInitializer.CreateDecayButton(this.content);
            this.SpellCastButton = UIInitializer.CreateSpellCastButton(this.content);
            this.EndTurnButton = UIInitializer.CreateEndTurnButton(this.content);
            this.InitialScreenAnimation = UIInitializer.CreateInitialScreenAnimation(this.content);
            this.MainCharacter = UIInitializer.CreateMainCharacter(this.content);
            this.MainHero = UIInitializer.CreateHero(this.content);
            this.EnemyHero = UIInitializer.CreateEnemyHero(this.content);
            this.SpellAnimationFactory = UIInitializer.CreateSpellAnitmationFactory();
            this.IceMap = UIInitializer.LoadIceMap(this.content);
            this.FireMap = UIInitializer.LoadFireMap(this.content);
            this.PoisonMap = UIInitializer.LoadPoisonMap(this.content);

            this.battleMenuDown = new Sprite(new Rectangle(), UIInitializer.LoadBattleMenu(this.content), new Vector2(10, 650));
            this.battleMenuUp = new Sprite(new Rectangle(), UIInitializer.LoadBattleMenu(this.content), new Vector2(10, 0));
            this.spellInfoOne = new Sprite(new Rectangle(), UIInitializer.LoadSpellInfoWindow(this.content), new Vector2(30, 500));
            this.spellInfoTwo = new Sprite(new Rectangle(), UIInitializer.LoadSpellInfoWindow(this.content), new Vector2(90, 500));
            this.spellInfoThree = new Sprite(new Rectangle(), UIInitializer.LoadSpellInfoWindow(this.content), new Vector2(150, 500));
            this.creditsSprite = new Sprite(new Rectangle(), UIInitializer.LoadCreditsSprite(this.content), new Vector2(800, 150));
            this.winLogo = new Sprite(new Rectangle(), UIInitializer.LoadWinLogo(this.content), new Vector2(450, 150));

            this.startGameText = "Start Game";
            this.creditsText = "Credits";
            this.exitText = "Exit";
            this.gobackText = "Go Back";
            this.iceMagicSchool = "Ice Magic School";
            this.fireMagicSchool = "Fire Magic School";
            this.poisonMagicSchool = "Poison Magic School";
            this.spellName = "Name: ";
            this.spellDamage = "Damage: ";
            this.heath = "Health: ";
            this.mana = "Mana: ";
            this.armor = "Armor: ";
            this.level = "Level: ";
            this.afflictionText = "Effect: ";

            this.font = this.content.Load<SpriteFont>("Font");

            this.EnemyCounter = this.IceMap.EnemyCounter + this.FireMap.EnemyCounter + this.PoisonMap.EnemyCounter;

            this.FireSpells = UIInitializer.CreateFireSpells(this.content);
            this.PoisonSpells = UIInitializer.CreatePoisonSpells(this.content);
            this.IceSpells = UIInitializer.CreateIceSpells(this.content);

            this.SpellsCasted = new List<SpellAnimation>();
            this.ShieldsCasted = new List<SpellAnimation>();
        }

        public EnemyTile Enemy { get; set; }

        public List<Spell> FireSpells { get; set; }

        public List<Spell> IceSpells { get; set; }

        public List<Spell> PoisonSpells { get; set; }

        public List<SpellAnimation> SpellsCasted { get; set; }

        public List<SpellAnimation> ShieldsCasted { get; set; }

        public Button GreenButton { get; set; }

        public Button BlueButton { get; set; }

        public Button RedButton { get; set; }

        public Button GoBackButton { get; set; }

        public Button BattleStateButtonOne { get; set; }

        public Button BattleStateButtonTwo { get; set; }

        public Button BattleStateButtonThree { get; set; }

        public Button FireballButton { get; set; }

        public Button FireShieldButton { get; set; }

        public Button MeteorButton { get; set; }

        public Button IceboltButton { get; set; }

        public Button IceBarrierButton { get; set; }

        public Button HurricaneButton { get; set; }

        public Button PoisonspitButton { get; set; }

        public Button PoisonCloudButton { get; set; }

        public Button DecayButton { get; set; }

        public Button SpellCastButton { get; set; }

        public Button EndTurnButton { get; set; }

        public Map IceMap { get; set; }

        public Map FireMap { get; set; }

        public Map PoisonMap { get; set; }

        public int EnemyCounter { get; set; }

        public Character MainCharacter { get; set; }

        public Hero MainHero { get; set; }

        public Hero EnemyHero { get; set; }

        public Background RedCastle { get; set; }

        public Background BlueCastle { get; set; }

        public Background GreenCastle { get; set; }

        public Animation InitialScreenAnimation { get; set; }

        public SpellAnimationFactory SpellAnimationFactory { get; set; }

        public GameTime GameTime { get; set; }

        public void DrawBlackBackground()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            this.blackBackground.Draw(this.spriteBatch);
        }

        public void DrawEnemyHero()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            this.EnemyHero.Draw(this.spriteBatch);
        }

        public void DrawHeroMenuText() 
        {
            this.spriteBatch.DrawString(this.font, this.heath + this.MainHero.Health, new Vector2(80, 20), Color.Black);
            this.spriteBatch.DrawString(this.font, this.mana + this.MainHero.Mana, new Vector2(80, 45), Color.Black);
            this.spriteBatch.DrawString(this.font, this.armor + this.MainHero.Armor, new Vector2(80, 70), Color.Black);
            this.spriteBatch.DrawString(this.font, this.level + this.MainHero.Level, new Vector2(80, 95), Color.Black);
            this.spriteBatch.DrawString(this.font, this.afflictionText + this.MainHero.Affliction, new Vector2(80, 120), Color.Black);
        }

        public void DrawEnemyMenuText()
        {
            this.spriteBatch.DrawString(this.font, this.heath + this.EnemyHero.Health, new Vector2(1000, 20), Color.Black);
            this.spriteBatch.DrawString(this.font, this.mana + this.EnemyHero.Mana, new Vector2(1000, 45), Color.Black);
            this.spriteBatch.DrawString(this.font, this.armor + this.EnemyHero.Armor, new Vector2(1000, 70), Color.Black);
            this.spriteBatch.DrawString(this.font, this.level + this.EnemyHero.Level, new Vector2(1000, 95), Color.Black);
            this.spriteBatch.DrawString(this.font, this.afflictionText + this.EnemyHero.Affliction, new Vector2(1000, 120), Color.Black);
        }

        public void DrawBlueCastle()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            this.BlueCastle.Draw(this.spriteBatch);
        }

        public void DrawGreenCastle()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            this.GreenCastle.Draw(this.spriteBatch);
        }

        public void DrawRedCastle()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            this.RedCastle.Draw(this.spriteBatch);
        }

        public override void DrawBackGround()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            this.background.Draw(this.spriteBatch);
        }

        public void DrawLoserBackground()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;
            this.loserBackground.Draw(this.spriteBatch);
        }

        public void DrawBattleMenu()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;
            this.battleMenuDown.Draw(this.spriteBatch);
            this.battleMenuUp.Draw(this.spriteBatch);
        }

        public void DrawCreditsBackground()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;
            this.creditsBackground.Draw(this.spriteBatch);
        }

        public void DrawCreditsSprite() 
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;
            this.creditsSprite.Draw(this.spriteBatch);
        }

        public void DrawWinLogo()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;
            this.winLogo.Draw(this.spriteBatch);
        }

        public void DrawBattleBackground()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            this.battleBackground.Draw(this.spriteBatch);
        }

        public void DrawStartMenuButtons()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            this.GreenButton.Draw(this.spriteBatch);
            this.spriteBatch.DrawString(this.font, this.startGameText, new Vector2(600, 280), Color.Black);
            this.BlueButton.Draw(this.spriteBatch);
            this.spriteBatch.DrawString(this.font, this.creditsText, new Vector2(610, 380), Color.Black);
            this.RedButton.Draw(this.spriteBatch);
            this.spriteBatch.DrawString(this.font, this.exitText, new Vector2(625, 480), Color.Black);
        }

        public void DrawSchoolSelectButtons()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            this.BlueButton.Draw(this.spriteBatch);
            this.spriteBatch.DrawString(this.font, this.iceMagicSchool, new Vector2(223, 528), Color.Black);
            this.RedButton.Draw(this.spriteBatch);
            this.spriteBatch.DrawString(this.font, this.fireMagicSchool, new Vector2(575, 528), Color.Black);
            this.GreenButton.Draw(this.spriteBatch);
            this.spriteBatch.DrawString(this.font, this.poisonMagicSchool, new Vector2(915, 528), Color.Black);
        }

        public void DrawGoBackButton()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;
            this.GoBackButton.Draw(this.spriteBatch);
            this.spriteBatch.DrawString(this.font, this.gobackText, new Vector2(200, 629), Color.Black);
        }

        public void DrawBattleStateButtons()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            this.BattleStateButtonOne.Draw(this.spriteBatch);
            this.BattleStateButtonTwo.Draw(this.spriteBatch);
            this.BattleStateButtonThree.Draw(this.spriteBatch);
            this.EndTurnButton.Draw(this.spriteBatch);
            this.SpellCastButton.Draw(this.spriteBatch);
        }

        public void DrawSpellInfoWindow()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;
            if (this.BattleStateButtonOne.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                this.spellInfoOne.Draw(this.spriteBatch);
                this.spriteBatch.DrawString(this.font, this.spellName + this.MainHero.PlayerSpells[0].Name, new Vector2(65, 540), Color.Black);
                this.spriteBatch.DrawString(this.font, this.mana + this.MainHero.PlayerSpells[0].ManaCost, new Vector2(65, 570), Color.Black);
                this.spriteBatch.DrawString(this.font, this.spellDamage + this.MainHero.PlayerSpells[0].Damage, new Vector2(65, 600), Color.Black);
                this.spriteBatch.DrawString(this.font, this.armor + this.MainHero.PlayerSpells[0].Armor, new Vector2(65, 630), Color.Black);
            }
            else if (this.BattleStateButtonTwo.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                this.spellInfoTwo.Draw(this.spriteBatch);
                this.spriteBatch.DrawString(this.font, this.spellName + this.MainHero.PlayerSpells[1].Name, new Vector2(125, 540), Color.Black);
                this.spriteBatch.DrawString(this.font, this.mana + this.MainHero.PlayerSpells[1].ManaCost, new Vector2(125, 570), Color.Black);
                this.spriteBatch.DrawString(this.font, this.spellDamage + this.MainHero.PlayerSpells[1].Damage, new Vector2(125, 600), Color.Black);
                this.spriteBatch.DrawString(this.font, this.armor + this.MainHero.PlayerSpells[1].Armor, new Vector2(125, 630), Color.Black);
            }
            else if (this.BattleStateButtonThree.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {
                this.spellInfoThree.Draw(this.spriteBatch);
                this.spriteBatch.DrawString(this.font, this.spellName + this.MainHero.PlayerSpells[2].Name, new Vector2(185, 540), Color.Black);
                this.spriteBatch.DrawString(this.font, this.mana + this.MainHero.PlayerSpells[2].ManaCost, new Vector2(185, 570), Color.Black);
                this.spriteBatch.DrawString(this.font, this.spellDamage + this.MainHero.PlayerSpells[2].Damage, new Vector2(185, 600), Color.Black);
                this.spriteBatch.DrawString(this.font, this.armor + this.MainHero.PlayerSpells[2].Armor, new Vector2(185, 630), Color.Black);
            }
        }

        public void DrawInitialScreenAnimation()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            this.InitialScreenAnimation.Draw(this.spriteBatch, new Vector2(0, 0));
        }

        public void UpdateInitialScreenAnimation()
        {
            this.InitialScreenAnimation.Update(this.GameTime);
        }

        public void DrawMap(Map map)
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            foreach (Tile tile in map.TileMap)
            {
                if (tile.Type == TypesOfGroundTiles.Grass)
                {
                    new TileImage(
                        new Sprite(
                            tile.TileRectangle,
                        UIInitializer.CreateGrassTile(this.content))).Draw(this.spriteBatch);
                }
                else if (tile.Type == TypesOfGroundTiles.Rock)
                {
                    new TileImage(
                        new Sprite(
                            tile.TileRectangle,
                        UIInitializer.CreateRockTile(this.content))).Draw(this.spriteBatch);
                }
                else if (tile.Type == TypesOfGroundTiles.Path)
                {
                    new TileImage(
                        new Sprite(
                            tile.TileRectangle,
                        UIInitializer.CreatePathTile(this.content))).Draw(this.spriteBatch);
                }
                else if (tile.Type == TypesOfGroundTiles.GoToBlue)
                {
                    new TileImage(
                        new Sprite(
                            tile.TileRectangle,
                        UIInitializer.CreateGoToBlueTile(this.content))).Draw(this.spriteBatch);
                }
                else if (tile.Type == TypesOfGroundTiles.GoToGreen)
                {
                    new TileImage(
                        new Sprite(
                            tile.TileRectangle,
                        UIInitializer.CreateGoToGreenTile(this.content))).Draw(this.spriteBatch);
                }
                else if (tile.Type == TypesOfGroundTiles.GoToRed)
                {
                    new TileImage(
                        new Sprite(
                            tile.TileRectangle,
                        UIInitializer.CreateGoToRedTile(this.content))).Draw(this.spriteBatch);
                }
                else if (tile.Type == TypesOfGroundTiles.RedEnemyTile)
                {
                    new TileImage(
                        new Sprite(
                            tile.TileRectangle,
                        UIInitializer.CreateRedEnemy(this.content))).Draw(this.spriteBatch);
                }
                else if (tile.Type == TypesOfGroundTiles.GreenEnemyTile)
                {
                    new TileImage(
                        new Sprite(
                            tile.TileRectangle,
                        UIInitializer.CreateGreenEnemy(this.content))).Draw(this.spriteBatch);
                }
                else if (tile.Type == TypesOfGroundTiles.BlueEnemyTile)
                {
                    new TileImage(
                        new Sprite(
                            tile.TileRectangle,
                        UIInitializer.CreateBlueEnemy(this.content))).Draw(this.spriteBatch);
                }
            }
        }

        public void DrawHero()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            this.MainHero.Draw(this.spriteBatch);
        }

        public void DrawMainCharacter()
        {
            this.spriteBatch = EntryPoint.Game.SpriteBatch;

            this.MainCharacter.Draw(this.spriteBatch);
        }

        public void UpdateMainCharacter()
        {
            this.MainCharacter.Update(this.GameTime);
        }

        public void UpdateMap(Map map) 
        {
            foreach (Tile tile in map.TileMap)
            {
                if (tile.Type == TypesOfGroundTiles.RedEnemyTile ||
                    tile.Type == TypesOfGroundTiles.BlueEnemyTile ||
                    tile.Type == TypesOfGroundTiles.GreenEnemyTile)
                {
                    EnemyTile newEnemyTile = tile as EnemyTile;
                    if (newEnemyTile.IsDefeated)
                    {
                        new TileImage(
                            new Sprite(
                                tile.TileRectangle,
                       UIInitializer.CreateGrassTile(this.content))).Draw(this.spriteBatch);
                    }
                }
            }
        }
    }
}
