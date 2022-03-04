using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crear : MonoBehaviour
{

    [SerializeField]
    GameObject prefab;

    [SerializeField]
    [StringInList("Estructura","UnidadPelea","Aldeano")]
    string tipoCreacion;

    GameObject unidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CrearNpc() {

        if (tipoCreacion == "Estructura") {

            if (GameManager.vComida >= 100)
                Instantiate(prefab);
            else Debug.Log("Falta de comida");

        }

        if (tipoCreacion == "UnidadPelea") {
                        
            for (int i = 0; i<ManagerEstructuras.Cuarteles.Count; i++) {

                if (ManagerEstructuras.Cuarteles[i].GetComponent<Cuartel>().seleccion == true && GameManager.vComida >= 100) {

                    unidad = Instantiate(prefab, ManagerEstructuras.Cuarteles[i].transform.position, ManagerEstructuras.Cuarteles[i].transform.rotation);

                }

            }

        }

        if (tipoCreacion == "Aldeano") {

            if (GameManager.cantAldeanos < GameManager.maxAldeanos) {

                Instantiate(prefab, GameObject.Find("castillo").transform.position, GameObject.Find("castillo").transform.rotation);

            }
            

        }
        
        

    }

}
