using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGame
{
    public enum ItemGameType
    {
        Key = 0,
        Bonus,
        Upgrade
    }
    public string nameScene;
    public string tagName;
    public ItemGameType m_type;

    public ItemGame(string nameScene, string tagName,ItemGameType m_type) {
        this.nameScene = nameScene;
        this.tagName = tagName;
        this.m_type = m_type;
    }
}
