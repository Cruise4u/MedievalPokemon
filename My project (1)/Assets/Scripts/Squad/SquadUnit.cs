using Sirenix.OdinInspector;
using UnityEngine;

public class SquadUnit : MonoBehaviour
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
}
