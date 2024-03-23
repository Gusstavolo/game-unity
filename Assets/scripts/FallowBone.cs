using UnityEngine;
using UnityEngine.UIElements;

public class FallowBone : MonoBehaviour
{
    public Transform Bone; // Refer�ncia para o transform da m�o do jogador
    public Vector3 offsetRotate = new Vector3(0f, 0f, 0f);
    public Vector3 offsetPosition = new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Bone != null) // Verifica se a m�o do jogador foi atribu�da
        {
            transform.position = Bone.position + offsetPosition; // Define a posi��o do item para a posi��o da m�o do jogador
            transform.rotation = Bone.rotation * Quaternion.Euler(offsetRotate); // Define a rota��o do item para a rota��o da m�o do jogador
            
          
        }
    }
}