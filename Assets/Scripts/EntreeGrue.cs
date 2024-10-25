using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntreeGrue : MonoBehaviour
{
    public GameObject crane;             // La grue
    public GameObject enterCraneButton;  // Bouton qui s'affiche pour entrer dans la grue
    public GameObject exitCraneButton;   // Bouton qui s'affiche pour sortir de la grue
    public float activationDistance = 1.0f; // Distance pour afficher le bouton
    public GameObject player;            // Le personnage (capsule)

    private Mouvements Mouvements; // Le script de mouvement de la grue
    private MouvementPersonnage MouvementPersonnage; // Le script de mouvement du personnage

    public int booleen; // Variable pour savoir si le personnage est dans la grue ou non


    void Start()
    {
        // On récupère les scripts de mouvement
        Mouvements = crane.GetComponent<Mouvements>();
        MouvementPersonnage = player.GetComponent<MouvementPersonnage>();

        // Désactive le script de mouvement de la grue au début
        Mouvements.enabled = false;

        // Cache le bouton au début
        enterCraneButton.SetActive(false);

        // Le personnage est en dehors de la grue au début mettre booleen à 0
        booleen = 0;

    }

    void Update()
    {
        // Vérifie la distance entre le joueur et la grue
        float distanceToCrane = Vector3.Distance(player.transform.position, crane.transform.position);

        // Si la distance est inférieure à la distance d'activation, on affiche le bouton
        if (distanceToCrane <= activationDistance)
        {
            enterCraneButton.SetActive(true);
            // Si le joueur appuie sur le bouton, on appelle la fonction EnterCrane
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Entrée");
                EnterCrane();
            }

        }
        else
        {
            enterCraneButton.SetActive(false);
        }

        // Si le joueur est dans la grue, on affiche le bouton pour sortir
        if (booleen == 1)
        {
            enterCraneButton.SetActive(false);
            exitCraneButton.SetActive(true);
            // Si le joueur appuie sur le bouton, on appelle la fonction ExitCrane
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Sortie");
                ExitCrane();
            }
        }
        else
        {
            exitCraneButton.SetActive(false);
        }


    }

    // Fonction à appeler lorsqu'on clique sur le bouton
    public void EnterCrane()
    {
        // Désactive le mouvement du personnage et cache la capsule
        MouvementPersonnage.enabled = false;
        player.SetActive(false);

        // Active le mouvement de la grue
        Mouvements.enabled = true;

        // Cache le bouton après avoir entré dans la grue
        enterCraneButton.SetActive(false);

        // Le personnage est dans la grue mettre booleen à 1
        booleen = 1;

        //Fixe la position du personnage à la position de la grue
        player.transform.position = crane.transform.position;
    }

    // Fonction à appeler lorsqu'on clique sur le bouton pour sortir de la grue
    public void ExitCrane()
    {
        // Active le mouvement du personnage et affiche la capsule
        MouvementPersonnage.enabled = true;
        player.SetActive(true);

        // Désactive le mouvement de la grue
        Mouvements.enabled = false;

        // Cache le bouton après être sorti de la grue
        exitCraneButton.SetActive(false);

        // Le personnage est en dehors de la grue mettre booleen à 0
        booleen = 0;

        //Fixe la position du personnage à la position de la grue avec un décalage
        player.transform.position = crane.transform.position + new Vector3(-1, 0, 0);

    }
}

