using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{



    //en este script solo se detectara la colision con las balas, se colocara la vida del animal y la comida que podrá otorgar
    
   
    

    public int vida;
    [HideInInspector]
    public int vidaVariante;

    public int comidaObtenida;
    [HideInInspector]
    public int comidaVariante;
    // Start is called before the first frame update
    void Start()
    {
        comidaVariante = comidaObtenida;
        vidaVariante = vida;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {

        if (other.tag == "Bala") {

            vidaVariante-=other.GetComponent<Bala>().damage;
            
        }

    }


}
