namespace RPG.Controller.States
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using RPG.View.Renderers;
    using RPG.View.UI;

    public class SchoolSelectState : State
    {
        public SchoolSelectState(State nextState)
            : base(nextState)
        {
        }

        public override void Draw(MonoGameRenderer renderer)
        {
            renderer.DrawBlackBackground();
            renderer.DrawBlueCastle();
            renderer.DrawRedCastle();
            renderer.DrawGreenCastle();

            renderer.BlueButton.Sprite.Rectangle = new Rectangle(175, 500, 250, 80);
            renderer.GreenButton.Sprite.Rectangle = new Rectangle(875, 500, 250, 80);
            renderer.RedButton.Sprite.Rectangle = new Rectangle(530, 500, 250, 80);

            renderer.DrawSchoolSelectButtons();
        }

        public override void Execute(MonoGameRenderer renderer)
        {
            Button greenButton = renderer.GreenButton;
            Button redButton = renderer.RedButton;
            Button blueButton = renderer.BlueButton;

            bool mouseOverGreen = greenButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            bool mouseOverRed = redButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            bool mouseOverBlue = blueButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);

            if (mouseOverGreen)
            {
                greenButton.ChangeToHoverImage();
            }
            else
            {
                greenButton.ChangeToInactiveImage();
            }

            if (mouseOverRed)
            {
                redButton.ChangeToHoverImage();
            }
            else
            {
                redButton.ChangeToInactiveImage();
            }

            if (mouseOverBlue)
            {
                blueButton.ChangeToHoverImage();
            }
            else
            {
                blueButton.ChangeToInactiveImage();
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverGreen)
            {
                greenButton.ChangeToClickedImage();
                Texture2D newTextureForCharacter = EntryPoint.Game.Content.Load<Texture2D>("GreenMage");
                Texture2D newTextureForHero = EntryPoint.Game.Content.Load<Texture2D>("BigGreenMage");

                renderer.MainCharacter.Texture = newTextureForCharacter;
                renderer.MainHero.Texture = newTextureForHero;
                renderer.MainHero.PlayerSpells = renderer.PoisonSpells;
                renderer.MainHero.MagicSchool = RPG.Model.Enumerations.SpellType.Poison;

                renderer.BattleStateButtonOne = renderer.PoisonspitButton;
                renderer.BattleStateButtonTwo = renderer.PoisonCloudButton;
                renderer.BattleStateButtonThree = renderer.DecayButton;

                StateMachine.SchoolSelectState.NextState = StateMachine.PoisonMap;
                StateMachine.ChangeState();
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverRed)
            {
                redButton.ChangeToClickedImage();
                Texture2D newTextureForCharacter = EntryPoint.Game.Content.Load<Texture2D>("RedMage");
                Texture2D newTextureForHero = EntryPoint.Game.Content.Load<Texture2D>("BigRedMage");

                renderer.MainCharacter.Texture = newTextureForCharacter;
                renderer.MainHero.Texture = newTextureForHero;
                renderer.MainHero.PlayerSpells = renderer.FireSpells;
                renderer.MainHero.MagicSchool = RPG.Model.Enumerations.SpellType.Fire;

                renderer.BattleStateButtonOne = renderer.FireballButton;
                renderer.BattleStateButtonTwo = renderer.FireShieldButton;
                renderer.BattleStateButtonThree = renderer.MeteorButton;

                StateMachine.SchoolSelectState.NextState = StateMachine.FireMap;
                StateMachine.ChangeState();
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverBlue)
            {
                blueButton.ChangeToClickedImage();
                Texture2D newTextureForCharacter = EntryPoint.Game.Content.Load<Texture2D>("BlueMage");
                Texture2D newTextureForHero = EntryPoint.Game.Content.Load<Texture2D>("BigBlueMage");

                renderer.MainCharacter.Texture = newTextureForCharacter;
                renderer.MainHero.Texture = newTextureForHero;
                renderer.MainHero.PlayerSpells = renderer.IceSpells;
                renderer.MainHero.MagicSchool = RPG.Model.Enumerations.SpellType.Ice;

                renderer.BattleStateButtonOne = renderer.IceboltButton;
                renderer.BattleStateButtonTwo = renderer.IceBarrierButton;
                renderer.BattleStateButtonThree = renderer.HurricaneButton;

                StateMachine.SchoolSelectState.NextState = StateMachine.IceMap;
                StateMachine.ChangeState();
            }
        }
    }
}
