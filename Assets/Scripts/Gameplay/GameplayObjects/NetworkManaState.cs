using System;
using Unity.Netcode;
using UnityEngine;

namespace Unity.BossRoom.Gameplay.GameplayObjects
{
    /// <summary>
    /// MonoBehaviour containing only one NetworkVariableInt which represents this object's health.
    /// </summary>
    public class NetworkManaState : NetworkBehaviour
    {

        [HideInInspector]
        public NetworkVariable<int> ManaPoints = new NetworkVariable<int>();

        // public subscribable event to be invoked when HP has been fully depleted
        public event Action ManaPointsDepleted;

        // public subscribable event to be invoked when HP has been replenished
        public event Action ManaPointsReplenished;

        public event Action<string, bool> NotEnoughMana;

        private const string m_AlertText = "Not enough mana!";

        void OnEnable()
        {
            ManaPoints.OnValueChanged += ManaPointsChanged;
        }

        void OnDisable()
        {
            ManaPoints.OnValueChanged -= ManaPointsChanged;
        }

        void ManaPointsChanged(int previousValue, int newValue)
        {
            if (previousValue > 0 && newValue <= 0)
            {
                // newly reached 0 HP
                ManaPointsDepleted?.Invoke();
            }
            else if (previousValue <= 0 && newValue > 0)
            {
                // newly revived
                ManaPointsReplenished?.Invoke();
            }
        }

        public bool HasEnoughMana(int manaCost)
        {
            bool result = manaCost <= ManaPoints.Value;
            if(!result) NotEnoughMana?.Invoke(m_AlertText, false);

            return result;
        }
    }
}
