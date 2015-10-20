namespace RPG.Controller.States
{
    using Microsoft.Xna.Framework.Input;
    using RPG.View.Renderers;

    public class InitialState : State
    {
        public InitialState(State nextState)
            : base(nextState)
        {
        }

        public override void Draw(MonoGameRenderer renderer)
        {
            renderer.DrawInitialScreenAnimation();
            renderer.UpdateInitialScreenAnimation();
        }

        public override void Execute(MonoGameRenderer renderer)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Enter))
            {
                StateMachine.ChangeState();
            }
        }
    }
}
