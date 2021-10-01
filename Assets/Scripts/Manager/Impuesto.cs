using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Impuesto : MonoBehaviour
{
    public float ImpuestoValor;

    public int Personas;

    [HideInInspector]
    public float Dinero;

    public float Delay;

    public Text textoDinero;

    ActualizadorNumeros<Impuesto> ActualizadorNumeros = new ActualizadorNumeros<Impuesto>();

    float Timer;

    private bool HasCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        Timer = Time.time + Delay;
    }

    // Update is called once per frame
    void Update()
    {
        ActualizadorNumeros.ActualizarNumeros(textoDinero, Dinero);

        Invocar();

        if (HasCooldown == true)
        {
            StartCoroutine(enumerator());
        }

    }
    
    public void Invocar()
    {
        if (HasCooldown == false)
        {
            if (Timer < Time.time)
            {
                GenerarImpuesto();

                HasCooldown = true;

                Timer = Time.time + Delay;
            }
        }
    }

    public void GenerarImpuesto()
    {
        Dinero = Dinero + (Personas * ImpuestoValor);
    }

    public IEnumerator enumerator()
    {
        yield return new WaitForSeconds(.2f);

        HasCooldown = false;

        StopCoroutine(enumerator());

    }

}
