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

        levelNum = player.levelNum;

        masterVol = player.masterVol;
        musicVol = player.musicVol;
        soundVol = player.soundVol;
    }
}
