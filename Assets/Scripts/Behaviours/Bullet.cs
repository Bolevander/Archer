using UnityEngine;

namespace Archer
{
    internal class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private Animator _animator;
        private readonly string _explosionTriggerName = "Explosion";
        private float _timeToDestroy = 1f;

        [field: SerializeField] public float BulletSpeed { get; private set; }
        [field: SerializeField] public Rigidbody2D Body { get; private set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.isTrigger)
            {
                Body.velocity = Vector2.zero;
                if (collision.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeDamage(_damage);
                }
                _animator.SetTrigger(_explosionTriggerName);
                Destroy(gameObject, _timeToDestroy); 
            }
        }
    }
}
