using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFALL : MonoBehaviour
{

    public float rotationThreshold = 2f; // limite de tempo para iniciar a rota��o

    public float tempoLimiteForaDoChao = 2f; // Tempo limite fora do ch�o antes de considerar uma queda
    public float tempoForaDoChao = 0f; // Tempo acumulado fora do ch�o
    public float velocidadeRotacao = 100f;

    private Animator animator;
    //private PlayerController playerController;

    public bool isGrounded; // Vari�vel para verificar se o jogador est� no ch�o


    void Start()
    {
        // obt�m a refer�ncia ao CharacterController
        animator = GetComponent<Animator>();
       

    }

    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

       

        if (!isGrounded)
        {
            // se o jogador estiver no ar, faz ele girar
            if (tempoForaDoChao > tempoLimiteForaDoChao)
            {
           

                animator.enabled = false;
            }
           
         tempoForaDoChao += Time.deltaTime;
       
            
          
            // reinicia o tempo no ar
        }else
        {
            animator.enabled = true;
            tempoForaDoChao = 0f;
        }

  

    }
  }



