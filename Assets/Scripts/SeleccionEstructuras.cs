using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionEstructuras : MonoBehaviour
{//016055555 2
    [SerializeField]
    [StringInList("espadachin", "arquero", "caballero")]
    string tipoEstructura;

    BotonManager botonManager;
    // Start is called before the first frame update
    void Start()
    {
        botonManager = GameObject.Find("botonManager").GetComponent<BotonManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        for (int i = 0; i < botonManager.botones.Length; i++)
        {

            botonManager.botones[i].SetActive(false);

        }

        if (tipoEstructura == "espadachin") {

            Debug.Log("cuartel de espadachines");
            botonManager.botones[1].SetActive(true);

        }
        if (tipoEstructura == "arquero") {

            Debug.Log("cuartel de arqueros");
            botonManager.botones[0].SetActive(true);

        }
        if (tipoEstructura == "caballero") {

            Debug.Log("cuartel de caballeros");
            botonManager.botones[2].SetActive(true);

        } 


    }
}
