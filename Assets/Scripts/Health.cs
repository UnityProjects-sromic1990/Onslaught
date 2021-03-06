using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth = 1f;
    public float healthValue { get; private set; }

    [Tooltip("This object will be destroyed when health is reduced to zero. If left blank, will destoy this object")]
    public GameObject rootToKill = null;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (rootToKill == null)
            rootToKill = gameObject;

        healthValue = startingHealth;
    }

    public void SelfDestruct()
    {
        ChangeHealth(-healthValue);
    }

    public virtual void ChangeHealth(float amountToChange)
    {
        float newHealth = healthValue + amountToChange;

        newHealth = Mathf.Clamp(newHealth, 0f, startingHealth);
        healthValue = newHealth;

        if (healthValue == 0)
            Die();
    }

    public bool IsFullHealth()
    {
        return (healthValue == startingHealth);
    }

    protected virtual void Die()
    {
        Destroy(rootToKill);
    }
}
