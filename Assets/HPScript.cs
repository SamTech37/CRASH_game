using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPScript : MonoBehaviour
{
    public Image HPbar;
    public float currentHP,maxHP;
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        HPbar = GetComponent<Image>();
        maxHP = player.hp;
        currentHP = player.hp;
    }

    // Update is called once per frame
    void Update()
    {
        currentHP = player.hp;
        HPbar.fillAmount = currentHP / maxHP;
    }
}
