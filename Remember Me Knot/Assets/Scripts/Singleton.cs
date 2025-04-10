using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jess doesn't remember where this came from but it was from one of the resources - I dont believe its being used and likely lingering old content. 

/// <summary>
/// Used to force there only being one of a class via inheritance and allows it to be called anywhere.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private bool initialized;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name, typeof(T));
                    instance = go.GetComponent<T>();
                }
            }
            return instance;
        }
    }

    public static bool isValidSingleton()
    {
        return (instance != null);
    }

    public static void nullify()
    {
        instance = null;
    }

    public static void destroy()
    {
        Destroy(instance.gameObject);
        instance = null;
    }
}
