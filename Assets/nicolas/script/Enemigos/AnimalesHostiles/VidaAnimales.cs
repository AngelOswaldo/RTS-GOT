using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaAnimales : MonoBehaviour
{

    public int VidaAnimal;

    public int ComidaAdar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (VidaAnimal <= 0)
        {
            ComidaManager.Comida = ComidaManager.Comida + ComidaAdar;
            Destroy(this.gameObject);
        }
    }
}
