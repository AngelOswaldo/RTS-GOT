using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crear : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CrearNpc() {

        if (GameManager.vComida >= 100)
            Instantiate(prefab);
        else Debug.Log("Falta de comida");
        

    }

}
