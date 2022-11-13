using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class HealthBar : MonoBehaviour
{
    float elapsedTime;
    public Image healthBar;
    public GameObject GameOverText;
    public bool gameOver=false;


    void Update()
    {
        elapsedTime += Time.deltaTime;
        healthBar.fillAmount = (healthBar.fillAmount - Time.deltaTime*0.01f);
        if (healthBar.fillAmount==0)
        {
            GameOverText.SetActive(true);
            gameOver = true;
            StartCoroutine(MainMenu());
        }
    }

    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
