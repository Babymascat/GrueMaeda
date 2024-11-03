using UnityEngine;
using UnityEngine.UI; // Pour Text ou TextMeshPro si nécessaire

public class GameTimer : MonoBehaviour
{
    public Text timerText; // Pour Text classique
    // public TextMeshProUGUI timerText; // Utilisez cette ligne si vous utilisez TextMeshPro

    private float timeElapsed;
    private bool isRunning;

    void Start()
    {
        timeElapsed = 0f;      // Initialiser le temps à 0
        isRunning = true;      // Démarrer le timer
    }

    void Update()
    {
        if (isRunning)
        {
            // Incrémente le temps écoulé
            timeElapsed += Time.deltaTime;

            // Formatage du temps en minutes et secondes
            int minutes = Mathf.FloorToInt(timeElapsed / 60);
            int seconds = Mathf.FloorToInt(timeElapsed % 60);

            // Afficher le temps dans le format "MM:SS"
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    // Fonction pour arrêter le timer
    public void StopTimer()
    {
        isRunning = false;
    }

    // Fonction pour démarrer ou redémarrer le timer
    public void StartTimer()
    {
        isRunning = true;
        timeElapsed = 0f;
    }
}