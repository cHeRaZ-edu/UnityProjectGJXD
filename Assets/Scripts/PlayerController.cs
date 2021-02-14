using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float health = 100.0f;
    private bool isWeapon = false; 
    private bool isWeaponStun = false;
    //Llaves
        
    //ItemsBounus
    private int itemsBouns = 0;

    public float GetHealth() {
        return health;
    }
    public bool GetIsWeapon()
    {
        return isWeapon;
    }
    public bool GetWeaponStun()
    {
        return isWeaponStun;
    }
    public int GetItemBonus()
    {
        return itemsBouns;
    }
    public void Damage(float damage) {
        health -= damage;
    }
    private void Update()
    {
        if(health < 0) {
            // ... Game over
        }
    }
    public void Possess(PlayerController playerController) {
        health = playerController.GetHealth();
        isWeapon = playerController.GetIsWeapon();
        isWeaponStun = playerController.GetWeaponStun();
        itemsBouns = playerController.GetItemBonus();
    }
}
