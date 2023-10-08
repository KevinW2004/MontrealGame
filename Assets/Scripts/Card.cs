using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardSystem
{
    [System.Serializable]
    public class Card
    {
        public string name; // 卡牌名称
        public int level; // 卡牌等级

        public Card(string name, int level)
        {
            this.name = name;
            this.level = level;
        }
    }
}
