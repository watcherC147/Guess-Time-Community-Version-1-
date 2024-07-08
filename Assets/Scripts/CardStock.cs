using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStock : MonoBehaviour
{
    public TextAsset cardData;
    public List<Card> cardList =new List<Card>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadCardData() //加载卡牌数据
    {
        string[] dataRow = cardData.text.Split('\n');
        foreach (string row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#") continue;
            else if (rowArray[0] == "charactor") //角色卡
            {
                int id = int.Parse(rowArray[1]);
                string name = rowArray[2];
                int health = int.Parse(rowArray[3]);
                int erosion = int.Parse(rowArray[4]);
                int lucky = int.Parse(rowArray[5]);
                string skill = rowArray[6];
                CharacterCard characterCard = new CharacterCard(id, name, health, erosion, lucky, skill);
                cardList.Add(characterCard);
                Debug.Log("读取到角色卡："+characterCard.cardName);
            }
            else if (rowArray[0] == "basicAction") //基础卡
            {
                int id = int.Parse(rowArray[1]);
                string name = rowArray[2];
                int damage = int.Parse(rowArray[3]);
                int defense = int.Parse(rowArray[4]);
                BasicActionCard basicActionCard= new BasicActionCard(id, name, damage, defense);
                cardList.Add(basicActionCard);
                Debug.Log("读取到基础卡："+basicActionCard.cardName);
            }
            else
            {

            }

        }
    }
}
