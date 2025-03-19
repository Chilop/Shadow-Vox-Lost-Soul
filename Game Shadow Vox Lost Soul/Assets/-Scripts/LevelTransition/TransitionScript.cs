using Unity.VisualScripting;
using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    public Transform positionOfSpawn,playerPosition,camPosition,OldCenter,NewCenter;
    public GameObject nextLevelObject, thisLevel;
    public float timer = 0, transitionTime = 2;
    public bool nextLevel;
    private void Start()
    {
        nextLevel = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            playerPosition = other.transform;
            nextLevel = true;
        }
    }
    private void Update()
    {
        if (nextLevel) {
            timer += 1 * Time.deltaTime;
            nextLevelObject.SetActive(true);
            if (timer > transitionTime)
            {
                playerPosition.transform.position = positionOfSpawn.position;
                thisLevel.SetActive(false);
                timer = 0;
                nextLevel = false;
            }
        }
    }
}
