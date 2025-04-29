using UnityEngine;
using Unity.Mathematics;
using Unity.VisualScripting;
using System;
public class TeoricalEnhacedFillZone : MonoBehaviour
{
    public Transform corner1, corner2;
    public Vector3[] inBetweenPositions;
    public GameObject AssignedSpawnable;
    public Vector3 C1, C2;
    

    private void Awake()
    {
        C1 = (corner1.position);
        C2 = corner2.position;
        C1 = new Vector3(Mathf.Round(C1.x),Mathf.Round(C1.y),Mathf.Round(C1.z));
        C2 = new Vector3(Mathf.Round(C2.x),Mathf.Round(C2.y),Mathf.Round(C2.z));
        int Index = 0;
        for (int i = 0; i < Mathf.Abs(C1.x - C2.x); i++) {
            for (int j = 0; j < Mathf.Abs(C1.y - C2.y); j++) {
                for (int k = 0; k < Mathf.Abs(C1.z - C2.z); k++) {

                    Array.Resize(ref inBetweenPositions, inBetweenPositions.Length+1);
                    
                    if (C1.x < C2.x) inBetweenPositions[Index] = new Vector3(C1.x + i, inBetweenPositions[Index].y, inBetweenPositions[Index].z);
                    else inBetweenPositions[Index] = new Vector3(C1.x - i, inBetweenPositions[Index].y, inBetweenPositions[Index].z);
                    if (C1.y < C2.y) inBetweenPositions[Index] = new Vector3(inBetweenPositions[Index].x,C1.y+j, inBetweenPositions[Index].z);
                    else inBetweenPositions[Index] = new Vector3(inBetweenPositions[Index].x, C1.y-j, inBetweenPositions[Index].z);
                    if (C1.y < C2.y) inBetweenPositions[Index] = new Vector3(inBetweenPositions[Index].x, inBetweenPositions[Index].y, C1.z+k);
                    else inBetweenPositions[Index] = new Vector3(inBetweenPositions[Index].x, inBetweenPositions[Index].y, C1.z-k);

                    GameObject InstantiatedObject = Instantiate(AssignedSpawnable, inBetweenPositions[Index],transform.rotation);
                    InstantiatedObject.transform.parent = this.transform;

                    Index++;
                }
            }
        }

        Debug.Log((C1.x - C2.x * C1.y - C2.y * C1.z - C2.z));
        this.GetComponent<MeshRenderer>().enabled = false;
    }
}
