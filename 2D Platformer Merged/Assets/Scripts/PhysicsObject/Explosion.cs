using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
        anim["Explode"].wrapMode = wrapMode.Once;
        animation.Play("Explode");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
