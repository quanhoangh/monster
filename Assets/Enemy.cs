using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   public Animator _animator;
    public GameObject sukk;
    public GameObject hit_Slash;
    GameObject currenhit;
    public playerExp playerExp;
    Transform player;
    public float exp_buff;
    public int maxHeath ;
    private int currentHeath;
    private int die_coldown=0;
    public AudioSource sound_hit;
    // Start is called before the first frame update
    void Start()
    {
         currentHeath = maxHeath;  
         player=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
         playerExp=GameObject.FindGameObjectWithTag("Player").GetComponent<playerExp>();
        sound_hit = GameObject.Find("sound_hit").GetComponent<AudioSource>();
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
        if(currentHeath>0){
        _animator.SetTrigger("hurt");
            sound_hit.Play();
           transform.position=new Vector3(transform.position.x +0.1f,transform.position.y +0.2f);
            Hit_Slash();
        
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
        GetComponent<Enemy>().enabled=false;
        GetComponent<enemy_beti>().enabled=false;
        this.enabled =false;
        Destroy(currentGhost,2f);
        }    
    }
    
 
 IEnumerator destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
public void Hit_Slash(){
         if(player.transform.localScale.x>0){
       currenhit= Instantiate(hit_Slash,transform.position,Quaternion.Euler(new Vector3(0,180,0)));
        
        }else if(player.transform.localScale.x<0){
      currenhit=  Instantiate(hit_Slash,transform.position,Quaternion.Euler(new Vector3(0,0,0))); 
        }
        Destroy(currenhit,2f);
    }
}
