using UnityEngine;

public class GrueControl : MonoBehaviour
{
    // Référence au articulationBody de la grue
    public ArticulationBody articulationBodyMoufleBas; // Référence à l'ArticulationBody du MoufleBas
    public ArticulationBody articulationBodyChariot3; // Référence à l'ArticulationBody du Chariot3
    public ArticulationBody articulationBodyChariot2; // Référence à l'ArticulationBody du Chariot4
    public ArticulationBody articulationBodyChariot1; // Référence à l'ArticulationBody du Chariot1
    public ArticulationBody articulationBodyFleche; // Référence à l'ArticulationBody de la fleche
    public ArticulationBody articulationBodyMat; // Référence à l'ArticulationBody du mat

    // Référence au support de pied de la grue
    public GameObject support_arr_dr1; // Référence au support de pied arrière droit 1
    public GameObject support_arr_dr2; // Référence au support de pied arrière droit 2
    public GameObject support_arr_dr3; // Référence au support de pied arrière droit 3
    public GameObject support_arr_ga1; // Référence au support de pied arrière gauche 1
    public GameObject support_arr_ga2; // Référence au support de pied arrière gauche 2
    public GameObject support_arr_ga3; // Référence au support de pied arrière gauche 3
    public GameObject support_av_dr1; // Référence au support de pied avant droit 1
    public GameObject support_av_dr2; // Référence au support de pied avant droit 2
    public GameObject support_av_dr3; // Référence au support de pied avant droit 3
    public GameObject support_av_ga1; // Référence au support de pied avant gauche 1
    public GameObject support_av_ga2; // Référence au support de pied avant gauche 2
    public GameObject support_av_ga3; // Référence au support de pied avant gauche 3

    // Tableau des ArticulationBody des supports de pied
    private ArticulationBody[] supportArticulations;

    // Variable pour vérifier si les supports de pied sont verrouillés
    private bool supportsLocked = false;

    // Référence au RigidBody de roue
    public Rigidbody roueRigidbody;





    void Start()
    {

        // Initialisation des articulations des supports de pied (on présume qu'ils ont des ArticulationBody attachés)
        supportArticulations = new ArticulationBody[]
        {
            support_arr_dr1.GetComponent<ArticulationBody>(),
            support_arr_dr2.GetComponent<ArticulationBody>(),
            support_arr_dr3.GetComponent<ArticulationBody>(),
            support_arr_ga1.GetComponent<ArticulationBody>(),
            support_arr_ga2.GetComponent<ArticulationBody>(),
            support_arr_ga3.GetComponent<ArticulationBody>(),
            support_av_dr1.GetComponent<ArticulationBody>(),
            support_av_dr2.GetComponent<ArticulationBody>(),
            support_av_dr3.GetComponent<ArticulationBody>(),
            support_av_ga1.GetComponent<ArticulationBody>(),
            support_av_ga2.GetComponent<ArticulationBody>(),
            support_av_ga3.GetComponent<ArticulationBody>()
        };

        // Vérifie si l'ArticulationBody a bien été assignée
        if (articulationBodyMoufleBas != null)
        {
            // Configure le XDrive de l'ArticulationBody
            ArticulationDrive xDrive = articulationBodyMoufleBas.xDrive;

            // Mettre le lower limit du XDrive à 0 ou à -5 selon la condition
            xDrive.lowerLimit = 0; // Remplacez par -5 si vous le souhaitez

            articulationBodyMoufleBas.xDrive = xDrive; // Applique les modifications
        }
        if (articulationBodyChariot3 != null)
        {
            // Configure le XDrive de l'ArticulationBody
            ArticulationDrive xDrive = articulationBodyChariot3.xDrive;

            // Mettre le lower limit du XDrive à 0 ou à -5 selon la condition
            xDrive.upperLimit = 0; // Remplacez par -5 si vous le souhaitez

            articulationBodyChariot3.xDrive = xDrive; // Applique les modifications
        }
        if (articulationBodyChariot2 != null)
        {
            // Configure le XDrive de l'ArticulationBody
            ArticulationDrive xDrive = articulationBodyChariot2.xDrive;

            // Mettre le lower limit du XDrive à 0 ou à -5 selon la condition
            xDrive.upperLimit = 0; // Remplacez par -5 si vous le souhaitez

            articulationBodyChariot2.xDrive = xDrive; // Applique les modifications
        }
        if (articulationBodyChariot1 != null)
        {
            // Configure le XDrive de l'ArticulationBody
            ArticulationDrive xDrive = articulationBodyChariot1.xDrive;

            // Mettre le lower limit du XDrive à 0 ou à -5 selon la condition
            xDrive.upperLimit = 0; // Remplacez par -5 si vous le souhaitez

            articulationBodyChariot1.xDrive = xDrive; // Applique les modifications
        }
        if (articulationBodyFleche != null)
        {
            // Configure le XDrive de l'ArticulationBody
            ArticulationDrive xDrive = articulationBodyFleche.xDrive;

            // Mettre le lower limit du XDrive à 0 ou à -5 selon la condition
            xDrive.upperLimit = 0; // Remplacez par -5 si vous le souhaitez

            articulationBodyFleche.xDrive = xDrive; // Applique les modifications
        }
        if (articulationBodyMat != null)
        {
            // Configure le XDrive de l'ArticulationBody
            ArticulationDrive xDrive = articulationBodyMat.xDrive;

            xDrive.stiffness = 0.00f;
            xDrive.damping = 3.402823e+38f;

            articulationBodyMat.xDrive = xDrive; // Applique les modifications
        }


    }


    void Update()
    {
        // Vérifier si la grue bouge (moufle bas)
        ArticulationDrive xDrive1 = articulationBodyMoufleBas.xDrive;
        // Si le mouvement est limité par le lowerLimit de l'ArticulationBody du MoufleBas
        if (xDrive1.target < 0.1f)
        {
            LockSupports();
        }
        else
        {
            UnlockSupports();
        }
        /* if (xDrive1.lowerLimit == 0)
        {
            LockSupports();
        }
        else
        {
            UnlockSupports();
        } */


        // Vérifier si la grue bouge (chariot3)
        ArticulationDrive xDrive2 = articulationBodyChariot3.xDrive;
        // Si le mouvement est limité par le lowerLimit de l'ArticulationBody du Chariot3
        if (xDrive2.target > 0.1f)
        {
            LockSupports();
        }
        else
        {
            UnlockSupports();
        }
        /* if (xDrive2.upperLimit == 0)
        {
            UnlockSupports();
        }
        else
        {
            LockSupports();
        } */


        // Vérifier si la grue bouge (fleche)
        ArticulationDrive xDrive3 = articulationBodyFleche.xDrive;
        // Si le mouvement est limité par le lowerLimit de l'ArticulationBody de la Fleche
        if (xDrive3.target > 6f)
        {
            LockSupports();
        }
        else
        {
            UnlockSupports();
        }
        /*  if (xDrive3.upperLimit == 0)
         {
             UnlockSupports();
         }
         else
         {
             LockSupports();
         } */


        // Vérifier si la grue bouge (mat)
        ArticulationDrive xDrive4 = articulationBodyMat.xDrive;
        // Si le mouvement est limité par le lowerLimit de l'ArticulationBody du Mat
        if (xDrive4.target > 1.0f || xDrive4.target < -1.0f)
        {
            LockSupports();
        }
        else
        {
            UnlockSupports();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si le crochet touche le terrain
        if (collision.gameObject.CompareTag("Terrain"))
        {
            UnlockGrue();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Lorsque le crochet ne touche plus le terrain, libère les contraintes
        if (collision.gameObject.CompareTag("Terrain"))
        {
            LockGrue();
        }
    }

    // Méthode pour verrouiller les supports de pied
    private void LockSupports()
    {
        if (!supportsLocked)
        {
            foreach (var support in supportArticulations)
            {
                if (support != null)
                {

                    ArticulationDrive xDrive = support.xDrive;

                    // Stiffness à 0
                    xDrive.stiffness = 100000f;

                    // Damping à 10e38
                    xDrive.damping = 10f;

                    xDrive.forceLimit = 10000f;

                    // Mettre à jour le XDrive
                    support.xDrive = xDrive;

                    support.useGravity = false; // Désactiver la gravité

                    //support.isKinematic = true; // Activer le mode kinematic

                    support.collisionDetectionMode = CollisionDetectionMode.Continuous; // Activer la détection de collision continue


                }
            }

            // Bloquer le rigidbody des roues
            roueRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

            supportsLocked = true; // Marquer les supports comme verrouillés
        }
    }

    // Méthode pour déverrouiller les supports de pied
    private void UnlockSupports()
    {
        if (supportsLocked)
        {
            foreach (var support in supportArticulations)
            {
                if (support != null)
                {

                    ArticulationDrive xDrive = support.xDrive;

                    // Stiffness à 100000
                    xDrive.stiffness = 100000f;

                    // Damping à 100
                    xDrive.damping = 100f;

                    // Mettre à jour le XDrive
                    support.xDrive = xDrive;

                }

                // Débloquer le rigidbody des roues
                roueRigidbody.constraints = RigidbodyConstraints.None;

                supportsLocked = false; // Marquer les supports comme déverrouillés
            }
        }
    }

    //méthode pour verrouiller la grue
    private void LockGrue()
    {
        // Configure le XDrive de l'ArticulationBodyDuMoufleBas
        ArticulationDrive xDrive1 = articulationBodyMoufleBas.xDrive;
        // Mettre le lower limit du XDrive à 0 ou à -5 selon la condition
        xDrive1.lowerLimit = 0; // Remplacez par -5 si vous le souhaitez
        articulationBodyMoufleBas.xDrive = xDrive1; // Applique les modifications

        // Configure le XDrive de l'ArticulationBodyDesChariots
        ArticulationDrive xDrive2 = articulationBodyChariot3.xDrive;
        ArticulationDrive xDrive3 = articulationBodyChariot2.xDrive;
        ArticulationDrive xDrive4 = articulationBodyChariot1.xDrive;
        // Mettre le lower limit du XDrive à 0 ou à -5 selon la condition
        xDrive2.upperLimit = 0; // Remplacez par -5 si vous le souhaitez
        xDrive3.upperLimit = 0; // Remplacez par -5 si vous le souhaitez
        xDrive4.upperLimit = 0; // Remplacez par -5 si vous le souhaitez
        articulationBodyChariot3.xDrive = xDrive2; // Applique les modifications
        articulationBodyChariot2.xDrive = xDrive3; // Applique les modifications
        articulationBodyChariot1.xDrive = xDrive4; // Applique les modifications

        // Configure le XDrive de l'ArticulationBodyDeLaFleche
        ArticulationDrive xDrive5 = articulationBodyFleche.xDrive;
        // Mettre le lower limit du XDrive à 0 ou à -5 selon la condition
        xDrive5.upperLimit = 0; // Remplacez par -5 si vous le souhaitez
        articulationBodyFleche.xDrive = xDrive5; // Applique les modification

        // Configure le XDrive de l'ArticulationBodyDuMat
        ArticulationDrive xDrive6 = articulationBodyMat.xDrive;
        xDrive6.stiffness = 0.00f;
        xDrive6.damping = 3.402823e+38f;
        articulationBodyMat.xDrive = xDrive6; // Applique les modifications
    }

    //méthode pour déverrouiller la grue
    private void UnlockGrue()
    {
        // Configure le XDrive de l'ArticulationBodyDuMoufleBas
        ArticulationDrive xDrive1 = articulationBodyMoufleBas.xDrive;
        // Mettre le lower limit du XDrive à 0 ou à -5 selon la condition
        xDrive1.lowerLimit = -5; // Remplacez par -5 si vous le souhaitez
        articulationBodyMoufleBas.xDrive = xDrive1; // Applique les modifications

        // Configure le XDrive de l'ArticulationBodyDesChariots
        ArticulationDrive xDrive2 = articulationBodyChariot3.xDrive;
        ArticulationDrive xDrive3 = articulationBodyChariot2.xDrive;
        ArticulationDrive xDrive4 = articulationBodyChariot1.xDrive;
        // Mettre le lower limit du XDrive à 0 ou à -5 selon la condition
        xDrive2.upperLimit = 1.26f; // Remplacez par -5 si vous le souhaitez
        xDrive3.upperLimit = 1.26f; // Remplacez par -5 si vous le souhaitez
        xDrive4.upperLimit = 1.26f; // Remplacez par -5 si vous le souhaitez
        articulationBodyChariot3.xDrive = xDrive2; // Applique les modifications
        articulationBodyChariot2.xDrive = xDrive3; // Applique les modifications
        articulationBodyChariot1.xDrive = xDrive4; // Applique les modifications

        // Configure le XDrive de l'ArticulationBodyDeLaFleche
        ArticulationDrive xDriveResetFleche = articulationBodyFleche.xDrive;
        xDriveResetFleche.target = 0.0f;
        articulationBodyFleche.xDrive = xDriveResetFleche; // Applique les modifications
        ArticulationDrive xDrive5 = articulationBodyFleche.xDrive;
        // Mettre le lower limit du XDrive à 0 ou à -5 selon la condition
        xDrive5.upperLimit = 45; // Remplacez par -5 si vous le souhaitez
        articulationBodyFleche.xDrive = xDrive5; // Applique les modifications

        // Configure le XDrive de l'ArticulationBodyDuMat
        ArticulationDrive xDriveResetMat = articulationBodyMat.xDrive;
        xDriveResetMat.target = 0.0f;
        articulationBodyMat.xDrive = xDriveResetMat; // Applique les modifications
        ArticulationDrive xDrive6 = articulationBodyMat.xDrive;
        xDrive6.stiffness = 100000f;
        xDrive6.damping = 100f;
        articulationBodyMat.xDrive = xDrive6; // Applique les modifications
    }


}
