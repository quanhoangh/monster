using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lateWidown : MonoBehaviour
{
    private Text levelText;
    private Image experienceBarImage;
    private expBar levelSystem;
    
    // Start is called before the first frame update
    private void Awake(){
        levelText =transform.Find("levelText").GetComponent<Text>();
        experienceBarImage=transform.Find("experienceBarImage").Find("bar").GetComponent<Image>();
        setExperienceBarSize(.5f);
        SetlevelNumber(7);
    }
    private void setExperienceBarSize(float experineceNormalized){
        experienceBarImage.fillAmount= experineceNormalized;
    }
    private void SetlevelNumber(int levelNumber){
        levelText.text ="LEVEL"+(levelNumber+1) ;
    }
    public void SetlevelSystem(expBar levelSystem){
        this.levelSystem=levelSystem;
        SetlevelNumber(levelSystem.GetlevelNumber());
        setExperienceBarSize(levelSystem.GetExperienceNormalized());

        levelSystem.onExperiencechanged += levelSystem_onExperiencechanged;
        levelSystem.onlevelchanged += levelSystem_onlevelchanged;

    }
    private void levelSystem_onlevelchanged (object sender,System.EventArgs e){
        setExperienceBarSize(levelSystem.GetExperienceNormalized());
    }
    private void levelSystem_onExperiencechanged(object sender,System.EventArgs e){
        setExperienceBarSize(levelSystem.GetExperienceNormalized());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
