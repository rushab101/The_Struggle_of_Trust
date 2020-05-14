using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public float torqueMultiplier = 50;
    public Vector2 shardSpeedMultiplier = new Vector2(150, 500);

    public float fadingSpeed = 1f;
    public float startFadingAfterSeconds = 5f;

    

    private Rigidbody2D rigid;
    private Vector3 rotation;
    private Vector2 force;
    private bool isActive = false;
    private bool makeTransparent = false;
    private bool killMe = false;
    private float currentTime = 0;

    private Renderer[] renderers;

    void Start()
    {
        renderers = gameObject.GetComponentsInChildren<Renderer>();
        rigid = GetComponent<Rigidbody2D>();

        float rndTorqueSpeed = (Random.value + 1) * torqueMultiplier;
        force = new Vector2((Random.value) * shardSpeedMultiplier.x, (Random.value) * shardSpeedMultiplier.y);

        rigid.AddTorque(rndTorqueSpeed);
        float side = Random.value;

        if (side > 0.5)
            force.x *= (-1);
        else
        {
            force.x *= (1);
        }
        rigid.AddForce(force);
    }

    void Update()
    {
        if (isActive)
        {
            TimeUpdate();
        }

        if (makeTransparent)
        {
            MakeTransparent();
        }

        if (killMe)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isActive = true;
    }

    private void MakeTransparent()
    {
        foreach (Renderer renderer in renderers)
        {
            Color color = renderer.material.color;
            if (color.a > 0)
                color.a = Mathf.MoveTowards(color.a, 0, Time.deltaTime * fadingSpeed);
            renderer.material.color = color;

            if (color.a <= 0)
            {
                makeTransparent = false;
                killMe = true;
            }
        }
    }

    private void TimeUpdate()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= startFadingAfterSeconds)
        {
            isActive = false;
            currentTime = 0;
            makeTransparent = true;
        }
    }
}
