// using System.IO;
// using System.Numerics;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Pathfinding;
// public class EnemyAI : MonoBehaviour
// {
// [Header("Pathfinding")]
// public Transform target;
// public float activate=50f; 
// public float pathUpdate=0.5f;
// [Header("Physics")]
// public float speed =5f;
// public float nextWaypoint=3f;
// public float jumpNodeHeight=0.8f;
// public float jumpModifỉer =0.3f;
// public float jumpCheckOffset=0.1f;
// [Header("Custom Behvior")]
// public bool follwEnbled =true;
// public bool jumpEnbled =true;
// public bool directionLookEnbled=true;

// private  Pathfinding.Path path;
// private int currenWaypoint =0;
// bool isGrounded=false;
// Seeker seeker;
// public Rigidbody2D rb;
// public void Start() {
//     seeker =GetComponent<Seeker>();
//     InvokeRepeating("UpdatePath",0f,pathUpdate);
// }
// private void FixedUpdate() {
//     if(targetInDistance() && follwEnbled)
//     {
//         PathFollow();
//     }
    
// }
// private void UpdatePath(){
//     if(follwEnbled && targetInDistance()&& seeker.IsDone())
//     {
//       seeker.StartPath(rb.position,target.position,OnPathComplete);
//     }
    
// }
// private void PathFollow(){
//     if(path==null)
//     {
//         return;
//     }
//     if(currenWaypoint>=path.vectorPath.Count)
//     {
//         return;
//     }
//     isGrounded =Physics2D.Raycast(transform.position,-UnityEngine.Vector3.up,GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);
    
//     UnityEngine.Vector2 direction =((UnityEngine.Vector2)path.vectorPath[currenWaypoint]-rb.position).normalized;
//     UnityEngine.Vector2 force =direction*speed*Time.deltaTime;

//     //fump
//     if(jumpEnbled && isGrounded)
//     {
//         if(direction.y > jumpNodeHeight){
//             rb.AddForce(UnityEngine.Vector2.up *speed*jumpModifỉer);
//         }
//     }
//     //movement
//     rb.AddForce(force);
//     //next Waypoint
//     float distance =UnityEngine.Vector2.Distance(rb.position,path.vectorPath[currenWaypoint]);
//     if(distance < nextWaypoint){
//         currenWaypoint++;
//     }
//     if(directionLookEnbled)
//     {
//         if(rb.velocity.x >0.5f){
//             transform.localScale =new UnityEngine.Vector3(-1f*Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);
//         }
//         else if(rb.velocity.x <-0.05f){
//             transform.localScale =new UnityEngine.Vector3(Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);
//         }
//     }
// }
// private bool targetInDistance()
// {
//     return UnityEngine.Vector2.Distance(transform.position,target.transform.position)<activate;
// }
// private void OnPathComplete(Pathfinding.Path p){
//     if(!p.error)
//     {
//         path=p;
//         currenWaypoint=0;
//     }
// }   




// }
