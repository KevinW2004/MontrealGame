using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardSystem
{
    public class CardManager : MonoBehaviour
    {
        // 卡牌列表
        public List<Card> cards = new List<Card>();

        // 单例模式
        public static CardManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // 拾取卡牌
        public void PickUpCard(Card card)
        {
            cards.Add(card);
            // 在这里可以更新UI来显示主角拥有的卡牌数量和属性
        }

        // 使用卡牌
        public bool UseCard(int cardIndex)
        {
            if (cardIndex >= 0 && cardIndex < cards.Count)
            {
                // 根据卡牌属性执行相应的逻辑，例如击杀敌人
                //int kills = cards[cardIndex].kills;
                // 在这里可以执行击杀敌人的操作，根据kills的值来判断能否击杀
                // 同时在击杀后，你可以从卡牌列表中移除卡牌
                cards.RemoveAt(cardIndex);
                return true;
            }
            return false;
        }
    }
}

