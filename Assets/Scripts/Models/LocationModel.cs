using UnityEngine;

namespace Archer
{
    [CreateAssetMenu(fileName = "LocationModel", menuName = "Data/LocationModel")]
    internal class LocationModel : ScriptableObject
    {
        public Location locationPrefab;
    }
}