using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public abstract class ManagerBase : SerializedMonoBehaviour,IManager
{
    public abstract IEnumerator Init();
}
