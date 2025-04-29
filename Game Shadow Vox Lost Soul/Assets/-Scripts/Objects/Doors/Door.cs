using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] protected bool _islocked;
    [SerializeField] private Collider _collider;
    [SerializeField] private UnityEvent _doorOpened = new UnityEvent();
    [SerializeField] private UnityEvent _doorClosed = new UnityEvent();


    public void UnlockDoor()
    {
        _islocked = false;
    }

    public void LockDoor()
    {
        _islocked = true;
    }
    
    public void OpenDoor()
    {
        UnlockDoor();
        _collider.enabled = false;
        gameObject.SetActive(false);
        _doorOpened?.Invoke();
    }

    public void CloseDoor()
    {
        LockDoor();
        _collider.enabled = true;
        gameObject.SetActive(true);
        _doorClosed?.Invoke();
    }
}
