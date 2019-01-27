using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class townMaker : MonoBehaviour
{
    public const int townSize = 6;
    public GameObject[] NPCTile = new GameObject[townSize];
    public List<GameObject> npcsInTown;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject npc in npcsInTown)
        {
            if(npc.name == "Botanist_GRP")
            {
                //NPCTile[0]
            }
            if(npc.name == "Doctor_GRP")
            {
                //NPCTile[1]
            }
            if(npc.name == "Farmer_GRP")
            {
                //NPCTile[2]
            }
            if(npc.name == "Merchant_GRP")
            {
                //NPCTile[3]
            }
        }
        //Implement home and exit tile stuff
        //NPCTile[4] Add HomeTile stuff
        //NPCTile[5] Add ExitTile stuff
    }
}
