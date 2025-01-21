using UnityEngine;

public class TargetDisplayer : MonoBehaviour
{
    // Displays a target by default
    // What this does is that enables a child GameObject component that "shows" an arrow to the TargetReference we're aiming at..
    // Will need to add a displayer for multiple targets, adjacent targets, etc.
    // For now this is a single-target cast displayer..
    public void DisplayTarget(GameObject target,bool condition)
    {
        if(target != null)
        {
            if (condition == true)
            {
                target.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                target.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

}
