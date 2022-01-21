using System.Collections.Generic;
using UnityEngine;

namespace Archer
{
    internal class Location : MonoBehaviour
    {
        [SerializeField] private Transform _playerStartPosition;
        [SerializeField] private List<Transform> _enemyPositions;

        public Transform PlayerStartPosition => _playerStartPosition;
        public List<Transform> EnemyPositions => _enemyPositions;
    }
}
