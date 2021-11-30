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
            myTower.enemies.Add(other.gameObject);

            //MANDAMOS A LLAMAR LA FUNCION DE ATAQUE
            if (myTower.haveEnemy == false)
            {
                myTower.haveEnemy = true;
                StartCoroutine(myTower.Attack());
            }
        }
    }

    //QUITAMOS DE LA LISTA LOS ENEMIGOS QUE SE SALGAN DEL RANGO
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(myTower.enemiesTag))
        {
            myTower.enemies.Remove(other.gameObject);
        }
    }
}
