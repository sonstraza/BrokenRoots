using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Town_Grid : MonoBehaviour
{
    public int divisions;//must be odd
    public GameObject GridItem;
    public List<GameObject> AllpossibleTiles;
    static List<GameObject> npcList;//Data.npcsInTown;
    
    void Start()
    {
        npcList = AllpossibleTiles;
        //npcList = Data.NPCNames;//doesn't work...
        Vector3 size = GridItem.GetComponent<Renderer>().bounds.size;
        Transform Center = GridItem.gameObject.transform;
        Vector3 botLeftCorner = Vector3.zero;
        botLeftCorner.x = Center.position.x - size.x/2;
        botLeftCorner.z = Center.position.z - size.z/2;

        botLeftCorner.x += size.x / (divisions * 2);
        botLeftCorner.z += size.z / (divisions * 2);

        int counter = 0;

        for(int z = 0; z < divisions; z++)
        {
            for(int x = 0; x < divisions; x++)
            {
                if (counter >= npcList.Count)
                    break;
                if (botLeftCorner != Center.position)
                {
                    Instantiate(npcList[counter], botLeftCorner, Quaternion.identity);
                    counter++;
                }

                botLeftCorner.x += size.x / (divisions);
            }
            botLeftCorner.x = Center.position.x - size.x / 2;
            botLeftCorner.x += size.x / (divisions * 2);

            botLeftCorner.z += size.z / (divisions);
        }
    }
}