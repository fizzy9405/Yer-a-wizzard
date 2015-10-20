namespace RPG.Controller
{
    using System;

    public static class EntryPoint
    {
        public static FirstRPG Game { get; set; }

        public static void Main()
        {
            using (Game = new FirstRPG())
            {
                Game.Run();
            }
        }

        public static void ExitGame()
        {
            Game.Exit();
        }
    }
}
