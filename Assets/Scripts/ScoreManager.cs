using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Referencia al texto de puntuaci�n
    private float score = 0; // Puntuaci�n inicial
    public float scoreRate = 1; // Incremento de puntuaci�n por segundo

    void Start()
    {
        // Inicializar el texto de puntuaci�n
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    void Update()
    {
        // Aumentar la puntuaci�n con el tiempo
        score += scoreRate * Time.deltaTime;
        // Actualizar el texto de puntuaci�n
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("LastScore", Mathf.FloorToInt(score));
        PlayerPrefs.Save();
    }
}
