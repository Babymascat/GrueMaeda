using UnityEngine;

public class CableController : MonoBehaviour
{
    public Transform moufleHaut;
    public Transform moufleBas;
    public Transform cable;
    public float scaleFactor = 4.0f;

    private Vector3 initialCableScale;
    private Vector3 initialCablePosition;
    private float initialDistance;

    private Vector3 previousCableScale;

    void Start()
    {
        initialCablePosition = cable.position;
        initialCableScale = cable.localScale;
        previousCableScale = initialCableScale;

        initialDistance = Vector3.Distance(moufleHaut.position, moufleBas.position);
    }

    void Update()
    {
        Vector3 positionHaut = moufleHaut.position;
        Vector3 positionBas = moufleBas.position;

        float currentDistance = Vector3.Distance(positionHaut, positionBas);

        Vector3 newCableScale = new Vector3(
            initialCableScale.x,
            initialCableScale.y,
            initialCableScale.z + (currentDistance - initialDistance) * scaleFactor
        );

        UpdateCableScaleAndPosition(newCableScale);
    }

    void UpdateCableScaleAndPosition(Vector3 newCableScale)
    {
        if (Mathf.Abs(newCableScale.z - previousCableScale.z) > 0.0001f)
        {
            cable.localScale = newCableScale;

            Vector3 positionCable = cable.position;

            float deltaScale = newCableScale.z - previousCableScale.z;
            float yOffset = deltaScale * 0.05f; // Ajuste en fonction de la différence d'échelle

            // Limite le yOffset à des valeurs raisonnables pour éviter des mouvements brusques
            yOffset = Mathf.Clamp(yOffset, -1.2f, 1.2f);

            // Applique le changement de position en fonction de l'échelle
            cable.position = new Vector3(
                positionCable.x,
                positionCable.y + yOffset,
                positionCable.z
            );

            previousCableScale = newCableScale;
        }
    }
}