using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static DialogueElement;

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
    public Image sprite;
    public Image textBackground;
    private readonly float textPlayBackSpeed = .1f;

    private void Start()
    {
        player = GetComponent<Player>();
        dialogueQueue = new Queue<string>();
        dialogueBox.enabled = false;
        sprite.enabled = false;
        textBackground.enabled = false;
    }

    // Start the Dialogue and stop the player from moving until dialogue is finished
    private void StartDialogue()
    {
        player.canMove = false;
        dialogueQueue.Clear();
        dialogueBox.text = "";
        sprite.sprite = dialogueElement.CharacterPic;

        // Enable UI
        dialogueBox.enabled = true;
        sprite.enabled = true;
        textBackground.enabled = true;

        if (!dialogueElement.introducedToPlayer)
        {
            dialogueTextArray = dialogueElement.IntroText;
            dialogueElement.introducedToPlayer = true;
            player.clip1 = dialogueElement.IntroSoundPlaybackStart;
            player.clip2 = dialogueElement.IntroSoundPlaybackEnd;
        }
        else if (player.keyItems.ContainsKey(dialogueElement.Character) && dialogueElement.keyItem1DialoguePlayed)
        {
            dialogueTextArray = dialogueElement.KeyItem1Text;
            dialogueElement.keyItem1DialoguePlayed = true;
            player.clip1 = dialogueElement.KeyItem1Playback;
            player.clip2 = dialogueElement.KeyItem2Playback;
        }
        else
        {
            dialogueTextArray = dialogueElement.GeneralText;
            player.clip1 = dialogueElement.IntroSoundPlaybackStart;
            player.clip2 = dialogueElement.IntroSoundPlaybackEnd;
        }
        

        /*
        //Botanist key item dialogue
        if (dialogueElement.Character == Characters.Botanist && player.keyItems[dialogueElement.Character])
        {

        }
        //Doctor key item dialogue
        if (dialogueElement.Character == Characters.Doctor && player.keyItems[dialogueElement.Character])
        {
        }
        //Farmer key item dialogue
        if (dialogueElement.Character == Characters.Farmer && player.keyItems[dialogueElement.Character])
        {
        }
        //Merchant key item dialogue
        if (dialogueElement.Character == Characters.Merchant && player.keyItems[dialogueElement.Character])
        {
        }
        */



        
        
        // If KeyItem1 for Farmer || Doctor || Botonist has beenObtained
        //dialogueTextArray = dialogueElement.KeyItem1Text;

        // If General Text
        //dialogueTextArray = dialogueElement.GeneralText;

        foreach (string sentence in dialogueTextArray)
        {
            dialogueQueue.Enqueue(sentence);
        }

        player.audioSource.clip = player.clip1;
        player.audioSource.Play();

        DisplayNextSentence();
    }
    private void DisplayNextSentence()
    {

        if(dialogueQueue.Count == 1)
        {
            player.audioSource.clip = player.clip2;
            player.audioSource.Play();
        }
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
        sprite.enabled = false;
        textBackground.enabled = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
            {
                dialogueElement = other.gameObject.GetComponent<DialogueElement>();
                if (!talkingToNPC)
                {
                    talkingToNPC = true;
                    StartDialogue();
                }
                else
                {
                    DisplayNextSentence();
                }

                if (!Data.npcsInTown.Contains(dialogueElement.CharacterPrefab))
                {
                    //Data.npcsInTown.Add(dialogueElement.CharacterPrefab);
                    Data.npcsInTown.Add(dialogueElement.CharacterPrefab);
                    //Resources.Load(this.gameObject.name);
                }
            }
            


        }

    }

}
