using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathPlayer : MonoBehaviour
{   
    public Animator _animator;
    public int maxHeath=100;
    public int currenHeath;

    public heathBar heathBar;
    public float time=0.1f;
    public int hp_buff;
    private float intTime;
    public Text hp_Text;
    public GameObject Menu_gameover;
    // Start is called before the first frame update
    void Start()
    {
        currenHeath =maxHeath;
        heathBar.SetMaxHeath(maxHeath);
        Menu_gameover.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        hp_Text.text=""+ maxHeath +"/" + currenHeath;
          if(Input.GetKeyDown(KeyCode.T)){
         currenHeath -=5000;   
         
        }
        heathBar.SetMaxHeath(maxHeath); 
        heathBar.SetHeath(currenHeath);
    }
    private void Awake(){
                        time=intTime;

    }
    public void takeDame(int dame){
        currenHeath -= dame;
        heathBar.SetHeath(currenHeath);
         if(currenHeath >0){
            _animator.SetTrigger("hurt");
            transform.position =new Vector2(transform.position.x,transform.position.y+0.1f);
            // colldown();

         }
          if(currenHeath <= 0){
            die();
        }
    }
    void die(){
        _animator.SetBool("deah",true);
        Time.timeScale = 0;
        Menu_gameover.SetActive(true);
        GetComponent<playercontroll>().enabled=false;
    }
    
}
