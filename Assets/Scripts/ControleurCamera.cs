using UnityEngine;
using UnityEngine.InputSystem;

public class ControleurCamera : MonoBehaviour
{
    [SerializeField]
    private float vitesse;

    [SerializeField]
    private float vitesseRotation;

    private Vector2 deplacement;

    private float rotation;

    private void Deplacer(InputAction.CallbackContext contexte)
    {
        deplacement = contexte.action.ReadValue<Vector2>();
    }

    private void Rotater(InputAction.CallbackContext contexte)
    {
        rotation = contexte.action.ReadValue<float>();
    }
}
