namespace RPG.Model.Interfaces
{
    using Heroes;

    public interface ITile
    {
        int Index { get; }

        string Name { get; }

        // string ActOnPlayer(Hero hero);
    }
}
