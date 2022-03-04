using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocacionPorton : MonoBehaviour
{
    [HideInInspector]
    public int contadorColisiones;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contadorColisiones >= 9) {

            Debug.Log("COLOCACION DISPONIBLE");

        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
