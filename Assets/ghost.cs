using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    public float ghostDelay;

    private float ghostDelaySeconds;
    public GameObject ghost_;
    public bool makeGhost =false;
    public float colldownSeconds;
    private float colldown_;
    public Attack attack_;
    private int atkSeconds=1;
    public int dameBuff;
    int i=0;
    // Start is called before the first frame update
    void Start()
    {
     ghostDelaySeconds =ghostDelay;   
     colldown_=colldownSeconds;
    }

    // Update is called once per frame
    void Update()
    {  
        
    if(makeGhost && colldown_>0){

        if(ghostDelaySeconds>0){
            ghostDelaySeconds -=Time.deltaTime;

        }else{
            GameObject currentGhost=Instantiate(ghost_,transform.position,transform.rotation);
            Sprite currenSprite =GetComponent<SpriteRenderer>().sprite;
            currentGhost.transform.localScale =this.transform.localScale;
            currentGhost.GetComponent<SpriteRenderer>().sprite =currenSprite;
            ghostDelaySeconds=ghostDelay;
            Destroy(currentGhost,0.6f);
            colldown_-=Time.deltaTime;
            if(atkSeconds>0){
            for(i=0;i<1;i++){
                atkSeconds -=1;
                attack_.attackdame += dameBuff;
                }  
        }
              
        }
        
    }
    if(colldown_<=0)
        {
            atkSeconds=1;
            attack_.attackdame -=dameBuff;
             makeGhost=false;
             colldown_=colldownSeconds;
        }
    }
}
