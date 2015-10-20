namespace RPG.Controller.States
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using RPG.View.Renderers;
    using RPG.View.UI;

    public class MenuSelectState : State
    {
        public MenuSelectState(State nextState)
            : base(nextState)
        {
        }

        public override void Draw(MonoGameRenderer renderer)
        {
            renderer.DrawBackGround();

            renderer.BlueButton.Sprite.Rectangle = new Rectangle(415, 350, 450, 80);
            renderer.GreenButton.Sprite.Rectangle = new Rectangle(415, 250, 450, 80);
            renderer.RedButton.Sprite.Rectangle = new Rectangle(415, 450, 450, 80);

            renderer.DrawStartMenuButtons();
        }

        public override void Execute(MonoGameRenderer renderer)
        {
            Button startButton = renderer.GreenButton;
            Button exitButton = renderer.RedButton;
            Button optionsButton = renderer.BlueButton;

            bool mouseOverStart = startButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            bool mouseOverExit = exitButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);
            bool mouseOverOptions = optionsButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);

            if (mouseOverStart)
            {
                startButton.ChangeToHoverImage();
            }
            else
            {
                startButton.ChangeToInactiveImage();
            }

            if (mouseOverExit)
            {
                exitButton.ChangeToHoverImage();
            }
            else
            {
                exitButton.ChangeToInactiveImage();
            }

            if (mouseOverOptions)
            {
                optionsButton.ChangeToHoverImage();
            }
            else
            {
                optionsButton.ChangeToInactiveImage();
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverStart)
            {
                startButton.ChangeToClickedImage();
                StateMachine.CurrentState.NextState = StateMachine.SchoolSelectState;
                ////EntryPoint.game.renderer.ShouldPlayerMove = true;
                StateMachine.ChangeState();
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverExit)
            {
                exitButton.ChangeToClickedImage();
                ////EntryPoint.game.renderer.ShouldPlayerMove = true;
                ////StateMachine.ChangeState();
                EntryPoint.Game.Exit();
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverOptions)
            {
                optionsButton.ChangeToClickedImage();
                ////EntryPoint.game.renderer.ShouldPlayerMove = true;
                StateMachine.CurrentState.NextState = StateMachine.CreditsState;
                StateMachine.ChangeState();
            }
        }
    }
}
