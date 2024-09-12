using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Contrôleur de la caméra
/// </summary>
public class ControleurCamera : MonoBehaviour
{
    /// <summary>
    /// Variable pour gérer la vitesse de déplacement WASD
    /// </summary>
    [SerializeField]
    private float vitesse;
    /// <summary>
    /// Variable pour gérer la vitesse d'inclinaison
    /// </summary>
    [SerializeField]
    private float vitesseRotation;
    /// <summary>
    /// Variable pour le déplacement
    /// </summary>
    private Vector2 deplacement;
    /// <summary>
    /// Variable pour la rotation
    /// </summary>
    private float rotation;

    /// <summary>
    /// Fonction pour associer un vecteur à la variable déplacement (emprunté depuis Le Destructeur)
    /// </summary>
    /// <param name="contexte"></param>
    public void Deplacer(InputAction.CallbackContext contexte)
    {
        deplacement = contexte.action.ReadValue<Vector2>();
    }

    /// <summary>
    /// Fonction pour associer un float à la variable de rotation (emprunté depuis Le Destructeur)
    /// </summary>
    /// <param name="contexte">L'événement</param>
    public void Rotater(InputAction.CallbackContext contexte)
    {
        rotation = contexte.action.ReadValue<float>();
        Debug.Log("Rotate");
    }

    /// <summary>
    /// Fonction pour zoomer à l'appuie, puis dézoomer lors de l'annulation
    /// </summary>
    /// <param name="contexte">L'événement</param>
    public void Zoomer(InputAction.CallbackContext contexte)
    {
        if (contexte.performed)
        {
            transform.position += transform.forward * 20;
            Debug.Log("Zoomer");
        }
        if (contexte.canceled)
        {
            transform.position -= transform.forward * 20;
            Debug.Log("Dézoomer");
        }
    }

    /// <summary>
    /// Fonction pour dézoomer à l'appuie, puis zoomer lors de l'annulation
    /// </summary>
    /// <param name="contexte">L'événement</param>
    public void Dezoomer(InputAction.CallbackContext contexte)
    {
        if (contexte.performed)
        {
            transform.position -= transform.forward * 20;
            Debug.Log("Zoomer");
        }
        if (contexte.canceled)
        {
            transform.position += transform.forward * 20;
            Debug.Log("Dézoomer");
        }
    }

    /// <summary>
    /// Ce code est utile pour mettre à jour les mouvements (emprunté depuis Le Destructeur)
    /// </summary>
    private void FixedUpdate()
    {
        // Déplacement dans le plan XZ
        Vector3 deplacementEffectif = (deplacement.y * transform.forward + deplacement.x * transform.right).normalized;
        transform.position += deplacementEffectif * vitesse * Time.deltaTime;

        // Rotation autour de l'axe des Y
        transform.Rotate(Vector3.left, rotation * vitesseRotation * Time.deltaTime);
    }
}
