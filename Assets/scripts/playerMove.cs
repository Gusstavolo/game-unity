using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //public float speed = 1000f;


    public CharacterController controller;


    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float playerRunSpeed = 1.2f;
    private float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;

    private Animator animator;
    

    void Start()
    {

        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
 
    void Update()
    {

        bool groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Obtém as entradas de movimento
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Normaliza o vetor de movimento
        Vector3 move = Vector3.zero;
        if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
        {
            move = new Vector3(horizontalInput, 0, 0);
        }
        else
        {
            move = new Vector3(0, 0, verticalInput);
        }

        // Inverte as entradas de movimento
        move = new Vector3(-move.x, 0, -move.z);

        controller.Move(move * Time.deltaTime * playerSpeed);
         if ( Input.GetKey(KeyCode.LeftShift))
                {
            controller.Move(move * Time.deltaTime * playerSpeed * playerRunSpeed);
        }



        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        

       
             

        // Changes the height position of the player..
        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        } 

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);



        animator.SetBool("isRunning", Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0);




         }
}

