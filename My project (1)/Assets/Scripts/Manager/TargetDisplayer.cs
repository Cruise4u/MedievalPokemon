using UnityEngine;

public class TargetDisplayer : MonoBehaviour
{
    public TargetManager TargetManager;

    public void Init()
    {
        TargetManager = GetComponent<TargetManager>();
    }

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
                target.GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
            else
            {
                target.GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
        }
    }




    // Iterates through the list and goes forward 
    // Showcasing the next element (+1) on that list.. 
    public void DisplayNextTargetOnList()
    {

    }


    // Iterates through the list and goes backwards 
    // Showcasing the previous element (-1) on that list..
    public void DisplayPreviousTargetOnList()
    {

    }

}
