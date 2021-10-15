using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField]
    int vida;
    [SerializeField]
    int comidaObtenida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0) {
            GameManager.vComida += comidaObtenida;
            Destroy(gameObject);
        } 
    }

    private void OnTriggerEnter(Collider other) {

        if (other.tag == "Bala") {

            vida-=other.GetComponent<Bala>().damage;

        }
    
    }
}
