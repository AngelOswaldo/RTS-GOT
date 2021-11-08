using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldadoController : MonoBehaviour
{
    
    public float vida;

    [HideInInspector]
    public NavMeshAgent nav;

    //variable para verificar si el objeto esta seleccionado
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
        //si el objeto esta seleccionado y das un click derecho irá a la direccion en donde se dio el click
        if (Input.GetMouseButton(1) && seleccion==true) {

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
                //se activa la animacion de correr
                anim.SetInteger("estado", 1);
                nav.destination = hit.point;

            }
        }

        
        //si el objeto no se mueve y no esta atacando entonces se activara la animacion de idle
        if(nav.velocity.magnitude==0 && gameObject.GetComponent<Atacar>().estado!="ataque") anim.SetInteger("estado", 0);

        if (vida <= 0) {

            anim.SetInteger("estado", 3);
            Destroy(gameObject, 3);

        }
     
    }

    private void OnMouseDown()
    {
        
        if (seleccion == false) seleccion = true;
        else seleccion = false;
        
    }

    
}
