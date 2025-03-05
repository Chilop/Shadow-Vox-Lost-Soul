using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Unity.Collections.AllocatorManager;
using static UnityEditor.FilePathAttribute;

[CreateAssetMenu(fileName = "BlocksScriptable", menuName = "Scriptable Objects/BlocksScriptable")]
[ExecuteAlways]
public class BlocksScriptable : ScriptableObject
{
    [Header("objetos disponibles")]
    public GameObject EditaMiNombre;
    public GameObject[] BloquesDeDEsarrollo;
    public int ElementoAIsntanciar;
    public Vector3 LocalisacionDeBloque;
    [Header("instanciado de un solo objeto")]
    public bool Generar = false;
    [Header("instanciado en area, el area se empieza a generar de la posicion seleccionada a cordenadas positivas o mayores")]
    public Vector3 TamanoDeArea;
    public bool GenerarArea = false;

    private void OnValidate()
    {
        if (Generar) {
            Instantiate(BloquesDeDEsarrollo[ElementoAIsntanciar], LocalisacionDeBloque, new Quaternion(0, 0, 0, 0));
            Generar = false;
        }
        if (GenerarArea){
            GameObject Contenedor = Instantiate(EditaMiNombre, LocalisacionDeBloque, new Quaternion(0, 0, 0, 0));
            for (int i = 0; i < TamanoDeArea.x; i++) {
                for (int j = 0; j < TamanoDeArea.y; j++) {
                    for (int k = 0; k < TamanoDeArea.z; k++) {
                        Instantiate(BloquesDeDEsarrollo[ElementoAIsntanciar],new Vector3(LocalisacionDeBloque.x+i, LocalisacionDeBloque.y+j, LocalisacionDeBloque.z+k), new Quaternion(0, 0, 0, 0),Contenedor.transform);
                    }
                }
            }
            GenerarArea = false;
        }
    }
}
