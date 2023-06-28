using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public int speed;
    int destroyTime = 10;
    float liveT = 0;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        liveT += Time.deltaTime;
        if ( liveT >= destroyTime )
        {
            Destroy(gameObject);
        }
    }
}
