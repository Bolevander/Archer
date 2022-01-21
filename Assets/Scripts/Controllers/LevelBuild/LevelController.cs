using UnityEngine;

namespace Archer
{
    internal class LevelController : IInitializeController, ITearDownController
    {
        private LocationBuilder _locationBuilder;
        private PlayerBuilder _playerBuilder;
        private CommonEnemyBuilder _enemyBuilder;
        private EnemyCounter _enemyCounter;
        private CoinDropper _coinDropper;

        public void Initialize()
        {
            _locationBuilder = new LocationBuilder();
            _playerBuilder = new PlayerBuilder();
            _enemyBuilder = new CommonEnemyBuilder();
            _enemyCounter = new EnemyCounter();
            _coinDropper = new CoinDropper();

            _locationBuilder.OnLevelComplete += CreatePlayer;
            _locationBuilder.OnLevelComplete += CreateEnemy;
            _locationBuilder.OnLevelComplete += ResetEnemyCount;
            _enemyCounter.IsEnemyOver += GetAccessToNextLocation;

            CreateStartLocation();
        }

        public void TearDown()
        {
            _locationBuilder.OnLevelComplete -= CreatePlayer;
            _locationBuilder.OnLevelComplete -= CreateEnemy;
            _locationBuilder.OnLevelComplete -= ResetEnemyCount;
            _enemyCounter.IsEnemyOver -= GetAccessToNextLocation;
            _locationBuilder.TearDown();
        }

        private void CreateStartLocation()
        {
            _locationBuilder.BuildLevel(Resources.Load<LocationModel>(AssetsPath.Path[Assets.StartLevel]));           
        }

        private void CreatePlayer()
        {
            _playerBuilder.BuildPlayer(_locationBuilder.CurrentLocation.PlayerStartPosition);
        }

        private void CreateEnemy()
        {
            _enemyBuilder.BuildEnemy(_locationBuilder.CurrentLocation.EnemyPositions,
                _enemyCounter.DecreaseEnemyCount, _coinDropper.DropACoin);
        }

        private void ResetEnemyCount()
        {
            _enemyCounter.EnemyCount = _locationBuilder.CurrentLocation.EnemyPositions.Count;
        }

        private void GetAccessToNextLocation()
        {
            _locationBuilder.CurrentGate.CanPoceed = true;
        }
    }
}