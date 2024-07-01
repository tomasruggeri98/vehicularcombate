using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text scoreText; // Referencia al texto de puntuación

    void Start()
    {
        // Obtener la puntuación guardada
        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        scoreText.text = "Last Score: " + lastScore.ToString();
    }

    // Método para cargar la escena de juego
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); // Cambia "SampleScene" al nombre de tu escena de juego
    }
}
