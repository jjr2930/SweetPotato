using UnityEngine;
public class MonoSingle<T> : MonoBehaviour where T : MonoBehaviour
{
    static object lockObject = new object();
    static T instance;
    public static T Instance
    {
        get
        {
            lock (lockObject)
            {
                if (null == instance)
                {
                    GameObject newObj = new GameObject(typeof(T).Name);
                    instance = newObj.AddComponent<T>();
                    DontDestroyOnLoad(newObj);
                }
            }

            return instance;
        }
    }
}