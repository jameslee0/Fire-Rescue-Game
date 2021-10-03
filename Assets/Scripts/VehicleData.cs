using UnityEngine.UI;
using UnityEngine;

public class VehicleData : MonoBehaviour
{
    public Animator occupied;
    public Text hp, pl, sc;
    public float health = 100f;
    public float civilScore;
    private float bonusScore;
    public float peopleLeft;
    public bool full = false;
    public GameObject win, lose;
    public GameObject bronze, silver, gold;

    private void Start()
    {
        win.SetActive(false);
        lose.SetActive(false);
        bronze.SetActive(false);
        silver.SetActive(false);
        gold.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        hp.text = health.ToString();
        pl.text = peopleLeft.ToString();
        sc.text = civilScore.ToString();

        if (full == true)
        {
            occupied.SetBool("Vacant", true);
        }
        else
        {
            occupied.SetBool("Vacant", false);
        }

        if (health == 0f)
        {
            lose.SetActive(true);
            Text f = GameObject.FindGameObjectWithTag("FailText").GetComponent<Text>();
            f.text = "Emergencies are no excuse for bad driving! Sheesh!";
            Time.timeScale = 0f;
        }

        if (peopleLeft == 0)
        {
            Time.timeScale = 0f;
            win.SetActive(true);
            Text t = GameObject.FindGameObjectWithTag("TScore").GetComponent<Text>();
            t.text = (civilScore + bonusScore).ToString();


        }

        if (peopleLeft == 4)
        {
            bronze.SetActive(true);
        }

        if (peopleLeft == 3)
        {
            silver.SetActive(true);
        }

        if (peopleLeft == 1)
        {
            gold.SetActive(true);
        }
    }
}
