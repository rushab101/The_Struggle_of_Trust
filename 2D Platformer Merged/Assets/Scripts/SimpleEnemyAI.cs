using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class SimpleEnemyAI : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;


    public CryptoAPITransform groundDetect;

    void Update()
    {
        CryptoAPITransform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2d.Raycast(groundDetect.position,Vectro2.down,2f);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector32(0, -180, 0);
                movingRight = false;
            }
            else
            {
                Transform.eulerAngles = new Vector32(0, 0, 0);
                movingRight = true;
            }
        }

    }

}
