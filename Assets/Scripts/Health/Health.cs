using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;
    public float currentHealth;
    private Animator anim;
    public bool dead = false;
    public GameObject counter;

    public float iDuration = 2;
    public int flashes = 3;

    private GameObject count;


    public InGameMenu gameMenu;

    private void Awake()
    {
        currentHealth = startHealth;
        anim = GetComponent<Animator>();
        count = GameObject.FindGameObjectWithTag("Ads");
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            gameMenu.Setup();
        }

    }
    public void PlayerDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
        }
        else if (!dead && currentHealth <= 0)
        {
            anim.SetTrigger("Die");
            GetComponent<PlayerActionScrpit>().enabled = false;
            dead = true;

        }
    }

    public void AddHealth(float healthAdd)
    {
        currentHealth = Mathf.Clamp(currentHealth + healthAdd, 0, startHealth);

    }

}
