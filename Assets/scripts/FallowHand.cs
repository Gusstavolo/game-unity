using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FallowHand : MonoBehaviour
{
    public Transform maoDoJogador; // Refer�ncia para o transform da m�o do jogador
    public Vector3 offsetRotacao = new Vector3(0f, 0f, 90f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (maoDoJogador != null) // Verifica se a m�o do jogador foi atribu�da
        {
            transform.position = maoDoJogador.position; // Define a posi��o do item para a posi��o da m�o do jogador
            transform.rotation = maoDoJogador.rotation * Quaternion.Euler(offsetRotacao); ;// Define a rota��o do item para a rota��o da m�o do jogador

            
        }
    }
}
