using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class enemyFyli : MonoBehaviour
{
    public Transform target; 
    public float speed =5f;
    public float nextWaypointdistance=3f;
    Path path;
    int currentWaypoint =0;
    Seeker seeker;
    Rigidbody2D rb;
    public bool check=false;
    // Start is called before the first frame update
    void Start()
    {
       
        seeker =GetComponent<Seeker>();
        rb=GetComponent<Rigidbody2D>();
        target=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        InvokeRepeating("UndatePath",0f,0.5f);
        
        
         
    }
    void UndatePath(){
        if(check){
           if(seeker.IsDone())
        seeker.StartPath(rb.position,target.position,onPathComplete); 
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(check){
            move();
        }
        
    }
    void onPathComplete(Path P){
        if(!P.error){
            path=P;
            currentWaypoint =0;
        }
    }
    private void move(){
        
        if(path==null)return;
        
        if(currentWaypoint>=path.vectorPath.Count){
            return;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] -rb.position).normalized;
        Vector2 force =direction *speed ;
        rb.AddForce(force);
        float distance =Vector2.Distance(rb.position,path.vectorPath[currentWaypoint]);
        if(distance<nextWaypointdistance){
            currentWaypoint++;
        }

        //fipx
        if(force.x >=0.01f){
            transform.localScale =new Vector3(1f,1f,1f);
        }else if(force.x <=-0.01f){
            transform.localScale =new Vector3(-1f,1f,1f);
        }
    }
    

        
}
