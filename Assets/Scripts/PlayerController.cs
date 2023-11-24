using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
            if (lives == 0)
            {
                Debug.Log("Game Over");
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("GameOverScene");
            }
            else
            {
                ResetPlayer();
            }
            textoVidas.text = $"Vidas: {lives}";
        }
    }

    private void ResetPlayer()
    {
        transform.position = initialPosition;  // Retorna o jogador à posição inicial
        deathSound.Play();
        // Você pode adicionar outras ações aqui, como reproduzir uma animação ou som de ressurgimento.
    }
}
