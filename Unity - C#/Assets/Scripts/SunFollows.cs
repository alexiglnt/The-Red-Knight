using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFollows : MonoBehaviour
{
    public Transform target; // On d�fini une variable publique pour la cible de la cam�ra
    public float smoothing = 5f; // On d�fini une variable publique avec un d�faut pour le smoothing que l'on veut appliquer � la cam�a
    Vector3 offset; // Propri�t� qui va contenir la diff�rence � maintenir entre la position du personnage ainsi que la position de la cam�ra
                    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position; // Calcul de l'offset � garder entre le personnage et la cam�ra
    }
    void FixedUpdate()
    {
        // Fixed Update au lieu de Update pour avoir une interval r�gulier, au lieu de chaque frame
        Vector3 targetCamPosition = target.position + offset; // on d�fini la position o� la cam�ra doit se trouver
        transform.position = Vector3.Lerp(transform.position, targetCamPosition, smoothing * Time.deltaTime); // met � jour la position de la cam�ra
                                                                                                              
    }
}
