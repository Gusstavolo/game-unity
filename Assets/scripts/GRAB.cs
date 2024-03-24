using UnityEngine;
using UnityEngine.UIElements.Experimental;



public class GrabSystem : MonoBehaviour
{
    private bool isGrabbing = false;
    private bool isGrabbingHAND = false;
    public GameObject grabbedObject;
  
    private Rigidbody grabbedRigidbody;
    private Transform grabPosition;
   

    [SerializeField] protected KeyCode grabKey = KeyCode.G; // Você pode mudar a tecla conforme necessário
    [SerializeField] protected float grabRange = 2f; // Distância máxima para pegar objetos
    [SerializeField] protected LayerMask grabbableLayer; // Camada de objetos pegáveis
    [SerializeField] protected float throwForce = 10f; // Força do lançamento
    private Animator animator;

    private Transform grabPositionHAND;
    [SerializeField] private KeyCode grabKeyHAND = KeyCode.G; // Você pode mudar a tecla conforme necessário
    [SerializeField] private LayerMask grabbableLayerHAND; // Camada de objetos pegáveis

  public Transform HANDPOS; // Referência para o transform da mão do jogador
    public Vector3 offsetRotacaoHAND = new Vector3(0f, 0f, 90f);
    public Vector3 offsetPositionHAND = new Vector3(0f, 0f, 0f);
    public Transform HEADPOS; // Referência para o transform da mão do jogador
    public Vector3 offsetRotateHEAD = new Vector3(0f, 0f, 0f);
    public Vector3 offsetPositionHEAD = new Vector3(0f, 0f, 0f);



    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    void Update()
    {
     




        if (Input.GetKeyDown(grabKey))
        {
            if (!isGrabbingHAND)
            {
                if (!isGrabbing)
                {
                    TryGrab();
                }
                else
                {
                    ReleaseGrab();
                }
            }
        }

        if (isGrabbing)
        {
            UpdateGrabbedObjectPosition();
        }
       
        if (Input.GetKeyDown(grabKeyHAND) )
        {
            if (!isGrabbing)
            {
                  if (!isGrabbingHAND)
                        {
                            TryGrabHAND();
                        }
                  else
                      {
                           ReleaseGrabHAND();
                      }

            }
             
        }

        if (isGrabbingHAND)
        {
            
            UpdateGrabbedObjectPositionHAND();
        }
    }

    void TryGrab()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, grabRange, grabbableLayer);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Grabbable"))
            {
                animator.SetBool("test", true);
                isGrabbing = true;
                
                grabbedObject = collider.gameObject;
                grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
                grabbedRigidbody.isKinematic = true; // Torna o objeto cinemático
                break;
            }
        }
    }
    void TryGrabHAND()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, grabRange, grabbableLayerHAND);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Grabbable"))
            {
               
                isGrabbingHAND = true;
                grabbedObject = collider.gameObject;
                grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
                grabbedRigidbody.isKinematic = true; // Torna o objeto cinemático

                Item itemComponent = grabbedObject.GetComponent<Item>();
                if (itemComponent != null)
                {
                    itemComponent.Use(); // Chama o método Use() do componente Item
                }
                break;
            }
        }
    }

    void ReleaseGrab()
    {
        if (grabbedObject != null && grabbedRigidbody != null)
        {
            
            animator.SetBool("test", false);
            grabbedRigidbody.isKinematic = false; // Torna o objeto não cinemático antes de lançá-lo
            grabbedRigidbody.AddForce(transform.forward * throwForce, ForceMode.Impulse); // Aplica uma força para lançar o objeto
            grabbedRigidbody = null;
            grabbedObject = null;
            isGrabbing = false;
            
        }
    }
    void ReleaseGrabHAND()
    {
      
        if (grabbedObject != null && grabbedRigidbody != null)
        {
          
            grabbedRigidbody.isKinematic = false; // Torna o objeto não cinemático antes de lançá-lo
            grabbedRigidbody.AddForce(transform.forward * 2, ForceMode.Impulse); // Aplica uma força para lançar o objeto
            grabbedRigidbody = null;
            grabbedObject = null;
            isGrabbingHAND = false;

        }
    }
     

    void UpdateGrabbedObjectPosition()
    {
        if (grabbedObject != null)
        {
           
            grabbedObject.transform.position = HEADPOS.position + offsetPositionHEAD ; // Define a posição do item para a posição da mão do jogador
            grabbedObject.transform.rotation = HEADPOS.rotation * Quaternion.Euler(offsetRotateHEAD); ;// Define a rotação do item para a rotação da mão do jogador

        }

    }
    public void UpdateGrabbedObjectPositionHAND()
    {
        if (grabbedObject != null)
        {
            grabbedObject.transform.position = HANDPOS.position + offsetPositionHAND;
            grabbedObject.transform.rotation = HANDPOS.rotation * Quaternion.Euler(offsetRotacaoHAND);
           
        }

    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, grabRange);
    }
}
