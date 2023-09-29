using Unity.BossRoom.Gameplay.Actions;
using Unity.BossRoom.Gameplay.GameplayObjects.Character;
using UnityEngine;

public abstract class ActionAffectData : ScriptableObject
{
    [SerializeField] private string m_AffectLayer;
    [SerializeField] private AffectActionType m_AffectType;

    public string AffectLayer => m_AffectLayer;

    public abstract void AffectValue(ServerCharacter parent, GameObject target, int value);
}
