using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposito : MonoBehaviour
{



    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        ManagerEstructuras.Depositos.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
