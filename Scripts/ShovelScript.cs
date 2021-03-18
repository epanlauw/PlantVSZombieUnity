using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelScript : MonoBehaviour
{
    public AudioSource sound;
    void OnMouseDown()
    {
        if(GameManager.currentPlant == null && !GameManager.shovelEnabled)
        {
            GameManager.shovelEnabled = true;
            sound.Play();
            Instantiate(Resources.Load("Prefabs/Sprite", typeof(GameObject)) as GameObject,
                        transform.position,Quaternion.identity);
        }
    }
}
