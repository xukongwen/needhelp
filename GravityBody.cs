using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : GravityObject
{
    public Rigidbody rb;
    Quaternion targetRot;
	Quaternion smoothedRot;

    void Awake () {
		InitRigidbody ();
		targetRot = transform.rotation;
		smoothedRot = transform.rotation;

	}
    void FixedUpdate () {
		// Gravity
		Vector3 gravity = NBodySimulation.CalculateAcceleration (rb.position);
		rb.AddForce (gravity, ForceMode.Acceleration);

	}

    void InitRigidbody () {
		rb = GetComponent<Rigidbody> ();
		rb.interpolation = RigidbodyInterpolation.Interpolate;
		rb.useGravity = false;
		rb.isKinematic = false;
		rb.centerOfMass = Vector3.zero;
		rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
	}
}
