using UnityEngine;
using UnityEngine.UIElements;

public class FallowBone : MonoBehaviour
{
    public Transform Bone; // Referência para o transform da mão do jogador
    public Vector3 offsetRotate = new Vector3(0f, 0f, 0f);
    public Vector3 offsetPosition = new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Bone != null) // Verifica se a mão do jogador foi atribuída
        {
            transform.position = Bone.position + offsetPosition; // Define a posição do item para a posição da mão do jogador
            transform.rotation = Bone.rotation * Quaternion.Euler(offsetRotate); // Define a rotação do item para a rotação da mão do jogador
            
          
        }
    }
}