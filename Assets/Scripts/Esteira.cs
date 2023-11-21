using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Esteira : MonoBehaviour
{
    [SerializeField] float velocidade; // A velocidade da correia transportadora
    [SerializeField] bool SentidoX = false; // Se a correia transportadora deve animar na direção X
    [SerializeField] bool SentidoZ = false; // Se a correia transportadora deve animar na direção Z
    [SerializeField] bool Inverter = false; // Se a correia transportadora deve animar em reverso
    [SerializeField] GameObject Player;

    Rigidbody rCorpo; // O componente rigidbody da correia transportadora
    float curX; // O deslocamento X atual da textura da correia transportadora
    float curY; // O deslocamento Y atual da textura da correia transportadora
    float velocidadeAnimacao; // A velocidade da animação da correia transportadora
    Rigidbody rb;

    // Start é chamado antes do primeiro quadro
    void Start()
    {
        rCorpo = GetComponent<Rigidbody>(); // Obter o componente rigidbody da correia transportadora
        curX = GetComponent<Renderer>().material.mainTextureOffset.x; // Obter o deslocamento X atual da textura da correia transportadora
        curY = GetComponent<Renderer>().material.mainTextureOffset.y; // Obter o deslocamento Y atual da textura da correia transportadora
        velocidadeAnimacao = velocidade / 5; // Calcular a velocidade da animação da correia transportadora
        rb = Player.GetComponent<Rigidbody>();
    }

    // Update é chamado uma vez por quadro
    void Update()
    {

    }

    // FixedUpdate é chamado a cada quadro de taxa de quadros fixa
    private void FixedUpdate()
    {
        var dt = Time.fixedDeltaTime; // Obter o tempo delta fixo
        Vector3 pos = rCorpo.position; // Obter a posição atual da correia transportadora

        rCorpo.MovePosition(pos); // Mover a correia transportadora para sua posição atual

        if (SentidoX) // Se a correia transportadora deve animar na direção X
        {
            var forcaX = Vector3.left * velocidade * dt * (Inverter ? -1 : 1);
            rCorpo.position +=  forcaX;// Mover a correia transportadora na direção X
            //rb.AddForce(forcaX, ForceMode.Impulse);
            curY += dt * velocidadeAnimacao; // Atualizar o deslocamento Y da textura da correia transportadora
        }
        if (SentidoZ) // Se a correia transportadora deve animar na direção Z
        {
            var forcaZ = Vector3.back * velocidade * dt * (Inverter ? -1 : 1);
            rCorpo.position += forcaZ; // Mover a correia transportadora na direção Z
            //rb.AddForce(forcaZ, ForceMode.Impulse);
            curY += dt * velocidadeAnimacao; // Atualizar o deslocamento Y da textura da correia transportadora
        }
        rCorpo.MovePosition(pos); // Mover a correia transportadora para sua posição atual

        var nome = GetComponent<Renderer>().material.name; // Obter o nome do material usado pela correia transportadora
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(curX, curY); // Definir o deslocamento da textura da correia transportadora
    }
}
