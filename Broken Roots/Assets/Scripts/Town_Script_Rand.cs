using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town_Script_Rand : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float spawnRadius = 10.0f;
    public float distanceApart = 2;
    public int loopCap = 10000;

    // Start is called before the first frame update
    void Start()
    {
        int numObj = objectsToSpawn.Length;
        //make places for all possible NPC's to go
        //foreach found npc, place them into thier respective slots
        //requires that the gameobjects being spawned are tagged as "NPC"
        for (int i = 0; i < numObj; i++)
        {
            Vector3 spawnPosition = getSpawnPos();
            GameObject objectToSpawn = objectsToSpawn[i];

            Vector3 offSetSpawnPos = transform.position + spawnPosition;

            RaycastHit hit;
            if (Physics.Raycast(offSetSpawnPos, Vector3.down, out hit))
            {
                if (hit.collider.tag != "NPC")
                {
                    Vector3 finalSpawnPos = hit.point;

                    Instantiate(objectToSpawn, finalSpawnPos, Quaternion.identity);
                }
            }
        }
    }

    bool IsTooClose(Vector3 pendingPos, GameObject[] neighbors)
    {
        if (neighbors.Length == 0)
        {
            return false;
        }

        bool tooClose = false;

        foreach (var f in neighbors)
        {
            if ((pendingPos - f.transform.position).magnitude < distanceApart)
            {
                tooClose = true;
                break;
            }
        }

        return tooClose;
    }

    Vector3 getSpawnPos()
    {
        Vector2 spawnPositionV2 = Random.insideUnitCircle * spawnRadius;

        Vector3 spawnPosition = new Vector3(spawnPositionV2.x, 0.0f, spawnPositionV2.y);

        GameObject[] neighbors = GameObject.FindGameObjectsWithTag("NPC");
        int limiter = 0;
        while (IsTooClose(spawnPosition, neighbors) && limiter < loopCap)
        {
            spawnPositionV2 = Random.insideUnitCircle * spawnRadius;

            spawnPosition = new Vector3(spawnPositionV2.x, 0.0f, spawnPositionV2.y);
            limiter++;
        }
        if(limiter >= loopCap)
        {
            Debug.Log("Infinite Loop avoided, Either too small radius or too big distance gap");
        }
        
        return spawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
