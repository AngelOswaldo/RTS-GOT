using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuartel : MonoBehaviour
{
    [HideInInspector]
    public bool seleccion = false;
    // Start is called before the first frame update

    private void Awake()
    {
        ManagerEstructuras.Cuarteles.Add(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //solo para probar la seleccion de cuarteles
        if (seleccion == true) {

            transform.GetChild(1).GetComponent<Renderer>().material.color = Color.black;

        } else transform.GetChild(1).GetComponent<Renderer>().material.color = Color.blue;
    }

    private void OnMouseDown()
    {
        for (int i = 0; i <  ManagerEstructuras.Cuarteles.Count; i++) {

            ManagerEstructuras.Cuarteles[i].GetComponent<Cuartel>().seleccion = false;

        }

        seleccion = true;
        Debug.Log(gameObject.name);
        
    }
}
