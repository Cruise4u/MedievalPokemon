using UnityEngine;

public abstract class EntityInputClass : MonoBehaviour
{
    [SerializeField]
    private bool _isInputBlocked;
    public bool isInputBlocked { get => _isInputBlocked; set => _isInputBlocked = value; }

    public abstract void Init();

    public abstract void BlockInput();
}
