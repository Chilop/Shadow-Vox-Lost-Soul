using Unity.VisualScripting;
using UnityEngine;

public class CollitionDefinition : MonoBehaviour
{
    public GameObject grass, lava, water, wood,stone;
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
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Lava")
        {
            Instantiate(lava, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "water") {
            Instantiate(water, this.transform.position, this.transform.rotation);
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Wood")
        {
            Instantiate(wood, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Stone")
        {
            Instantiate(stone, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            other.gameObject.SetActive(false);
        }
        else Destroy(this.gameObject);
    }
}
