using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_hp_Fly : MonoBehaviour
{
     public Animator _animator;
    public GameObject sukk;
    public playerExp playerExp;
    public float exp_buff;
    public int maxHeath ;
    private int currentHeath;
    private int die_coldown=0;
    // Start is called before the first frame update
    void Start()
    {
         currentHeath = maxHeath;  
         playerExp= GameObject.FindGameObjectWithTag("Player").GetComponent<playerExp>();

    }

    // Update is called once per frame
    void Update()
    {
    if(currentHeath <=0){
        destroy();
    }
    }
    public void takeDamage(int damage){
        currentHeath -= damage;
        Debug.Log("dame: "+damage);
        if(currentHeath>0){
        _animator.SetTrigger("hurt");
           transform.position=new Vector3(transform.position.x +0.1f,transform.position.y +0.2f);
        }

        if(currentHeath<=0){
            die();
        }
    }
    void die(){
        _animator.SetBool("death",true);
        if(die_coldown==0){
        playerExp.currenExp += exp_buff;
        die_coldown++;
        StartCoroutine(destroy());
        GameObject currentGhost=Instantiate(sukk,transform.position,transform.rotation);
        GetComponent<enemyFyli>().enabled=false;
        GetComponent<enemyFly_Attk>().enabled=false;
        this.enabled =false;
        Destroy(currentGhost,2f);
        }
        
       
      
    }
    
 
 IEnumerator destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
