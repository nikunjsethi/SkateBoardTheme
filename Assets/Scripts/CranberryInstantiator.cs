using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class CranberryInstantiator : MonoBehaviour
{
    float elapsedTime;
    public GameObject CranberryPrefab;
    public List<Transform> instantiatingPoints = new List<Transform>();

    void Start()
    {

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            instantiatingPoints.Add(gameObject.transform.GetChild(i));
            Debug.Log(i);
        }

    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime>5)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (instantiatingPoints[i].childCount == 0)
                {
                    {
                        GameObject cranberry = Instantiate(CranberryPrefab, instantiatingPoints[i]);
                    }
                }
            }
            elapsedTime = 0;
        }
    }
}
