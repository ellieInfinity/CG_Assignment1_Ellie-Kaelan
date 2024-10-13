using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 8f;
    [SerializeField] private float gravity = -9.8f;

    [Header("Grounding")]
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundLayer;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    public AudioSource walking;

    private bool gameEnd = false;


    private void Start() {
        controller = GetComponent<CharacterController>();
    }

    private void Update() {
        Grounding();
        if (!gameEnd)
        {
            Movement();
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                walking.enabled = true;
            }
            else walking.enabled = false;
        }
        
    }

    private void Movement() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * x + transform.forward * z;
        controller.Move(moveDirection * playerSpeed * Time.deltaTime);
    }

    private void Grounding() {
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -1f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}