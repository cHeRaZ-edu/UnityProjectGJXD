using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfo : MonoBehaviour
{
    public GameObject target;
    private RectTransform rectTransform;
    public bool isStart = false;
    private string titleCharacter = "Character";
    void Start() {
        rectTransform = GetComponent<RectTransform>();
    }    
    public void SetTitle(string titleCharacter) {
        this.titleCharacter = titleCharacter;
        foreach(Transform child in gameObject.transform) {
            if(child.gameObject.tag == "Text") {
                child.gameObject.GetComponent<Text>().text = this.titleCharacter;
            }
        }
    }
    void Update() {
        if(isStart)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position);
            transform.position = new Vector3(screenPos.x, screenPos.y, transform.position.z);
        }
    }
}
