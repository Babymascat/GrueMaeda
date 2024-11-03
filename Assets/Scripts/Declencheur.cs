using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Declencheur : MonoBehaviour
{
    public int stocks = 0; // Déclaration de la variable stocks
    public AffichageStock affichageStock; // Référence à votre script d'affichage

    void Start()
    {
        // Affichage initial
        Debug.Log("Stocks : " + stocks);
        if (affichageStock != null)
        {
            affichageStock.UpdateStockDisplay(stocks); // Mise à jour de l'affichage au démarrage
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Élément ajouté");
        stocks++;
        Debug.Log("Stocks : " + stocks);

        // Mettre à jour l'affichage
        if (affichageStock != null)
        {
            affichageStock.UpdateStockDisplay(stocks);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Élément enlevé");
        stocks--;
        Debug.Log("Stocks : " + stocks);

        // Mettre à jour l'affichage
        if (affichageStock != null)
        {
            affichageStock.UpdateStockDisplay(stocks);
        }
    }
}