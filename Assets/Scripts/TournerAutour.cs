using UnityEngine;

/// <summary>
/// Classe pour gérer la rotation des astres
/// </summary>
public class TournerAutour : MonoBehaviour
{
    /// <summary>
    /// On fait le tour de quel objet?
    /// </summary>
    public GameObject cible;
    /// <summary>
    /// Combien de jour on passe par seconde
    /// </summary>
    public ControleurTemps controleurTemps;
    /// <summary>
    /// Variable pour les calculs
    /// </summary>
    [SerializeField]
    private float revolution;
    private float vitesse;

    /// <summary>
    /// Fonction pour gérer la vitesse des révolutions.
    /// TRÈS IMPORTANT -> Si on n'a pas ça et qu'on change le Ratio, rien ne sera mis à jour.
    /// TRÈS IMPORTANT (2) -> J'ai retiré mon Awake, donc c'est le seul moyen d'enclencher le mouvement.
    /// </summary>
    void Update()
    {
        mettreAJourRevolution();
        transform.RotateAround(cible.transform.position, Vector3.up, vitesse * Time.deltaTime);
    }

    /// <summary>
    /// Fonction pour convertir en degré une représention de N rotation sur 365 jours
    /// </summary>
    private void mettreAJourRevolution()
    {
        int annee = 365;
        float ratioTemps = controleurTemps.RatioTemps;

        vitesse = ((annee * ratioTemps) * 360) / revolution;
    }
}
