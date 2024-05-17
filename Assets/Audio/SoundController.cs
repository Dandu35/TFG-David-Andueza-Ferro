using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip soundClip;
    public float soundInterval = 3f; // Intervalo de tiempo entre cada reproducción de sonido
    public float maxVolumeDistance = 5f; // Distancia máxima a la que el sonido alcanza su volumen máximo
    public float minVolumeDistance = 1f; // Distancia mínima a la que el sonido comienza a sonar
    public Transform player; // Referencia al objeto del jugador

    private AudioSource audioSource;
    private float timeSinceLastSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timeSinceLastSound = 0f;
    }

    void Update()
    {
        // Calcula la distancia entre el objeto y el jugador
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Calcula el volumen del sonido en función de la distancia al jugador
        float volume = Mathf.Clamp(1f - (distanceToPlayer - minVolumeDistance) / (maxVolumeDistance - minVolumeDistance), 0f, 1f);

        // Establece el volumen del AudioSource
        audioSource.volume = volume;

        // Actualiza el temporizador
        timeSinceLastSound += Time.deltaTime;

        // Verifica si es hora de reproducir otro sonido
        if (timeSinceLastSound >= soundInterval)
        {
            // Reproduce el sonido
            audioSource.PlayOneShot(soundClip);

            // Reinicia el temporizador
            timeSinceLastSound = 0f;
        }
    }
}
