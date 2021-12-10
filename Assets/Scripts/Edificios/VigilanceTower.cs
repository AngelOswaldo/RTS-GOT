using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VigilanceTower : MonoBehaviour
{
    [Header("Tower Stats")]
    public int HP;
    public int baseAttack;
    public int speedAttack;
    public int damageMultiplier;

    [Header("Enemy")]
    public bool haveEnemy = false;
    public List<SoldadoController> enemies;
    public string enemiesTag;

    [Header("Allies")]
    public List<SoldadoController> archers;
    public string alliesTag;
    public int maxArchers;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(enemies.Count<0)
        {
            haveEnemy = false;
            enemies.Clear();
        }
        
    }

    public IEnumerator Attack()
    {
        int enemyCount = 0;
        while(haveEnemy)
        {
            if (enemies[enemyCount] == null)
            {
                if(enemyCount<enemies.Count-1)
                {
                    enemyCount += 1;
                }
                else
                {
                    enemies.Clear();
                    break;
                }
            }
            enemies[enemyCount].vida -= CalculateDamage();
            yield return new WaitForSeconds(speedAttack);
        }
    }

    //Calculamos el daño dependiendo del numero de arqueros en la torre
    private int CalculateDamage()
    {
        int totalAttack;
        if (archers.Count > 1)
        {
            damageMultiplier = archers.Count;
            totalAttack = baseAttack * damageMultiplier;
            return totalAttack;
        }
        else
        {
            totalAttack = baseAttack;
            return totalAttack;
        }
    }

}
