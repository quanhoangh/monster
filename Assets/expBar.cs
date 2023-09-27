using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class expBar 
{
    public event EventHandler onExperiencechanged;
    public event EventHandler onlevelchanged;
    public int level;
    public float experience;
    public float experieceToNextLevel;
    // Start is called before the first frame update


    public expBar(){
        level =0;
        experience=0;
        experieceToNextLevel =100;
    }
    public void AddExperience(int amount){
        experience += amount;
        if(experience >=experieceToNextLevel){
            level ++;
            experience -=experieceToNextLevel;
            if(onlevelchanged !=null) onlevelchanged(this,EventArgs.Empty);
        }
        if(onExperiencechanged !=null) onExperiencechanged(this,EventArgs.Empty);
    }
    public int GetlevelNumber(){
        return level;
    }

    public float GetExperienceNormalized(){
        return (float) experience/experieceToNextLevel;
        
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
}
