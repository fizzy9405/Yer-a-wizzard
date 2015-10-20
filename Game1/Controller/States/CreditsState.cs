namespace RPG.Controller.States
{
    using Microsoft.Xna.Framework.Input;
    using RPG.View.Renderers;
    using RPG.View.UI;

    public class CreditsState : State
    {
        public CreditsState(State nextState)
            : base(nextState)
        {
        }

        public override void Draw(MonoGameRenderer renderer)
        {
            renderer.DrawCreditsBackground();
            renderer.DrawCreditsSprite();
            renderer.DrawGoBackButton();
        }

        public override void Execute(MonoGameRenderer renderer)
        {
            Button gobackButton = renderer.GoBackButton;
            bool mouseOverGoBack = gobackButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);

            if (mouseOverGoBack)
            {
                gobackButton.ChangeToHoverImage();
            }
            else
            {
                gobackButton.ChangeToInactiveImage();
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && mouseOverGoBack)
            {
                gobackButton.ChangeToClickedImage();
                ////EntryPoint.game.renderer.ShouldPlayerMove = true;
                // StateMachine.CurrentState.NextState = StateMachine.menuSelectState;
                StateMachine.ChangeState();
            }
        }
    }
}
