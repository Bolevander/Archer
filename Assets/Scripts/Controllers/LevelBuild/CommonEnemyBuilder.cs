using System;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{
    internal class CommonEnemyBuilder
    {
        private readonly CommonEnemyModel[] _enemyData;       

        public CommonEnemyBuilder()
        {
            _enemyData = Resources.LoadAll<CommonEnemyModel>(AssetsPath.Path[Assets.Enemy]);
        }

        public void BuildEnemy(List<Transform> enemyPositions, Action<Enemy> CheckEnemyCount, Action<Enemy> DropACoin)
        {
            foreach (Transform enemyPos in enemyPositions)
            {
                int rnd = UnityEngine.Random.Range(0, _enemyData.Length);
                var enemy = GameObject.Instantiate<Enemy>(_enemyData[rnd].
                    enemyPrefab, enemyPos.position, Quaternion.Euler(0, 0, 180));
                enemy.Speed = _enemyData[rnd].enemyModel.maxSpeed;
                enemy.CurrentHP = _enemyData[rnd].enemyModel.maxHealthPoints;
                enemy.RangeCollider.radius = _enemyData[rnd].weapon.shootingRange;
                enemy.Price = _enemyData[rnd].enemyModel.price;                
                enemy.IsDead += DropACoin;
                enemy.IsDead += CheckEnemyCount;
                enemy.IsDead += enemy.Delete;
            }
        }
    }
}