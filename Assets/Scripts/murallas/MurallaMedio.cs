using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurallaMedio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Porton") {

            other.gameObject.GetComponent<ColocacionPorton>().contadorColisiones++;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Porton")
        {

            other.gameObject.GetComponent<ColocacionPorton>().contadorColisiones--;

        }
    }
}
