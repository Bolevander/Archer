using System;
using UnityEngine;

namespace Archer
{
    internal class LocationBuilder : ITearDownController
    {
        public event Action OnLevelComplete;

        public Gate CurrentGate { get; private set; }
        public Location CurrentLocation { get; private set; }

        public void BuildLevel(LocationModel locationModel)
        {
            CurrentLocation = GameObject.Instantiate(locationModel.locationPrefab);
            CurrentGate = CurrentLocation.GetComponentInChildren<Gate>();
            CurrentGate.OnGateReached += DestroyLevel;
            CurrentGate.OnGateReached += BuildLevel;
            OnLevelComplete?.Invoke();
        }

        public void TearDown()
        {
            CurrentGate.OnGateReached -= DestroyLevel;
            CurrentGate.OnGateReached -= BuildLevel;
        }

        public void DestroyLevel(LocationModel locationModel)
        {
            GameObject.Destroy(CurrentLocation.gameObject);
        }
    }
}