using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentTileScript : MonoBehaviour
{
    public float progressionItemChance = 50f;
    public float npcSpawnChance = 9999f;
    public GameObject spawnLocation;
    public bool hasNPCSpawned = false;

    ExploreGameManager _exploreGameManager;
    GameObject[] npcArr;

    // Start is called before the first frame update
    void Start()
    {
        _exploreGameManager = GameObject.Find("ExplorationGameState").GetComponent<ExploreGameManager>();
        npcArr = _exploreGameManager.npcArray;


        System.Random number = new System.Random();
        int spawnResult = number.Next(1, 100);
        if(spawnResult >= progressionItemChance && !hasNPCSpawned)
        {
            int choiceResult = number.Next(0, 10000);
            if(choiceResult >= npcSpawnChance)
            {
                //GameObject.Instantiate(choiceOfNPC(), spawnLocation.transform);

                Vector3 spawnOffset = new Vector3(0, 2f, 0);
                GameObject choice = choiceOfNPC();
                if(choice != null)
                {
                    GameObject newNPC = Instantiate(choice, spawnLocation.transform.position + spawnOffset, Quaternion.identity);
                    newNPC.transform.localScale = new Vector3(3, 3, 3);
                }
                
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject choiceOfNPC()
    {
        System.Random rand = new System.Random();
        int npcElement = rand.Next(0, npcArr.Length - 1);
        if(Data.npcsInTown.Contains(npcArr[npcElement].name) || ExploreGameManager.npcFound.Contains(npcArr[npcElement].name))
        {
            return null;
        }
        else
        {
            ExploreGameManager.npcFound.Add(npcArr[npcElement].name);
        }
        GameObject choice = npcArr[npcElement];
        return choice;
    }
}
