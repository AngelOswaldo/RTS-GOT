using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    //target de la bala
    public Transform target;
    //daño de la bala
    public int damage;
    //velocidad de la bala
    public float speed;

    /*//direccion de la bala
    [HideInInspector]
    public Vector3 velocity = new Vector3(2f, 0);*/

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestoyBullet());
    }

    // Update is called once per frame
    void Update()
    {
        if(target!=null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
            transform.LookAt(target.position);
        }
    }

    IEnumerator DestoyBullet()
    {
        Destroy(gameObject, 2f);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cuerpo") {

            Destroy(gameObject);

        }
    }
}
//2931540891