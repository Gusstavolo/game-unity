using UnityEngine;
using UnityEngine.UIElements.Experimental;



public class GrabSystem : MonoBehaviour
{
    private bool isGrabbing = false;
    private bool isGrabbingHAND = false;
    public GameObject grabbedObject;
  
    private Rigidbody grabbedRigidbody;
    private Transform grabPosition;
   

    [SerializeField] protected KeyCode grabKey = KeyCode.G; // Voc� pode mudar a tecla conforme necess�rio
    [SerializeField] protected float grabRange = 2f; // Dist�ncia m�xima para pegar objetos
    [SerializeField] protected LayerMask grabbableLayer; // Camada de objetos peg�veis
    [SerializeField] protected float throwForce = 10f; // For�a do lan�amento
    private Animator animator;

    private Transform grabPositionHAND;
    [SerializeField] private KeyCode grabKeyHAND = KeyCode.G; // Voc� pode mudar a tecla conforme necess�rio
    [SerializeField] private LayerMask grabbableLayerHAND; // Camada de objetos peg�veis

  public Transform HANDPOS; // Refer�ncia para o transform da m�o do jogador
    public Vector3 offsetRotacaoHAND = new Vector3(0f, 0f, 90f);
    public Vector3 offsetPositionHAND = new Vector3(0f, 0f, 0f);
    public Transform HEADPOS; // Refer�ncia para o transform da m�o do jogador
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
                grabbedRigidbody.isKinematic = true; // Torna o objeto cinem�tico
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
                grabbedRigidbody.isKinematic = true; // Torna o objeto cinem�tico

                Item itemComponent = grabbedObject.GetComponent<Item>();
                if (itemComponent != null)
                {
                    itemComponent.Use(); // Chama o m�todo Use() do componente Item
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
            grabbedRigidbody.isKinematic = false; // Torna o objeto n�o cinem�tico antes de lan��-lo
            grabbedRigidbody.AddForce(transform.forward * throwForce, ForceMode.Impulse); // Aplica uma for�a para lan�ar o objeto
            grabbedRigidbody = null;
            grabbedObject = null;
            isGrabbing = false;
            
        }
    }
    void ReleaseGrabHAND()
    {
      
        if (grabbedObject != null && grabbedRigidbody != null)
        {
          
            grabbedRigidbody.isKinematic = false; // Torna o objeto n�o cinem�tico antes de lan��-lo
            grabbedRigidbody.AddForce(transform.forward * 2, ForceMode.Impulse); // Aplica uma for�a para lan�ar o objeto
            grabbedRigidbody = null;
            grabbedObject = null;
            isGrabbingHAND = false;

        }
    }
     

    void UpdateGrabbedObjectPosition()
    {
        if (grabbedObject != null)
        {
           
            grabbedObject.transform.position = HEADPOS.position + offsetPositionHEAD ; // Define a posi��o do item para a posi��o da m�o do jogador
            grabbedObject.transform.rotation = HEADPOS.rotation * Quaternion.Euler(offsetRotateHEAD); ;// Define a rota��o do item para a rota��o da m�o do jogador

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
