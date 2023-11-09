using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenerateHP : MonoBehaviour
{
    private bool canHeal = false;

    public StandardHealth standardHealth;
    public event Action<float> OnHPPctChanged = delegate (float f) { };


    public float CurrentHpPct
    {
        get { return (float)standardHealth.currentHealth / (float)standardHealth.startingHealth; }
    }
    public void HealHP()
    {
        if (canHeal)
        {
            //StartCoroutine(InvunlerabilityTimer());

            standardHealth.currentHealth += 10;

            OnHPPctChanged(CurrentHpPct);
        }
    }

    public void Update()
    {
        Invoke("HealHP", 1.0f);
    }
    private IEnumerator InvunlerabilityTimer()
    {
        canHeal = false;
        yield return new WaitForSeconds(1.0f);
        canHeal = true;
    }
}
