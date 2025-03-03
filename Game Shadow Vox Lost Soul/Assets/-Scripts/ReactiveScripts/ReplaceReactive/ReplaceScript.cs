using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ReplaceScript : MonoBehaviour
{
    [Header("colider 0 arriba colider 1 abajo, coliders 2 3 4 y 5 laterales")]
    public GameObject[] coliders;
    [Header("si el tamaño es 0.2 no colisiona, si es 0.1 colisiono con un bloque liquido")]
    [Header("si el tamaño es 0.3 colisiona con un bloque solido,si es 0.25 colisiono con un bloque especial")]
    public Int16[] colitionCheck;
    [Header("valor maximo de prioridad 2 minimo 0")]
    public int priority;
    private void Start()
    {
        if(priority != 0) return;
        CollitionCheck();
        Efect();
    }

    public void CollitionCheck() {

        for (int i = 0; i < coliders.Length; i++) {
            colitionCheck[i] = 0;
            if (coliders[i].transform.localScale == new Vector3(0.1f, 0.1f, 0.1f)) colitionCheck[i] = 1;
            if (coliders[i].transform.localScale == new Vector3(0.3f, 0.3f, 0.3f)) colitionCheck[i] = 2;
        }
        
    }
    public void Efect() {
        //no collition
        if (colitionCheck[0] == 0 && colitionCheck[1] == 0 && colitionCheck[2] == 0 && colitionCheck[3] == 0 && colitionCheck[4] == 0 && colitionCheck[5] == 0)
        {
            return;
        }//collition with solid block up
        else if(colitionCheck[0] == 2 ) { 
            
        }
    }
}
