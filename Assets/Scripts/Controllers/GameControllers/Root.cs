using UnityEngine;

namespace Archer
{
    public class Root : MonoBehaviour
    {
        private GameSystemControllers _controllers;

        private void Start()
        {
            _controllers = new GameSystemControllers();
            _controllers?.Initialize();
        }

        private void Update()
        {
            _controllers?.Execute(UpdateType.Update);
        }

        private void FixedUpdate()
        {
            _controllers?.Execute(UpdateType.Fixed);
        }

        private void OnDestroy()
        {
            _controllers?.TearDown();
        }
    } 
}