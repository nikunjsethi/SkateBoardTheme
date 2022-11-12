using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceDetection : MonoBehaviour
{
    private GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        Parent = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Surface"))
        {
            StartCoroutine(ResetPosition());
        }
    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(2f);
        Parent.transform.rotation = Quaternion.Euler(0, -90, 0);
    }
}
