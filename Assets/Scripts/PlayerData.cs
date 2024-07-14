using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class PlayerData : MonoBehaviour
{
    public CardStore CardStore;
    public bool[] playerCards;
    public int playerSourseOfTheUniverse;
    public TextAsset playerDatas;
    // Start is called before the first frame update
    void Start()
    {
        CardStore.LoadCardData();
        LoadPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadPlayerData()
    {
        playerCards=new bool[CardStore.cardList.Count];
        string[] dataRow=playerDatas.text.Split('\n');
        foreach(var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#") continue;
            else if (rowArray[0] == "SourseOfTheUniverse")
            {
                playerSourseOfTheUniverse=int.Parse(rowArray[1]);
            }
            else if(rowArray[0] == "Card")
            {
                int id = int.Parse(rowArray[1]);
                playerCards[id] = true;
            } 
        }
    }
    public void SavePlayerData()
    {
        
        string path = Application.dataPath + "/CardBag/PlayerDatas.csv";
        List<string> datas = new List<string>();
        datas.Add("SourseOfTheUniverse," + playerSourseOfTheUniverse.ToString());
        for(int i = 0; i < playerCards.Length; i++)
        {
            if (playerCards[i]==true)
                datas.Add("Card,"+i.ToString());
        }
        File.WriteAllLines(path, datas);
        Debug.Log(datas);
    }
}
