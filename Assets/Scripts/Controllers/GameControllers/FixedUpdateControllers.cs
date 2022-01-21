namespace Archer
{
    internal class FixedUpdateControllers : Controllers
    {
        public FixedUpdateControllers()
        {
            _controllers.AddRange(new IController[]
            {
                new InputController(),
            });
        }
    }
}