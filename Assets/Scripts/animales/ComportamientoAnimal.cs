using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoAnimal : MonoBehaviour
{

    //esto es para decidir que tipo de animal sera
    [StringInList("hostil", "noHostil")]
    public string tipoAnimal;

    //velocidad del animal
    [SerializeField]
    float speed;

    //indicador de si esta huyendo o no
    bool estadoHuir;

    //variable en donde se guardara una direccion
    Vector3 direccion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //si el estado de huir es verdadero, entonces el objeto irá hacia la direccion obtenida
        if (estadoHuir == true) {

            transform.position = new Vector3(transform.position.x + direccion.x * speed * Time.deltaTime, 0.35f, transform.position.z + direccion.z * speed * Time.deltaTime);

        }

        //si se detecta que la vida es menos o igual a 0 entonces la comida aumentara y el objeto(el animal) sera eliminado
        if (transform.GetChild(0).gameObject.GetComponent<Animal>().vida <= 0) {

            GameManager.vComida += transform.GetChild(0).gameObject.GetComponent<Animal>().comidaObtenida;
            Destroy(gameObject);

        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        //si el animal es un tipo no hostil y un soldado esta en su zona entonces se obtendra la direccion de huida y se activara el modo huir
        if (other.tag == "soldado" && tipoAnimal == "noHostil") {
            
            //se obtiene la direccion de huida
            direccion = (transform.position - other.transform.position).normalized;
            estadoHuir = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        //si no hay nadie en la zona del animal entonces dejara de huir
        estadoHuir=false;
    }
}
