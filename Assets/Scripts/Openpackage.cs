using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openpackage : MonoBehaviour
{
    public GameObject characterCardPrefab;
    public GameObject basicActionCardPrefab;
    public GameObject effectCardPrefab;
    public GameObject cardPool;
    CardStore cardStore;
    List<GameObject> cards = new List<GameObject>();
    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        cardStore = GetComponent<CardStore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickOpen()
    {
        if (playerData.playerSourseOfTheUniverse < 1)
            return;
        playerData.playerSourseOfTheUniverse -= 1;
        ClearPool();
        for(int i = 0; i < 1; i++)
        {
            Card card =cardStore.RandomCard();
            GameObject newCard;
            if(card is CharacterCard)
            {
                newCard = GameObject.Instantiate(characterCardPrefab, cardPool.transform);
                newCard.GetComponent<CardDisplay>().card = card;
                cards.Add(newCard);
            }
            else if(card is BasicActionCard)
            {
                newCard = GameObject.Instantiate(basicActionCardPrefab, cardPool.transform);
                newCard.GetComponent<CardDisplay>().card = card;
                cards.Add(newCard);
            }
            else if (card is EffectCard)
            {
                newCard = GameObject.Instantiate(effectCardPrefab, cardPool.transform);
                newCard.GetComponent<CardDisplay>().card = card;
                cards.Add(newCard);
            }
        }
        SaveCardData();
        playerData.SavePlayerData();
    }
    public void ClearPool()
    {
        foreach(var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
    }
    public void SaveCardData()
    {
        foreach(var card in cards)
        {
            int id = card.GetComponent<CardDisplay>().card.id;
            playerData.playerCards[id]= true;
            cardStore.cardList.Remove(card.GetComponent<CardDisplay>().card);
        }
    }
}
