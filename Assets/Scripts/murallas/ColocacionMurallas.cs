using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocacionMurallas : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    GameObject final;

    [SerializeField]
    ColocacionEstructuras colocacion;
    
    float repeticiones;
    float longitud = 0;

    float separacion=1.9f;

    [HideInInspector]
    public Vector3 posicionInicial;
    Vector3 ultimaposicion;

    List<GameObject> murallas;

    [HideInInspector]
    public RaycastHit hit;

    [HideInInspector]
    public bool movimiento = true;

    bool creacion = true;

    // Start is called before the first frame update
    void Start()
    {
        murallas = new List<GameObject>();

        
        ultimaposicion = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(1) && creacion==true) {

            creacion = false;
            murallas[murallas.Count - 1].SetActive(false);
            murallas[murallas.Count - 1] = Instantiate(final, murallas[murallas.Count - 1].transform.position, murallas[murallas.Count - 1].transform.rotation);
            colocacion.enabled = true;
        }

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && creacion==true) 
        {
            hit.point = new Vector3(hit.point.x, 6.3f, hit.point.z);
            VaciarLista();

            //podras mover la ubicacion de la muralla hasta darle click en algun punto
            if (movimiento == true) {
                posicionInicial = transform.position;
                hit.point = new Vector3(hit.point.x, 6.3f, hit.point.z);
                transform.position = hit.point;

            }

            //
            if (Input.GetMouseButton(1)) {

                //si se da el click la primera torre dejara de moverse con el mouse
                movimiento = false;

                //si detecta que el mouse esta hacia la DERECHA
                if (hit.point.x > posicionInicial.x)
                {

                    //calculo para saber la distancia desde la posicion inicial hasta el mouse 
                    longitud = hit.point.x - posicionInicial.x;
                    //calculo para saber cuantas murallas se crearan
                    repeticiones = longitud / separacion;

                    for (int i = 0; i < repeticiones; i++)
                    {

                        GameObject nuevaMuralla = Instantiate(prefab, new Vector3(ultimaposicion.x + separacion, transform.position.y, transform.position.z), transform.rotation);
                        ultimaposicion = nuevaMuralla.transform.position;

                        murallas.Add(nuevaMuralla);

                    }

                    ultimaposicion = transform.position;

                }

                //si detecta que el mouse esta hacia la IZQUIERDA
                if (hit.point.x < posicionInicial.x)
                {
                    //calculo para saber la distancia desde la posicion inicial hasta el mouse 
                    longitud = posicionInicial.x - hit.point.x;
                    //calculo para saber cuantas murallas se crearan
                    repeticiones = longitud / separacion;

                    for (int i = 0; i < repeticiones; i++)
                    {

                        GameObject nuevaMuralla = Instantiate(prefab, new Vector3(ultimaposicion.x - separacion, transform.position.y, transform.position.z), transform.rotation);
                        ultimaposicion = nuevaMuralla.transform.position;

                        murallas.Add(nuevaMuralla);

                    }

                    ultimaposicion = transform.position;

                }

                

            }
            
            
        }
    }


    public void VaciarLista() {

        for (int i = 0; i < murallas.Count; i++) {

            Destroy(murallas[i]);
           // murallas.Remove(murallas[i]);

        }

    }
}
