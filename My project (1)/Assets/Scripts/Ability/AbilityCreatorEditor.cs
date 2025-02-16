using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityCreatorEditor", menuName = "Ability/AbilityCreatorEditor")]
public class AbilityCreatorEditor : SerializedScriptableObject
{
    [Title("Ability List")]
    [ListDrawerSettings(ShowFoldout = true)]
    public List<Ability> abilities;

    [Button("Create New Ability")]
    private void CreateNewAbility()
    {
        // Logic to create a new ability
        Debug.Log("New Ability Created");
    }
}



