using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : SingletonBase<InputHandler>
{
    public KeyCode walkUp { get; set; }
    public KeyCode walkDown { get; set; }
    public KeyCode walkLeft { get; set; }
    public KeyCode walkRight { get; set; }
    public KeyCode interact { get; set; }
    public KeyCode showInventory { get; set; }

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
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("interactKey", "Space"));
        showInventory = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("inventoryKey", "I"));
    }

    void Awake()
    {
        SingletonAwake();
        DontDestroyOnLoad(gameObject);
    }
}
