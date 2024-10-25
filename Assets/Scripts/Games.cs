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

    private int button;

    //Personnage en dehors de la grue
    private bool playerBool = true;



    // Start is called before the first frame update
    void Start()
    {
        button = 1;

        //On active le display1
        display1.SetActive(true);

        //On cache la display2
        display2.SetActive(false);

        //On cache les boutons 2, 3, 4 et 5
        button2.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

        if (playerBool == true)
        {
            display1.SetActive(true);
            display2.SetActive(false);
        }
        else
        {
            display1.SetActive(false);
            display2.SetActive(true);
        }

        //Si le joueur appuie sur entrée passe au bouton suivant
        if (Input.GetKeyDown(KeyCode.Return))
        {
            button++;
        }

        switch (button)
        {
            case 1:
                button1.SetActive(true);
                button2.SetActive(false);
                break;
            case 2:
                button1.SetActive(false);
                button2.SetActive(true);
                break;
        }


    }
}
