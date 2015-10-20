namespace RPG.Controller
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using RPG.Controller.States;

    public static class StateMachine
    {
        public static State CurrentState { get; set; }

        public static State PreviousState { get; set; }

        public static Dictionary<string, State> States { get; set; }

        public static InitialState InitialState { get; set; }

        public static MenuSelectState MenuSelectState { get; set; }

        public static BattleState BattleState { get; set; }

        public static FireMapState FireMap { get; set; }

        public static IceMapState IceMap { get; set; }

        public static PoisonMapState PoisonMap { get; set; }

        public static SchoolSelectState SchoolSelectState { get; set; }

        public static EndTurnState EndTurnState { get; set; }

        public static EnemyTurnState EnemyTurnState { get; set; }

        public static GameOverState GameOverState { get; set; }

        public static CreditsState CreditsState { get; set; }

        public static void Initialize()
        {
            States = new Dictionary<string, State>();
            BattleState = new BattleState(EndTurnState);
            EnemyTurnState = new EnemyTurnState(BattleState);
            EndTurnState = new EndTurnState(EnemyTurnState);
            PoisonMap = new PoisonMapState(BattleState);
            FireMap = new FireMapState(BattleState);
            IceMap = new IceMapState(BattleState);
            SchoolSelectState = new SchoolSelectState(IceMap);
            MenuSelectState = new MenuSelectState(SchoolSelectState);
            GameOverState = new GameOverState(MenuSelectState);
            InitialState = new InitialState(MenuSelectState);
            CreditsState = new CreditsState(MenuSelectState);

            BattleState.NextState = EndTurnState;

            States.Add("InitialState", InitialState); 
            States.Add("MenuSelectState", MenuSelectState);
            States.Add("BattleState", BattleState);
        }

        public static void ChangeState()
        {
            CurrentState = CurrentState.NextState;
        }
    }
}
