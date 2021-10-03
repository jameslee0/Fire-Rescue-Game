using UnityEngine;

public class Crash : MonoBehaviour
{
    private const string Name = "Fire Obstacle";
    public VehicleData vd;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit Detected");
        if (other.CompareTag("Fire"))
        {
            vd.health -= 10;
            FindObjectOfType<AudioController>().Play(Name);
        }
        
    }
}
