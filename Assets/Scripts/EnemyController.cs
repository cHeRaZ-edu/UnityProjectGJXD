using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string titleEnemy = "Enemy";
    private CharacterController controller;
    public GameObject groupBox;
    // Start is called before the first frame update
    public float health = 100.0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (!GameObject.FindGameObjectWithTag("UIGame"))
        {
            Debug.Log("UIGame no existe");
            return;
        }

        GameObject _groupBox = GameObject.Instantiate(groupBox, GameObject.FindGameObjectWithTag("UIGame").transform);
        _groupBox.AddComponent<CharacterInfo>();
        CharacterInfo ci = _groupBox.GetComponent<CharacterInfo>();
        foreach (Transform child in gameObject.transform)
{
            if (child.gameObject.tag == "targetAboveUI")
            {
                ci.target = child.gameObject;
            }
        }
        ci.isStart = true;
        ci.SetTitle(titleEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
