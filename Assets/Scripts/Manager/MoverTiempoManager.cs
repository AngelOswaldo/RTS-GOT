using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTiempoManager : MonoBehaviour
{
    
    public void PausarTiempo()
    {
        Time.timeScale = 0;
    }

    public void ReanudarTiempo()
    {
        Time.timeScale = 1;
    }

    public void RelentizarTiempo()
    {
        Time.timeScale = 0.5f;
    }

    public void AvanzarTiempo()
    {
        Time.timeScale = 2;
    }

}
