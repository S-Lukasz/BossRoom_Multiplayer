using Unity.BossRoom.Gameplay.GameplayObjects;
using Unity.BossRoom.Gameplay.GameplayObjects.Character;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthAffectData", menuName = "BossRoom/Actions/HealthAffect")]
public class HealthAffectData : ActionAffectData
{    
    public override void AffectValue(ServerCharacter parent, GameObject target, int value)
    {
        var targetToAffect = target.GetComponent<IDamageable>();
        if (targetToAffect != null)
        {
            targetToAffect.ReceiveHP(parent, value);
        }
    }
}
