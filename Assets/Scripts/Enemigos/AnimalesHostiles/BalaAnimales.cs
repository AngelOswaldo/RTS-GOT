using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaAnimales : MonoBehaviour
{

    public float Speed;

    public Rigidbody RB;

    public int DamageSoldados;

    public float TiempoAdestruir;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, TiempoAdestruir);
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = transform.forward * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Amigo")
        {
            other.GetComponent<Vida>().VidaPersonaje = other.GetComponent<Vida>().VidaPersonaje + other.GetComponent<Vida>().Armadura - DamageSoldados;

            Destroy(this.gameObject);

            print("Pegue a amigo");

        }

        else if (other.gameObject.tag == "Soldado")
        {
            other.GetComponent<Vida>().VidaPersonaje = other.GetComponent<Vida>().VidaPersonaje + other.GetComponent<Vida>().Armadura - DamageSoldados;

            Destroy(this.gameObject);

            print("Pegue a soldado");

        }

    }

}
