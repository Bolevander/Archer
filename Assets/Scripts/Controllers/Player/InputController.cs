using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Archer
{
    internal class InputController : IInitializeController, IExecuteController
    {
        private Player _player;
        private Vector2 _inputAxis;
        private PlayerMovementController _playerMovement;
        private PlayerShootingController _playerShooting;

        public void Initialize()
        {
            _player = GameObject.FindObjectOfType<Player>();
            _playerMovement = new PlayerMovementController();
            _playerShooting = new PlayerShootingController();
        }

        public void Execute()
        {
            _inputAxis.x = CrossPlatformInputManager.GetAxis("Horizontal");
            _inputAxis.y = CrossPlatformInputManager.GetAxis("Vertical");

            if (_inputAxis.x != 0 || _inputAxis.y != 0)
            {
                _playerMovement.Move(_inputAxis, _player.Body, _player.Speed);
                _playerMovement.Rotate(_inputAxis, _player.Body);
            }
            else
            {
                Vector3 direction = _playerShooting.GetDirection(_player.SpotedEnemies, _player.transform.position);
                if (direction != Vector3.zero)
                {
                    _playerMovement.Rotate(direction, _player.Body);
                    _playerShooting.Shoot(_player.Muzzle, _player.Weapon.shootingSpeed, _player.Weapon.bullet);
                }
            }
        }
    }
}