using UnityEngine.UI;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    public Text time;
    private float total;
    public float minute;
    public float second;
    public GameObject lose;

    private void Start()
    {
        while (second >= 60)
        {
            minute++;
            second -= 60;
        }

        total = (minute * 60) + second;
    }

    void Update()
    {
        total -= Time.deltaTime;
        minute = (int)total / 60;
        second = (int)total % 60;

        time.text = String.Format("{0:0}:{1:00}", minute, second);

        if (total <= 0)
        {
            Time.timeScale = 0f;
            lose.SetActive(true);
            Text f = GameObject.FindGameObjectWithTag("FailText").GetComponent<Text>();
            f.text = "Oof. Couldn't save them all, could you?";
        }

    }
}
