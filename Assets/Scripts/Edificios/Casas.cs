using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casas : MonoBehaviour
{
    [SerializeField]
    int aumentarCapacidad;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.maxAldeanos += aumentarCapacidad;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
