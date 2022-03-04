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

    [SerializeField]
    [StringInList("movimiento","sin movimiento")]
    string tipoColocacion;

    float rotacion = 0;
    void Start()
    {

        movimientoPreColocacion = true;
        
    }

    // Update is called once per frame
    void Update()
    {


        if (tipoColocacion == "movimiento") {

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && movimientoPreColocacion == true)
            {
                hit.point = new Vector3(hit.point.x, 6.3f, hit.point.z);
                transform.position = hit.point;

            }

            if (Input.GetMouseButtonUp(0) && movimientoPreColocacion == true)
            {
                movimientoPreColocacion = false;
                GameManager.vComida -= GameManager.vPrecioAldeanos;
                StartCoroutine("CargaDeColocacion");

            }
            if (Input.GetMouseButtonUp(1) && movimientoPreColocacion == true) Destroy(gameObject);

            if (Input.GetKeyDown(KeyCode.R))
            {
                rotacion += 90;
                transform.rotation = Quaternion.Euler(0, rotacion, 0);
            }

        }

        if (tipoColocacion == "sin movimiento") {

            StartCoroutine("CargaDeColocacion");

        }
        
    }

    IEnumerator CargaDeColocacion(){

        yield return new WaitForSeconds(tiempoColocacion);
        GameObject nuevaEstructura = Instantiate(prefab, transform.position, transform.rotation);
        
        Destroy(gameObject);

    }
}
