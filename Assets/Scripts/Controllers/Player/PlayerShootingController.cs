using System.Collections.Generic;
using UnityEngine;

namespace Archer
{
    internal class PlayerShootingController
    {
        private float delay;

        public void Shoot(Transform muzzle, float shootingSpeed, Bullet bulletPrefab)
        {
            if (delay <= 0)
            {
                Bullet bullet = GameObject.Instantiate<Bullet>(bulletPrefab, muzzle.position, muzzle.rotation);
                bullet.Body.AddForce(muzzle.up * bullet.BulletSpeed, ForceMode2D.Impulse);
                delay = 1 / shootingSpeed;
            }
            else
            {
                delay -= Time.fixedDeltaTime;
            }
        }

        public Vector3 GetDirection(List<Enemy> spotedEnemies, Vector3 position)
        {
            if (spotedEnemies.Count > 0)
            {
                Enemy target = spotedEnemies[0];
                foreach (Enemy enemy in spotedEnemies)
                {
                    if ((enemy.transform.position - position).sqrMagnitude <
                        (target.transform.position - position).sqrMagnitude)
                    {
                        target = enemy;
                    }
                }
                return target.transform.position - position;
            }
            return Vector3.zero;
        }
    }
}
