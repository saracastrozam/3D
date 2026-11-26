using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Transform> enemyPosition;
    public GameObject enemy;
    public float waitTime;

    void Start()
    {
        StartCoroutine(spawing());
    }
    
    IEnumerator spawing()
    {
       for(int i = 0; i < enemyPosition.Count; i++)
        {
            int enemyPos = Random.Range(0, enemyPosition.Count);

            Instantiate(enemy, enemyPosition[enemyPos].position, enemyPosition[enemyPos].rotation);

            yield return new WaitForSeconds(waitTime);
        }

     }

   
}
