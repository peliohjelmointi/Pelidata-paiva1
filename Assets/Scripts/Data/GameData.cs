using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector2 playerPosition;
    
    public GameData()
    {
        playerPosition = new Vector2(-3, -3); //pelaajan alkusijainti
    }
}
