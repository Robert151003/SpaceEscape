using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool level1;
    public bool level2;
    public bool level3;
    public bool level4;
    public bool level5;        
    public bool level6;
    public bool level7;
    public bool level8;        
    public bool level9;
    public bool level10;
    public bool level11;
    public bool level12;
    public bool level13;
    public bool level14;
    public bool level15;
    public bool level16;
    public bool level17;
    public bool level18;
    public bool level19;
    public bool level20;
    public bool level21;
    public bool level22;
    public bool level23;
    public bool level24;

    public int levelNum;

    public int masterVol;
    public int musicVol;
    public int soundVol;

    public PlayerData(progressSaver player)
    {
        level1 = player.level1;
        level2 = player.level2;
        level3 = player.level3;            
        level4 = player.level4;
        level5 = player.level5;
        level6 = player.level6;
        level7 = player.level7;
        level8 = player.level8;
        level9 = player.level9;
        level10 = player.level10;
        level11 = player.level11;
        level12 = player.level12;
        level13 = player.level13;
        level14 = player.level14;
        level15 = player.level15;
        level16 = player.level16;
        level17 = player.level17;
        level18 = player.level18;
        level19 = player.level19;
        level20 = player.level20;
        level21 = player.level21;
        level22 = player.level22;
        level23 = player.level23;
        level24 = player.level24;

        levelNum = player.levelNum;

        masterVol = player.masterVol;
        musicVol = player.musicVol;
        soundVol = player.soundVol;
    }
}
