using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationScript : MonoBehaviour
{
    [Header("Show In Inspector")]

    GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "UpwardExplore")
        {

        }
        else if (collision.gameObject.name == "DownwardExplore")
        {

        }
        else if (collision.gameObject.name == "LeftExplore")
        {

        }
        else if (collision.gameObject.name == "RightExplore")
        {

        }
    }
}
