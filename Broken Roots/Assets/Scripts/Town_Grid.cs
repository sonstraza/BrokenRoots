using UnityEngine;
using System.Collections;

public class Town_Grid : MonoBehaviour
{
    public int divisions;//must be odd
    public GameObject GridItem;
    public GameObject[] NPCPrefabList;

    void Start()
    {
        Vector3 size = GridItem.GetComponent<Renderer>().bounds.size;
        Transform Center = GridItem.gameObject.transform;
        Vector3 botLeftCorner = Vector3.zero;
        botLeftCorner.x = Center.position.x - size.x/2;
        botLeftCorner.z = Center.position.z - size.z/2;

        botLeftCorner.x += size.x / (divisions * 2);
        botLeftCorner.z += size.z / (divisions * 2);

        for(int z = 0; z < divisions; z++)
        {
            for(int x = 0; x < divisions; x++)
            {
                if (botLeftCorner != Center.position)
                    Instantiate(NPCPrefabList, botLeftCorner, Quaternion.identity);

                botLeftCorner.x += size.x / (divisions);
            }
            botLeftCorner.x = Center.position.x - size.x / 2;
            botLeftCorner.x += size.x / (divisions * 2);

            botLeftCorner.z += size.z / (divisions);
        }
    }
}