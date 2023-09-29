using Unity.BossRoom.Gameplay.GameplayObjects;
using Unity.BossRoom.Gameplay.GameplayObjects.Character;
using UnityEngine;

[CreateAssetMenu(fileName = "ManaAffectData", menuName = "BossRoom/Actions/ManaAffect")]
public class ManaAffectData : ActionAffectData
{
    public override void AffectValue(ServerCharacter parent, GameObject target, int value)
    {
        var targetToAffect = target.GetComponent<IManable>();
        if (targetToAffect != null)
        {
            targetToAffect.ReceiveMana(parent, value);
        }
    }
}
