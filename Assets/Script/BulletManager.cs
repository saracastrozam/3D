using System.Collections;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public int num;

    private void Update()
    {
        while (num < 30)
        {
            num++;
            Debug.Log(num);
        }

      
    }

}

 
