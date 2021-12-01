using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Aldeano : MonoBehaviour
{
    public float vida;

    [HideInInspector]
    public NavMeshAgent nav;

    [HideInInspector]
    public bool seleccion;

    [SerializeField]
    int CantidadPiedraRecolectar;

    [SerializeField]
    int CantidadMaderaRecolectar;

    [SerializeField]
    float tiempoRecoleccion;
    float tiempo;

    [SerializeField]
    float tiempoRep;
    float tiempoRep2=0;

    bool ataque = false;
    float delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        seleccion = false;
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
        if (Input.GetMouseButton(1) && seleccion == true)
        {
            
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                nav.destination = hit.point;

            }
        }
    }

    private void OnMouseDown()
    {

        if (seleccion == false) seleccion = true;
        else seleccion = false;

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("detectado");

        if (other.tag == "Piedra") {

            nav.destination = other.transform.position;
            float distancia = Vector3.Distance(transform.position, other.transform.position);
            if (distancia <= 1) {

                tiempo += Time.deltaTime;
                if (tiempo >= tiempoRecoleccion) {

                    GameManager.vPiedra += CantidadPiedraRecolectar;
                    other.GetComponent<Recursos>().cantVariable -= CantidadPiedraRecolectar;
                    tiempo = 0;

                }

            }
        }

        if (other.tag == "Arbol")
        {

            nav.destination = other.transform.position;
            float distancia = Vector3.Distance(transform.position, other.transform.position);
            if (distancia <= 1)
            {

                tiempo += Time.deltaTime;
                if (tiempo >= tiempoRecoleccion)
                {

                    GameManager.vMadera += CantidadMaderaRecolectar;
                    other.GetComponent<Recursos>().cantVariable -= CantidadMaderaRecolectar;
                    tiempo = 0;

                }

            }
        }

        if (other.tag == "Animal")
        {


            float distancia = Vector3.Distance(transform.position, other.transform.position);
            nav.destination = other.transform.position;
            if (distancia < 1.5)
            {
                ataque = true;
                if (delay >= 1.5f)
                {
                    other.gameObject.transform.GetChild(0).gameObject.GetComponent<Animal>().vidaVariante -= 3;
                    delay = 0;
                }

                if (other.gameObject.transform.GetChild(0).gameObject.GetComponent<Animal>().vidaVariante <= 0)
                {
                    ataque = false;
                }

                nav.destination = transform.position;

            }

        }
        
        if (other.tag == "cuartelArqueros") {
            Debug.Log(other.GetComponent<Estructuras>().vidaVariable);
            if (other.GetComponent<Estructuras>().vidaVariable < other.GetComponent<Estructuras>().vidaInicial) {

                float distancia = Vector3.Distance(transform.position, other.transform.position);
                nav.destination = other.transform.position;
                

                if (distancia < 3.5f) {
                    tiempoRep2 += Time.deltaTime;
                    nav.destination = transform.position;
                    if (tiempoRep2 >= tiempoRep) {

                        other.GetComponent<Estructuras>().vidaVariable += 1;
                        
                        tiempoRep2 = 0;

                    }
                    
                }
            }

        }
    }

}
