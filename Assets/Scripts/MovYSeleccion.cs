using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovYSeleccion : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent nav;

    [HideInInspector]
    public bool seleccion;

    [HideInInspector]
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        seleccion = false;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1) && seleccion==true) {

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {

                anim.SetInteger("estado", 1);
                nav.destination = hit.point;

            }
        }

        

        if(nav.velocity.magnitude==0 && gameObject.GetComponent<Atacar>().estado!="ataque") anim.SetInteger("estado", 0);

     
    }

    private void OnMouseDown()
    {
        
        if (seleccion == false) seleccion = true;
        else seleccion = false;
        
    }

    
}
