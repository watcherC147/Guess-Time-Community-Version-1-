using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openpackage : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject cardPool;
    CardStore cardStore;
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
        for(int i = 0; i < 5; i++)
        {
            GameObject newCard=GameObject.Instantiate(cardPrefab,cardPool.transform);
            newCard.GetComponent<CardDisplay>().card = cardStore.RandomCard();
        }
    }
}
