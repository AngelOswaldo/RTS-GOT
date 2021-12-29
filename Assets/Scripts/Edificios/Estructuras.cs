using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estructuras : MonoBehaviour
{
    public int vidaInicial;

    [HideInInspector]
    public int vidaVariable;

    // Start is called before the first frame update
    void Start()
    {
        vidaVariable = vidaInicial;
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaVariable <= 0) Destroy(gameObject);
    }
}
