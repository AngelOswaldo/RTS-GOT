using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarEdificios : MonoBehaviour
{

    RaycastHit hit;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {


        
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) 
        {
            hit.point = new Vector3(hit.point.x, 0.5f, hit.point.z);
            transform.position = hit.point;

        }

        if (Input.GetMouseButton(0) && GameManager.vOro>=100)
        {
            GameManager.vOro -= GameManager.vPrecioAldeanos;
            GameObject npc = Instantiate(prefab, transform.position, transform.rotation);
            GameManager.npcControlados.Add(npc);
            Destroy(gameObject);

        }
    }
}
