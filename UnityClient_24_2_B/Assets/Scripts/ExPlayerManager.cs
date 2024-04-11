using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExPlayerManager : MonoBehaviour
{
    public List<PlayerData> playerDatas = new List<PlayerData>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 100; i++)
        {
            PlayerData playerData = new PlayerData()
            {
                playerName = "플레이어 " + i.ToString(),
                playerLevel = Random.Range(0, 20)
            };
            playerDatas.Add(playerData);
        }

        //플레이어 데이터 리스트에서 레벨이 10이상인 플레이어를 찾는다.
        var highLevelPlayers = playerDatas.Where(PlayerData => PlayerData.playerLevel >= 10);

        foreach (var Player in highLevelPlayers)
        {
            Debug.Log("High Level Player: " + Player.playerName + " Lv : " + Player.playerLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
