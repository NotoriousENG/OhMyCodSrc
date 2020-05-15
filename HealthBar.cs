using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //public PlayerHealth playerHealth;
    public Image healthBar;
    public float maxHealth;
    public float currHealth;

    public void updateHealthBar()
    {
        Debug.Log("Updating Health Bar");
        healthBar.fillAmount = currHealth / maxHealth;
    }

    public void setMaxHealth(float num)
    {
        maxHealth = num;
        updateHealthBar();
    }
    public void setCurrHealth(float num)
    {
        currHealth = num;
        updateHealthBar();
    }
}
