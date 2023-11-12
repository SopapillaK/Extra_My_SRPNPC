using System;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public AudioClip hurt;
    public AudioClip heal;
    internal void TakeDamage(int amount)
    {
        GetComponent<IHealth>().TakeDamage(amount);
    }

    internal void HealHP()
    {
        GetComponent<IHealth>().HealHP();

    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(hurt);

            if (gameObject.tag == "InvulNPC")
            {
               HealHP();
            }
        }

        if ((Input.GetKeyDown(KeyCode.H)) && (gameObject.tag == "ManualHeal"))
        {
            HealHP();
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(heal);
        }
    }
}