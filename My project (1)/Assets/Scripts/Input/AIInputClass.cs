public class AIInputClass : EntityInputClass
{
    public override void BlockInput()
    {
        isInputBlocked = true;
    }

    public override void Init()
    {
        isInputBlocked = false;
    }
}