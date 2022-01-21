namespace Archer
{
    internal class GameSystemControllers : GameStateControllers
    {
        public GameSystemControllers()
        {
            AddCluster(new UpdateControllers(), UpdateType.Update);
            AddCluster(new FixedUpdateControllers(), UpdateType.Fixed);
        }
    }
}
