using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazBotones : MonoBehaviour
{//016055555 2
    [SerializeField]
    [StringInList("cuartel", "aldeano")]
    string mostrarInterfaz;

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

        if (mostrarInterfaz == "cuartel")
        {

            Debug.Log("cuartel");
            botonManager.botones[0].SetActive(true);
            botonManager.botones[1].SetActive(true);
            botonManager.botones[2].SetActive(true);

        }

        if (mostrarInterfaz == "aldeano")
        {
            botonManager.botones[3].SetActive(true);
        }
    }
}
