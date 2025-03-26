using UnityEngine;
using Unity.Mathematics;
using Unity.VisualScripting;
using System;
public class TeoricalEnhacedFillZone : MonoBehaviour
{
    public Transform corner1, corner2;
    public Transform[] inBetweenPositions;
    public Vector3 C1, C2;
    

    private void Awake()
    {
        C1 = (corner1.position);
        C2 = corner2.position;
        C1 = new Vector3(Mathf.Round(C1.x),Mathf.Round(C1.y),Mathf.Round(C1.z));
        C2 = new Vector3(Mathf.Round(C2.x),Mathf.Round(C2.y),Mathf.Round(C2.z));
        Array.Resize(ref inBetweenPositions,(int)(C1.x-C2.x* C1.y - C2.y * C1.z - C2.z));

        Debug.Log((C1.x - C2.x * C1.y - C2.y * C1.z - C2.z));
    }
}
