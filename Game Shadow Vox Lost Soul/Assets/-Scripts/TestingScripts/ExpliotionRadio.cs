using UnityEngine;

public class ExpliotionRadio : MonoBehaviour
{
    public void ExplosionDamage(Vector3 center, float radius)
    {
        int maxColliders = 10;
        Collider[] hitColliders = new Collider[maxColliders];
        int numColliders = Physics.OverlapSphereNonAlloc(center, radius, hitColliders);
        for (int i = 0; i < numColliders; i++)
        {
            hitColliders[i].SendMessage("AddDamage");
        }
    }
}
