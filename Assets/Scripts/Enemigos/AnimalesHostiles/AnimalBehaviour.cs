using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour
{
    public Rigidbody AnimalRB;
   
    bool Atento = false;

    public float SpeedPasivo;

    public float SpeedAtaque;

    bool CooldownVolteo = false;

    public float DelayVolteo;

    float TimerVolteo;
   
    bool Tocando;

    bool HasCooldown = false;

    public GameObject bola;

    GameObject bolaRotation;

    float Timer;

    public float DelayAtaque;

    // Start is called before the first frame update
    void Start()
    {
        TimerVolteo = Time.time + DelayVolteo;
    }

    // Update is called once per frame
    void Update()
    {
        Run();

        LlamadoVolteo();

        LanzarAtaque();

        if (CooldownVolteo == true)
        {
            StartCoroutine(ReturnBoolVolteo());
        }

        if (Tocando == false)
        {
            Timer = Time.time + DelayAtaque;
        }

        if (HasCooldown == true)
        {
            StartCoroutine(ReturnCooldown());
        }

        if (bolaRotation != null)
        {
            bolaRotation.transform.rotation = transform.rotation;
        }

    }

    public void Run()
    {
        if (Atento == false)
        {
            AnimalRB.velocity = transform.forward * SpeedPasivo;
        }
    }

    public void Volteo()
    {
        transform.Rotate(0, Random.Range(0, 361), 0);
    }

    public void LlamadoVolteo()
    {
        if (Atento == false)
        {
            if (CooldownVolteo == false)
            {
                if (TimerVolteo < Time.time)
                {
                    Volteo();

                    TimerVolteo = Time.time + DelayVolteo;

                    CooldownVolteo = true;

                }
            }
        }

    }

    public void LanzarAtaque()
    {
        if (Tocando == true)
        {
            if (HasCooldown == false)
            {
                if (Timer < Time.time)
                {
                    bolaRotation = Instantiate(bola, transform.position, Quaternion.identity);

                    HasCooldown = true;

                    Timer = Time.time + DelayAtaque;

                    print("Lanzado");
                }



            }
        }
    }

    IEnumerator ReturnBoolVolteo()
    {
        yield return new WaitForSeconds(.2f);

        CooldownVolteo = false;

        StopCoroutine(ReturnBoolVolteo());

    }

    IEnumerator ReturnCooldown()
    {
        yield return new WaitForSeconds(.2f);

        HasCooldown = false;

        StopCoroutine(ReturnCooldown());


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Soldado")
        {
            Tocando = true;
        }

        if (collision.gameObject.tag == "Amigo")
        {
            Tocando = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Amigo" || other.gameObject.tag == "Soldado" && Tocando == false)
        {
            Atento = true;

            transform.LookAt(other.gameObject.transform);

            AnimalRB.velocity = transform.forward * SpeedAtaque;

        }

        if(other.gameObject.tag=="Amigo" && other.GetComponent<Vida>().VidaPersonaje <= 0)
        {
            Tocando = false;

            Atento = false;

        }
        else if(other.gameObject.tag=="Soldado" && other.GetComponent<Vida>().VidaPersonaje <= 0)
        {
            Tocando = false;

            Atento = false;

        }

    }

   private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Soldado" || other.gameObject.tag == "Amigo")
        {
            Tocando = false;

            Atento = false;
        }
    }
 
  

}
