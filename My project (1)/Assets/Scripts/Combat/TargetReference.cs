using UnityEngine;

public class TargetReference : MonoBehaviour
{
    public ETeamTag TeamTag; 
    private ICombatTarget _selfTarget;

    public ICombatTarget SelfTarget { get { return _selfTarget; } set { _selfTarget = value; } }

    public void Init()
    {
        _selfTarget = GetComponent<ICombatTarget>();
    }


}



