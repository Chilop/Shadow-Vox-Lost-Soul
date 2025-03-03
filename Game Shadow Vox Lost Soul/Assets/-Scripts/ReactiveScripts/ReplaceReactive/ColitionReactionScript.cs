using UnityEngine;

public class ColitionReactionScript : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SolidBlock") { 
            this.gameObject.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
        }
        if (other.tag == "nonInteractiveBlock")
        {
            this.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        if (other.tag == "LavaBlock")
        {
            this.gameObject.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
    }
}
