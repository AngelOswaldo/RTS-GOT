using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{



    //en este script solo se detectara la colision con las balas, se colocara la vida del animal y la comida que podrá otorgar
    
   
    

    public int vida;
    public int comidaObtenida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {

        if (other.tag == "Bala") {

            vida-=other.GetComponent<Bala>().damage;
            
        }

    }


}
