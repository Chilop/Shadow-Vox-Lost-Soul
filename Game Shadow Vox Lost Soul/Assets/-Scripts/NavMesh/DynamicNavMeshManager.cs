using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.AI.Navigation;

[RequireComponent(typeof(NavMeshSurface))]
public class DynamicNavMeshManager : MonoBehaviour
{
    [SerializeField] private NavMeshSurface navMeshSurface;
    private bool terrainGenerated = false;

    private void Awake()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
        TeoricalEnhacedFillZone.OnTerrainGenerated += BakeNavMesh;
        Debug.Log("Manager suscrito al evento.");
        
        if (terrainGenerated)
        {
            BakeNavMesh();
        }
    }

    private void OnDestroy()
    {
        TeoricalEnhacedFillZone.OnTerrainGenerated -= BakeNavMesh;
    }

    private void BakeNavMesh()
    {
        Debug.Log("Generando NavMesh...");

        if (navMeshSurface == null)
        {
            Debug.LogError("NavMeshSurface no encontrado.");
            return;
        }

        terrainGenerated = true;
        
        List<GameObject> navegables = new List<GameObject>();
        List<GameObject> obstaculos = new List<GameObject>();

        foreach (TeoricalEnhacedFillZone fillZone in FindObjectsOfType<TeoricalEnhacedFillZone>())
        {
            foreach (Transform child in fillZone.transform)
            {
                if (child.CompareTag("Navigable") && child.gameObject.layer != LayerMask.NameToLayer("Walkable"))
                {
                    child.gameObject.layer = LayerMask.NameToLayer("Walkable");
                    navegables.Add(child.gameObject);
                }
                else if (child.CompareTag("Obstacle") && child.gameObject.layer != LayerMask.NameToLayer("Obstacle"))
                {
                    child.gameObject.layer = LayerMask.NameToLayer("Obstacle");
                    obstaculos.Add(child.gameObject);
                }
            }
        }

        Debug.Log($"Navegables detectados: {navegables.Count}, Obstáculos detectados: {obstaculos.Count}");
        navMeshSurface.BuildNavMesh();
        Debug.Log("NavMesh reconstruido dinámicamente.");
    }
}
