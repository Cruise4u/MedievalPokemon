using System;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : ManagerBase
{
    private List<GUIToast> _toastList = new List<GUIToast>();
    private CustomObjPoolManager _poolManager;

    public override IEnumerator Init()
    {
        // Initialize the GUIManager
        _poolManager = FindObjectOfType<CustomObjPoolManager>();
        yield return null;
    }

    public void ShowToast(string message)
    {
        var toastPool = _poolManager.GetPool<GUIToast>();
        GUIToast toast = toastPool.Get();
        //toast.Show(message);
        _toastList.Add(toast);
    }

    public void HideToast(GUIToast toast)
    {
        if (_toastList.Contains(toast))
        {
            _toastList.Remove(toast);
            var toastPool = _poolManager.GetPool<GUIToast>();
            toastPool.Return(toast);
        }
    }
}
