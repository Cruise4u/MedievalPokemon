using System.Collections;
using UnityEngine;

public abstract class ManagerBase : MonoBehaviour,IManager
{
    public abstract IEnumerator Init();
}
