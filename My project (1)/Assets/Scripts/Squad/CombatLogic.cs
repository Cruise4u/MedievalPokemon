using UnityEngine;

public class CombatLogic : MonoBehaviour
{
    public void AttackTarget(ICombatTarget target, int damage)
    {
        target.GetWithAbilityEffect(ECombatOperation.Attack, damage);
    }

    public void HealTarget(ICombatTarget target, int heal)
    {
        target.GetWithAbilityEffect(ECombatOperation.Heal, heal);
    }


}