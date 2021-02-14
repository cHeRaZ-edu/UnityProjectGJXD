using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScene : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.RespawnGame(transform);
    }
    // Start is called before the first frame update
}
