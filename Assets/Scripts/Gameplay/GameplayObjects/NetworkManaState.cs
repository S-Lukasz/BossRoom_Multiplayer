using System;
using Unity.Netcode;
using UnityEngine;

namespace Unity.BossRoom.Gameplay.GameplayObjects
{
    public class NetworkManaState : NetworkBehaviour
    {

        [HideInInspector]
        public NetworkVariable<int> ManaPoints = new NetworkVariable<int>();

        public event Action ManaPointsDepleted;
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
                ManaPointsDepleted?.Invoke();
            }
            else if (previousValue <= 0 && newValue > 0)
            {
                ManaPointsReplenished?.Invoke();
            }
        }

        public bool CheckMana(int manaCost)
        {
            bool result = manaCost <= ManaPoints.Value;
            
            if(!result) NotEnoughMana?.Invoke(m_AlertText, false);

            Debug.Log("HasEnoughMana, result: "+result+" on object: "+gameObject.name);

            return result;
        }
    }
}
