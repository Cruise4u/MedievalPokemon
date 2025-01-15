using UnityEngine;

public class PlayerInputClass : EntityInputClass
{
    public override void BlockInput()
    {
        isInputBlocked = true;
        Debug.Log("Input Blocked!");
    }

    public override void Init()
    {
        isInputBlocked = false;
    }
}
