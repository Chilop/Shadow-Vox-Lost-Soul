using Unity.VisualScripting;
using UnityEngine;

public class CamMovementBetweenLevels : MonoBehaviour
{
    public int CamStartPoints;
    public float camTimer=0;
    public GameObject[] camPoints;
    public void LevelChange() {
            CamStartPoints++;
        transform.position = camPoints[CamStartPoints].transform.position;
    }
}
