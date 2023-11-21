using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int lives = 3;  // Número inicial de vidas
    private Vector3 initialPosition = Vector3.zero;  // Posição inicial do jogador
    public TextMeshProUGUI textoVidas;

    [SerializeField] AudioSource deathSound;

    private void Start()
    {
        initialPosition = transform.position;
        textoVidas.text = $"Vidas: {lives}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Morte"))  // Verifique se o jogador colidiu com a plataforma
        {
            lives--;  // Subtrai uma vida
            Debug.Log("AAAAAAAAAAAAAAAAAAAA");
            if (lives <= 0)
            {
                // Se o jogador não tiver mais vidas, você pode adicionar um código para game over aqui.
                Debug.Log("Game Over");
                // Neste exemplo, vamos apenas reiniciar o jogador.
                ResetPlayer();
            }
            else
            {
                textoVidas.text = $"Vidas: {lives}";
                ResetPlayer();
                
            }
        }
    }

    private void ResetPlayer()
    {
        transform.position = initialPosition;  // Retorna o jogador à posição inicial
        deathSound.Play();
        // Você pode adicionar outras ações aqui, como reproduzir uma animação ou som de ressurgimento.
    }
}
