using UnityEngine;
using Unity.VisualScripting;

[UnitTitle("Custom Event Trigger")]
[UnitCategory("Events")]
public class CustomEventTriggerNode : Unit
{
    // Define the input ports
    [DoNotSerialize]
    public ValueInput eventName;

    [DoNotSerialize]
    public ValueInput targetObjects;

    [DoNotSerialize]
    public ControlInput trigger;

    // Define the output port
    [DoNotSerialize]
    public ControlOutput triggered;

    // Define the node's behavior
    protected override void Definition()
    {
        // Define the input ports
        eventName = ValueInput<string>("eventName");
        targetObjects = ValueInput<GameObject[]>("targetObjects");

        trigger = ControlInput("trigger", Trigger);

        // Define the output port
        triggered = ControlOutput("triggered");

        // Define the control flow
        Succession(trigger, triggered);
    }

    // Method to trigger the event
    private ControlOutput Trigger(Flow flow)
    {
        string eventToTrigger = flow.GetValue<string>(eventName);
        GameObject[] targets = flow.GetValue<GameObject[]>(targetObjects);

        foreach (GameObject target in targets)
        {
            if (target != null)
            {
                CustomEvent.Trigger(target, eventToTrigger);
            }
        }

        return triggered;
    }
}