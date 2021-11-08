using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ComportamientoAnimal : MonoBehaviour
{


    private NavMeshAgent animal;
    //esto es para decidir que tipo de animal sera
    [StringInList("hostil", "noHostil")]
    public string tipoAnimal;

    //velocidad del animal
    [SerializeField]
    float speed;
    [SerializeField]
    float daño;
    
    //indicador de si esta huyendo o no
    [HideInInspector]
    public bool estadoHuir;

    [SerializeField]
    GameObject destino;
    Animator anim;

    float delay = 0;

    //variable en donde se guardara una direccion
    Vector3 direccion;
    // Start is called before the first frame update
    void Start()
    {
        estadoHuir = false;
        anim = gameObject.GetComponent<Animator>();
        animal = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        //ANIMAL NO HOSTIL

        if (tipoAnimal == "noHostil") {

            //si el estado de huir es verdadero, entonces el objeto irá hacia la direccion obtenida
            if (estadoHuir == true)
            {

                destino.transform.position = new Vector3(transform.position.x + direccion.x * speed * Time.deltaTime, 0f, transform.position.z + direccion.z * speed * Time.deltaTime);
                animal.destination = destino.transform.position;
                anim.SetInteger("estado", 1);

            }

            //CONDICION DE MORIR, si se detecta que la vida es menos o igual a 0 entonces la comida aumentara y el objeto(el animal) sera eliminado
            if (transform.GetChild(0).gameObject.GetComponent<Animal>().vida <= 0)
            {
                speed = 0;
                GameManager.vComida += transform.GetChild(0).gameObject.GetComponent<Animal>().comidaObtenida;
                transform.GetChild(0).gameObject.GetComponent<Animal>().comidaObtenida = 0;
                anim.SetInteger("estado", 2);
                Destroy(gameObject, 3);

            }

        }

        //ANIMAL HOSTIL

        if (tipoAnimal == "hostil") {

            //MISMA CONDICION DE MORIR PARA EL ANIMAL HOSTIL
            if (transform.GetChild(0).gameObject.GetComponent<Animal>().vida <= 0)
            {
                speed = 0;
                GameManager.vComida += transform.GetChild(0).gameObject.GetComponent<Animal>().comidaObtenida;
                transform.GetChild(0).gameObject.GetComponent<Animal>().comidaObtenida = 0;
                anim.SetInteger("estado", 2);
                Destroy(gameObject, 3);

            }


        }
        
        delay += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        //ANIMAL NO HOSTIL
        //si el animal es un tipo no hostil y un soldado esta en su zona entonces se obtendra la direccion de huida y se activara el modo huir
        if (other.tag == "soldado" && tipoAnimal == "noHostil") {
            
            //se obtiene la direccion de huida
            direccion = (transform.position - other.transform.position).normalized;
            
            estadoHuir = true;

        }

        //ANIMAL HOSTIL
        if (other.tag == "soldado" && tipoAnimal == "hostil") {
            //se calcula la distancia entre el animal y el soldado
            float distancia = Vector3.Distance(transform.position, other.transform.position);
            animal.destination = other.transform.position;
            anim.SetInteger("estado", 1);
            if (distancia < 1.5f) {

                
                
                if (delay >= 1.5f) {
                    other.gameObject.GetComponent<SoldadoController>().vida -= daño;
                    Debug.Log(other.gameObject.GetComponent<SoldadoController>().vida);
                    delay = 0;
                }

                if (other.gameObject.GetComponent<SoldadoController>().vida <= 0) Desactivacion();
                
                anim.SetInteger("estado", 3);
                Desactivacion();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        //si no hay nadie en la zona del animal entonces dejara de huir, perseguir o atacar
        Desactivacion();      
        anim.SetInteger("estado", 0);
    }

    private void Desactivacion() {
        animal.destination = transform.position;
    }
}
