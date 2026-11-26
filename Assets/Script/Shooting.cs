using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;
    public void Shoot()
    {
      Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);
    }

}
