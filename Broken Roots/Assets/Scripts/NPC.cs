using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string[] keyItems;
    public Transform[] LeftRight;
    public Transform[] TopBottom;
    public Transform[] Circle;
    public float speed;
    public float moveCoolDown;

    public enum Motion { LeftRight, TopBottom, Circle };
    public Motion motion;

    private Transform[] motionPathTargets;
    
    private DialogueElement dialogueElement;
    private bool canMove = true;
    
    private int currentPosition = 0;
    private float reachDistance = .1f;
    
    private float canMoveCounter;
    // Start is called before the first frame update
    void Start()
    {
        canMoveCounter = moveCoolDown;
        dialogueElement = GetComponent<DialogueElement>();
        if(motion == Motion.LeftRight)
        {
            motionPathTargets = LeftRight;
        }
        else if(motion == Motion.TopBottom)
        {
            motionPathTargets = TopBottom;
        }
        else if(motion == Motion.Circle)
        {
            motionPathTargets = Circle;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            float dist = Vector3.Distance(transform.position, motionPathTargets[currentPosition].position);
            transform.position = Vector3.MoveTowards(transform.position, motionPathTargets[currentPosition].position, Time.deltaTime * speed);

            if (dist <= reachDistance)
            {
                currentPosition++;
                canMove = false;
            }
            if (currentPosition >= motionPathTargets.Length)
            {
                currentPosition = 0;
            }
        }
        else
        {
            canMoveCounter -= Time.deltaTime;

            if(canMoveCounter < 0)
            {
                canMove = true;
                canMoveCounter = moveCoolDown;
            }
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canMove = false;
        }
    }
}
