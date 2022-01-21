namespace Archer
{
    internal class UpdateControllers : Controllers
    {
        public UpdateControllers()
        {
            _controllers.AddRange(new IController[]
            {
                new LevelController(),
                new CameraController(),
            });
        }
    }
}
