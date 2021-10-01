using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seleccion : MonoBehaviour
{
    private NavMeshAgent player;

    [HideInInspector]
    public bool seleccion;


    // Start is called before the first frame update
    void Start()
    {
        seleccion = false;
        player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (Input.GetMouseButton(1) && GameManager.seleccionGlobal==true && seleccion==true) {

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {

                player.destination = hit.point;

            }
        }

        //if (Input.GetMouseButton(1)) seleccion = false;

    }

    private void OnMouseDown()
    {
        GameManager.seleccionGlobal = true;
        if (seleccion == false) seleccion = true;
        else seleccion = false;
        

        Debug.Log("seleccionado");
    }

    
}
