using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreGameManager : MonoBehaviour
{
    [Header("Show in Inspector")]
    public static ExploreGameManager instance = null;
    public static Transform currentTile;
    public GameObject miniMapCam;

    [Header("Arrays for random spawning")]
    //public GameObject[] FogTileArray;
    public GameObject[] ExplorationTileArray;
    public GameObject[] npcArray;
    public static List<string> npcFound;
    public static GameObject[] keyItemArray;

    //[Header("Assigned Scripts")]
    //public SetCurrentTile _setCurrentTile;

    //Awake for singleton creation
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        currentTile = GameObject.Find("StartTile").transform;
        npcFound = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
