using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlowerScript : MonoBehaviour
{
    public GameObject prefabSun;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateSun", 5, 20);
    }

    // Update is called once per frame
    void InstantiateSun()
    {
        var temp = Instantiate(prefabSun, transform.position, Quaternion.identity) as GameObject;
        temp.GetComponent<SunScript>().newInstance = true;
    }
}
