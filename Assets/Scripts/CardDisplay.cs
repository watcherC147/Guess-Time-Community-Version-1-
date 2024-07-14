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
    public TextMeshProUGUI noteText;
    public TextMeshProUGUI typeText;
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
            healthText.text = "血："+character.health.ToString();
            erosionText.text="侵蚀："+character.erosion.ToString();
            luckyText.text="幸运："+character.lucky.ToString();
            skillText.text="技能："+character.skill;
        }
        else if(card is BasicActionCard) //基础卡显示
        {
            var basicAction = card as BasicActionCard;
            damageText.text = "伤害：" + basicAction.damage.ToString();
            defenseText.text = "防御：" + basicAction.defense.ToString();
            erosionAccumulationText.text=basicAction.erosionAccumulation.ToString();
            noteText.text = basicAction.note;
        }
        else if(card is EffectCard) //效果卡显示
        {
            var effect = card as EffectCard;
            erosionAccumulationText.text= effect.erosionAccumulation.ToString();
            typeText.text = "<" + effect.type + ">";
            effectText.text=effect.effect;
            noteText.text = effect.note;
        }
    }
}
