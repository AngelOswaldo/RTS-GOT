using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaAmiga : MonoBehaviour
{

    public int speed;

    public Rigidbody RB;

    public int DamageForEstructuras;

    public int DamageForGuerreros;

    public float TiempoAdestruir;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, TiempoAdestruir);
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Estructura")
        {
            other.GetComponent<VidaEstructuras>().VidaTorres = other.GetComponent<VidaEstructuras>().VidaTorres - DamageForEstructuras;
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Soldado")
        {
            other.GetComponent<Vida>().VidaPersonaje = other.GetComponent<Vida>().VidaPersonaje + other.GetComponent<Vida>().Armadura - DamageForGuerreros;
            Destroy(this.gameObject);
        }

    }
}
