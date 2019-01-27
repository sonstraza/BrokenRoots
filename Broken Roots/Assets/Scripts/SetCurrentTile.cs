using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCurrentTile : MonoBehaviour
{
    GameObject currentTileTransform;

    // Start is called before the first frame update
    void Start()
    {
        //currentTileTransform = ExploreGameManager.currentTile;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ExploreGameManager.currentTile = this.transform.parent.parent;
        }
    }
}
