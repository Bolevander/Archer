using System;
using UnityEngine;

namespace Archer
{
    internal class Gate : MonoBehaviour
    {
        public event Action<LocationModel> OnGateReached;
        [SerializeField] private LocationModel nextLocation;

        public bool CanPoceed { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out Player player) && !collision.isTrigger)
            {
                if (CanPoceed)
                {
                    OnGateReached?.Invoke(nextLocation); 
                }
            }
        }
    }
}