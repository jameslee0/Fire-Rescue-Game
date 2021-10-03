using UnityEngine;

public class PickUpCitizens : MonoBehaviour
{
    public VehicleData vd;
    private bool questPickedUp = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Citizen") && vd.full == false)
        {
            // Destroy coin object and update counter variable
            Debug.Log("Collision with Player");
            Destroy(other.gameObject);
            vd.civilScore += 10;
            vd.full = true;
            FindObjectOfType<AudioController>().Play("car door");
        }

        if (other.gameObject.CompareTag("Quest"))
        {
            vd.civilScore += 15;
            questPickedUp = true;
            Destroy(other.gameObject);
            FindObjectOfType<AudioController>().Play("car door");
        }

        if (other.gameObject.CompareTag("Safe") && vd.full == true)
        {
            vd.full = false;
            vd.civilScore += 15;
            vd.peopleLeft -= 1;
            FindObjectOfType<AudioController>().Play("car horn");

            if (questPickedUp)
            {
                vd.civilScore += 25;
                questPickedUp = false;
            }

        }
    }
}
