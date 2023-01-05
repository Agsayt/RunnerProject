using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static readonly Lazy<T> LazyInstance = new Lazy<T>(CreateSingleton);

    public static T Instance => LazyInstance.Value;

    private static T CreateSingleton()
    {
        var instance = GameObject.FindObjectOfType<T>();
        GameObject ownerObject;

        if (instance is null)
        { 
            ownerObject = new GameObject($"{typeof(T).Name} (singleton)");
            instance = ownerObject.AddComponent<T>();
        } 
        else
        {
            ownerObject = instance.gameObject;
        }

        DontDestroyOnLoad(ownerObject);
        return instance;
    }
}
