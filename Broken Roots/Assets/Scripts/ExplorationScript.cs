using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationScript : MonoBehaviour
{
    [Header("Show In Inspector")]

    GameObject playerObject;
    GameObject randomPrefabChoice;
    GameObject gameManager;
    public GameObject fogObject;
    // Start is called before the first frame update
    void Start()
    {
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
            tryToMakeTile(fogObject, new Vector3(0, 0, 200));
            tryToMakeTile(fogObject, new Vector3(-100, 0, 200));
            tryToMakeTile(fogObject, new Vector3(-200, 0, 200));
            tryToMakeTile(fogObject, new Vector3(100, 0, 200));
            tryToMakeTile(fogObject, new Vector3(200, 0, 200));
            Debug.Log("UpwardExplore collided");
        }
        else if (collision.gameObject.name == "DownwardExplore")
        {
            tryToMakeTile(fogObject, new Vector3(0, 0, -200));
            tryToMakeTile(fogObject, new Vector3(-100, 0, -200));
            tryToMakeTile(fogObject, new Vector3(-200, 0, -200));
            tryToMakeTile(fogObject, new Vector3(100, 0, -200));
            tryToMakeTile(fogObject, new Vector3(200, 0, -200));
            Debug.Log("DownExplore collided");
        }
        else if (collision.gameObject.name == "LeftExplore")
        {
            tryToMakeTile(fogObject, new Vector3(-200, 0, 0));
            tryToMakeTile(fogObject, new Vector3(-200, 0, -100));
            tryToMakeTile(fogObject, new Vector3(-200, 0, -200));
            tryToMakeTile(fogObject, new Vector3(-200, 0, 100));
            tryToMakeTile(fogObject, new Vector3(-200, 0, 200));
            Debug.Log("LeftExplore collided");
        }
        else if (collision.gameObject.name == "RightExplore")
        {
            tryToMakeTile(fogObject, new Vector3(200, 0, 0));
            tryToMakeTile(fogObject, new Vector3(200, 0, -100));
            tryToMakeTile(fogObject, new Vector3(200, 0, -200));
            tryToMakeTile(fogObject, new Vector3(200, 0, 100));
            tryToMakeTile(fogObject, new Vector3(200, 0, 200));
            Debug.Log("RightExplore collided");
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
