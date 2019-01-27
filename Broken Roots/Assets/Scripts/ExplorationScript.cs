﻿using System.Collections;
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
        //OnDrawGizmos();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "UpwardExplore")
        {
            //add at 1 tile away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 0, 0, currentTileTrans.transform.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.z + 100));
            //add 2 tiles away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 0, 0, currentTileTrans.transform.position.z + 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.z + 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.z + 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.z + 200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.z + 200));
            Debug.Log("UpwardExplore collided, Current Tile Pos: " + currentTileTrans.transform.position);
        }
        else if (collision.gameObject.name == "DownwardExplore")
        {
            //add at 1 tile away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 0, 0, currentTileTrans.transform.position.z + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.z + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.z + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.z + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.z + -100));
            //add 2 tiles away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 0, 0, currentTileTrans.transform.position.z + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.z + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.z + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.z + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.z + -200));
            Debug.Log("DownExplore collided, Current Tile Pos: " + currentTileTrans.transform.position);
        }
        else if (collision.gameObject.name == "LeftExplore")
        {
            //add at 1 tile away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.z + 0));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.z + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.z + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -100, 0, currentTileTrans.transform.position.z + 200));
            //add 2 tiles away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.z + 0));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.z + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.z + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + -200, 0, currentTileTrans.transform.position.z + 200));
            Debug.Log("LeftExplore collided, Current Tile Pos: " + currentTileTrans.transform.position);
        }
        else if (collision.gameObject.name == "RightExplore")
        {
            //add at 1 tile away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 0, 0, currentTileTrans.transform.position.z + 0));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.z + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.z + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 100, 0, currentTileTrans.transform.position.z + 200));

            //add at 2 tile away
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 0, 0, currentTileTrans.transform.position.z + 0));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.z + -100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.z + -200));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.z + 100));
            tryToMakeTile(fogObject, new Vector3(currentTileTrans.transform.position.x + 200, 0, currentTileTrans.transform.position.z + 200));
            Debug.Log("RightExplore collided, Current Tile Pos: " + currentTileTrans.transform.position);
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
        //if (!(Physics.CheckSphere(newTileLocation, 10)))
        {
            GameObject newTileInstance = GameObject.Instantiate(tileToSpawn, newTileLocation, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(currentTileTrans.position, 10);
    }

    void MakeEnvironmentTile(GameObject tileToSpawn, Vector3 newTileLocation)
    {
        Vector3 offset = new Vector3(0, -10, 0);
        GameObject newTileInstance = GameObject.Instantiate(tileToSpawn, newTileLocation + offset, Quaternion.identity);
        StartCoroutine(MoveOverSeconds(gameObject, newTileLocation, 5f));

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
        objectToMove.transform.position = end;
    }
}
