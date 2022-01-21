using System.Collections.Generic;

namespace Archer
{
    internal abstract class Controllers
    {
        protected List<IController> _controllers;

        public Controllers()
        {
            _controllers = new List<IController>();
        }

        public void Execute()
        {
            for (int i = 0; i < _controllers.Count; i++)
            {
                (_controllers[i] as IExecuteController)?.Execute();
            }
        }

        public void Initialize()
        {
            for (int i = 0; i < _controllers.Count; i++)
            {
                (_controllers[i] as IInitializeController)?.Initialize();
            }
        }

        public void TearDown()
        {
            for (int i = 0; i < _controllers.Count; i++)
            {
                (_controllers[i] as ITearDownController)?.TearDown();
            }
        }
    }
}