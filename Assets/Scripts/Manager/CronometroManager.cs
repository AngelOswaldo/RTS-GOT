using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CronometroManager : MonoBehaviour
{

    public Text[] textos;

    private int Secundero;

    private int Minutero;

    private int Hora;

    ActualizadorNumeros<CronometroManager> SegundoInstance = new ActualizadorNumeros<CronometroManager>();

    ActualizadorNumeros<CronometroManager> MinutoInstance = new ActualizadorNumeros<CronometroManager>();

    ActualizadorNumeros<CronometroManager> HoraInstance = new ActualizadorNumeros<CronometroManager>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Cronometro", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Secundero >= 60)
        {
            Minutero++;
            Secundero = 0;
        }

        if (Minutero >= 60)
        {
            Hora++;

            Minutero = 0;

        }

        SegundoInstance.ActualizarNumeros(textos[0], Secundero);

        MinutoInstance.ActualizarNumeros(textos[1], Minutero);

        HoraInstance.ActualizarNumeros(textos[2], Hora);

    }

    public void Cronometro()
    {
        Secundero++;
    }

}
