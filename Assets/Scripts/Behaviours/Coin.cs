using UnityEngine;

namespace Archer
{
    internal class Coin : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private Animator _animator;
        private Player _player;
        private bool _isFollowing;

        public void StartFollow()
        {
            _player = FindObjectOfType<Player>();
            _animator.applyRootMotion = true;
            _isFollowing = true;
        }

        private void FixedUpdate()
        {
            if (_isFollowing)
            {
                Vector2 direction = _player.transform.position - transform.position;
                _body.MovePosition(_body.position + _speed * Time.deltaTime * direction);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out Player player) && !collision.isTrigger)
            {
                player.Coins++;
                GameObject.Destroy(gameObject);
            }
        }
    }
}