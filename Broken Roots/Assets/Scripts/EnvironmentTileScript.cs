using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentTileScript : MonoBehaviour
{
    public float progressionItemChance = 50f;
    public float npcSpawnChance = 50f;
    public GameObject spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
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
        int npcElement = rand.Next(0, ExploreGameManager.npcArray.Length - 1);
        GameObject choice = ExploreGameManager.npcArray[npcElement];
        return choice;
    }
}
