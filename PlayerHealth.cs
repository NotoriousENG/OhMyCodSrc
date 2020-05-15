
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    [HideInInspector]
    public float currHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        setHealth();
        healthBar.setMaxHealth(maxHealth);
        healthBar.setCurrHealth(currHealth);
    }


    private void setHealth()
    {
        currHealth = maxHealth;
    }
    public void healPlayer(float num)
    {
        currHealth += num;
        healthBar.setCurrHealth(currHealth);
    }

    public void takeDamage(float dmgAmt)
    {
        currHealth -= dmgAmt;
        healthBar.setCurrHealth(currHealth);
    }

    public void forceUpdateHealthBar()
    {
        healthBar.updateHealthBar();
    }

}
