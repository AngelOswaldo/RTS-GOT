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

    //estado en el que se encuentra, ataque, no ataque
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
        
        //en caso de que colosione con un animal se procedera a atacar
        if (disparo == true && other.tag=="Animal") {


            dilay += Time.deltaTime;

            if (dilay >= 0.7f) {
                //se obtiene el objetivo
                objetivo = other.transform;
                //se activa el corrutine de disparo
                StartCoroutine("TiempoDisparo");
                //se activa la animacion de ataque
                gameObject.GetComponent<SoldadoController>().anim.SetInteger("estado", 2);
                //deja de moverse
                gameObject.GetComponent<SoldadoController>().nav.destination = transform.position;

                estado = "ataque";
            }
            

        }
    
    }

    private void OnTriggerExit(Collider other)
    {
        //si deja de colisionar con un animal
        if (other.tag == "Animal") {
            //el estado cambia
            estado = "no ataque";
            //el tiempo de dilay se resetea
            dilay = 0;
        }
    }




    //ataque y tiempo de disparo
    IEnumerator TiempoDisparo()
    {
        disparo = false;
        
        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
        bala.GetComponent<Bala>().target = objetivo;

        //Vector3 direccion = (objetivo.position - bala.transform.position).normalized;

        //bala.GetComponent<Bala>().velocity = direccion * bala.GetComponent<Bala>().speed;
        yield return new WaitForSeconds(tiempoDisparo);
        disparo = true;
    }
    
}
