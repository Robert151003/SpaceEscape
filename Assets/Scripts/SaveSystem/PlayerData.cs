using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool level1;
    public bool level2;

    public PlayerData(progressSaver player)
    {
        level1 = player.level1;
        level2 = player.level2;
    }
}
