using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarEstructuras : MonoBehaviour
{
    [HideInInspector]
    public bool TocandoEstructura=false;

    public float Speed;

    public Rigidbody EnemyRB;

    float Timer;

    public float Delay;

    bool HasCooldown = false;

    public GameObject Bola;

    GameObject BalaRotation;

    public bool Patrullar = true;

    float TimerPatrulla;

    public float DelayGiroPatrulla;

    bool CooldownPatrulla=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        LanzarEspadazo();

        if (Patrullar == true)
        {
            Llamamiento();
        }

        Patrulla();

        if (CooldownPatrulla == true)
        {
            StartCoroutine(returnPatrol());
        }

        if (BalaRotation != null)
        {
            BalaRotation.transform.rotation = transform.rotation;
        }

        if (HasCooldown == true)
        {
            StartCoroutine(returnCooldown());
        }

        if (TocandoEstructura == false)
        {
            Timer = Time.time + Delay;
        }


    }


    public void LanzarEspadazo()
    {
        if (TocandoEstructura == true)
        {
            if (HasCooldown == false)
            {
                if (Timer < Time.time)
                {
                    BalaRotation=Instantiate(Bola,transform.position,Quaternion.identity);

                     HasCooldown = true;

                     Timer = Time.time + Delay;

                     print("Lanzado");
                }



            }
        }
    }

    public void Rotacion()
    {
        transform.Rotate(0, Random.Range(0, 360), 0);
    }


    public void Llamamiento()
    {
        if (Patrullar == true)
        {
            if (CooldownPatrulla == false)
            {
                if (TimerPatrulla < Time.time)
                {
                    Rotacion();

                    TimerPatrulla = Time.time + DelayGiroPatrulla;

                    CooldownPatrulla = true;

                }
            }
        }
    }

    public void Patrulla()
    {
        if (Patrullar == true)
        {
            EnemyRB.velocity = transform.forward * Speed;
        }
    }

    public IEnumerator returnPatrol()
    {
        yield return new WaitForSeconds(.2f);

        CooldownPatrulla = false;

        StopCoroutine(returnPatrol());

    }
    public IEnumerator returnCooldown()
    {
        yield return new WaitForSeconds(.5f);

        HasCooldown = false;

        StopCoroutine(returnCooldown());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Estructura" || other.gameObject.tag == "Amigo" || other.gameObject.tag=="Animal" && TocandoEstructura == false )
        {
            Patrullar = false;

            transform.LookAt(other.gameObject.transform);

            EnemyRB.velocity = transform.forward * Speed;
        }

        if(other.gameObject.tag=="Estructura" && other.GetComponent<VidaEstructuras>().VidaTorres <= 0)
        {
            Patrullar = true;

            TocandoEstructura = false;
        }

        if (other.gameObject.tag == "Soldado" && other.GetComponent<Vida>().VidaPersonaje <= 0)
        {
            Patrullar = true;

            TocandoEstructura = false;
        }

        if(other.gameObject.tag=="Animal" && other.GetComponent<VidaAnimales>().VidaAnimal <= 0)
        {
            Patrullar = true;

            TocandoEstructura = false;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Estructura" || other.gameObject.tag == "Amigo" || other.gameObject.tag=="Animal")
        {

            Patrullar = true;

            TocandoEstructura = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Estructura" || collision.gameObject.tag == "Amigo" || collision.gameObject.tag=="Animal")
        {
            TocandoEstructura = true;
        }
    }



}
