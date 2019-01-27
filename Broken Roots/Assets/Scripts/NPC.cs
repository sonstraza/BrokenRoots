using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Transform[] motionPathTargets;
    private DialogueElement dialogueElement;
    private bool canMove = true;
    private int currentPosition;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        dialogueElement = GetComponent<DialogueElement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != motionPathTargets[currentPosition].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, motionPathTargets[currentPosition].position, speed);

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            canMove = false;

        }
    }
}
