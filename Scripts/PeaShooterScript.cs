using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooterScript : MonoBehaviour
{
    public GameObject prefabPea;

    float distance;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0, 2);
        distance = 6.09f - transform.position.x;   
    }

    void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, distance, LayerMask.GetMask("Zombies"));
        if (hit.collider != null)
            Instantiate(prefabPea, transform.position, Quaternion.identity);
    }
}
