using UnityEngine;
using TMPro; // Si usan Text normal de UI en vez de TextMeshPro, avisar para cambiar esto
using System.Collections;

public class Cronometro : MonoBehaviour
{
    [Header("Referencias")]
    public TMP_Text textoCronometro; // arrastrar el texto de UI que muestra el tiempo

    [Header("Config del tiempo")]
    public float tiempoTotal = 180f; // 3 minutos en segundos

    [Header("Config del pulso")]
    public float escalaPulso = 1.5f;   // qué tan grande se pone en el latido
    public float duracionPulso = 0.3f; // cuánto tarda en ir y volver

    [Header("Sonidos de alerta")]
    public AudioSource audioSource;
    public AudioClip sonidoNervioso;   // suena al entrar al minuto 2 (1:59)
    public AudioClip sonidoEstresado;  // suena al entrar al minuto 1 (0:59)

    [Header("Música de fondo por fase")]
    public AudioSource audioSourceMusica; // AudioSource aparte, dedicado a la música (con Loop activado)
    public AudioClip musicaNormal;    // de 3:00 a 2:00
    public AudioClip musicaNerviosa;  // de 1:59 a 1:00
    public AudioClip musicaEstresada; // de 0:59 a 0:00

    private float tiempoRestante;
    private int ultimoMinutoMostrado;
    private Vector3 escalaOriginal;
    private bool juegoTerminado = false;
    private RectTransform rectTexto;
    private Vector2 posicionFija;

    void Start()
    {
        tiempoRestante = tiempoTotal;
        escalaOriginal = textoCronometro.transform.localScale;
        ultimoMinutoMostrado = Mathf.CeilToInt(tiempoRestante / 60f);

        rectTexto = textoCronometro.GetComponent<RectTransform>();
        posicionFija = rectTexto.anchoredPosition;

        CambiarMusica(musicaNormal); // arranca sonando la música normal desde el inicio

        ActualizarTexto();
    }

    void Update()
    {
        if (juegoTerminado) return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0f)
        {
            tiempoRestante = 0f;
            ActualizarTexto();
            juegoTerminado = true;
            TerminarJuego();
            return;
        }

        ActualizarTexto();

        // Detectamos si acabamos de cruzar una marca de minuto entero
        int minutoActual = Mathf.CeilToInt(tiempoRestante / 60f);
        if (minutoActual < ultimoMinutoMostrado)
        {
            ultimoMinutoMostrado = minutoActual;
            StartCoroutine(PulsoCronometro());

            // Elegimos el sonido y la música según a qué minuto acabamos de entrar
            AudioClip sonidoAReproducir = null;
            if (minutoActual == 2)
            {
                sonidoAReproducir = sonidoNervioso;   // entrando a 1:59
                CambiarMusica(musicaNerviosa);
            }
            else if (minutoActual == 1)
            {
                sonidoAReproducir = sonidoEstresado; // entrando a 0:59
                CambiarMusica(musicaEstresada);
            }

            if (audioSource != null && sonidoAReproducir != null)
            {
                audioSource.PlayOneShot(sonidoAReproducir);
            }
        }
    }

    void ActualizarTexto()
    {
        int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
        textoCronometro.text = string.Format("{0}:{1:00}", minutos, segundos);
    }

    void LateUpdate()
    {
        // Se ejecuta DESPUÉS de todo lo demás (incluido el zoom de la cámara),
        // así garantizamos que quede clavado en su lugar pase lo que pase.
        rectTexto.anchoredPosition = posicionFija;
    }

    // Coroutine: agranda el texto de golpe y lo vuelve a achicar a su tamaño normal
    IEnumerator PulsoCronometro()
    {
        float mitad = duracionPulso / 2f;
        float t = 0f;

        // Fase 1: agrandar
        while (t < mitad)
        {
            t += Time.deltaTime;
            textoCronometro.transform.localScale = Vector3.Lerp(escalaOriginal, escalaOriginal * escalaPulso, t / mitad);
            yield return null;
        }

        t = 0f;
        // Fase 2: volver al tamaño normal
        while (t < mitad)
        {
            t += Time.deltaTime;
            textoCronometro.transform.localScale = Vector3.Lerp(escalaOriginal * escalaPulso, escalaOriginal, t / mitad);
            yield return null;
        }

        textoCronometro.transform.localScale = escalaOriginal;
    }

    // Corta la música actual y arranca el nuevo clip en loop.
    // Si ya está sonando ese mismo clip, no hace nada (evita reiniciarlo de golpe).
    void CambiarMusica(AudioClip nuevoClip)
    {
        if (audioSourceMusica == null || nuevoClip == null) return;
        if (audioSourceMusica.clip == nuevoClip) return;

        audioSourceMusica.clip = nuevoClip;
        audioSourceMusica.loop = true;
        audioSourceMusica.Play();
    }

    void TerminarJuego()
    {
        Debug.Log("¡Se acabó el tiempo!");
        // Acá Franco engancha lo que pase al terminarse el tiempo:
        // mostrar puntaje, pantalla de resultado, etc.
    }
}