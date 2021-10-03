using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    // CITIZEN VARIABLES
    public GameObject citizen;
    public Transform[] spawnLocations;
    public float spawnTimer;
    public float timeBetweenSpawns;
    public int spawnIndex;
    private List<int> usedSpawnIndices = new List<int>();

    // QUEST VARIABLES
    public GameObject quest;
    public Transform[] questSpawnLocations;
    public float questSpawnTimer;
    public float timeBetweenQuestSpawns;
    public int questSpawnIndex;
    private List<int> usedQuestIndices = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        // Set our timer variables for citizens and quests
        timeBetweenSpawns = 20.0f;
        spawnTimer = timeBetweenSpawns;

        timeBetweenQuestSpawns = 65.0f;
        questSpawnTimer = timeBetweenQuestSpawns;

        // Get a random index from our list of spawn locations and spawn a citizen there
        spawnIndex = UnityEngine.Random.Range(0, (spawnLocations.Length - 1));
        usedSpawnIndices.Add(spawnIndex);
        Instantiate(citizen, spawnLocations[spawnIndex].position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // If spawnTimer <= 0, we are ready to spawn a citizen, so spawn one
        if (spawnTimer <= 0)
        {
            // Get a random index from our list of spawn locations
            // If the location has already been used, get a new index
            bool usedIndex = true;

            while (usedIndex)
            {
                spawnIndex = UnityEngine.Random.Range(0, spawnLocations.Length);
                usedIndex = usedSpawnIndices.Contains(spawnIndex);
            }

            // Add index to the list of used indices, reset timer, and spawn in citizen at spawn location
            usedSpawnIndices.Add(spawnIndex);            
            spawnTimer = timeBetweenSpawns;
            Instantiate(citizen, spawnLocations[spawnIndex].position, Quaternion.identity);
        }

        // If questSpawnTimer <= 0, we are ready to spawn a quest, so do so
        if (questSpawnTimer <= 0)
        {
            // Get a random index from our list of quest spawn locations
            // If the location has already been used, get a new index
            bool usedQuestIndex = true;

            while (usedQuestIndex)
            {
                questSpawnIndex = UnityEngine.Random.Range(0, questSpawnLocations.Length);
                usedQuestIndex = usedQuestIndices.Contains(questSpawnIndex);
            }

            // Add index to the list of used spawn indices, reset timer, and spawn quest at spawn location
            usedQuestIndices.Add(questSpawnIndex);
            questSpawnTimer = timeBetweenQuestSpawns;
            Instantiate(quest, questSpawnLocations[questSpawnIndex].position, Quaternion.identity);
        }

        // Update timers for citizens and quests
        spawnTimer -= Time.deltaTime;
        questSpawnTimer -= Time.deltaTime;
    }
}
