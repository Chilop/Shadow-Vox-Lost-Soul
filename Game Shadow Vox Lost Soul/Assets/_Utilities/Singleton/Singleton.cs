using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : class
{
    public static T Source { get; private set; }

    [Header("SINGLETON")]
    [SerializeField]bool isPersistent = true;

    protected virtual void Awake()
    {
        if (Source != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
            
        Source = this as T;
        if (isPersistent)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
