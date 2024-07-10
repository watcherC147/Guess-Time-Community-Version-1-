using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI erosionText;
    public TextMeshProUGUI luckyText;
    public TextMeshProUGUI skillText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI effectText;
    public TextMeshProUGUI erosionAccumulationText;
    public Image backgroundImage;
    public Card card;
    // Start is called before the first frame update
    void Start()
    {
        ShowCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowCard()
    {
        nameText.text = card.cardName;
        if(card is CharacterCard ) //角色卡显示
        {
            var character = card as CharacterCard;
            healthText.text=character.health.ToString();
            erosionText.text=character.erosion.ToString();
            luckyText.text=character.lucky.ToString();
            skillText.text=character.skill;
            damageText.gameObject.SetActive(false);
            defenseText.gameObject.SetActive(false);
            effectText.gameObject.SetActive(false);
            erosionAccumulationText.gameObject.SetActive(false);
        }
        else if(card is BasicActionCard) //基础卡显示
        {
            var basicAction = card as BasicActionCard;
            damageText.text=basicAction.damage.ToString();
            defenseText.text=basicAction.defense.ToString();
            healthText.gameObject.SetActive(false);
            erosionText.gameObject.SetActive(false);
            luckyText.gameObject.SetActive(false);
            skillText.gameObject.SetActive(false);
            effectText.gameObject.SetActive (false);
            erosionAccumulationText.gameObject .SetActive(false);
        }
        else if(card is EffectCard) //效果卡显示
        {
            var effect = card as EffectCard;
            erosionAccumulationText.text= effect.effect.ToString();
            effectText.text=effect.effect;
            healthText.gameObject.SetActive(false) ;
            erosionText.gameObject.SetActive(false ) ;
            luckyText.gameObject.SetActive(false ) ;
            skillText.gameObject.SetActive(false);
            damageText.gameObject.SetActive(false);
            defenseText.gameObject.SetActive(false);
        }
    }
}
