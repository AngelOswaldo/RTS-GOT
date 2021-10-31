using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : MonoBehaviour
{
    // Start is called before the first frame update

    //prefab de la bala
    [SerializeField]
    GameObject balaPrefab;

    float dilay;

    //cada cuanto tiempo se hara el disparo o ataque
    [SerializeField]
    private float tiempoDisparo;
    //booleana para detectar si ya se hizo un disparo
    bool disparo;

    //variable donde se guardara la posicion del objetivo
    Transform objetivo;

    [HideInInspector]
    public string estado;

    

    void Start()
    {
        disparo = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other) {
        //se obtiene la posicion del objetivo
        

        if (disparo == true && other.tag=="Animal") {

            dilay += Time.deltaTime;

            if (dilay >= 0.7f) {
                objetivo = other.transform;
                Debug.Log("choque");
                StartCoroutine("TiempoDisparo");
                gameObject.GetComponent<MovYSeleccion>().anim.SetInteger("estado", 2);
                gameObject.GetComponent<MovYSeleccion>().nav.destination = transform.position;

                estado = "ataque";
            }
            

        }
    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Animal") {

            estado = "no ataque";
            dilay = 0;
        }
    }




    //ataque y tiempo de disparo
    IEnumerator TiempoDisparo()
    {
        disparo = false;
        
        GameObject bala = Instantiate(balaPrefab, transform.position, objetivo.transform.rotation);

        Vector3 direccion = (objetivo.position - bala.transform.position).normalized;

        bala.GetComponent<Bala>().velocity = direccion * bala.GetComponent<Bala>().speed;
        yield return new WaitForSeconds(tiempoDisparo);
        disparo = true;
    }
    
}
