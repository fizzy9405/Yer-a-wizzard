namespace RPG.Controller.States
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using RPG.Model.Enumerations;
    using RPG.View.Renderers;

    public abstract class GameState
        : State
    {
        public GameState(State nextState) :
            base(nextState)
        {
        }

        public override void Draw(MonoGameRenderer renderer)
        {
        }

        public override void Execute(MonoGameRenderer renderer)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Up))
            {
                renderer.MainCharacter.CharacterMovement = CharacterMovement.Up;
                Vector2 velocity = new Vector2(0, -5);
                renderer.MainCharacter.Velocity = velocity;
            }
            else if (state.IsKeyDown(Keys.Down))
            {
                renderer.MainCharacter.CharacterMovement = CharacterMovement.Down;
                Vector2 velocity = new Vector2(0, 5);
                renderer.MainCharacter.Velocity = velocity;
            }
            else if (state.IsKeyDown(Keys.Left))
            {
                renderer.MainCharacter.CharacterMovement = CharacterMovement.Left;
                Vector2 velocity = new Vector2(-5, 0);
                renderer.MainCharacter.Velocity = velocity;
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                renderer.MainCharacter.CharacterMovement = CharacterMovement.Right;
                Vector2 velocity = new Vector2(5, 0);
                renderer.MainCharacter.Velocity = velocity;
            }
            else
            {
                renderer.MainCharacter.CharacterMovement = CharacterMovement.Stationary;
                Vector2 velocity = new Vector2(0, 0);
                renderer.MainCharacter.Velocity = velocity;
            }

            if (renderer.EnemyCounter == 0)
            {
                renderer.MainHero.HasWon = true;
                StateMachine.CurrentState.NextState = StateMachine.GameOverState;
                StateMachine.ChangeState();
                StateMachine.CurrentState.Execute(renderer);
                return;
            }
        }
    }
}
