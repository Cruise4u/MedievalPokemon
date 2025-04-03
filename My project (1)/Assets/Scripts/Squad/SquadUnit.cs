using UnityEngine;

public class SquadUnit : MonoBehaviour,ICombatTarget
{
    public ETeamTag TeamTag;
    private ICombatTarget _selfTarget;

    private CharacterStats _characterStats;

    public CharacterStats CharacterStats { get { return _characterStats; } set { _characterStats = value; } }

    public void GetWithAbilityEffect()
    {
        throw new System.NotImplementedException();
    }

    public void GetStats(CharacterStats stats)
    {
        throw new System.NotImplementedException();
    }

    public void Init()
    {
        _characterStats = GetComponent<CharacterStats>();
        _characterStats.SetStats();
        _characterStats.ShowHealthStats();
    }

    public GameObject GetTargetGO()
    {
        return gameObject;
    }

    public void GetWithAbilityEffect(ECombatOperation op, int value)
    {
        if(op == ECombatOperation.Attack)
        {
            if(value >= _characterStats.CurrentHealth)
            {
                _characterStats.CurrentHealth = 0;
            }
            else
            {
                _characterStats.CurrentHealth -= value;
            }
        }
        else if(op == ECombatOperation.Heal)
        {
            if(value >= _characterStats.MaxHealth || _characterStats.CurrentHealth + value == _characterStats.MaxHealth)
            {
                _characterStats.MaxHealth = value;
                _characterStats.CurrentHealth = _characterStats.MaxHealth;
            }
            else
            {
                _characterStats.CurrentHealth += value;
            }
        }
    }
}
