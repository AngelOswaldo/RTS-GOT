using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion : MonoBehaviour
{
    [HideInInspector]
    public bool seleccion;

    GameObject indicadorSeleccion;
    // Start is called before the first frame update
    void Start()
    {
        seleccion = false;
        indicadorSeleccion = transform.GetChild(transform.childCount-1).gameObject;
        indicadorSeleccion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (seleccion == true)
        {

            indicadorSeleccion.SetActive(true);

        }
        else indicadorSeleccion.SetActive(false);
    }

    private void OnMouseDown()
    {

        if (seleccion == false) seleccion = true;
        else seleccion = false;



    }
}
