using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Contr�leur de la cam�ra
/// </summary>
public class ControleurCamera : MonoBehaviour
{
    /// <summary>
    /// Variable pour g�rer la vitesse de d�placement WASD
    /// </summary>
    [SerializeField]
    private float vitesse;
    /// <summary>
    /// Variable pour g�rer la vitesse d'inclinaison
    /// </summary>
    [SerializeField]
    private float vitesseRotation;
    /// <summary>
    /// Variable pour le d�placement
    /// </summary>
    private Vector2 deplacement;
    /// <summary>
    /// Variable pour la rotation
    /// </summary>
    private float rotation;

    /// <summary>
    /// Fonction pour associer un vecteur � la variable d�placement (emprunt� depuis Le Destructeur)
    /// </summary>
    /// <param name="contexte"></param>
    public void Deplacer(InputAction.CallbackContext contexte)
    {
        deplacement = contexte.action.ReadValue<Vector2>();
    }

    /// <summary>
    /// Fonction pour associer un float � la variable de rotation (emprunt� depuis Le Destructeur)
    /// </summary>
    /// <param name="contexte">L'�v�nement</param>
    public void Rotater(InputAction.CallbackContext contexte)
    {
        rotation = contexte.action.ReadValue<float>();
        Debug.Log("Rotate");
    }

    /// <summary>
    /// Fonction pour zoomer � l'appuie, puis d�zoomer lors de l'annulation
    /// </summary>
    /// <param name="contexte">L'�v�nement</param>
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
            Debug.Log("D�zoomer");
        }
    }

    /// <summary>
    /// Fonction pour d�zoomer � l'appuie, puis zoomer lors de l'annulation
    /// </summary>
    /// <param name="contexte">L'�v�nement</param>
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
            Debug.Log("D�zoomer");
        }
    }

    /// <summary>
    /// Ce code est utile pour mettre � jour les mouvements (emprunt� depuis Le Destructeur)
    /// </summary>
    private void FixedUpdate()
    {
        // D�placement dans le plan XZ
        Vector3 deplacementEffectif = (deplacement.y * transform.forward + deplacement.x * transform.right).normalized;
        transform.position += deplacementEffectif * vitesse * Time.deltaTime;

        // Rotation autour de l'axe des Y
        transform.Rotate(Vector3.left, rotation * vitesseRotation * Time.deltaTime);
    }
}
