using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleProjectile : MonoBehaviour
{
    [SerializeField]
	int numberOfProjectiles;

	[SerializeField]
	GameObject projectile;

	Vector2 startPoint;

	float radius, moveSpeed;

	// Use this for initialization
	void Start () {
		radius = 10f;
		moveSpeed = 10f;
        startPoint = transform.localPosition;
	}
	
	 // Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
         //   Debug.Log("Wnet in to thi shit");
			startPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			SpawnProjectiles (10);
		}
	}

	void SpawnProjectiles(int numberOfProjectiles)
	{
		float angleStep = 360f / numberOfProjectiles;
		float angle = 0f;

		for (int i = 0; i <= numberOfProjectiles - 1; i++) {
			
			float projectileDirXposition = startPoint.x + Mathf.Sin ((angle * Mathf.PI) / 180) * radius;
			float projectileDirYposition = startPoint.y + Mathf.Cos ((angle * Mathf.PI) / 180) * radius;

			Vector2 projectileVector = new Vector2 (projectileDirXposition, projectileDirYposition);
			Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

			var proj = Instantiate (projectile, startPoint, Quaternion.identity);
			proj.GetComponent<Rigidbody2D> ().velocity = 
				new Vector2 (projectileMoveDirection.x, projectileMoveDirection.y);

			angle += angleStep;
		}
	}
}
