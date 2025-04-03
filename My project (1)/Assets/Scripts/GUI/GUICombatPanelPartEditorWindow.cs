using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GUICombatPanelPartEditorWindow : OdinEditorWindow
{
    [MenuItem("Tools/GUI Combat Panel Part Editor")]
    private static void OpenWindow()
    {
        GetWindow<GUICombatPanelPartEditorWindow>().Show();
    }

    [Button("Track UI Elements")]
    private void TrackUIElements()
    {
        uiElementDictionary.uiElements.Clear();
        var allUIElements = FindObjectsOfType<GUICombatPanelPart>();
        foreach (var element in allUIElements)
        {
            var uiElementInfo = new UIElementInfo
            {
                UIElementGO = element.gameObject,
                Children = new List<ChildInfo>()
            };
            string panelName = element.panelNameEnum.ToString();

            if (!uiElementDictionary.uiElements.ContainsKey(element.panelNameEnum.ToString()))
            {
                uiElementDictionary.uiElements[panelName] = new List<UIElementInfo>();
            }

            foreach (Transform child in element.transform)
            {
                var childInfo = new ChildInfo
                {
                    ChildGO = child.gameObject
                };

                var textComponent = child.GetComponentInChildren<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    childInfo.TextGO = textComponent.gameObject;
                }
                uiElementInfo.Children.Add(childInfo);
            }
            uiElementDictionary.uiElements[panelName].Add(uiElementInfo);
        }
    }

    public class UIElementInfo
    {
        [HorizontalGroup("Split", 0.5f)]
        [BoxGroup("Split/Left", ShowLabel = false)]
        [ReadOnly]
        public GameObject UIElementGO;

        [HorizontalGroup("Split", 0.5f)]
        [BoxGroup("Split/Right", ShowLabel = false)]
        [LabelText("Parent GameObject Name")]
        public string ParentNewName;

        [HorizontalGroup("Split", 0.5f)]
        [BoxGroup("Split/Right", ShowLabel = false)]
        [LabelText("Base Child Name")]
        public string ChildNewName;

        [ListDrawerSettings(ShowFoldout = true)]
        public List<ChildInfo> Children;

        [Button("Rename GameObjects")]
        private void RenameGameObjects()
        {
            if (UIElementGO != null && !string.IsNullOrEmpty(ParentNewName))
            {
                UIElementGO.name = ParentNewName;
            }

            for (int i = 0; i < Children.Count; i++)
            {
                var childInfo = Children[i];
                if (childInfo.ChildGO != null && !string.IsNullOrEmpty(ChildNewName))
                {
                    childInfo.ChildGO.name = ChildNewName + i;
                }
                if (childInfo.TextGO != null && !string.IsNullOrEmpty(ChildNewName))
                {
                    childInfo.TextGO.name = ChildNewName + i + "_Txt";
                }
            }
        }

        [Button("Rename TextMeshPro")]
        private void RenameTextMeshPro()
        {
            for (int i = 0; i < Children.Count; i++)
            {
                var childInfo = Children[i];
                if (childInfo.TextGO != null)
                {
                    var textComponent = childInfo.TextGO.GetComponent<TextMeshProUGUI>();
                    if (textComponent != null && !string.IsNullOrEmpty(childInfo.NewText))
                    {
                        textComponent.text = childInfo.NewText;
                    }
                }
            }
        }
    }

    public class ChildInfo
    {
        [HorizontalGroup("ChildSplit", 0.5f)]
        [BoxGroup("ChildSplit/Left", ShowLabel = false)]
        [ReadOnly]
        public GameObject ChildGO;

        [HorizontalGroup("ChildSplit", 0.5f)]
        [BoxGroup("ChildSplit/Right", ShowLabel = false)]
        [ReadOnly]
        public GameObject TextGO;

        [HorizontalGroup("ChildSplit", 0.5f)]
        [BoxGroup("ChildSplit/Right", ShowLabel = false)]
        [LabelText("New Text")]
        public string NewText;
    }

    public class UIElementDictionary
    {
        [InlineEditor(Expanded = true)]
        public Dictionary<string, List<UIElementInfo>> uiElements = new Dictionary<string, List<UIElementInfo>>();
    }

    [InlineEditor(Expanded = true)]
    public UIElementDictionary uiElementDictionary = new UIElementDictionary();
}
