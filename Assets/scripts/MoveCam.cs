using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{

    public Transform target; // O jogador (transform) que a c�mera seguir�
    public Vector3 offset = new Vector3(0f, 3f, -5f); 

    // Start is called before the first frame update
    void Start()
    {
 
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Define a posi��o da c�mera para seguir o jogador com um offset
            transform.position = target.position + offset;

            // Faz a c�mera olhar para o jogador
            transform.LookAt(target.position);
        }

    }
}
