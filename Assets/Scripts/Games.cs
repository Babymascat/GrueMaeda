using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Games : MonoBehaviour
{

    //Référence au joueur
    public GameObject player;

    //Référence aux deux display
    public GameObject display1;
    public GameObject display2;

    //Référence au différents boutons
    public GameObject button1;
    public GameObject button2;

    //Référence aux différents boutons
    public GameObject button3;
    public GameObject button5;

    public GameObject CommandeGrue;

    public GameObject CameraDessus;
    public GameObject CameraStockage;

    private int buttonDisplay1;


    private MouvementPersonnage MouvementPersonnage; // Le script de mouvement du personnage


    // Start is called before the first frame update
    void Start()
    {

        MouvementPersonnage = player.GetComponent<MouvementPersonnage>();

        buttonDisplay1 = 1;

        //On active le display1
        display1.SetActive(true);

        //On cache la display2
        display2.SetActive(false);

        //On cache les boutons 2, 4 et 5
        button2.SetActive(false);
        button3.SetActive(false);
        button5.SetActive(false);

        CommandeGrue.SetActive(false);
        CameraDessus.SetActive(false);
        CameraStockage.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

        if (MouvementPersonnage.enabled == true)
        {
            display1.SetActive(true);
            display2.SetActive(false);
            CommandeGrue.SetActive(false);
            CameraDessus.SetActive(false);
            CameraStockage.SetActive(false);
            //Si le joueur appuie sur entrée passe au bouton suivant
            if (Input.GetKeyDown(KeyCode.Return))
            {
                buttonDisplay1++;
            }

            switch (buttonDisplay1)
            {
                case 1:
                    button1.SetActive(true);
                    button2.SetActive(false);
                    button3.SetActive(false);
                    button5.SetActive(false);
                    break;
                case 2:
                    button1.SetActive(false);
                    button2.SetActive(true);
                    button3.SetActive(false);
                    button5.SetActive(false);
                    break;
            }
        }
        else
        {
            display1.SetActive(false);
            display2.SetActive(true);
            CommandeGrue.SetActive(true);
            CameraDessus.SetActive(true);
            CameraStockage.SetActive(true);
            button1.SetActive(false);
            button2.SetActive(false);


        }




    }
}
