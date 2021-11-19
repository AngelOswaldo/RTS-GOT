using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonManager : MonoBehaviour
{
    
    public GameObject[] botones; //= new Text[];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < botones.Length; i++) {

            botones[i].SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
