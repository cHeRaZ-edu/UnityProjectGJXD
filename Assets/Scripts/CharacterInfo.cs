using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public GameObject target;
    private RectTransform rectTransform;
    public bool isStart = false;
    void Start() {
        rectTransform = GetComponent<RectTransform>();
    }    
    void Update() {
        if(isStart)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position);
            transform.position = new Vector3(screenPos.x, screenPos.y, transform.position.z);
        }
    }
}
