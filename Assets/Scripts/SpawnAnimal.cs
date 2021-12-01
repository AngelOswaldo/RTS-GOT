using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimal : MonoBehaviour
{
    //lista de animales que reapareceran
    [SerializeField]
    GameObject[] animales;

    //tiempo en el que reaparecera el animal
    [SerializeField]
    float tiempoRespawn;

    float tiempo=0;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < animales.Length; i++)
        {
            //verifica si algun animal esta muerto(desactivado)
            if (animales[i].activeInHierarchy == false)
            {
                //si el animal esta desactivado entonces el tiempo empieza a correr
                tiempo += Time.deltaTime;
                //si el tiempo es mayor al establecido entonces el animal reaparece
                if (tiempo >= tiempoRespawn)
                {
                    animales[i].transform.GetChild(0).gameObject.GetComponent<Animal>().comidaVariante =
                        animales[i].transform.GetChild(0).gameObject.GetComponent<Animal>().comidaObtenida;

                    animales[i].transform.GetChild(0).gameObject.GetComponent<Animal>().vidaVariante =
                        animales[i].transform.GetChild(0).gameObject.GetComponent<Animal>().vida;

                    animales[i].GetComponent<ComportamientoAnimal>().speedVariable =
                        animales[i].GetComponent<ComportamientoAnimal>().speedFijo;

                    animales[i].SetActive(true);

                    tiempo = 0;
                }

            }

        }
    }
}
