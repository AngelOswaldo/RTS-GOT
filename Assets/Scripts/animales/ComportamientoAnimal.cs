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
    public float speedFijo;
    [HideInInspector]
    public float speedVariable;

    [SerializeField]
    float damage;
    
    //indicador de si esta huyendo o no
    [HideInInspector]
    public bool estadoHuir;

    [SerializeField]
    GameObject destino;
    Animator anim;

    float delay = 0;

    //variable en donde se guardara una direccion
    Vector3 direccion;

    //tiempo en el que volvera a aparecer el animal

    float tiempo = 0;
    // Start is called before the first frame update
    void Start()
    {
        speedVariable = speedFijo;
        estadoHuir = false;
        anim = gameObject.GetComponent<Animator>();
        animal = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        
        //ANIMAL NO HOSTIL

        if (tipoAnimal == "noHostil") {

            //si el estado de huir es verdadero, entonces el objeto ir? hacia la direccion obtenida
            if (estadoHuir == true)
            {

                destino.transform.position = new Vector3(transform.position.x + direccion.x * speedVariable * Time.deltaTime, 0f, transform.position.z + direccion.z * speedVariable * Time.deltaTime);
                animal.destination = destino.transform.position;
                anim.SetInteger("estado", 1);

            }

            //CONDICION DE MORIR, si se detecta que la vida es menos o igual a 0 entonces la comida aumentara y el objeto(el animal) sera eliminado
            if (transform.GetChild(0).gameObject.GetComponent<Animal>().vidaVariante <= 0)
            {
                
                tiempo += Time.deltaTime;
                speedVariable = 0;
                GameManager.vComida += transform.GetChild(0).gameObject.GetComponent<Animal>().comidaVariante;
                transform.GetChild(0).gameObject.GetComponent<Animal>().comidaVariante = 0;
                anim.SetInteger("estado", 2);
                if (tiempo >= 3)gameObject.SetActive(false);

                //Destroy(gameObject, 3);

            }

        }

        //ANIMAL HOSTIL

        if (tipoAnimal == "hostil") {

            //MISMA CONDICION DE MORIR PARA EL ANIMAL HOSTIL
            if (transform.GetChild(0).gameObject.GetComponent<Animal>().vidaVariante <= 0)
            {
                speedVariable = 0;
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
            
            //se calcula la distancia entre el animal y el soldado
            float distancia = Vector3.Distance(transform.position, other.transform.position);
            if (distancia > 3)
            {
                //se obtiene la direccion de huida
                direccion = (transform.position - other.transform.position).normalized;
                estadoHuir = true;
            }
            else {

                estadoHuir = false;
                Desactivacion();
                anim.SetInteger("estado", 0);

            }

            
            


        }

        //ANIMAL HOSTIL
        if (other.tag == "soldado" && tipoAnimal == "hostil") {
            //se calcula la distancia entre el animal y el soldado
            float distancia = Vector3.Distance(transform.position, other.transform.position);
            animal.destination = other.transform.position;
            anim.SetInteger("estado", 1);
            if (distancia < 1.5f) {

                
                
                if (delay >= 1.5f) {
                    other.gameObject.GetComponent<SoldadoController>().vida -= damage;
                    Debug.Log(other.gameObject.GetComponent<SoldadoController>().vida);
                    delay = 0;
                }
                if(other.gameObject.GetComponent<SoldadoController>().vida > 0) anim.SetInteger("estado", 3);

                if (other.gameObject.GetComponent<SoldadoController>().vida <= 0) anim.SetInteger("estado", 0);

                
                Desactivacion();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        //si no hay nadie en la zona del animal entonces dejara de huir, perseguir o atacar
        estadoHuir = false;
        Desactivacion();      
        anim.SetInteger("estado", 0);
    }

    private void Desactivacion() {
        animal.destination = transform.position;
    }
}
