using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEstructuras : MonoBehaviour
{
    public int VidaTorres;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectHealth();
    }

    public void DetectHealth()
    {
        if (VidaTorres <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
