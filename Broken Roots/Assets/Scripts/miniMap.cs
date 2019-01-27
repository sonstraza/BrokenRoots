using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMap : MonoBehaviour
{
    bool miniMapOn = false;
    GameObject miniMapCam;
    // Start is called before the first frame update
    void Start()
    {
        miniMapCam = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            miniMapOn = !miniMapOn;

            if (!miniMapOn)
            {
                Debug.Log("Open MiniMap");
                miniMapCam.SetActive(true);
            }
            else
            {
                Debug.Log("Close MiniMap");
                miniMapCam.SetActive(false);
            }
        }
    }
}
