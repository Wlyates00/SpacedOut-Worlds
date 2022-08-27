using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

    public Image bossHeart;
    public Image backBossHeart;
    public Transform boss;
    public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(boss != null)
        {
            bossHeart.fillAmount = boss.GetComponent<FirstBoss>().health / 1000;
        }
        else if (boss == null)
        {
            bossHeart.fillAmount = 0f;
        }
        
    }
}
