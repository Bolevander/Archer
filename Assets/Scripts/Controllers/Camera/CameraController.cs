using UnityEngine;

namespace Archer
{
    internal class CameraController : IInitializeController, IExecuteController
    {
        private CameraView _cameraView;
        private float _cameraYOffset;
        private Player _player;

        public void Initialize()
        {
            _cameraView = GameObject.FindObjectOfType<CameraView>();
            _player = GameObject.FindObjectOfType<Player>();
            _cameraView.Camera.transform.position = _cameraView.CameraModel.cameraPosition;
            _cameraView.Camera.orthographicSize = _cameraView.CameraModel.size;
            _cameraYOffset = _cameraView.Camera.transform.position.y - _player.transform.position.y;
        }

        public void Execute()
        {
            if (_cameraView.CameraModel.isFollow)
            {
                Vector3 cameraPosition = _cameraView.Camera.transform.position;
                float newY = _player.transform.position.y + _cameraYOffset;
                if (newY > _cameraView.CameraModel.topBorder)
                {
                    newY = _cameraView.CameraModel.topBorder;
                }
                else if (newY < _cameraView.CameraModel.bottomBorder)
                {
                    newY = _cameraView.CameraModel.bottomBorder;
                }

                _cameraView.Camera.transform.position = new Vector3(cameraPosition.x, newY, cameraPosition.z);
            }
        }
    }
}
