using UnityEngine;

public class MusicaManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Conectar a un botón de "mutear" si quieren
    public void ToggleMute()
    {
        audioSource.mute = !audioSource.mute;
    }
}