namespace RPG.Controller.States
{
    using Microsoft.Xna.Framework.Input;
    using RPG.View.Renderers;
    using RPG.View.UI;

    public class GameOverState : State
    {
        private KeyboardState state;

        public GameOverState(State nextState)
            : base(nextState)
        {
        }

        public override void Draw(MonoGameRenderer renderer)
        {
            if (renderer.MainHero.HasWon)
            {
                renderer.DrawBlackBackground();
                renderer.DrawWinLogo();
                renderer.DrawGoBackButton();
            }
            else
            {
                renderer.DrawLoserBackground();
                renderer.DrawGoBackButton();
            }
        }

        public override void Execute(MonoGameRenderer renderer)
        {
            Button gobackButton = renderer.GoBackButton;
            bool mouseOverGoBack = gobackButton.Sprite.Rectangle.Contains(Mouse.GetState().X, Mouse.GetState().Y);

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && this.state.IsKeyUp(Keys.Space))
            {
                EntryPoint.Game.Renderer = new MonoGameRenderer();
                StateMachine.ChangeState();
                StateMachine.CurrentState.Execute(EntryPoint.Game.Renderer);
            }

            this.state = Keyboard.GetState();

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
                EntryPoint.Game.Renderer = new MonoGameRenderer();
                ////EntryPoint.game.renderer.ShouldPlayerMove = true;
                // StateMachine.CurrentState.NextState = StateMachine.menuSelectState;
                StateMachine.ChangeState();
                StateMachine.CurrentState.Execute(EntryPoint.Game.Renderer);
            }
        }
    }
}
