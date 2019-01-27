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

    ExploreGameManager _exploreGameManager;
    GameObject[] enviroArr;
    public GameObject fogObject;


    // Start is called before the first frame update
    void Start()
    {
        _exploreGameManager = GameObject.Find("ExplorationGameState").GetComponent<ExploreGameManager>();
        enviroArr = _exploreGameManager.ExplorationTileArray;
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
        if (collision.gameObject.name == "UpwardExplore")
        {
            currentTileTrans = collision.transform.parent.parent;
            //add at 1 tile away
            MakeEnvironmentTile(choiceOfEnviroTile(), new Vector3(currentTileTrans.position.x, 0, currentTileTrans.position.z + 100));
            //tryToMakeTile(choiceOfEnviroTile(), new Vector3(currentTileTrans.position.x, 0, currentTileTrans.position.z + 100));
            Debug.Log("Make Enviro1");
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x - 100, 0, currentTileTrans.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x - 200, 0, currentTileTrans.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 100, 0, currentTileTrans.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 200, 0, currentTileTrans.position.z + 100));
            //add 2 tiles away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 0, 0, currentTileTrans.position.z + 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x - 100, 0, currentTileTrans.position.z + 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x - 200, 0, currentTileTrans.position.z + 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 100, 0, currentTileTrans.position.z + 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 200, 0, currentTileTrans.position.z + 200));
            //Debug.Log("UpwardExplore collided, Current Tile Pos: " + currentTileTrans.position);
        }
        else if (collision.gameObject.name == "DownwardExplore")
        {
            currentTileTrans = collision.transform.parent.parent;
            //add at 1 tile away
            MakeEnvironmentTile(choiceOfEnviroTile(), new Vector3(currentTileTrans.position.x, 0, currentTileTrans.position.z - 100));
            //tryToMakeTile(choiceOfEnviroTile(), new Vector3(currentTileTrans.position.x, 0, currentTileTrans.position.z - 100));
            Debug.Log("Make Enviro2");
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x - 100, 0, currentTileTrans.position.z - 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x - 200, 0, currentTileTrans.position.z - 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 100, 0, currentTileTrans.position.z - 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 200, 0, currentTileTrans.position.z - 100));
            //add 2 tiles away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 0, 0, currentTileTrans.position.z - 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x - 100, 0, currentTileTrans.position.z - 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x - 200, 0, currentTileTrans.position.z - 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 100, 0, currentTileTrans.position.z - 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 200, 0, currentTileTrans.position.z - 200));
            //Debug.Log("DownExplore collided, Current Tile Pos: " + currentTileTrans.position);
        }
        else if (collision.gameObject.name == "LeftExplore")
        {
            currentTileTrans = collision.transform.parent.parent;
            //add at 1 tile away
            MakeEnvironmentTile(choiceOfEnviroTile(), new Vector3(currentTileTrans.position.x - 100, 0, currentTileTrans.position.z));
            //tryToMakeTile(choiceOfEnviroTile(), new Vector3(currentTileTrans.position.x - 100, 0, currentTileTrans.position.z));
            Debug.Log("Make Enviro3");
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x -  100, 0, currentTileTrans.position.z - 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x -  100, 0, currentTileTrans.position.z - 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x -  100, 0, currentTileTrans.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x -  100, 0, currentTileTrans.position.z + 200));
            //add 2 tiles away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x -  200, 0, currentTileTrans.position.z));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x -  200, 0, currentTileTrans.position.z - 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x -  200, 0, currentTileTrans.position.z - 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x -  200, 0, currentTileTrans.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x -  200, 0, currentTileTrans.position.z + 200));
            //Debug.Log("LeftExplore collided, Current Tile Pos: " + currentTileTrans.position);
        }
        else if (collision.gameObject.name == "RightExplore")
        {
            currentTileTrans = collision.transform.parent.parent;
            
            //add at 1 tile away
            MakeEnvironmentTile(choiceOfEnviroTile(), new Vector3(currentTileTrans.position.x + 100, 0, currentTileTrans.position.z));
            //tryToMakeTile(choiceOfEnviroTile(), new Vector3(currentTileTrans.position.x + 100, 0, currentTileTrans.position.z + 0));
            Debug.Log("Make Enviro4");
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 100, 0, currentTileTrans.position.z - 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 100, 0, currentTileTrans.position.z - 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 100, 0, currentTileTrans.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 100, 0, currentTileTrans.position.z + 200));

            //add at 2 tile away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 200, 0, currentTileTrans.position.z + 0));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 200, 0, currentTileTrans.position.z - 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 200, 0, currentTileTrans.position.z - 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 200, 0, currentTileTrans.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.position.x + 200, 0, currentTileTrans.position.z + 200));
            //Debug.Log("RightExplore collided, Current Tile Pos: " + currentTileTrans.position);
        }
    }

    /// <summary>
    /// Takes in a the fog tile GameObject and sets it to the input vector3.
    /// 
    /// When called has an offset
    /// </summary>
    /// <param name="tileToSpawn"></param>
    /// <param name="newTileLocation"></param>
    void tryToMakeTile(GameObject tileToSpawn, Vector3 newTileLocation)
    {
        if (!(Physics.CheckSphere(newTileLocation, 10)))
        {
            GameObject newTileInstance = GameObject.Instantiate(tileToSpawn, newTileLocation, Quaternion.identity);
        }
    }

    void MakeEnvironmentTile(GameObject tileToSpawn, Vector3 newTileLocation)
    {
        Vector3 offset = new Vector3(0, -20, 0);
        GameObject newTileInstance = GameObject.Instantiate(tileToSpawn, newTileLocation, Quaternion.identity);
        //StartCoroutine(MoveOverSeconds(gameObject, newTileLocation, 0.5f));
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        //objectToMove.transform.position = end;
    }

    GameObject choiceOfEnviroTile()
    {
        System.Random rand = new System.Random();
        int enviroElement = rand.Next(0, enviroArr.Length - 1);
        GameObject choice = enviroArr[enviroElement];
        return choice;
    }
}
