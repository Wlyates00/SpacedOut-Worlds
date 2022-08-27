using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUi : MonoBehaviour
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
        if (boss != null)
        {
            bossHeart.fillAmount = boss.GetComponent<SecondBoss>().health / 2500;
        }
        else if (boss == null)
        {
            bossHeart.fillAmount = 0f;
        }

    }
}
