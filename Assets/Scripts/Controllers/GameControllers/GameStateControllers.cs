namespace Archer
{
    internal abstract class GameStateControllers
    {
        private Controllers _updateCluster;
        private Controllers _fixedUpdateCluster;

        public void Initialize()
        {
            _updateCluster?.Initialize();
            _fixedUpdateCluster?.Initialize();
        }

        public void Execute(UpdateType updateType)
        {
            switch (updateType)
            {
                case UpdateType.Update:
                    _updateCluster?.Execute();
                    break;

                case UpdateType.Fixed:
                    _fixedUpdateCluster?.Execute();
                    break;

                default:
                    break;
            }
        }

        public void TearDown()
        {
            _updateCluster?.TearDown();
            _fixedUpdateCluster?.TearDown();
        }

        protected void AddCluster(Controllers cluster, UpdateType updateType = UpdateType.Update)
        {
            switch (updateType)
            {
                case UpdateType.Update:
                    _updateCluster = cluster;
                    break;

                case UpdateType.Fixed:
                    _fixedUpdateCluster = cluster;
                    break;

                default:
                    break;
            }
        }
    }
}
