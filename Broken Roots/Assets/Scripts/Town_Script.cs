using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town_Script : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float spawnRadius = 10.0f;
    public float distanceFromEach = 2;

    // Start is called before the first frame update
    void Start()
    {
        int numObj = objectsToSpawn.Length;
        //make places for all possible NPC's to go
        //foreach found npc, place them into thier respective slots
        //requires that the gameobjects being spawned are tagged as "NPC"
        for (int i = 0; i < numObj; i++)
        {
            Vector3 spawnPosition = getSpawnPos(i);
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

    Vector3 getSpawnPos (int objNum)
    {
        Collider[] neighbors;
        Vector3 spawnPosition;
        do
        {
            Vector2 spawnPositionV2 = Random.insideUnitCircle * spawnRadius;

            spawnPosition = new Vector3(spawnPositionV2.x, 0.0f, spawnPositionV2.y);

            neighbors = Physics.OverlapSphere(spawnPosition, distanceFromEach, 1<<8);

        } while (neighbors.Length > 0);
        return spawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
