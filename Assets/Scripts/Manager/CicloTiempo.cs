using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CicloTiempo : MonoBehaviour
{

    public float Delay;

    public int CantidadArotar;

    public Light Luz;

    private float Timer;

    private bool HasCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        Timer = Time.time + Delay;
    }

    // Update is called once per frame
    void Update()
    {
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
                RotarSol();

                HasCooldown = true;

                Timer = Time.time + Delay;

            }
        }
    }

    public void RotarSol()
    {
        Luz.transform.Rotate(CantidadArotar, 0, 0);
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(.2f);

        HasCooldown = false;

        StopCoroutine(enumerator());

    }

}


public class ActualizadorNumeros<T>
{
    public void ActualizarNumeros(Text texto,float Num)
    {
        texto.text = Num.ToString();
    }
}
