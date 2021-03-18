using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public AudioSource sound;

    void OnMouseDown()
    {
        if (GameManager.currentPlant != null || GameManager.shovelEnabled)
        {
            sound.Play();
            GameManager.currentPlant = null;
            GameManager.currentSeed = null;
            GameManager.shovelEnabled = false;
        }   
    }
}
