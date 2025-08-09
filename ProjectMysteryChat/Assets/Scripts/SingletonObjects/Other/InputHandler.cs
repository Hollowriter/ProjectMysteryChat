using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : SingletonBase<InputHandler>
{
    public KeyCode walkUp { get; set; }
    public KeyCode walkDown { get; set; }
    public KeyCode walkLeft { get; set; }
    public KeyCode walkRight { get; set; }
    public KeyCode walkUpArrow { get; set; }
    public KeyCode walkDownArrow { get; set; }
    public KeyCode walkLeftArrow { get; set; }
    public KeyCode walkRightArrow { get; set; }
    public KeyCode interact { get; set; }
    public KeyCode showInventory { get; set; }
    public KeyCode showGameplayMenu { get; set; }

   public bool inputDetected()
   {
        if (Input.anyKey)
            return true;
        return false;
   }

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        SetActivated(true);
        walkUp = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "W"));
        walkDown = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "S"));
        walkLeft = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        walkRight = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        walkUpArrow = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upArrowKey", "UpArrow"));
        walkDownArrow = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downArrowKey", "DownArrow"));
        walkLeftArrow = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftArrowKey", "LeftArrow"));
        walkRightArrow = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightArrowKey", "RightArrow"));
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("interactKey", "Space"));
        showInventory = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("inventoryKey", "E"));
        showGameplayMenu = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("gameplayMenuKey", "Escape"));
    }

    void Awake()
    {
        SingletonAwake();
        DontDestroyOnLoad(gameObject);
    }
}
