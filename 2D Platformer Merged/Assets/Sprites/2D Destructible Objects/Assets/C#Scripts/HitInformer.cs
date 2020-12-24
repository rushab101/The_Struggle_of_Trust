using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitInformer : MonoBehaviour {

    public MonoBehaviour toInform;
    private Collider2D hitBoxCollider;

    public void Start()
    {
        hitBoxCollider = GetComponent<Collider2D>();
    }

    public void HitReceived()
    {
        if (toInform is IHittable)
        {
            hitBoxCollider.enabled = false;
            ((IHittable)toInform).HitReceived();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sword")
        {
            HitReceived();
        }
    }
}
