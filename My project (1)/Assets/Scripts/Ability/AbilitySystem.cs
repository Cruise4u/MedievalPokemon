using UnityEngine;
using System;
using System.Collections.Generic;

public class AbilitySystem
{

}

public class AbilityGlobalRegistery
{
    public Dictionary<EAbilityID, Ability> AbilityDictionary;
}

public class AbilityActorRegistery
{
    public Dictionary<EAbilityID, Ability> AbilityDictionary;
}


public abstract class AbilityBuilder
{
    public abstract IAbilityProduct BuilderDefaultMethod();
}

public class BuffBuilder : AbilityBuilder
{
    public override IAbilityProduct BuilderDefaultMethod()
    {
        return new Buff();
    }
}

public class Buff : IAbilityProduct
{
    public Buff()
    {
        // Do something
    }
}

public interface IAbilityProduct
{

}


