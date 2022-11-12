using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CranberryInstantiator : MonoBehaviour
{
    float elapsedTime;
    public GameObject CranberryPrefab;
    public List<Transform> instantiatingPoints = new List<Transform>();
    // Start is called before the first frame update
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
            Debug.Log("Instantiated");
        }
    }

    //IEnumerator LoadCranberry()
    //{
    //    yield return new WaitForSeconds(3f);
    //    for (int i = 0; i < transform.childCount; i++)
    //    {
    //        {
    //            GameObject cranberry = Instantiate(CranberryPrefab, instantiatingPoints[i]);
    //        }
    //    }
    //}
}
