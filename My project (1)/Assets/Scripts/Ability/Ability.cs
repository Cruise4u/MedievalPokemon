using UnityEngine;
using System;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public abstract class BaseAbility : IAbilityProduct
{
    public EAbilityID AbilityID;
    public int Duration;
    public IAbilityEffect[] AbilityEffect;
    public ITarget[] TargetArray;

    public abstract void AbilityOperation();
}



public class ActiveAbility : BaseAbility
{
    public override void AbilityOperation()
    {
        throw new NotImplementedException();
    }
}

public class PassiveAbility : BaseAbility
{
    public override void AbilityOperation()
    {
        throw new NotImplementedException();
    }
}




public class Ability
{
    public EAbilityID AbilityID;
    public int Duration;
    public IAbilityEffect[] AbilityEffect;
    public ITarget[] TargetArray;
}

public enum EAbilityID
{
    Fireball,
    Frostnova,
    BlossomHeal,
}

public enum EAbilityEffect
{
    Damage,
    Heal,
    Slow,
    Stun,
    Poison,
    Burn,
    Chill,
}

public enum ETargetingType
{
    Single,
    Adjacent,
    AOE,
}

public enum ETargetTeam
{
    Friendly,
    Enemy,
    All,
    Self,
}



public class AbilitySO : SerializedScriptableObject
{
    public int AbilityDuration;
    public List<EAbilityEffect> AbilityEffectList;
    public List<ETargetTeam> TargetTeamList;
    public List<ETargetingType> TargetingTypeList;
}

public interface IAbilityEffect
{
    void ApplyEffect(ITarget[] targetArray);
}

public class DamageEffect : IAbilityEffect
{
    private int _damage;

    public DamageEffect(int damage)
    {
        _damage = damage;
    }

    public void ApplyEffect(ITarget[] targetArray)
    {
        foreach(ITarget target in targetArray)
        {
            target.targetGO().GetComponent<CharacterStats>().CurrentHealth -= _damage; 
        }
    }
}

public class HealEffect : IAbilityEffect
{
    private int _heal;

    public HealEffect(int heal)
    {
        _heal = heal;
    }

    public void ApplyEffect(ITarget[] targetArray)
    {
        foreach (ITarget target in targetArray)
        {
            target.targetGO().GetComponent<CharacterStats>().CurrentHealth -= _heal;
        }
    }
}

public class StunEffect : IAbilityEffect
{
    private bool _stun;

    public StunEffect(bool stun)
    {
        _stun = stun;
    }

    public void ApplyEffect(ITarget[] targetArray)
    {
        foreach (ITarget target in targetArray)
        {
            target.targetGO().GetComponent<CharacterStats>().IsStunned = true;
        }
    }
}

public class SlowEffect : IAbilityEffect
{
    public void ApplyEffect(ITarget[] targetArray)
    {
        throw new NotImplementedException();
    }
}

public interface ITarget
{
    GameObject targetGO();
}


