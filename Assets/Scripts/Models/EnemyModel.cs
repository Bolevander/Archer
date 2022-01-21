using UnityEngine;

namespace Archer
{
    [CreateAssetMenu(fileName = "EnemyModel", menuName = "Data/Enemy/EnemyModel")]
    internal class EnemyModel : ScriptableObject
    {
        public int maxHealthPoints;
        public int price;
        public float maxSpeed;
    }
}
