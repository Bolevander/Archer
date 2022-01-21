using UnityEngine;

namespace Archer
{
    [CreateAssetMenu(fileName = "CommonEnemy", menuName = "Data/Enemy/CommonEnemy")]
    internal class CommonEnemyModel : ScriptableObject
    {
        public Enemy enemyPrefab;
        public EnemyModel enemyModel;
        public WeaponModel weapon;
    }
}
