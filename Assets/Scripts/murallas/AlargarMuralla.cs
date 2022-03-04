using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlargarMuralla : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activar() {

        for (int i = 0; i < ManagerEstructuras.TorresAltas.Count; i++) {

            if (ManagerEstructuras.TorresAltas[i].GetComponent<TorreAlta>().seleccion == true) {

                GameObject nuevaTorre = Instantiate(prefab, ManagerEstructuras.TorresAltas[i].transform.position, ManagerEstructuras.TorresAltas[i].transform.rotation);
                nuevaTorre.GetComponent<ColocacionMurallas>().movimiento = false;
                nuevaTorre.GetComponent<ColocacionMurallas>().posicionInicial = nuevaTorre.transform.position;
                ManagerEstructuras.TorresAltas[i].SetActive(false);
              
            }

        }

    }
}
