using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Pour Text

public class AffichageStock : MonoBehaviour
{
    public Text stockText; // Pour Text classique

    void Start()
    {
        // Optionnel : Initialisez le texte avec 0 si le script Declencheur n'est pas encore en place
        UpdateStockDisplay(0);
    }

    // Méthode pour mettre à jour l'affichage du stock
    public void UpdateStockDisplay(int stocks)
    {
        stockText.text = "Stocks : " + stocks; // Mettre à jour le texte
    }
}