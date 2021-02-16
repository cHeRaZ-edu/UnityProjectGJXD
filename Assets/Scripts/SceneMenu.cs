using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneMenu : MonoBehaviour
{
    public GameObject bgCreditos;
    public GameObject bgInicio;

    public GameObject btnStart;
    public GameObject btnCreditos;
    public GameObject btnExit;
    public GameObject btnBackMenuInitial;

    private bool isCreditos = false;
    public void Start() {
        PantallaInicio();
    }
    public void StartScene() {
        GameManager.Instance.StartGame();
    }
    public void ExitGame() {
        Application.Quit();
    }
    public void Creditos() 
    {
        bgCreditos.SetActive(true);
        bgInicio.SetActive(false);
        
        btnBackMenuInitial.SetActive(true);
        btnStart.SetActive(false);
        btnCreditos.SetActive(false);
        btnExit.SetActive(false);
    }
    public void PantallaInicio()
    {
        bgCreditos.SetActive(false);
        bgInicio.SetActive(true);

        btnBackMenuInitial.SetActive(false);
        btnStart.SetActive(true);
        btnCreditos.SetActive(true);
        btnExit.SetActive(true);
    }
}
