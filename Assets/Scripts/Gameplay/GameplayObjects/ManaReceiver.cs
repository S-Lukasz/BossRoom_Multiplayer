using System;
using Unity.BossRoom.Gameplay.GameplayObjects.Character;
using Unity.Netcode;
using UnityEngine;

namespace Unity.BossRoom.Gameplay.GameplayObjects
{
    public class ManaReceiver : NetworkBehaviour, IManable
    {
        public event Action<ServerCharacter, int> ManaReceived;

        [SerializeField]
        NetworkLifeState m_NetworkLifeState;

        public void ReceiveMana(ServerCharacter inflicter, int mana)
        {
            if (IsAlive())
            {
                Debug.Log("Mana received: "+mana);
                ManaReceived?.Invoke(inflicter, mana);
            }
        }

        public bool IsAlive()
        {
            return m_NetworkLifeState.LifeState.Value == LifeState.Alive;
        }
    }
}
