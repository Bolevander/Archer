using UnityEngine;

namespace Archer
{
    internal class PlayerMovementController
    {        
        public void Move(Vector2 direction, Rigidbody2D body, float speed)
        {
            body.MovePosition(body.position + speed * Time.fixedDeltaTime * direction);
        }

        public void Rotate(Vector2 direction, Rigidbody2D body)
        {
            body.SetRotation(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
        }
    }
}
