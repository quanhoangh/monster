using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerExp : MonoBehaviour
{
    public float maxexp;
    public float currenExp;
    public exp exp;
    public Attack dame;
    public HeathPlayer hp;
    private int level=1;
    public Text expLevel;
    public Text timer;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        currenExp=0;
        
        exp.SetMaxExp(maxexp);
        exp.SetExp(currenExp);
    }

    // Update is called once per frame
    void Update()
    { 
        exp.SetExp(currenExp);
        level_up();
        time += Time.deltaTime;
        timer.text ="TIME:\n"+Math.Round(time,1);
        
        }
    public void level_up(){
         expLevel.text="" + level;
       
        if(currenExp>=maxexp){
            currenExp=currenExp-maxexp;
            exp.SetMaxExp(maxexp); 
            exp.SetExp(currenExp);
            level ++;
            dame.attackdame += 10;
            hp.maxHeath =hp.maxHeath +500;
            hp.currenHeath += 500;
            if(level>=3){
                maxexp +=maxexp* 0.3f;
            }else if(level>=10){
                maxexp +=maxexp* 0.2f;
            }else if(level>=50){
                maxexp +=maxexp* 0.5f;
            }else{
                maxexp +=maxexp* 0.4f;
            }
            
        }
    }
}
