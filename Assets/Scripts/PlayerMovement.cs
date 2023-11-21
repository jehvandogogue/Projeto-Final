using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do jogador
    public float jumpForce = 10f; // Força do pulo
    private bool isGrounded = true; // Verifica se o jogador está no chão
    private Rigidbody rb;

    [SerializeField] AudioSource jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Mantém a rotação do Rigidbody congelada
    }

    void Update()
    {
        // Mova o jogador horizontal e verticalmente
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, moveVertical * moveSpeed);
        rb.velocity = movement;

        // Permita que o jogador pule se estiver no chão
         if (Input.GetKeyDown("space") && isGrounded)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
            isGrounded = false;
            jumpSound.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifique se o jogador colidiu com uma superfície com um Layer chamado "Ground"
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }


   
        

    
}