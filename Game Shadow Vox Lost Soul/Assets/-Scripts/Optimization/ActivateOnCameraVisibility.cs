using UnityEngine;

public class ActivateOnCameraVisibility : MonoBehaviour
{
    public GameObject ObjectToHide;
    public void Start()
    {
        ObjectToHide.SetActive(false);
    }
    public void OnBecameVisible()
    {
        ObjectToHide.SetActive(true);
    }
    public void OnBecameInvisible()
    {
        ObjectToHide.SetActive(false);
    }
}
