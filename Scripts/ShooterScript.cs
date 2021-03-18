using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public float vel, damageHit;
    public bool isIce;
    public AudioClip clip;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3.09f);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(vel * Time.deltaTime, 0);   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            if (isIce)
                collision.gameObject.GetComponent<ZombieScript>().WalkSlow();
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
            collision.gameObject.GetComponent<ZombieScript>().life -= damageHit;
            Destroy(gameObject);
        }
    }
}
