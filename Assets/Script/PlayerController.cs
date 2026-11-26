using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float turnspeed = 120f;

    public InputActionReference move;
    private CharacterController controller;
    private Vector2 input;


    public float jumpForce = 10f;
    public float gravity = -20f;
    private float verticalVelocity;
    public InputActionReference jump;

    public Transform groundCheck;
    public float groundRadius;
    public LayerMask groundLayer;
    private bool isGrounded;

    public Animator anim;

    public InputActionReference shoot;

    public int life = 5;
    public bool isDead = false;
 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    private void OnEnable() { move.action.Enable(); jump.action.Enable(); shoot.action.Enable();  }

    private void OnDisable() { move.action.Disable(); jump.action.Disable(); shoot.action.Disable(); }

    void Update()
    {
        input = move.action.ReadValue<Vector2>();


        if (input.x != 0)
        {
            float rotationAmount = input.x * turnspeed * Time.deltaTime;
            transform.Rotate(0f, rotationAmount, 0f);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundLayer);

        if (jump.action.WasPerformedThisFrame()&& isGrounded)
        {
            verticalVelocity = jumpForce;
            anim.SetTrigger("Jump");
        }

        verticalVelocity += gravity * Time.deltaTime;
        
        if(shoot.action.WasPressedThisFrame() && isGrounded)
        {
            anim.SetTrigger("Shoot");
            
        }


        Vector3 direction = transform.forward * input.y * speed;
        direction.y = verticalVelocity;
        controller.Move(direction * Time.deltaTime);

        anim.SetFloat("Move", input.y);

    }


    private void OnTriggerEnter(Collider other)
    {
        life -= 1;

        if (life == 0)
        {

            isDead = true;
            Destroy(gameObject);
            Debug.Log("isdead");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.aquamarine;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

}