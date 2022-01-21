using System.Collections.Generic;
using UnityEngine;

namespace Archer
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal class Player : MonoBehaviour
    {
        [SerializeField] private PlayerModel _model;
        [SerializeField] private CircleCollider2D _rangeCollider;

        [field: SerializeField] public WeaponModel Weapon { get; set; }
        [field: SerializeField] public Rigidbody2D Body { get; private set; }
        [field: SerializeField] public Transform Muzzle { get; private set; }
        public List<Enemy> SpotedEnemies { get; private set; }
        public float Speed { get; set; }
        public int Coins { get; set; }
        public int CurrentHP { get; set; }

        private void Awake()
        {
            SpotedEnemies = new List<Enemy>();
            _rangeCollider.radius = Weapon.shootingRange;
            Speed = _model.maxSpeed;
            CurrentHP = _model.maxHealthPoints;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                SpotedEnemies.Add(enemy);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy enemy))
            {
                SpotedEnemies.Remove(enemy);
            }
        }
    }
}