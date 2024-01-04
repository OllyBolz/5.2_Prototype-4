using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Transform target;
	private float speed = 20.0f;
	private bool isTargetLocked;

	private float bulletStrength = 15.0f;
	private float delayTime = 5.0f;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (isTargetLocked && target != null)
		{
			Vector3 moveDirection = (target.transform.position - transform.position).normalized;
			transform.position += moveDirection * speed * Time.deltaTime;
			transform.LookAt(target);
		}
		else if (target == null)
		{ 
			Destroy(this.gameObject);
		}
	}

	public void Shoot(Transform newTarget)
	{
		target = newTarget;
		isTargetLocked = true;
		Destroy(gameObject, delayTime);
	}

	private void OnCollisionEnter(Collision other) 
	{
		if (target != null)
		{
			if (other.gameObject.CompareTag(target.tag))
			{
				Rigidbody targetRb = other.gameObject.GetComponent<Rigidbody>();
				Vector3 contact = -other.contacts[0].normal;
				targetRb.AddForce(contact * bulletStrength, ForceMode.Impulse);
				Destroy(this.gameObject);
				Destroy(other.gameObject, 0.5f);
			}
		}
	}
}
