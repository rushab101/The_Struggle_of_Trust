using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Vector2 velocity;

    public float smoothTimeY, smoothTimeX;

    public GameObject Player;

    public bool bounds;

    public Vector3 minCameraPosition;
    public Vector3 maxCameraPosition;


    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate() {
        float positionX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref velocity.x, smoothTimeX);
        float positionY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(positionX, positionY, transform.position.z);

        if (bounds) {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPosition.x, maxCameraPosition.x),
                Mathf.Clamp(transform.position.y, minCameraPosition.y, maxCameraPosition.y),
                Mathf.Clamp(transform.position.z, minCameraPosition.z, maxCameraPosition.z));
        }
    }
}
