using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoHostilesBehaviour : MonoBehaviour
{
    public float SpeedRelax;

    public float SpeedInWarning;

    bool HaveWarning = false;

    public Rigidbody RB;

    float TimerRotate;

    public float DelayToRotate;

    bool CooldownRotate = false;

    public float DelayToTranquilizarse;

    bool Tocado = false;

    // Start is called before the first frame update
    void Start()
    {
        TimerRotate = Time.time + DelayToRotate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Tocado == false)
        {
            CallingRotacion();

            if (HaveWarning == false)
            {
                RunRelax();
            }
            else if (HaveWarning == true)
            {
                RunWarning();
            }

            if (CooldownRotate == true)
            {
                StartCoroutine(ReturnCooldown());
            }

            if (HaveWarning == true)
            {
                StartCoroutine(ReturnWarning());
            }
        }
        else if (Tocado == true)
        {
            RB.velocity = new Vector3(0, 0, 0);
        }

    }

    public void Rotacion()
    {
        transform.Rotate(0, Random.Range(0, 361), 0);
    }

    public void CallingRotacion()
    {
        if (HaveWarning == false)
        {
            if (CooldownRotate == false)
            {
                if (TimerRotate < Time.time)
                {
                    Rotacion();

                    TimerRotate = Time.time + DelayToRotate;

                    CooldownRotate = true;

                }
            }
        }
    }

    public void RunRelax()
    {
        RB.velocity = transform.forward * SpeedRelax;
    }

    private IEnumerator ReturnCooldown()
    {
        yield return new WaitForSeconds(.2f);

        CooldownRotate = false;

        StopCoroutine(ReturnCooldown());

    }

    private void OnTriggerEnter(Collider other)
    {
        if (Tocado == false)
        {
            if (other.gameObject.tag == "Soldado" || other.gameObject.tag == "Amigo")
            {
                HaveWarning = true;

                transform.Rotate(0, 180, 0);

            }
        }

        if (other.gameObject.tag == "Bala")
        {
            Tocado = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (Tocado == false)
        {
            if (other.gameObject.tag == "Soldado" || other.gameObject.tag == "Amigo")
            {
                HaveWarning = true;

                transform.Rotate(0, 180, 0);

            }
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Soldado" || collision.gameObject.tag == "Amigo")
        {
            Tocado = true;
        }
    }

    public void RunWarning()
    {
        RB.velocity = transform.forward * SpeedInWarning;
    }


    private IEnumerator ReturnWarning()
    {
        yield return new WaitForSeconds(DelayToTranquilizarse);

        HaveWarning = false;

        StopCoroutine(ReturnWarning());

    }

}
