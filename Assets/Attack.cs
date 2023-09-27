using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackdame;
    public int dame;
void Start(){
    
}
       void Update(){   
    dame =attackdame;
}
private void OnTriggerEnter2D(Collider2D collider) {
    if(collider.gameObject.CompareTag("enemy")){
         
       
        for(int i=0;i<2;i++){
        collider.GetComponent<Enemy>().takeDamage(dame);
       
    }
    }
    if(collider.gameObject.CompareTag("enemy_Fly")){
         
        
        for(int i=0;i<2;i++){
        collider.GetComponent<enemy_hp_Fly>().takeDamage(dame);
     
    }
    }
       if(collider.gameObject.CompareTag("boss")){
         
        
        for(int i=0;i<2;i++){
        collider.GetComponent<hp_boss>().takeDamage(dame);
     
    }
    }
    
}
}
