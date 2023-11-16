using UnityEngine;
using UnityEngine.UI;

public class LevelHealth : MonoBehaviour
{
    private bool flag = (true);
    [HideInInspector]
    public int levelHealth = 100;

    [Header("textName")]
    public Text MyText;
    
    void Update()
    {
        if (flag)
        {
            MyText.GetComponent<Text>().text = "" + levelHealth;
            if (levelHealth >= 100)
                levelHealth = 100;
            if (levelHealth < 0)
            {
                MyText.GetComponent<Text>().text = "Game over";
                Debug.Log("Game over");
                flag = false;
            }
            
        }
    }
}
