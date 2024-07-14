using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStore : MonoBehaviour
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
            else if (rowArray[0] == "character") //角色卡
            {
                int id = int.Parse(rowArray[1]);
                string name = rowArray[2];
                int health = int.Parse(rowArray[3]);
                int erosion = int.Parse(rowArray[4]);
                int lucky = int.Parse(rowArray[5]);
                string skill = rowArray[6];
                CharacterCard characterCard = new CharacterCard(id, name, health, erosion, lucky, skill);
                cardList.Add(characterCard);
            }
            else if (rowArray[0] == "basicAction") //基础卡
            {
                int id = int.Parse(rowArray[1]);
                string name = rowArray[2];
                int damage = int.Parse(rowArray[3]);
                int defense = int.Parse(rowArray[4]);
                int erosionAccumulation = int.Parse(rowArray[5]);
                string note = rowArray[6];
                BasicActionCard basicActionCard = new BasicActionCard(id, name, damage, defense, erosionAccumulation, note);
                cardList.Add(basicActionCard);
            }
            else if (rowArray[0] =="effect") //效果卡
            {
                int id = int.Parse(rowArray[1]);
                string name = rowArray[2];
                int erosionAccumulation = int.Parse(rowArray[3]);
                string type=rowArray[4];
                string effect= rowArray[5];
                string note= rowArray[6];
                EffectCard effectCard = new EffectCard(id, name, erosionAccumulation, type,effect, note);
                cardList.Add(effectCard);
            }

        }
    }
    public Card RandomCard()
    {
        Card card;
        card = cardList[Random.Range(0, cardList.Count)];
        return card;
        //error:牌库没牌会报错，记得修！
    } 
}
