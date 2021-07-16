using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    public GameObject repIcon;
    public GameObject canvas;
    GameObject rep;
    public Vector2 spawnValues;
    public float startWait;
    double accuracyValue = 0.0f;
    double percentage = 0.0f;
    double maxValue = 1.0f;
    static int countThumbs = 0;
    bool alreadyExecuted = false;

    void Start()
    {
        if(alreadyExecuted == true)
        {
            StartCoroutine(SpawnRep());
        }
        else
        {
            Update();         
            StartCoroutine(SpawnRep());
        }
    }

    void Update()
    {
        accuracyValue = Convert.ToDouble(TextComparison.accuracycount);
        Debug.Log("accuracy = " + accuracyValue);

        maxValue = Convert.ToDouble(TextComparison.maxLength);
        Debug.Log("Max value = " + maxValue);

        percentage = Convert.ToDouble((accuracyValue / maxValue) * 100);
        Debug.Log("% = " + percentage);

        if (percentage >= 0 && percentage <= 20)
        {
            countThumbs = 1;
        }
        else if (percentage > 20 && percentage <= 40)
        {
            countThumbs = 2;
        }
        else if (percentage > 40 && percentage <= 60)
        {
            countThumbs = 3;
        }
        else if (percentage > 60 && percentage <= 80)
        {
            countThumbs = 4;
        }
        else if (percentage > 80 && percentage <= 100)
        {
            countThumbs = 5;
        }

        Debug.Log("Countthumbs " + countThumbs);

        alreadyExecuted = true;
    }
 
    IEnumerator SpawnRep()
    {
        while(alreadyExecuted)
        {
            yield return new WaitForSeconds(startWait);
            for (int i = 0; i < countThumbs; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValues.x, spawnValues.y);
                Quaternion spawnRotation = Quaternion.identity;
                rep = Instantiate(repIcon, spawnPosition, spawnRotation) as GameObject;
                spawnValues.x += 50.0f;

                rep.transform.SetParent(canvas.transform);

                yield return new WaitForSeconds(startWait);
            }    
 
        }
        alreadyExecuted = false;
    }
}



