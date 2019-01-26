﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueElement: MonoBehaviour
{
    public enum Characters { Farmer, Doctor, Botanist, Merchant };
    public enum AvatarPos { left, right };
    public Characters Character;
    public AvatarPos CharacterPosition;
    public Texture2D CharacterPic;

    [TextArea(3, 10)]
    public string[] IntroText;
    [TextArea(3, 10)]
    public string[] KeyItem1Text;
    
    public GUIStyle DialogueTextStyle;
    public float TextPlayBackSpeed;
    public AudioClip PlayBackSoundFile;

}
