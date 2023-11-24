using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do jogador
    public float jumpForce = 10f; // Força do pulo
    public float rotationSpeed = 500; //Velocidade de rotação
    private bool isGrounded = true; // Verifica se o jogador está no chão
    private Rigidbody rb;
    private Animator animator;
    [SerializeField] GameObject Avatar;

    private float lastRotation = 0;

    [SerializeField] AudioSource jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Mantém a rotação do Rigidbody congelada
        animator = Avatar.GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mova o jogador horizontal e verticalmente
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, moveVertical * moveSpeed);

        var IsMoving = movement.z != 0 || movement.x != 0;

        animator.SetBool("IsMoving", IsMoving);
        animator.SetBool("IsGrounded", isGrounded);
        rb.velocity = movement;

        RotateCharacter(moveHorizontal, moveVertical);

        // Permita que o jogador pule se estiver no chão
        if (Input.GetKeyDown("space") && isGrounded)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
            isGrounded = false;
            jumpSound.Play();
        }
    }

    void RotateCharacter(float moveHorizontal, float moveVertical)
    {
        float targetrotation = lastRotation;
        if (moveHorizontal != 0 && moveVertical != 0)
        {

            if (moveVertical > 0)
            {
                //45|-45
                targetrotation = moveHorizontal > 0f ? 45 : -45;
            }
            else
            {
                //135|-135
                targetrotation = moveHorizontal > 0f ? 135 : -135;
            }
        }
        else
        {
            if (moveHorizontal != 0f)
            {
                targetrotation = moveHorizontal > 0f ? 90 : -90;
            }

            if (moveVertical != 0f)
            {
                targetrotation = moveVertical > 0f ? 0f : 180f;
            }
        }
        lastRotation = targetrotation;
        transform.rotation = Quaternion.Euler(0f, targetrotation, 0f);
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