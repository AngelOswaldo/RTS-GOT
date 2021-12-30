using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocacionEstructuras : MonoBehaviour
{

    RaycastHit hit;
    public GameObject prefab;

    //cuanto tiempo demorara en colocarse el objeto
    [SerializeField]
    float tiempoColocacion;
    //booleana para determinar si aun estas moviendo la pre colocacion, una vez se de click ya no se deberia de mover
    bool movimientoPreColocacion;
    // Start is called before the first frame update
    void Start()
    {

        movimientoPreColocacion = true;
        
    }

    // Update is called once per frame
    void Update()
    {


        
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && movimientoPreColocacion==true) 
        {
            hit.point = new Vector3(hit.point.x, 0, hit.point.z);
            transform.position = hit.point;

        }

        if (Input.GetMouseButtonUp(0) && movimientoPreColocacion == true)
        {
            movimientoPreColocacion = false;
            GameManager.vComida -= GameManager.vPrecioAldeanos;
            StartCoroutine("CargaDeColocacion");

        }
        if (Input.GetMouseButtonUp(1) && movimientoPreColocacion==true) Destroy(gameObject);
    }

    IEnumerator CargaDeColocacion(){

        yield return new WaitForSeconds(tiempoColocacion);
        GameObject nuevaEstructura = Instantiate(prefab, transform.position, transform.rotation);
        
        Destroy(gameObject);

    }
}