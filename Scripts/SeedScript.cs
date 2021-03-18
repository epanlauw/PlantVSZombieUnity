using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedScript : MonoBehaviour
{
    public GameObject prefabPlant;
    public AudioSource[] sounds;

    bool canPlant = true;
    GameObject prefabSprite;

    void OnMouseDown()
    {
        var spr = Resources.Load("Prefabs/Sprite", typeof(GameObject)) as GameObject;
        if(canPlant && !GameManager.shovelEnabled && GameManager.currentPlant == null 
            & GameManager.cash >= prefabPlant.GetComponent<Properties>().price)
        {
            sounds[0].Play();
            prefabSprite = Instantiate(spr, transform.position, Quaternion.identity) as GameObject;
            GameManager.currentSeed = gameObject;
            GameManager.currentPlant = prefabPlant;
        }
        else if (!canPlant || GameManager.cash < prefabPlant.GetComponent<Properties>().price)
        {
            sounds[1].Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!canPlant || GameManager.cash < prefabPlant.GetComponent<Properties>().price)
            GetComponent<SpriteRenderer>().material.color = Color.gray;
        else
            GetComponent<SpriteRenderer>().material.color = Color.white;
    }

    public void StartRecharge()
    {
        canPlant = false;
        Destroy(prefabSprite);
        GameManager.currentSeed = null;
        StartCoroutine("WaitTime");
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(prefabPlant.GetComponent<Properties>().timeRecharge);
        canPlant = true;
    }
}
