using UnityEngine;

namespace Archer
{
    [CreateAssetMenu(fileName = "CameraModel", menuName = "Data/CameraModel")]
    internal class CameraModel : ScriptableObject
    {
        public Vector3 cameraPosition;
        public bool isFollow;
        public float size;
        public float bottomBorder;
        public float topBorder;
    }
}
