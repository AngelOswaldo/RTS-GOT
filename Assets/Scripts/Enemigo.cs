using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
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

    }

    // Update is called once per frame
    void Update()
    {
        


        //CUANDO EL TIPO DE ATAQUE SEA DE RANGO
        if (tipoAtaque == "rango")
        {

            //si el objeto no se mueve y no esta atacando entonces se activara la animacion de idle
            if (nav.velocity.magnitude == 0 && gameObject.GetComponent<Atacar>().estado != "ataque") anim.SetInteger("estado", 0);

        }


        //CUANDO EL TIPO DE ATAQUE SEA CERCANO
        if (tipoAtaque == "cercano")
        {

            if (nav.velocity.magnitude == 0 && ataque == false)
            {

                anim.SetInteger("estado", 0);

            }


        }


        if (vida <= 0)
        {

            anim.SetInteger("estado", 3);
            Destroy(gameObject, 3);

        }

        delay += Time.deltaTime;

    }



    private void OnTriggerStay(Collider other)
    {

        if (tipoAtaque == "cercano" && other.tag == "cuartelArqueros")
        {


            float distancia = Vector3.Distance(transform.position, other.transform.position);
            nav.destination = other.transform.position;
            anim.SetInteger("estado", 1);

            if (distancia < 3.5f)
            {
                ataque = true;
                if (delay >= 1.5f)
                {
                    other.gameObject.gameObject.GetComponent<Estructuras>().vidaVariable -= 3;
                    delay = 0;
                    Debug.Log(other.gameObject.gameObject.GetComponent<Estructuras>().vidaVariable);
                }

                if (other.gameObject.GetComponent<Estructuras>().vidaVariable > 0) anim.SetInteger("estado", 2);
                if (other.gameObject.GetComponent<Estructuras>().vidaVariable <= 0)
                {

                    anim.SetInteger("estado", 0);
                    ataque = false;
                }

                nav.destination = transform.position;

            }

        }
    }

    private void OnTriggerExit(Collider other)
    {

        anim.SetInteger("estado", 0);
        ataque = false;

    }
}
