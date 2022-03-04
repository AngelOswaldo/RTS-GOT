using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SoldadoController : MonoBehaviour
{
    [StringInList("rango", "cercano")]
    public string tipoAtaque;


    public float vida;

    [HideInInspector]
    public NavMeshAgent nav;

    [HideInInspector]
    public Animator anim;

    float delay = 0;

    bool ataque = false;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        GameManager.npcControlados.Add(gameObject);

        for (int i = 0; i < ManagerEstructuras.Cuarteles.Count; i++)
        {

            if (ManagerEstructuras.Cuarteles[i].GetComponent<Cuartel>().seleccion == true)
            {
                nav.destination = ManagerEstructuras.Cuarteles[i].transform.GetChild(3).transform.position;


            }

        }

    }

    // Update is called once per frame
    void Update()
    {

        if (nav.velocity.magnitude > 0) {

            anim.SetInteger("estado", 1);

        }
        //si el objeto esta seleccionado y das un click derecho irá a la direccion en donde se dio el click
        if (Input.GetMouseButton(1) && GetComponent<Seleccion>().seleccion==true) {

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
                //se activa la animacion de correr
                anim.SetInteger("estado", 1);
                nav.destination = hit.point;

            }
        }


        //CUANDO EL TIPO DE ATAQUE SEA DE RANGO
        if (tipoAtaque == "rango") {

            //si el objeto no se mueve y no esta atacando entonces se activara la animacion de idle
            if (nav.velocity.magnitude == 0 && gameObject.GetComponent<Atacar>().estado != "ataque") anim.SetInteger("estado", 0);

        }


        //CUANDO EL TIPO DE ATAQUE SEA CERCANO
        if (tipoAtaque == "cercano") {

            if (nav.velocity.magnitude == 0 && ataque==false) {

                anim.SetInteger("estado", 0);              

            }
            

        }
        if (Input.GetKeyDown(KeyCode.Q)) Debug.Log(nav.velocity.magnitude);
        

        if (vida <= 0) {

            anim.SetInteger("estado", 3);
            Destroy(gameObject, 3);

        }

        delay += Time.deltaTime;

    }

    

    private void OnTriggerStay(Collider other)
    {

        if (tipoAtaque == "cercano" && other.tag == "Animal")
        {


            float distancia = Vector3.Distance(transform.position, other.transform.position);
            nav.destination = other.transform.position;
            anim.SetInteger("estado", 1);

            if (distancia < 1.5)
            {
                ataque = true;
                if (delay >= 1.5f)
                {
                    other.gameObject.transform.GetChild(0).gameObject.GetComponent<Animal>().vidaVariante -= 3;
                    delay = 0;
                }

                if(other.gameObject.transform.GetChild(0).gameObject.GetComponent<Animal>().vidaVariante>0) anim.SetInteger("estado", 2);
                if (other.gameObject.transform.GetChild(0).gameObject.GetComponent<Animal>().vidaVariante <= 0) {
                  
                    anim.SetInteger("estado", 0);
                    ataque = false;
                } 

                nav.destination = transform.position;

            }

        }
    }

    private void OnTriggerExit(Collider other) {

        anim.SetInteger("estado", 0);
        ataque = false;

    }
}
