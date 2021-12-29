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

    private Rigidbody rig;
    private float amount = 5;
    //direccion de la bala
    /*[HideInInspector]
    public Vector3 velocity = new Vector3(2f, 0);*/

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        StartCoroutine(DestoyBullet());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target!=null)
        {
            rig.AddForce((target.position - transform.position) * amount);
            transform.rotation = Quaternion.LookRotation(rig.velocity);
            rig.velocity = ((target.position - transform.position) * speed);
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