using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Settings singleton
    private static bool m_ShuttingDown = false;
    private static object m_Lock = new object();
    private static GameManager m_Instance;
    //--------------------------------------------------------
    //Variable in game
    private bool isPauseGame = false;
    public PlayerController player;
    public SceneManagerItems sceneManagerItems = new SceneManagerItems();
    public bool GetIsPauseGame() {
        return isPauseGame;
    }
    //Start Game
    public void StartGame() {
        player = new PlayerController();
        sceneManagerItems.Clear();
        SceneManager.LoadScene("Level");
    }
    public void InitialMenu() {
        SceneManager.LoadScene("Menu");
    }
    public void PauseGame(UIManager uiManager) {
        isPauseGame = true;
        uiManager.setUI(UIManager.UIPauseTag);
    }
    public void ResumeGame(UIManager uiManager) {
        isPauseGame = false;
        uiManager.setUI(UIManager.UIGameTag);
    }
    public void Possess(Transform transform) {
       GameObject gameObjectPlayer = GameObject.FindGameObjectWithTag("Player");
        PlayerController pc = gameObjectPlayer.GetComponent<PlayerController>();
        pc.Possess(player);
        gameObjectPlayer.transform.position = transform.localPosition;
    }
    public void ChangeRoom(PlayerController pc, string nameScene) {
        player.Possess(pc);
        SceneManager.LoadScene(nameScene);
    }
    public void RespawnGame(Transform transform) {
        if(player == null) {
            this.gameObject.AddComponent(typeof (PlayerController));
            this.player = this.gameObject.GetComponent<PlayerController>();
        }
        Possess(transform);
        sceneManagerItems.RemoveItemsTaked();
    }
    public void TakeItem(GameObject go, ItemGame.ItemGameType mType) {
        sceneManagerItems.pushItem(go,mType);
    }

    private void Update()
    {
        if (isPauseGame)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    //--------------------------------------------------------
    //Settings singleton
    public static GameManager Instance
    {
        get
        {
            if(m_ShuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(GameManager) +
                    "' already destroyed. Returning null.");
                return null;
            }
            lock (m_Lock)
            {
                if (m_Instance == null)
                {
                    // Search for existing instance.
                    m_Instance = (GameManager)FindObjectOfType(typeof(GameManager));

                    // Create new instance if one doesn't already exist.
                    if (m_Instance == null)
                    {
                        // Need to create a new GameObject to attach the singleton to.
                        var singletonObject = new GameObject();
                        m_Instance = singletonObject.AddComponent<GameManager>();
                        singletonObject.name = typeof(GameManager).ToString() + " (Singleton)";

                        // Make instance persistent.
                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return m_Instance;
            }
        }
    }
    private void OnApplicationQuit()
    {
        m_ShuttingDown = true;
    }
    private void OnDestroy()
    {
        m_ShuttingDown = true;
    }
}
