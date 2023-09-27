using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp_boss : MonoBehaviour
{
    public Animator _animator;
    public GameObject sukk;
    public playerExp playerExp;
    public GameObject hit_Slash;
    public boss_UI hp_bar;
    Transform player;
    GameObject currenhit;
    public float exp_buff;
    public int maxHeath ;
    private int currentHeath;
    private int die_coldown=0;
    public GameObject Menu_win;

    // Start is called before the first frame update
    void Start()
    {
        currentHeath = maxHeath;
        hp_bar.SetMaxHeath(maxHeath);  
        Menu_win.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {  
        hp_bar.SetMaxHeath(maxHeath); 
        hp_bar.SetHeath(currentHeath);
    if(currentHeath <=0){
         hp_bar.SetMaxHeath(maxHeath); 
        hp_bar.SetHeath(currentHeath);
        destroy();
    }
    }
    public void takeDamage(int damage){
        currentHeath -= damage;
        if(currentHeath>0){
        // _animator.SetTrigger("hurt");
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Hit_Slash();

        }

        if(currentHeath<=0){
             hp_bar.SetMaxHeath(maxHeath); 
        hp_bar.SetHeath(currentHeath);
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
        Menu_win.SetActive(true);
        GetComponent<hp_boss>().enabled=false;
        GetComponent<BossMove>().enabled=false;
        this.enabled =false;
        Destroy(currentGhost,2f);
        }
        
       
      
    }
    public void Hit_Slash(){
         if(player.transform.localScale.x>0){
       currenhit= Instantiate(hit_Slash,transform.position,Quaternion.Euler(new Vector3(0,180,0)));
        
        }else if(player.transform.localScale.x<0){
      currenhit=  Instantiate(hit_Slash,transform.position,Quaternion.Euler(new Vector3(0,0,0))); 
        }
        Destroy(currenhit,2f);
    

    }
 
 IEnumerator destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
