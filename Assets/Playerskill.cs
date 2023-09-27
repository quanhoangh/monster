using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerskill : MonoBehaviour 
{
    public Animator animator;
    public Rigidbody2D rb;
    public Transform skill_2Tranform;
    public GameObject bullet;
    public GameObject bullet_skill3;
    public GameObject bullet_up;
     public GameObject bullet_skil_dash;
    public Transform skill3_tranform;
    public Transform  skill_dash_tranfrom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
public void skill_2(){
            if(GetComponent<playercontroll>().transform.localScale.x>0){
    Instantiate(bullet,skill_2Tranform.position,Quaternion.Euler(new Vector3(0,0,0)));
        
        }else if(GetComponent<playercontroll>().transform.localScale.x<0){
    Instantiate(bullet,skill_2Tranform.position,Quaternion.Euler(new Vector3(0,180,0))); 
        
        }
    }
    public void skill_3(){
        Instantiate(bullet_skill3,skill3_tranform.position,transform.rotation);
    }
    public void skill_up(){
         if(GetComponent<playercontroll>().transform.localScale.x>0){
    Instantiate(bullet_up,skill_2Tranform.position,Quaternion.Euler(new Vector3(0,180,0)));
        
        }else if(GetComponent<playercontroll>().transform.localScale.x<0){
    Instantiate(bullet_up,skill_2Tranform.position,Quaternion.Euler(new Vector3(0,0,0))); 
        
        }
    }
    public void skill_dash(){
        Instantiate(bullet_skil_dash,skill_dash_tranfrom.position,transform.rotation);
    }
}

