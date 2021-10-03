using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroToMainMenu : MonoBehaviour
{
    public float introLength = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMenu());
    }

    // Waits until the intro finishes playing and then loads the main menu scene
    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(introLength);

        SceneManager.LoadScene(1);
    }
}
