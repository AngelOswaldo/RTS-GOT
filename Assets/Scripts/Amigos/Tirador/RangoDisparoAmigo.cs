using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoDisparoAmigo : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Estructura" || other.gameObject.tag == "Soldado" || other.gameObject.tag=="Animal")
        {
            GetComponentInParent<DetectarTorresTiradorAmigo>().ListoParaDisparar = true;
            print("Esto dentro");
        }
    }

}
