using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    //Tags UIs
    public const string
     UIManageTag = "UIManager",
     UIGameTag = "UIGame",
     UIItemViewTag = "UIItemView",
     UIPauseTag = "UIPause",
     UIOptionsTag = "UIOptions",
     UIGameOverTag = "UIGameOver",
     UIWinTag = "UIWin";

    public string current = UIGameTag;
    public bool isChangeUI = false;
    public List<GameObject> UIs = new List<GameObject>();
    // Start is called before the first frame update
    void Start() {
        UIs.Add(GameObject.FindGameObjectWithTag(UIGameTag));
        UIs.Add(GameObject.FindGameObjectWithTag(UIItemViewTag));
        UIs.Add(GameObject.FindGameObjectWithTag(UIPauseTag));
        UIs.Add(GameObject.FindGameObjectWithTag(UIOptionsTag));
        UIs.Add(GameObject.FindGameObjectWithTag(UIGameOverTag));
        UIs.Add(GameObject.FindGameObjectWithTag(UIWinTag));
        isChangeUI = true;
        EventsUIType();
    }
    // Update is called once per frame
    void Update() {
        EventsUIType();
    }
    public void setUI(string tagName) {
        if (current == tagName)
            return;
        current = tagName;
        isChangeUI = true;
    }
    private void ClearUI() {
        foreach(GameObject ui in UIs) {
            ui.SetActive(false);
        }
    }
    private void EventsUIType() {
        if (isChangeUI) {
            isChangeUI = false;
            ClearUI();
            ShowUIByTagName(current);
        }
    }
    private void ShowUIByTagName(string UIName) {
        foreach (GameObject ui in UIs) {
            if(ui.tag == UIName)
                ui.SetActive(true);
        }
    }
}
