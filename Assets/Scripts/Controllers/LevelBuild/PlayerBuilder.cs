using UnityEngine;

namespace Archer
{
    internal class PlayerBuilder
    {
        private Player _playerPrefab;
        private Player _player;

        public void BuildPlayer(Transform playerStartPosition)
        {
            if (_playerPrefab != null)
            {
                _player.transform.position = playerStartPosition.position;
            }
            else
            {
                _playerPrefab = Resources.Load<Player>(AssetsPath.Path[Assets.Player]);
                _player = GameObject.Instantiate<Player>(_playerPrefab,
                    playerStartPosition.position, Quaternion.identity);
            }
        }
    }
}