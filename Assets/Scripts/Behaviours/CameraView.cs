using UnityEngine;

namespace Archer
{
    internal class CameraView : MonoBehaviour
    {
        [field: SerializeField] public CameraModel CameraModel { get; set; }
        [field: SerializeField] public Camera Camera { get; private set; }
    }
}
