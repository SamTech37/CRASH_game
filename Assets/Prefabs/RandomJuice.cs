using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomJuice : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite[] juice;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, juice.Length);
        rend.sprite = juice[rand];
        transform.Rotate(new Vector3(0, 0, Random.Range(0, 180)));
    }

    
}
