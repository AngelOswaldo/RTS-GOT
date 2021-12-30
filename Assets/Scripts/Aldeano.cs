using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Aldeano : MonoBehaviour
{
    public float vida;

    [HideInInspector]
    public NavMeshAgent nav;

    [Header("Recoleccion")]
    [SerializeField]
    int CantidadPiedraRecolectar;

    [SerializeField]
    int CantidadMaderaRecolectar;

    [Header("Carga maxima")]
    [SerializeField]
    int maxPiedra;
    int piedraVariable;

    [SerializeField]
    int maxMadera;
    int maderaVariable;

    [SerializeField]
    int maxComida;
    int comidaVariable;


    [Header("Tiempos")]
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
        nav = GetComponent<NavMeshAgent>();
        GameManager.npcControlados.Add(gameObject);
        piedraVariable = 0;
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
        if (Input.GetMouseButton(1) && gameObject.GetComponent<Seleccion>().seleccion == true)
        {
            
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                nav.destination = hit.point;

            }
        }

        //cuando ya tiene el maximo de piedras que puede cargar
        //buscara el deposito mas cercano e ira a dejar su carga aumentando el score en pantalla
        if (piedraVariable >= maxPiedra) {

                ManagerEstructuras.CalcularDepositoCercano(this.gameObject);
                        

        }
    }


    private void OnTriggerStay(Collider other)
    {

        //si detecta piedras y aun tiene espacio para llevar piedras
        //entonces podra ir a recolectar
        if (other.tag == "Piedra" && piedraVariable<maxPiedra) {

            nav.destination = other.transform.position;
            float distancia = Vector3.Distance(transform.position, other.transform.position);
            if (distancia <= 1) {

                tiempo += Time.deltaTime;
                //cada cierto tiempo la cantidad de piedra que lleva aumenta y
                //el recurso se va disminuyendo segun la cantidad que recolecte el aldeano
                if (tiempo >= tiempoRecoleccion) {

                    piedraVariable += CantidadPiedraRecolectar;
                    other.GetComponent<Recursos>().cantVariable-= CantidadPiedraRecolectar;
                    tiempo = 0;
                    Debug.Log(piedraVariable);
                }

            }
        }

        if (other.tag == "Arbol" && maderaVariable<maxMadera)
        {

            nav.destination = other.transform.position;
            float distancia = Vector3.Distance(transform.position, other.transform.position);
            if (distancia <= 1)
            {

                tiempo += Time.deltaTime;
                if (tiempo >= tiempoRecoleccion)
                {

                    maderaVariable += CantidadMaderaRecolectar;
                    other.GetComponent<Recursos>().cantVariable -= CantidadMaderaRecolectar;
                    tiempo = 0;
                    Debug.Log(maderaVariable);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Deposito")
        {

            GameManager.vPiedra += piedraVariable;
            piedraVariable = 0;

        }
    }

}
