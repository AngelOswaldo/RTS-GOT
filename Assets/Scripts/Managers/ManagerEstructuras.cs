using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEstructuras : MonoBehaviour
{

    public static List<GameObject>Cuarteles;
    public static List<GameObject>Depositos;
    public static List<GameObject>TorresAltas;
    


    // Start is called before the first frame update
    void Start()
    {
        Cuarteles = new List<GameObject>();
        Depositos = new List<GameObject>();      
        TorresAltas = new List<GameObject>();      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CalcularDepositoCercano(GameObject aldeano) {

        GameObject aux = new GameObject();


        //algoritmo que calcula las distancia con el resto de depositos y los ordena de mayor a menos segun las distancias
        for (int i = 0; i < Depositos.Count-1; i++) {

            for (int j = 0; j < Depositos.Count-1; j++) {

                if (Vector3.Distance(aldeano.transform.position, Depositos[j].transform.position) >
                    Vector3.Distance(aldeano.transform.position, Depositos[j + 1].transform.position)) {

                    aux = Depositos[j];
                    Depositos[j] = Depositos[j + 1];
                    Depositos[j + 1] = aux;

                }



            }

        }

        aldeano.GetComponent<Aldeano>().nav.destination = Depositos[0].transform.position;

    }
}
