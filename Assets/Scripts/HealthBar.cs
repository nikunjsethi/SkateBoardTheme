using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    float elapsedTime;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        healthBar.fillAmount = (healthBar.fillAmount - Time.deltaTime*0.01f);
        if (healthBar.fillAmount==0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(0);
        }
    }
}
