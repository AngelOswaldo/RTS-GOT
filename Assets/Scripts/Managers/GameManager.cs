using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    
    [Header("Maximos")]

    //cantidad maxima de poblacion segun el castillo
    [SerializeField]
    int poblacionMaximaCastillo;
    //cantidad maxima de poblacion segun las casas que se tenga
    [SerializeField]
    int maxAldeanos;
    //cantidad de recursos que se pueden guardar segun los depositos que se tenga
    [SerializeField]
    int maxRecursos;

    [Header("Precios")]
    [SerializeField]
    int precioAldeanos;


    //valores o cantidad de recursos variables, osea que cambian
    public static int vOro;
    public static int vMadera;
    public static int vPiedra;
    public static int vComida;

    public static int cantAldeanos = 0;
    public static int vPrecioAldeanos;
    [Header("Textos a mostrar")]
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
