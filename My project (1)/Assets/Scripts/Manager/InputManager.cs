using System;
using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour, ISystemManager
{
    public EntityInputClass[] Inputs;
    public PlayerInputClass PlayerInput;
    public AIInputClass AIINput;

    public Action DelegateBlockInput;

    public bool _isAllInputBlocked;
    public bool IsAllInputBlocked { get => _isAllInputBlocked; set => _isAllInputBlocked = value;}

    public void BlockInput()
    {
        DelegateBlockInput.Invoke();
    }

    public IEnumerator Init()
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
