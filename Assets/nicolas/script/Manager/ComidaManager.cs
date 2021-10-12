using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComidaManager : MonoBehaviour
{

    public static int Comida;

    public Text ComidaTxt;

    ActualizadorNumeros<ComidaManager> ActualizadorNumeros = new ActualizadorNumeros<ComidaManager>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActualizadorNumeros.ActualizarNumeros(ComidaTxt, Comida);
    }
}
