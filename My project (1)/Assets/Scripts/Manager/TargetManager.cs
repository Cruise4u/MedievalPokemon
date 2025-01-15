using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using UnityEditor.Playables;
using UnityEngine;

public class TargetManager : MonoBehaviour, ICombatManager
{
    public ETeamTag EnemyTag;

    public TargetReference TargetSelected;

    [SerializeField]
    private List<TargetReference> _targetList;
    private List<GameObject> _targetGOList;

    // This is an integer (will start at 0)
    // So we can iterate through an array/list of targets
    // And at each element we can display the component index of the target we're aiming at..
    public int targetSelectorIndex;

    public Action<GameObject,bool> OnTargetSelected;

    public IEnumerator Init()
    {
        Debug.LogWarning("Initialized Manager method");
        _targetList = new List<TargetReference>();
        _targetGOList = new List<GameObject>();
        TargetSelected = null;
        OnTargetSelected += gameObject.GetComponent<TargetDisplayer>().DisplayTarget;
        AddTargets(EnemyTag);
        yield return null; 
    }

    public void AddTargets(ETeamTag tag)
    {
        TargetReference[] targets = FindObjectsOfType<TargetReference>().Where(target => target.TeamTag == tag).ToArray();
        for(int i = 0; i < targets.Length; i++)
        {
            _targetList.Add(targets[i]);
            _targetGOList.Add(targets[i].gameObject);
        }
    }

    public void RemoveTarget(TargetReference target)
    {
        if(target != null)
        {
            _targetList.Remove(target);
            _targetGOList.Add(target.gameObject);
        }
    }

    public void ChooseTarget(TargetReference targetSelected)
    {
        if (targetSelected != null)
        {
            TargetSelected = targetSelected;
        }
    }

    public void NextTarget()
    {
        OnTargetSelected.Invoke(_targetGOList[targetSelectorIndex], false);
        if (targetSelectorIndex != _targetGOList.Count - 1)
        {
            targetSelectorIndex += 1;
        }
        else if (targetSelectorIndex == _targetGOList.Count - 1)
        {
            targetSelectorIndex = 0;
        }
        OnTargetSelected.Invoke(_targetGOList[targetSelectorIndex],true);
    }

    public void PreviousTarget()
    {
        OnTargetSelected.Invoke(_targetGOList[targetSelectorIndex], false);
        if (targetSelectorIndex != 0)
        {
            targetSelectorIndex -= 1;
        }
        else if (targetSelectorIndex == 0)
        {
            targetSelectorIndex = _targetGOList.Count - 1;
        }
        OnTargetSelected.Invoke(_targetGOList[targetSelectorIndex], true);
    }

    public void StartCombatInit()
    {
        throw new NotImplementedException();
    }
}
