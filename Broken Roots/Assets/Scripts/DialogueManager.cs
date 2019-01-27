using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Player player;

    // Talking to NPC's
    private bool canTalkToNPC;
    private bool talkingToNPC;

    private Queue<string> dialogueQueue;
    private string[] dialogueTextArray;
    private DialogueElement dialogueElement;
    private string sentence;
    public Text dialogueBox;
    private readonly float textPlayBackSpeed = .1f;

    private void Start()
    {
        player = GetComponent<Player>();
        dialogueQueue = new Queue<string>();

    }

    // Start the Dialogue and stop the player from moving until dialogue is finished
    private void StartDialogue()
    {
        player.canMove = false;
        dialogueQueue.Clear();
        dialogueBox.text = "";
        dialogueBox.enabled = true;

        // If Intro
        dialogueTextArray = dialogueElement.IntroText;
        // If KeyItem1 for Farmer || Doctor || Botonist has beenObtained
        //dialogueTextArray = dialogueElement.KeyItem1Text;
        
        // If General Text
        //dialogueTextArray = dialogueElement.GeneralText;

        foreach (string sentence in dialogueTextArray)
        {
            dialogueQueue.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    private void DisplayNextSentence()
    {
        
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }
        sentence = dialogueQueue.Dequeue();
        dialogueBox.text = sentence;
        
    }

    private void EndDialogue()
    {
        player.canMove = true;
        talkingToNPC = false;
        dialogueBox.enabled = false;
        print("End of Dialogue");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
            {
                if (!talkingToNPC)
                {
                    talkingToNPC = true;
                    dialogueElement = other.gameObject.GetComponent<DialogueElement>();
                    StartDialogue();
                    
                }
                else
                {
                    DisplayNextSentence();
                }
            }

        }

    }

}
