using UnityEngine;
using UnityEngine.UI;

public class HeroChange : MonoBehaviour
{
    [Header("Wizard Hero")]
    public Image wizardHeroButton;
    public Image wizardHeroImage;
    
    [Header("Knight Hero")]
    public Image knightHeroButton;
    public Image knightHeroImage;
    
    [Header("Armored Hero")]
    public Image armoredHeroButton;
    public Image armoredHeroImage;
    
    [Header("Elf Hero")]
    public Image elfHeroButton;
    public Image elfHeroImage;
    
    [Header("Man Hero")]
    public Image manHeroButton;
    public Image manHeroImage;
    
    [Header("BlackSmith Hero")]
    public Image blackSmithHeroButton;
    public Image blackSmithHeroImage;
    
    private string _currentHero;

    private Color transparent = new Color(1, 1, 1, 0.5f);
    private Color nonTransparent = new Color(1, 1, 1, 1f);
    void Start()
    {
        _currentHero = PlayerPrefs.GetString("hero");
        if (_currentHero == string.Empty)                    
        {                                                
            _currentHero = "knight";                     
            Change(_currentHero);                    
        }
        ChangeUI();
    }

    public void Change(string hero)         
    {                                       
        _currentHero = hero;            
        PlayerPrefs.SetString("hero", _currentHero);
        ChangeUI();
        Debug.Log(_currentHero);    
    }                                       
    
    public void ChangeUI()                                                               
    {                                                                                    
        if (_currentHero == "wizard")
        {
            wizardHeroImage.color = nonTransparent;
            wizardHeroButton.color = nonTransparent;

            armoredHeroImage.color = transparent;
            armoredHeroButton.color = transparent;
            
            elfHeroImage.color = transparent;
            elfHeroButton.color = transparent;
            
            manHeroImage.color = transparent;
            manHeroButton.color = transparent;
            
            blackSmithHeroImage.color = transparent;
            blackSmithHeroButton.color = transparent;
            
            knightHeroImage.color = transparent;
            knightHeroButton.color = transparent;
        }                                                                                
        else if (_currentHero == "armored")                                               
        {                                                                                
            wizardHeroImage.color = transparent;
            wizardHeroButton.color = transparent;

            armoredHeroImage.color = nonTransparent;
            armoredHeroButton.color = nonTransparent;
            
            elfHeroImage.color = transparent;
            elfHeroButton.color = transparent;
            
            manHeroImage.color = transparent;
            manHeroButton.color = transparent;
            
            blackSmithHeroImage.color = transparent;
            blackSmithHeroButton.color = transparent;
            
            knightHeroImage.color = transparent;
            knightHeroButton.color = transparent;
        }                                                                                
        else if (_currentHero == "elf")                                               
        {                                                                                
            wizardHeroImage.color = transparent;
            wizardHeroButton.color = transparent;

            armoredHeroImage.color = transparent;
            armoredHeroButton.color = transparent;
            
            elfHeroImage.color = nonTransparent;
            elfHeroButton.color = nonTransparent;
            
            manHeroImage.color = transparent;
            manHeroButton.color = transparent;
            
            blackSmithHeroImage.color = transparent;
            blackSmithHeroButton.color = transparent;
            
            knightHeroImage.color = transparent;
            knightHeroButton.color = transparent;
        }   
        else if (_currentHero == "man")                                               
        {                                                                                
            wizardHeroImage.color = transparent;
            wizardHeroButton.color = transparent;

            armoredHeroImage.color = transparent;
            armoredHeroButton.color = transparent;
            
            elfHeroImage.color = transparent;
            elfHeroButton.color = transparent;
            
            manHeroImage.color = nonTransparent;
            manHeroButton.color = nonTransparent;
            
            blackSmithHeroImage.color = transparent;
            blackSmithHeroButton.color = transparent;
            
            knightHeroImage.color = transparent;
            knightHeroButton.color = transparent;  
        }  
        else if (_currentHero == "blackSmith")                                               
        {                                                                                
            wizardHeroImage.color = transparent;
            wizardHeroButton.color = transparent;

            armoredHeroImage.color = transparent;
            armoredHeroButton.color = transparent;
            
            elfHeroImage.color = transparent;
            elfHeroButton.color = transparent;
            
            manHeroImage.color = transparent;
            manHeroButton.color = transparent;
            
            blackSmithHeroImage.color = nonTransparent;
            blackSmithHeroButton.color = nonTransparent;
            
            knightHeroImage.color = transparent;
            knightHeroButton.color = transparent;
        }
        else if (_currentHero == "knight")                                               
        {                                                                                
            wizardHeroImage.color = transparent;
            wizardHeroButton.color = transparent;

            armoredHeroImage.color = transparent;
            armoredHeroButton.color = transparent;
            
            elfHeroImage.color = transparent;
            elfHeroButton.color = transparent;
            
            manHeroImage.color = transparent;
            manHeroButton.color = transparent;
            
            blackSmithHeroImage.color = transparent;
            blackSmithHeroButton.color = transparent;
            
            knightHeroImage.color = nonTransparent;
            knightHeroButton.color = nonTransparent;
        }  
    }                                                                                    
}
