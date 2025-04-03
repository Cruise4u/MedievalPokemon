using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetManager : ManagerBase
{
    public ETeamTag EnemyTag;
    public ICombatTarget Target;
    public int TargetIndex;

    public event Action<GameObject, bool> OnTargetSelected;

    [SerializeField]
    private List<ICombatTarget> _targetList;
    private List<GameObject> _targetGOList;

    private void FetchEnemyTargets()
    {
        //Get All targets with the EnemyTag into a single Array
        var targetArray = FindObjectsOfType<SquadUnit>()
            .Where(target => target.TeamTag == EnemyTag)
            .ToArray();
        for(int i = 0; i < targetArray.Length; i++)
        {
            _targetList.Add(targetArray[i]);
            _targetGOList.Add(_targetList[i].GetTargetGO());
        }
    }

    private void ResetTargets()
    {
        _targetList.Clear();
        _targetGOList.Clear();
        Target = null;
    }

    public void AddTargets(ETeamTag tag)
    {
        var targets = FindObjectsOfType<SquadUnit>()
            .Where(target => target.TeamTag == tag)
            .ToArray();

        foreach (var target in targets)
        {
            _targetList.Add(target);
            _targetGOList.Add(target.gameObject);
        }
    }

    public void RemoveTarget(ICombatTarget target)
    {
        if (target != null)
        {
            _targetList.Remove(target);
            _targetGOList.Remove(target.GetTargetGO());
        }
    }

    public void ChooseTarget()
    {
        Target = _targetList[TargetIndex];
    }

    public void NextTarget()
    {
        UpdateTargetSelection(false);
        TargetIndex = (TargetIndex + 1) % _targetGOList.Count;
        UpdateTargetSelection(true);
    }

    public void PreviousTarget()
    {
        UpdateTargetSelection(false);
        TargetIndex = (TargetIndex - 1 + _targetGOList.Count) % _targetGOList.Count;
        UpdateTargetSelection(true);
    }

    private void UpdateTargetSelection(bool isSelected)
    {
        if (_targetGOList.Count > 0)
        {
            OnTargetSelected?.Invoke(_targetGOList[TargetIndex], isSelected);
        }
    }

    public override IEnumerator Init()
    {
        _targetList = new List<ICombatTarget>();
        _targetGOList = new List<GameObject>();
        FetchEnemyTargets();
        TargetIndex = 0;
        OnTargetSelected += GetComponent<TargetDisplayer>().DisplayTarget;
        yield return null;
    }



}

