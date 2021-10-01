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

        Instantiate(prefab, new Vector3(Random.Range(-20,20),0.5f, Random.Range(-15, 15)), transform.rotation);
        

    }

}
