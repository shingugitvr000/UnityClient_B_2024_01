using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;                  //JSON 직렬화를 위한 패키지
using UnityEngine;

public class ExJsonData : MonoBehaviour
{
    string filePath;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.persistentDataPath + "/PlayerData.json";
        Debug.Log(filePath);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerData playerData = new PlayerData();
            playerData.playerName = "플레이어 1";
            playerData.playerLevel = 1;
            playerData.items.Add("돌1");
            playerData.items.Add("바위1");
            SaveData(playerData);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerData playerData = new PlayerData();

            playerData = LoadData();

            Debug.Log(playerData.playerName);
            Debug.Log(playerData.playerLevel);
            for(int i = 0; i < playerData.items.Count; i++)
            {
                Debug.Log(playerData.items[i]);
            }          
        }
    }
    void SaveData(PlayerData data)
    {
        //JSON 직렬화
        string jsonData = JsonConvert.SerializeObject(data);
        //파일 저장
        File.WriteAllText(filePath, jsonData);
    }

    PlayerData LoadData()
    {
        if(File.Exists(filePath)) 
        {
            //파일에서 데이터 읽기
            string jsonData = File.ReadAllText(filePath);

            //JSON 역직렬화
            PlayerData data = JsonConvert.DeserializeObject<PlayerData>(jsonData);
            return data;
        }
        else
        {
            return null;
        }
    }
}
