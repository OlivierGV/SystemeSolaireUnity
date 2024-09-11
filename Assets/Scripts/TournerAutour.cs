using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using System.Runtime.CompilerServices;
using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TournerAutour : MonoBehaviour
{
    /* Code inspir� du site web : https://docs.unity3d.com/ScriptReference/Transform.RotateAround.html */

    // � assigner dans l'inspecteur
    public GameObject cible;
    // Appeler le controleur
    public ControleurTemps controleurTemps;
    // Vitesse de l'objet (1 seconde = 1.0 ann�e)
    [SerializeField]
    private float revolution;
    private float vitesse;

    private void Awake()
    {
        mettreAJourRevolution();
    }
    // Pour chaque frame
    void Update()
    {
        /* Exemple d'utilisation
         * transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime); 
         * Vector3.up == Vector3(0,1,0) ET 20 * Time.deltaTime == 20 degr�s par seconde.
         */
        mettreAJourRevolution();
        transform.RotateAround(cible.transform.position, Vector3.up, vitesse * Time.deltaTime);
    }

    private void mettreAJourRevolution()
    {
        // variable pour la lecture
        int annee = 365;
        float ratioTemps = controleurTemps.RatioTemps;

        // conversion pour savoir combien de degr� repr�sente N sur 365 jours
        vitesse = ((annee * ratioTemps) * 360) / revolution;
    }
}
