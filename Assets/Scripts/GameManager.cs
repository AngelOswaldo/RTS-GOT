using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    //costo modificable de crear aldeanos
    [SerializeField]
    int precioAldeanos;

    //costo real para crear los aldeanos
    public static int vPrecioAldeanos;
    //cantidad maxima de aldeanos
    public int maxAldeanos = 10;
    //cantidad actual de aldeanos
    public static int cantAldeanos = 0;

    //valores o cantidad de recursos que se tiene
    public static int vOro;
    public static int vMadera;
    public static int vPiedra;
    public static int vComida;


    //texto para mostrar los valores o cantidades de recursos que se tiene
    [SerializeField]
    Text oro;
    [SerializeField]
    Text madera;
    [SerializeField]
    Text piedra;
    [SerializeField]
    Text comida;

    //texto para mostrar la cantidad de aldeanos y su maximo
    [SerializeField]
    Text aldeanos;
    
    //lista de npc
    public static List<GameObject> npcControlados;



    // Start is called before the first frame update
    void Start()
    {
        vOro = 200;
        vMadera = 200;
        vPiedra = 200;
        vComida = 200;
        vPrecioAldeanos = precioAldeanos;
    }

    // Update is called once per frame
    private void Awake()
    {
        npcControlados = new List<GameObject>();

        if (vComida <= 0) vComida = 0;
    }

    void Update() {

        //se muestra la cantidad de recursos y aldeanos en todo momento
        oro.text = "Oro: " + vOro;
        madera.text = "Madera: " + vMadera;
        piedra.text = "Piedra: " + vPiedra;
        comida.text = "Comida: " + vComida;
        aldeanos.text = "Aldeanos: " + cantAldeanos + "/" + maxAldeanos;

    
    }


    
}
