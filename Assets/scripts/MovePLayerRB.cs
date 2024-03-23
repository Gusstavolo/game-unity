using UnityEngine;

public class RBMOVE : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float runSpeed = 2f;
    private Rigidbody rb;
    private Vector3 movement;
    private Animator animator;
    public bool isGrounded; // Vari�vel para verificar se o jogador est� no ch�o
    public float jumpForce = 10f; // For�a do pulo

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        // Obt�m as entradas de teclado
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Calcula o movimento baseado nas teclas pressionadas
        movement = new Vector3(-moveHorizontal, 0f, -moveVertical).normalized;
        if (Input.GetKey(KeyCode.LeftShift)){
            movement = new Vector3(-moveHorizontal, 0f, -moveVertical).normalized * runSpeed;
        }
        // Se houver algum movimento, ajusta a orienta��o do jogador
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false); // Desativa a anima��o de corrida
        }
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
    }
    void FixedUpdate()
    {
        // Aplica o movimento ao Rigidbody
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

}
