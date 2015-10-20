namespace RPG.Controller
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using RPG.Controller;
    using RPG.View;
    using RPG.View.Renderers;

    public class FirstRPG : Game
    {
        public FirstRPG()
        {
            this.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.Graphics.PreferredBackBufferHeight = 800;
            this.Graphics.PreferredBackBufferWidth = 1280;
        }

        public GraphicsDeviceManager Graphics { get; set; }

        public SpriteBatch SpriteBatch { get; set; }

        public MonoGameRenderer Renderer { get; set; }

        protected override void Initialize()
        {
            this.Renderer = new MonoGameRenderer();
            StateMachine.Initialize();
            StateMachine.CurrentState = StateMachine.States["InitialState"];
            StateMachine.CurrentState.Execute(this.Renderer);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            this.Renderer.GameTime = gameTime;
            StateMachine.CurrentState.Execute(this.Renderer);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            this.SpriteBatch.Begin();
            StateMachine.CurrentState.Draw(this.Renderer);
            this.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
