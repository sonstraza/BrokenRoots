using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueElement: MonoBehaviour
{
    public enum Characters { Farmer, Doctor, Botanist, Merchant };
    public GameObject CharacterPrefab;

    public enum AvatarPos { left, right };
    public Characters Character;
    public AvatarPos CharacterPosition;
    public Sprite CharacterPic;

    public bool introducedToPlayer = false;
    public bool keyItem1DialoguePlayed = false;

    [TextArea(3, 10)]
    public string[] IntroText;
    [TextArea(3, 10)]
    public string[] KeyItem1Text;
    [TextArea(3, 10)]
    public string[] KeyItem2Text;
    [TextArea(3, 10)]
    public string[] KeyItem3Text;
    [TextArea(3, 10)]
    public string[] GeneralText;

    public AudioClip IntroSoundPlaybackStart;
    public AudioClip IntroSoundPlaybackEnd;
    public AudioClip KeyItem1Playback;
    public AudioClip KeyItem2Playback;
    
}
