using UnityEngine;

namespace Archer
{
    [CreateAssetMenu(fileName = "PlayerModel", menuName = "Data/PlayerModel")]
    internal class PlayerModel : ScriptableObject
    {
        public float maxSpeed;
        public int maxHealthPoints;
    }
}
