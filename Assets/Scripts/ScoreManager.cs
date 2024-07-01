using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Referencia al texto de puntuación
    private float score = 0; // Puntuación inicial
    public float scoreRate = 1; // Incremento de puntuación por segundo

    void Start()
    {
        // Inicializar el texto de puntuación
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    void Update()
    {
        // Aumentar la puntuación con el tiempo
        score += scoreRate * Time.deltaTime;
        // Actualizar el texto de puntuación
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("LastScore", Mathf.FloorToInt(score));
        PlayerPrefs.Save();
    }
}
