using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < GameManager.npcControlados.Count; i++) {

            GameManager.npcControlados[i].GetComponent<SoldadoController>().seleccion = false;
            
        
        }
    }
}
