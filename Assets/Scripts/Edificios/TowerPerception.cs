using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPerception : MonoBehaviour
{
    public VigilanceTower myTower;

    //AGREGAMOS A LA LISTA LOS ENEMIGOS QUE ENTREN AL RANGO
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(myTower.enemiesTag))
        {
            myTower.enemies.Add(other.GetComponent<SoldadoController>());

            //MANDAMOS A LLAMAR LA FUNCION DE ATAQUE
            if (myTower.haveEnemy == false)
            {
                myTower.haveEnemy = true;
                StartCoroutine(myTower.Attack());
            }
        }
        else if(other.CompareTag(myTower.alliesTag))
        {
            if(other.GetComponent<SoldadoController>().tipoAtaque == "rango")
            {
                if(myTower.archers.Count<myTower.maxArchers)
                {
                    myTower.archers.Add(other.GetComponent<SoldadoController>());
                    other.gameObject.SetActive(false);
                }

            }
        }

    }

    //QUITAMOS DE LA LISTA LOS ENEMIGOS QUE SE SALGAN DEL RANGO
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(myTower.enemiesTag))
        {
            myTower.enemies.Remove(other.GetComponent<SoldadoController>());
        }
    }
}
