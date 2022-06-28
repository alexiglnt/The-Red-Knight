using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFollows : MonoBehaviour
{
    public Transform target; // On défini une variable publique pour la cible de la caméra
    public float smoothing = 5f; // On défini une variable publique avec un défaut pour le smoothing que l'on veut appliquer à la caméa
    Vector3 offset; // Propriété qui va contenir la différence à maintenir entre la position du personnage ainsi que la position de la caméra
                    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position; // Calcul de l'offset à garder entre le personnage et la caméra
    }
    void FixedUpdate()
    {
        // Fixed Update au lieu de Update pour avoir une interval régulier, au lieu de chaque frame
        Vector3 targetCamPosition = target.position + offset; // on défini la position où la caméra doit se trouver
        transform.position = Vector3.Lerp(transform.position, targetCamPosition, smoothing * Time.deltaTime); // met à jour la position de la caméra
                                                                                                              
    }
}
