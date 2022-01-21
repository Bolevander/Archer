using System;
using UnityEngine;

namespace Archer
{
    internal class EnemyCounter
    {
        public event Action IsEnemyOver;
        public int EnemyCount { get; set; }

        public void DecreaseEnemyCount(Enemy enemy)
        {
            EnemyCount--;
            if (EnemyCount <= 0)
            {
                IsEnemyOver?.Invoke();
            }
        }
    }
}
