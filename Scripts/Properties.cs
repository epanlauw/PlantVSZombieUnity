using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    public int life, price, timeRecharge;

    AudioClip sound;

    void Start()
    {
        sound = Resources.Load("Audios/Plant", typeof(AudioClip)) as AudioClip;
    }

    void Update()
    {
        CheckDeath();
        CheckMouse();
    }

    void CheckDeath()
    {
        if (life <= 0)
            Destroy(gameObject);
    }

    void CheckMouse()
    {
        if (GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            OnMouseDown();
    }

    void OnMouseDown()
    {
        if(GameManager.shovelEnabled && Input.GetMouseButton(0))
        {
            GameManager.shovelEnabled = false;
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
            Destroy(gameObject);
        }    
    }
}
