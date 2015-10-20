namespace RPG.Controller.States
{
    using RPG.View.Renderers;

    public abstract class State
    {
        public State(State nextState)
            : this(nextState, string.Empty)
        {
        }

        public State(State nextState, string message)
        {
            this.NextState = nextState;
            this.Message = message;
        }

        public string Message { get; set; }

        public State NextState { get; set; }

        public abstract void Execute(MonoGameRenderer renderer);

        public abstract void Draw(MonoGameRenderer renderer);
    }
}
