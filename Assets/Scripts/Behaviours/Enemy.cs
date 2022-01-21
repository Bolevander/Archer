using System;
using UnityEngine;

namespace Archer
{
    internal class Enemy : MonoBehaviour
    {
        public event Action<Enemy> IsDead;

        [field: SerializeField] public CircleCollider2D RangeCollider { get; set; }
        public int CurrentHP { get; set; }
        public int Price { get; set; }
        public float Speed { get; set; }


        public void TakeDamage(int damage)
        {
            if (damage <= CurrentHP)
            {
                CurrentHP -= damage;
            }
            else
            {
                CurrentHP = 0;
            }

            if (CurrentHP == 0)
            {
                IsDead?.Invoke(this);
            }
        }

        public void Delete(Enemy enemy)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
