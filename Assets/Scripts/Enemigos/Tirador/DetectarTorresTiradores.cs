using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarTorresTiradores : MonoBehaviour
{

    public float speed;

    public Rigidbody EnemyRB;

    [HideInInspector]
    public bool ListoParaDisparar = false;

    [HideInInspector]
    public bool HasCooldown;

    public float Delay;

    float timer;

    public GameObject BolaAdisparar;

    GameObject bolaDisparada;

    public bool Patrullar = true;

    bool CooldownPatrulla;

    float TimerPatrulla;

    public float DelayGiroPatrulla;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LanzarBola();

        if (Patrullar == true)
        {
            Llamamiento();
        }

        Patrulla();

        if (CooldownPatrulla == true)
        {
            StartCoroutine(returnPatrol());
        }

        if (bolaDisparada != null)
        {
            bolaDisparada.transform.rotation = transform.rotation;
        }

        if (HasCooldown == true)
        {
            StartCoroutine(returnBool());
        }

        if (ListoParaDisparar == false)
        {
            timer = Time.time + Delay;
        }

    }

    public void LanzarBola()
    {
        if (ListoParaDisparar == true)
        {
            if (HasCooldown == false)
            {
                if (timer < Time.time)
                {
                    bolaDisparada = Instantiate(BolaAdisparar, transform.position, Quaternion.identity);

                    HasCooldown = true;

                    timer = Time.time + Delay;

                    print("Lance arquero");

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
            EnemyRB.velocity = transform.forward * speed;
        }
    }

    public IEnumerator returnPatrol()
    {
        yield return new WaitForSeconds(.2f);

        CooldownPatrulla = false;

        StopCoroutine(returnPatrol());

    }

    public IEnumerator returnBool()
    {
        yield return new WaitForSeconds(.5f);

        HasCooldown = false;

        StopCoroutine(returnBool());

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="Estructura" && ListoParaDisparar == false)
        {
            Patrullar = false;

            transform.LookAt(other.transform.position);

            EnemyRB.velocity = transform.forward * speed;

        }
        else if(other.gameObject.tag == "Amigo" && ListoParaDisparar == false)
        {

            Patrullar = false;

            transform.LookAt(other.transform.position);

            EnemyRB.velocity = transform.forward * speed;
        }

        else if (other.gameObject.tag == "Animal" && ListoParaDisparar==false)
        {

            Patrullar = false;

            transform.LookAt(other.transform.position);

            EnemyRB.velocity = transform.forward * speed;
        }

        if(other.gameObject.tag=="Estructura" && other.GetComponent<VidaEstructuras>().VidaTorres <= 0)
        {

            Patrullar = true;

            ListoParaDisparar = false;
        }

        if(other.gameObject.tag=="Amigo" && other.GetComponent<Vida>().VidaPersonaje <= 0)
        {
            Patrullar = true;

            ListoParaDisparar = false;
        }

        if(other.gameObject.tag=="Animal" && other.GetComponent<VidaAnimales>().VidaAnimal <= 0)
        {
            Patrullar = true;

            ListoParaDisparar = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Estructura" || other.gameObject.tag == "Amigo" || other.gameObject.tag=="Animal")
        {
            Patrullar = true;

            ListoParaDisparar = false;
        }
    }

}
