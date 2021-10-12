using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovYSeleccion : MonoBehaviour
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

        if (Input.GetMouseButton(1) && seleccion==true) {

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {

                player.destination = hit.point;

            }
        }

    }

    private void OnMouseDown()
    {
        
        if (seleccion == false) seleccion = true;
        else seleccion = false;
        

        Debug.Log("seleccionado");
    }

    
}
