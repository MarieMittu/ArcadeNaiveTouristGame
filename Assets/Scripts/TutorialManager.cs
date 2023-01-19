using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    //public GameObject spawner;
    public float waitTime = 3f;

    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (waitTime <= 0)
            {
                popUpIndex++;
                waitTime += 3f;
            } else
            {
                waitTime -= Time.deltaTime;
            }
        } else if (popUpIndex == 1)
        {
            if (waitTime <= 0)
            {
                popUpIndex++;
                waitTime += 3f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpIndex == 2)
        {
            if (waitTime <= 0)
            {
                popUpIndex++;
                waitTime += 3f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpIndex == 3)
        {
            if (waitTime <= 0)
            {
                popUpIndex++;
                waitTime += 3f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        } else if (popUpIndex == 4)
        {
            Destroy(gameObject, waitTime);
        }
    }
}
