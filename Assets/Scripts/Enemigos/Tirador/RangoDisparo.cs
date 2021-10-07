using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoDisparo : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Estructura" || other.gameObject.tag == "Amigo" || other.gameObject.tag=="Animal")
        {
            GetComponentInParent<DetectarTorresTiradores>().ListoParaDisparar = true;
            print("Esto dentro");
        }
    }



}
