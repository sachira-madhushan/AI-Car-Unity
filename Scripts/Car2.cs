using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class Car2 : MonoBehaviour
{

    public PathCreator car2Path;
    public float speed = 50;
    float realspeed;

    void Start()
    {
        
    }

 
    void Update()
    {
        realspeed += speed * Time.deltaTime;
        transform.position = car2Path.path.GetPointAtDistance(realspeed);
    }
}
