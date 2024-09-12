using UnityEngine;

/// <summary>
/// Classe pour g�rer la rotation des astres
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
    /// Fonction pour g�rer la vitesse des r�volutions.
    /// TR�S IMPORTANT -> Si on n'a pas �a et qu'on change le Ratio, rien ne sera mis � jour.
    /// TR�S IMPORTANT (2) -> J'ai retir� mon Awake, donc c'est le seul moyen d'enclencher le mouvement.
    /// </summary>
    void Update()
    {
        mettreAJourRevolution();
        transform.RotateAround(cible.transform.position, Vector3.up, vitesse * Time.deltaTime);
    }

    /// <summary>
    /// Fonction pour convertir en degr� une repr�sention de N rotation sur 365 jours
    /// </summary>
    private void mettreAJourRevolution()
    {
        int annee = 365;
        float ratioTemps = controleurTemps.RatioTemps;

        vitesse = ((annee * ratioTemps) * 360) / revolution;
    }
}
