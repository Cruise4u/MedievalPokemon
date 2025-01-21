using TMPro;


public static class GUIDisplayHelper
{
    public static void DisplayTurn(TextMeshProUGUI text, int turnID)
    {
        if (turnID == 0)
        {
            text.text = "Player Turn";
        }
        else
        {
            text.text = "AI Turn";
        }
    }
}

public class GUIToast
{

}

public class GUIToastAnimation
{

}