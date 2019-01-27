using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationScript : MonoBehaviour
{
    [Header("Show In Inspector")]

    GameObject playerObject;
    GameObject randomPrefabChoice;
    GameObject gameManager;
    Transform currentTileTrans;
    public GameObject fogObject;
    // Start is called before the first frame update
    void Start()
    {
        currentTileTrans = ExploreGameManager.currentTile;
        playerObject = GameObject.Find("Player");
        gameManager = GameObject.Find("ExplorationGameState");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "UpwardExplore")
        {
            //add at 1 tile away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 0, 0, currentTileTrans.transform.position.x + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.x + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.x + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.x + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.x + 100));
            //add 2 tiles away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 0, 0, currentTileTrans.transform.position.x + 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.x + 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.x + 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.x + 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.x + 200));
            Debug.Log("UpwardExplore collided, Current Tile Pos: " + currentTileTrans.transform.position);
        }
        else if (collision.gameObject.name == "DownwardExplore")
        {
            //add at 1 tile away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 0, 0, currentTileTrans.transform.position.x + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.x + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.x + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.x + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.x + -100));
            //add 2 tiles away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 0, 0, currentTileTrans.transform.position.x + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.x + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.x + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.x + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.x + -200));
            Debug.Log("DownExplore collided, Current Tile Pos: " + currentTileTrans.transform.position);
        }
        else if (collision.gameObject.name == "LeftExplore")
        {
            //add at 1 tile away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.x + 0));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.x + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.x + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.x + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.x + 200));
            //add 2 tiles away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.x + 0));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.x + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.x + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.x + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.x + 200));
            Debug.Log("LeftExplore collided, Current Tile Pos: " + currentTileTrans.transform.position);
        }
        else if (collision.gameObject.name == "RightExplore")
        {
            //add at 1 tile away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 0, 0, currentTileTrans.transform.position.x + 0));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.x + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.x + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.x + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.x + 200));

            //add at 2 tile away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 0, 0, currentTileTrans.transform.position.x + 0));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.x + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.x + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.x + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.x + 200));
            Debug.Log("RightExplore collided, Current Tile Pos: " + currentTileTrans.transform.position);
        }
    }

    void tryToMakeTile(GameObject tileToSpawn, Vector3 newTileLocation)
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawSphere(newTileLocation, 5);
        if (!(Physics.CheckSphere(newTileLocation, 10)))
        {
            GameObject newTileInstance = GameObject.Instantiate(tileToSpawn, newTileLocation, Quaternion.identity);
        }
    }
}
