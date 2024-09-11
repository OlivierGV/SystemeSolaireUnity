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

    public void Deplacer(InputAction.CallbackContext contexte)
    {
        deplacement = contexte.action.ReadValue<Vector2>();
        Debug.Log("Move");
    }

    public void Rotater(InputAction.CallbackContext contexte)
    {
        rotation = contexte.action.ReadValue<float>();
        Debug.Log("Rotate");
    }

    private void FixedUpdate()
    {
        // Déplacement dans le plan XZ
        Vector3 deplacementEffectif = (deplacement.y * transform.forward + deplacement.x * transform.right).normalized;
        transform.position += deplacementEffectif * vitesse * Time.deltaTime;

        // Rotation autour de l'axe des Y
        transform.Rotate(Vector3.left, rotation * vitesseRotation * Time.deltaTime);
    }
}
