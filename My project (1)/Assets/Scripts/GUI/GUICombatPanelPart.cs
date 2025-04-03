using UnityEngine;

public class GUICombatPanelPart : MonoBehaviour
{
    public EUIPanelName panelNameEnum;
}

public enum EUIPanelName
{
    Action,
    Item,
    Skill,
    Descriptor
}