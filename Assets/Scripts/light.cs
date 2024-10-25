using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{

    //Référence à la lumière
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    public GameObject light5;
    public GameObject light6;
    public GameObject light7;
    public GameObject light8;
    public GameObject light9;
    public GameObject light10;
    public GameObject light11;
    public GameObject light12;

    // Start is called before the first frame update
    void Start()
    {
        //mettre intensité à 0 des 6 premieres lumieres
        light1.GetComponent<Light>().intensity = 0;
        light2.GetComponent<Light>().intensity = 0;
        light3.GetComponent<Light>().intensity = 0;
        light4.GetComponent<Light>().intensity = 0;
        light5.GetComponent<Light>().intensity = 0;
        light6.GetComponent<Light>().intensity = 0;

        //Eteindre la lumière
        light7.SetActive(false);
        light8.SetActive(false);
        light9.SetActive(false);
        light10.SetActive(false);
        light11.SetActive(false);
        light12.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        //Si la touche "L" est appuyée
        if (Input.GetKeyDown(KeyCode.I))
        {
            //Si la lumière est éteinte
            if (light7.activeSelf == false)
            {
                //mettre intensité à 1 des 6 premieres lumieres
                light1.GetComponent<Light>().intensity = 5;
                light2.GetComponent<Light>().intensity = 5;
                light3.GetComponent<Light>().intensity = 5;
                light4.GetComponent<Light>().intensity = 5;
                light5.GetComponent<Light>().intensity = 5;
                light6.GetComponent<Light>().intensity = 5;

                //Allumer la lumière
                light7.SetActive(true);
                light8.SetActive(true);
                light9.SetActive(true);
                light10.SetActive(true);
                light11.SetActive(true);
                light12.SetActive(true);
            }
            //Si la lumière est allumée
            else
            {
                //mettre intensité à 0 des 6 premieres lumieres
                light1.GetComponent<Light>().intensity = 0;
                light2.GetComponent<Light>().intensity = 0;
                light3.GetComponent<Light>().intensity = 0;
                light4.GetComponent<Light>().intensity = 0;
                light5.GetComponent<Light>().intensity = 0;
                light6.GetComponent<Light>().intensity = 0;

                //Eteindre la lumière
                light7.SetActive(false);
                light8.SetActive(false);
                light9.SetActive(false);
                light10.SetActive(false);
                light11.SetActive(false);
                light12.SetActive(false);
            }
        }

    }
}
