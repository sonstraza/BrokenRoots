using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform[] LeftRight;
    public Transform[] TopBottom;
    public Transform[] Circle;

    public enum Motion { LeftRight, TopBottom, Circle };
    public Motion motion;

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
        if((transform.position != motionPathTargets[currentPosition].position) && canMove)
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
