using System;
using Unity.BossRoom.Gameplay.GameplayObjects.Character;
using UnityEngine;

namespace Unity.BossRoom.Gameplay.GameplayObjects
{
    public interface IManable
    {
        void ReceiveMana(ServerCharacter inflicter, int mana);
    
        ulong NetworkObjectId { get; }
        Transform transform { get; }

        bool IsAlive();
    }
}

