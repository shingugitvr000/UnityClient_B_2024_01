using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameData" , menuName = "GameData", order = 50)]
public class GameData : ScriptableObject
{
    public string gameName;
    public int gameScore;
    public bool isGmaeActive;       
}
