using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    enum EventAction
    {
        none = 0,
        ItemTake,
        Win,
        Lose
    }
    UIManager uiManager;
    bool anyKeyUp = false;
    bool anyKeyDown = false;
    bool isUIPressAnyEvent = false;
    public const float timeHideAnyEvent = 3.0f;
    public float time = timeHideAnyEvent;
    private EventAction action = EventAction.none;
    private void Start() {
        uiManager = GameObject.FindGameObjectWithTag(UIManager.UIManageTag).GetComponent<UIManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) {
            PressAny();
            if (anyKeyUp) {
                anyKeyUp = false;
                //Press Up
                PressAnyUp();
            } else {
                anyKeyDown = true;
            }
        } else {
            if(anyKeyDown) {
                anyKeyDown = false;
                PressAnyDown();
            }
            else {
                anyKeyUp = true;
            }
        }
        EventEscape();

        //Movimiento del personaje
        // AWSD ...
        // Click Left atacar
        //...
        // Click Right Stun
        //...
        EventChangeRoom();
        //Time hide UIItemView
        if (isUIPressAnyEvent) {
            time -= Time.deltaTime;
            if(time < 0) {
                time = timeHideAnyEvent;
                isUIPressAnyEvent = false;
                EventAnyAction();
            }
        }
    }
    //-----Events Any Input
    private void PressAnyUp() {

    }
    private void PressAnyDown() {
        switch (uiManager.current) {
            case UIManager.UIGameOverTag:
                {
                    action = EventAction.Lose;
                    isUIPressAnyEvent = true;
                    break;
                }
            case UIManager.UIWinTag:
                {
                    action = EventAction.Win;
                    isUIPressAnyEvent = true;
                    break;
                }
            case UIManager.UIItemViewTag:
                {
                    action = EventAction.ItemTake;
                    isUIPressAnyEvent = true;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
    private void PressAny() {

    }
    //------------------------
    private void EventChangeRoom() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            GameManager.Instance.ChangeRoom(player.GetComponent<PlayerController>(),"3A");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.ChangeRoom(player.GetComponent<PlayerController>(), "3B");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameManager.Instance.ChangeRoom(player.GetComponent<PlayerController>(), "2A");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameManager.Instance.ChangeRoom(player.GetComponent<PlayerController>(), "2B");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GameManager.Instance.ChangeRoom(player.GetComponent<PlayerController>(), "1A");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            GameManager.Instance.ChangeRoom(player.GetComponent<PlayerController>(), "1B");
        }
    }
    //-----------------------------------------
    //Events Inputs
    private void EventEscape() {
        //Logica tecla Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (uiManager.current)
            {
                case UIManager.UIPauseTag:
                    {
                        uiManager.setUI(UIManager.UIGameTag);
                        break;
                    }
                case UIManager.UIOptionsTag:
                    {
                        uiManager.setUI(UIManager.UIPauseTag);
                        break;
                    }
                default:
                    {
                        //Pausar ...
                        uiManager.setUI(UIManager.UIPauseTag);
                        break;
                    }
            }
        }
    }
    private void EventAnyAction() {
        switch(action)
        {
            case EventAction.ItemTake:
                {
                    uiManager.setUI(UIManager.UIGameTag);
                    break;
                }
            case EventAction.Lose:
                {
                    // Regresar al menu
                    BackInitialMenu();
                    break;
                }
            case EventAction.Win:
                {
                    BackInitialMenu();
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    //-----------------------------------------
    //Events Buttons
    public void OptionsPanel() {
        uiManager.setUI(UIManager.UIOptionsTag);
    }
    public void BackMenuPause() {
        uiManager.setUI(UIManager.UIPauseTag);
    }
    public void ExitGame() {
        Application.Quit();
    }
    public void GameResume() {
        GameManager.Instance.ResumeGame(uiManager);
    }
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }
    //Initial Menu
    public void BackInitialMenu()
    {
        GameManager.Instance.InitialMenu();
    }
   

}
