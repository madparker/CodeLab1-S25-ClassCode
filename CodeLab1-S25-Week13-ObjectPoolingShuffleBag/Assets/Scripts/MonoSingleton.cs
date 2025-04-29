using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T instance = null;

    public bool dontDestroyOnLoad = false;

    public static T Instance
    {
        get { return instance; }
    }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Debug.Log($"MonoSingleton destroyed: {name}");
            Destroy(gameObject);
        }
        else
        {
            instance = (T)this;
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }

    protected virtual void OnDestroy()
    {
        Debug.Log($"MonoSingleton destroyed: {name}");
    }
}