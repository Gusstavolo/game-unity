using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FallowHand : MonoBehaviour
{
    public Transform maoDoJogador; // Referência para o transform da mão do jogador
    public Vector3 offsetRotacao = new Vector3(0f, 0f, 90f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (maoDoJogador != null) // Verifica se a mão do jogador foi atribuída
        {
            transform.position = maoDoJogador.position; // Define a posição do item para a posição da mão do jogador
            transform.rotation = maoDoJogador.rotation * Quaternion.Euler(offsetRotacao); ;// Define a rotação do item para a rotação da mão do jogador

            
        }
    }
}
