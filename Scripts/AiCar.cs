using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using TMPro;

public class AiCar : MonoBehaviour
{
    public PathCreator Path;
    float speed = 2;
    float realspeed;
    public GameObject car1, car2,greenLite,RedLite,limit20,limit40,limit60;
    float distanceCar1, distanceCar2;
    public TMP_Text speedText, timeText, distanceText,subtitalText;
    float time, DistanceAiCar;
    int returnValue;
    void Start()
    {
        speedText.text = "SPEED :10km/h";
    }

    void Update()
    {
        int nearestSpeedTower= NearestSpeedLimit();
        switch (nearestSpeedTower)
        {
            case 20:
                speed = 5;
                subtitalText.text = "Ooo.. Speed Limit Is 20..";
                speedText.text = "SPEED :20km/h";
                break;
            case 40:
                speed = 6;
                subtitalText.text = "Ooo.. Speed Limit Is 40..";
                speedText.text = "SPEED :40km/h";
                break;
            case 60:
                speed = 8;
                subtitalText.text = "Ooo.. Speed Limit Is 60..";
                speedText.text = "SPEED :60km/h";
                break;

        }
        distanceCar1 = Vector3.Distance(car1.transform.position, transform.position);
        distanceCar2 = Vector3.Distance(car2.transform.position, transform.position);


        if(distanceCar1<100f || distanceCar2 < 100f)
        {
            greenLite.SetActive(false);
            RedLite.SetActive(true);
            subtitalText.text = "Hey Man...Hurry Up....";
            speedText.text = "SPEED :00km/h";
        }
        else
        {
            greenLite.SetActive(true);
            RedLite.SetActive(false);
            realspeed += speed * Time.deltaTime;
            transform.position = Path.path.GetPointAtDistance(realspeed);
            transform.rotation = Path.path.GetRotationAtDistance(realspeed);
            DistanceAiCar += 0.01f;
            
        }


        time += Time.deltaTime;
        DisplayTime(time);
        Distance();
    }

    void DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timeText.text = "TIME :"+string.Format("{0:00}:{1:00}", minutes, seconds);

       
    }

    void Distance()
    {
        int x = (int)DistanceAiCar;
        distanceText.text = "DISTANCE :" + x + "Km";
    }

    int NearestSpeedLimit()
    {

        
        float limit20distance = Vector3.Distance(limit20.transform.position, transform.position);
        float limit40distance = Vector3.Distance(limit40.transform.position, transform.position);
        float limit60distance = Vector3.Distance(limit60.transform.position, transform.position);

        if (limit20distance < 100f)
        {
            returnValue = 20;
         
        }
        if (limit40distance < 100f)
        {
            returnValue = 40;
            
        }
        if (limit60distance < 100f)
        {
            returnValue = 60;
         
        }


        
        return returnValue;
    }
}
