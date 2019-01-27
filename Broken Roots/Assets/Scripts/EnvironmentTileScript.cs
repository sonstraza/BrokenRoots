using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentTileScript : MonoBehaviour
{
    public float progressionItemChance = 50f;
    public float npcSpawnChance = 50f;
    public GameObject spawnLocation;

    ExploreGameManager _exploreGameManager;
    GameObject[] npcArr;

    // Start is called before the first frame update
    void Start()
    {
        _exploreGameManager = GameObject.Find("ExplorationGameState").GetComponent<ExploreGameManager>();
        npcArr = _exploreGameManager.npcArray;


        System.Random number = new System.Random();
        int spawnResult = number.Next(1, 100);
        if(spawnResult >= progressionItemChance)
        {
            int choiceResult = number.Next(0, 100);
            if(choiceResult >= npcSpawnChance)
            {
                GameObject.Instantiate(choiceOfNPC(), spawnLocation.transform);
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
        GameObject choice = npcArr[npcElement];
        return choice;
    }
}
