using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassInstantiate : MonoBehaviour
{
    public GameObject prefabsGrass;

    GameObject grass;

    float currentX = -4.82f;
    float currentY = 2.38f;
    float distanceX;
    float distanceY;

    bool newLine = true;
    // Start is called before the first frame update
    void Start()
    {
        distanceX = prefabsGrass.GetComponent<SpriteRenderer>().bounds.size.x;
        distanceY = prefabsGrass.GetComponent<SpriteRenderer>().bounds.size.y;

        for(int i = 0; i < 45; i++)
        {
            if(i % 9 == 0 && i != 0)
            {
                newLine = true;
                currentY = grass.transform.position.y - distanceY;
            }
            if (newLine)
            {
                newLine = false;
                grass = Instantiate(prefabsGrass, new Vector2(-4.82f, currentY), Quaternion.identity) as GameObject;
            }
            else
            {
                grass = Instantiate(prefabsGrass, new Vector2(currentX, currentY), Quaternion.identity) as GameObject;
            }

            currentX = grass.transform.position.x + distanceX;
            grass.transform.SetParent(transform);
        }
    }
}
