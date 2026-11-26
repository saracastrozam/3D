using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public int force;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward *force, ForceMode.Impulse);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
