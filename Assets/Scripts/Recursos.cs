using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recursos : MonoBehaviour
{
    
    public int cantInicial;

    [HideInInspector]
    public int cantVariable;


    // Start is called before the first frame update
    void Start()
    {
        cantVariable = cantInicial;
    }

    // Update is called once per frame
    void Update()
    {
        if (cantVariable <= 0) {

            gameObject.SetActive(false);

        }
    }
}
