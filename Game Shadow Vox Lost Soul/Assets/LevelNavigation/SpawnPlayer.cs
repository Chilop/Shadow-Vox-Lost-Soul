using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        Instantiate(Player,transform.position,transform.rotation);
        this.gameObject.SetActive(false);
    }

}
