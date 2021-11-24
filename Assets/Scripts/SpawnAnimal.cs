using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimal : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    int tiempoSpawn;

    [SerializeField]
    int cantidadMaxima;

    List<GameObject> animales = new List<GameObject>();
    List<Transform> pos = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        //se crea los animales del inicio
        for (int i = 0; i < cantidadMaxima;i++) {

            animales.Add(Instantiate(prefab, transform.position, transform.rotation));
            animales[i].transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
            

        }

        //se cambian las posiciones de inicio
        animales[0].transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
        animales[1].transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);

        //se guarda las 3 posiciones en la lista para los siguientes spawns
        for (int i = 0; i < cantidadMaxima; i++) {

            pos.Add(animales[i].transform);

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {

            Debug.Log(animales.Count);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(animales.Count);

        }
    }
}
