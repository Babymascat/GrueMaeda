using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Définition des états de rotation.
// Fixe = pas de mouvement, Positif = rotation dans un sens, Negatif = rotation dans l'autre sens.
public enum EtatRotation { Fixe = 0, Positif = 1, Negatif = -1 };

public class RotationControleur : MonoBehaviour
{
    // Etat initial de l'articulation (fixe par défaut, sans mouvement)
    public EtatRotation rotationState = EtatRotation.Fixe;

    // Vitesse de rotation. Public pour qu'elle soit modifiable dans l'inspecteur Unity.
    public float speed = 0.01f;

    // Composant ArticulationBody qui permet de manipuler l'articulation (physique de la grue)
    private ArticulationBody articulation;

    // Variable pour gérer l'inertie (accélération et décélération progressives)
    private float currentVelocity = 0f;

    // Appelée au démarrage. Ici on récupère le composant ArticulationBody de l'objet attaché à ce script.
    void Start()
    {
        articulation = GetComponent<ArticulationBody>();
    }

    // FixedUpdate est utilisée pour les mises à jour liées à la physique (appelée à intervalle régulier, synchronisé avec le moteur physique)
    void FixedUpdate()
    {
        // Si l'état de rotation n'est pas fixe (donc Positif ou Negatif), on effectue la rotation
        if (rotationState != EtatRotation.Fixe)
        {
            // Calcul du changement de rotation en fonction de l'état actuel (positif ou négatif), la vitesse et le deltaTime (temps écoulé)
            float rotationChange = (float)rotationState * speed * Time.fixedDeltaTime;

            // On récupère la rotation actuelle et on ajoute le changement de rotation pour définir la nouvelle cible
            float rotationGoal = CurrentPrimaryAxisRotation() + rotationChange;

            // On appelle la fonction pour tourner vers la nouvelle cible
            RotateTo(rotationGoal);
        }
    }

    // Cette fonction récupère la rotation actuelle de l'axe principal de l'articulation (en degrés)
    float CurrentPrimaryAxisRotation()
    {
        // L'angle actuel de l'articulation est donné en radians, donc on le convertit en degrés.
        float currentRotationRads = articulation.jointPosition[0]; // jointPosition[0] contient la rotation de l'axe principal
        float currentRotation = Mathf.Rad2Deg * currentRotationRads; // Conversion de radians à degrés
        return currentRotation; // Retourne la valeur de la rotation en degrés
    }

    // Fonction pour faire tourner l'articulation jusqu'à une cible donnée (rotation en degrés)
    void RotateTo(float primaryAxisRotation)
    {
        // Récupère le XDrive de l'articulation (paramètre de contrôle de l'articulation en termes de position/rotation)
        var drive = articulation.xDrive;

        // Utilisation de Mathf.SmoothDamp pour garantir une transition douce entre la rotation actuelle et la rotation cible.
        // La variable currentVelocity permet de ralentir la descente naturellement avec une inertie.
        float smoothedTarget = Mathf.SmoothDamp(drive.target, primaryAxisRotation, ref currentVelocity, 0.5f);

        // Applique la cible adoucie à l'articulation
        drive.target = smoothedTarget;

        // Applique le nouveau XDrive avec la cible mise à jour
        articulation.xDrive = drive;
    }
}