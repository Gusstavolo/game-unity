using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GrabSystem : MonoBehaviour
{
    private bool isGrabbing = false;
    private bool isGrabbingHAND = false;
    private GameObject grabbedObject;
    private Rigidbody grabbedRigidbody;
    private Transform grabPosition;

    [SerializeField] private KeyCode grabKey = KeyCode.G; // Você pode mudar a tecla conforme necessário
    [SerializeField] private Transform defaultGrabPosition; // Posição padrão para segurar o objeto
    [SerializeField] private float grabRange = 2f; // Distância máxima para pegar objetos
    [SerializeField] private LayerMask grabbableLayer; // Camada de objetos pegáveis
    [SerializeField] private float throwForce = 10f; // Força do lançamento
    private Animator animator;

    private Transform grabPositionHAND;
    [SerializeField] private KeyCode grabKeyHAND = KeyCode.G; // Você pode mudar a tecla conforme necessário
    [SerializeField] private Transform defaultGrabPositionHAND; // Posição padrão para segurar o objeto
    [SerializeField] private LayerMask grabbableLayerHAND; // Camada de objetos pegáveis
   



    void Start()
    {
        grabPosition = defaultGrabPosition;
        grabPositionHAND = defaultGrabPositionHAND;
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
            grabbedObject.transform.position = grabPosition.position;
            grabbedObject.transform.rotation = grabPosition.rotation;
        }
      
    }
    void UpdateGrabbedObjectPositionHAND()
    {
        if (grabbedObject != null)
        {
            grabbedObject.transform.position = grabPositionHAND.position;
            grabbedObject.transform.rotation = grabPositionHAND.rotation;
        }

    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, grabRange);
    }
}
