using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //physics and effects
    float inputHorizontal, inputVertical;
    public float speed = 10.0f;//12 secs standstill = death
    public Joystick joystick;
    Rigidbody2D rb;
    public GameObject effect;
    public AudioSource hitSound;
    //hp stuff
    public float hp = 600f;
    private bool isStandstill;
    public EnemySpawner enemySpawner;
    //Gameover stuff
    private Camera cam;
    [SerializeField] private float targetzoom = 100f;
    public GameController gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }


    void Update()
    {
        inputHorizontal = joystick.Horizontal;
        inputVertical = joystick.Vertical;

        if (hp <= 0) Gameover();
     }
    //update frame rate depends on physics engine
    void FixedUpdate()
    {
        Vector2 direction = new Vector2(inputHorizontal, inputVertical).normalized;
        rb.velocity = direction * speed;
        isStandstill = (rb.velocity.magnitude <= 0.2f);
        hp-= 1f + enemySpawner.waves/180;//loses  hp every frame(physics)

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isStandstill && hp <= 600f) hp+=speed*2.2f;//kill to recover hp
    }
    public void Gameover()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        hitSound.pitch = Random.Range(0.8f, 1.6f);
        hitSound.Play();
        cam.orthographicSize = targetzoom;
        gameController.EndGame();
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(rb);
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(GetComponent<PlayerMovement>());

    }
}
