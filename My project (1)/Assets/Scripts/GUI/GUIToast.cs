using TMPro;
using UnityEngine;

public class GUIToast : MonoBehaviour
{
    EGUICombatToastType GUICombatToastType;
    private GUIToastAnimation _animation;

    public void WriteValue(TextMeshProUGUI textBox,string text)
    {
        textBox.text = text;
    }

    public void ShowMessage(TextMeshProUGUI textBox)
    {
        textBox.enabled = true;
    }

    public void HideMessage(TextMeshProUGUI textBox)
    {
        textBox.enabled = false;
    }
}
