using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public float life, vel;

    bool canWalk, canEat;
    Rigidbody2D rb;
    Animator anim;
    AudioSource sound;
    SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        canEat = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlant();
        CheckDeath();
    }

    void FixedUpdate()
    {
        rb.velocity = canWalk ? new Vector2(-vel * Time.deltaTime, 0) : Vector2.zero;
    }

    void CheckDeath()
    {
        if (life <= 0)
            Destroy(gameObject);
    }

    void CheckPlant()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, 0.3f, LayerMask.GetMask("Plants"));

        if (hit.collider != null)
        {
            anim.SetBool("isEating", true);
            canWalk = false;
            if (canEat)
                StartCoroutine(Eating(hit.collider));
            if (!sound.isPlaying)
                sound.Play();
        }
        else
        {
            sound.Stop();
            StopCoroutine("Eating");
            canWalk = canEat = true;
            anim.SetBool("isEating", false);
        }
    }

    IEnumerator Eating(Collider2D col)
    {
        canEat = false;
        yield return new WaitForSeconds(2);
        canEat = true;
        if (col != null)
            col.gameObject.GetComponent<Properties>().life--;
    }

    public void WalkSlow()
    {
        StopCoroutine("WalkFast");
        sp.material.color = Color.cyan;
        vel = 1;
        StartCoroutine("WalkFast");
    }

    IEnumerator WalkFast()
    {
        yield return new WaitForSeconds(10);
        sp.material.color = Color.white;
        vel = 6;
    }
}
