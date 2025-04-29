using UnityEngine;

public class ColitionReactionScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SolidBlock") { 
            this.gameObject.transform.localScale = new Vector3(transform.localScale.x,0.3f,transform.localScale.z);
        }
        if (other.tag == "nonInteractiveBlock")
        {
            this.gameObject.transform.localScale = new Vector3(transform.localScale.x, 0.1f, transform.localScale.z);
        }
        if (other.tag == "LavaBlock")
        {
            this.gameObject.transform.localScale = new Vector3(transform.localScale.x, 0.2f, transform.localScale.z);
        }
    }
}
