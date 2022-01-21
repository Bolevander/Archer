using UnityEngine;

namespace Archer
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Data/Weapon")]
    internal class WeaponModel : ScriptableObject
    {
        public float shootingSpeed;
        public float shootingRange;
        public Bullet bullet;
    }
}