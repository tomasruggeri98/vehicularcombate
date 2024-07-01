using UnityEngine;

public class PoliceCarAudio : MonoBehaviour
{
    public AudioClip[] policeSirens; // Arreglo de clips de audio de sirenas policiales
    private AudioSource audioSource;
    private int currentIndex = -1; // Índice del clip actual reproducido
    private float nextSirenTime; // Tiempo para reproducir el próximo clip

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextSiren();
    }

    void Update()
    {
        // Verificar si se puede reproducir el próximo clip
        if (!audioSource.isPlaying && Time.time >= nextSirenTime)
        {
            PlayNextSiren();
        }
    }

    void PlayNextSiren()
    {
        if (policeSirens.Length > 0)
        {
            // Elegir aleatoriamente el tiempo de espera entre 3 y 10 segundos
            float waitTime = Random.Range(3f, 10f);
            nextSirenTime = Time.time + waitTime;

            // Elegir el siguiente clip de audio
            currentIndex = (currentIndex + 1) % policeSirens.Length;
            audioSource.clip = policeSirens[currentIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No se han asignado clips de audio de sirena para reproducir.");
        }
    }
}
