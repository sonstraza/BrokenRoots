using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTileScript : MonoBehaviour
{
    [Header("Show in Inspector")]
    public GameObject hasBeenCollider;
    public GameObject playerObject;

    private bool destroyThis = false;
    private bool distanceToDestroy = false;

    float destroyDistance = 20;
    public float currentDistanceToPlayer;


    float playerDistanceX;
    float playerDistanceZ;
    float planeLocationX;
    float planeLocationZ;

    // Start is called before the first frame update
    void Start()
    {

        hasBeenCollider = GameObject.Find("hasBeenBoolCheck");
        playerObject = GameObject.Find("Player");
        playerDistanceX = playerObject.transform.position.x;
        playerDistanceZ = playerObject.transform.position.z;
        planeLocationX = this.transform.position.x;
        planeLocationZ = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        playerDistanceX = playerObject.transform.position.x;
        playerDistanceZ = playerObject.transform.position.z;
        planeLocationX = this.transform.position.x;
        planeLocationZ = this.transform.position.z;

        currentDistanceToPlayer = Mathf.Sqrt(Mathf.Abs(playerDistanceX - planeLocationX) 
                                            + Mathf.Abs(playerDistanceZ - planeLocationZ));

        Debug.Log("currentDistanceToPlayer: " + currentDistanceToPlayer);

        if(currentDistanceToPlayer > destroyDistance)
        {
            distanceToDestroy = true;
            Debug.Log("DistanceToDestroy: " + distanceToDestroy);
            if (distanceToDestroy && !destroyThis)
            {
            }

            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collider)
    {
       if(collider.gameObject.name == "hasBeenBoolCheck")
        {
            destroyThis = true;
        }
    }
}
