using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    //da�o de la bala
    public int damage;
    //velocidad de la bala
    public float speed;

    //direccion de la bala
    [HideInInspector]
    public Vector3 velocity = new Vector3(2f, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * speed * Time.deltaTime;
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal") {

            Destroy(gameObject);

        }
    }
}
//2931540891