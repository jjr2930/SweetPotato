using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_MonoSingle<T> : UIBehaviour where T : UIBehaviour
{
    static T instance = null;
    static object lockObject = new object();
    public static T Instance
    {
        get
        {
            lock (lockObject)
            {
                if (null == instance)
                {
                    GameObject go = Instantiate(Resources.Load("Prefabs/EmptyUI")) as GameObject;
                    instance = go.AddComponent<T>();
                    instance.name = typeof(T).Name;
                }
            }
            return instance;
        }
    }
}