using UnityEngine;

public class SquadUnit : MonoBehaviour, ICombatTarget
{
    private CharacterStats _characterStats;
    private TargetReference _targetRef;

    public CharacterStats CharacterStats { get { return _characterStats; } set { _characterStats = value; } }
    public TargetReference TargetReference { get { return _targetRef; } set { _targetRef = value; } }


    public void Init()
    {
        _characterStats = GetComponent<CharacterStats>();
        _targetRef = GetComponent<TargetReference>();
        _characterStats.SetStats();
        _characterStats.ShowHealthStats();
    }

    public void AttackTarget(ICombatTarget target)
    {
        target.TakeDamage(_characterStats.CurrentAttackPower);
    }

    public int GetHP()
    {
        return CharacterStats.CurrentHealth;
    }

    public void TakeDamage(int damage)
    {
        var newHP = CharacterStats.CurrentHealth;
        newHP -= damage;
        CharacterStats.CurrentHealth = newHP;
    }


}
