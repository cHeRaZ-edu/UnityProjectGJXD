using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerItems : MonoBehaviour
{
    private List<ItemGame> items = new List<ItemGame>();
    public void pushItem(GameObject item,ItemGame.ItemGameType mType) {
        string currentName = SceneManager.GetActiveScene().name;
        string tagName = item.tag;
        items.Add(new ItemGame(currentName,tagName,mType));
    }
    public void Clear() {
        items.Clear();
    }
    public void RemoveItemsTaked() {
        string currentName = SceneManager.GetActiveScene().name;
        foreach(ItemGame item in items) {
            if(currentName.Equals(item.nameScene)) {
                GameObject go = GameObject.FindGameObjectWithTag(item.tagName);
                DestroyImmediate(go,true);
            }
        }
    }
}
