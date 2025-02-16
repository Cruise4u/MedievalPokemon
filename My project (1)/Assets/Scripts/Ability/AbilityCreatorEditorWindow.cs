using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

public class AbilityCreatorEditorWindow : OdinEditorWindow
{
    [MenuItem("Tools/Ability Creator")]
    private static void OpenWindow()
    {
        GetWindow<AbilityCreatorEditorWindow>().Show();
    }

    [InlineEditor(Expanded = true)]
    public AbilityCreatorEditor abilityCreatorEditor;

    protected override void OnEnable()
    {
        base.OnEnable();
        if (abilityCreatorEditor == null)
        {
            abilityCreatorEditor = CreateInstance<AbilityCreatorEditor>();
        }
    }


}


