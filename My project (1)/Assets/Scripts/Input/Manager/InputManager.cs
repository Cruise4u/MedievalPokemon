using System;
using System.Collections;
using UnityEngine;

public class InputManager : ManagerBase
{
    public EntityInputClass[] Inputs;

    public Action DelegateBlockInput;

    public bool _isAllInputBlocked;
    public bool IsAllInputBlocked { get => _isAllInputBlocked; set => _isAllInputBlocked = value;}

    public void BlockInput()
    {
        DelegateBlockInput.Invoke();
    }

    public override IEnumerator Init()
    {
        Inputs = FindObjectsOfType<EntityInputClass>();
        foreach (EntityInputClass input in Inputs)
        {
            DelegateBlockInput += input.BlockInput;
        }
        yield return null;
    }

    public void StartSystemInit()
    {
        StartCoroutine(Init());
    }
}
