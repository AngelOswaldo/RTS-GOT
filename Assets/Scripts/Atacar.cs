using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : MonoBehaviour
{
    // Start is called before the first frame update

    //prefab de la bala
    [SerializeField]
    GameObject balaPrefab;

    //cada cuanto tiempo se hara el disparo o ataque
    [SerializeField]
    private float tiempoDisparo;
    //booleana para detectar si ya se hizo un disparo
    bool disparo;

    //variable donde se guardara la posicion del objetivo
    Transform objetivo;

    

    void Start()
    {
        disparo = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        

    }

    private void OnTriggerStay(Collider other) {
        //se obtiene la posicion del objetivo
        objetivo = other.transform;

        if (disparo == true && other.tag=="Animal") {
            Debug.Log("choque");
            StartCoroutine("TiempoDisparo");

        }
    
    }


    //ataque y tiempo de disparo
    IEnumerator TiempoDisparo()
    {
        disparo = false;
        GameObject bala = Instantiate(balaPrefab, transform.position, transform.rotation);

        Vector3 direccion = (objetivo.position - bala.transform.position).normalized;

        bala.GetComponent<Bala>().velocity = direccion * bala.GetComponent<Bala>().speed;
        yield return new WaitForSeconds(tiempoDisparo);
        disparo = true;
    }
}
