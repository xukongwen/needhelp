using UnityEngine;
using System.Collections;
using TMPro;

public class Orbiter : MonoBehaviour {


    public Vector3 force;

    public Rigidbody rb;

    private void Awake() {
        
        
        
        
        TrajectoryPredictor trajectory = GetComponent<TrajectoryPredictor>();        
        trajectory.OnPredictionIterationStep = HandlePredictionGravity;
        

        rb = GetComponent<Rigidbody>();
        
        
        
    }

    void HandlePredictionGravity(ref Vector3 currentIterationVel, Vector3 currentIterationPos, TrajectoryPredictor tpInstance) {
        force = NBodySimulation.CalculateAcceleration(currentIterationPos);
        
        currentIterationVel = force;
        //Debug.DrawRay(transform.position, force.normalized,Color.red);
  
  
    }


}
