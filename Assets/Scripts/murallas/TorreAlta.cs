using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreAlta: MonoBehaviour
{
    [HideInInspector]
    public bool seleccion=false;

    private void Awake()
    {
        ManagerEstructuras.TorresAltas.Add(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < ManagerEstructuras.TorresAltas.Count; i++)
        {

            ManagerEstructuras.TorresAltas[i].GetComponent<TorreAlta>().seleccion = false;

        }

        seleccion = true;

    }
}
