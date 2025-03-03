using Unity.VisualScripting;
using UnityEngine;

public class CollitionDefinition : MonoBehaviour
{
    public GameObject grass, lava, water;
    public float timerMax,timer=0;

    public void FixedUpdate()
    {
        timer += 1 * Time.fixedDeltaTime;
        if(timer>timerMax) Destroy(this.gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Grass")
        {
            Instantiate(grass, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Lava")
        {
            Instantiate(lava, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        else if (other.tag == "water") {
            Instantiate(water, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        else Destroy(this.gameObject);
    }
}
