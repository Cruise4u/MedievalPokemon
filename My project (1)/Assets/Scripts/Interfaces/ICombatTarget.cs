using UnityEngine;

public interface ICombatTarget
{
    GameObject GetTargetGO();

    void GetStats(CharacterStats stats);

    void GetWithAbilityEffect(ECombatOperation op,int value);
}

public enum ECombatOperation
{
    Attack,
    Heal,
}