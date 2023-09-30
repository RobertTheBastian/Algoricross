using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeEditor : MonoBehaviour
{

    public TMPro.TMP_Text codeTextUI;
    public string codeString;
    string validGlyphs = "abcdefghijklmnopqrstuvwxyz 1234567890 +=-*/(){}!\n";
    int cursorLocation;


    private void Start()
    {
        cursorLocation = 0;
        codeString = "";

    }

    private void Update()
    {

        handleControlKeys();
        handleNavigationkeys();
        handleTypingKeys();

        //Add method for handling the cursor (not mouse, oldschool cursor)

        Debug.Log(cursorLocation);
        codeTextUI.text = codeString;
    }

    private void handleTypingKeys()
    {
        foreach(char c in Input.inputString)
        {
            Debug.Log(c);

            //Handle backspace.
            if (c == '\b')
            {
                if(codeString.Length !=0)
                {
                    cursorLocation--;
                    codeString = codeString.Substring(0, codeTextUI.text.Length - 1);
                }
            }

            else if(validGlyphs.Contains(c.ToString()))
            {
               
                if (string.IsNullOrEmpty(codeString) || cursorLocation == codeString.Length)
                {
                    codeString += c;
                }
                else
                {
                   codeString = codeString.Insert(cursorLocation, c.ToString());
                }
                cursorLocation++;
            }
        }
    }

    private void handleControlKeys()
    {

    }

    private void handleNavigationkeys()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
          if(cursorLocation >0)
            {
                cursorLocation--;
            }
        }
    }


    public void RunCode()
    {
        Debug.Log("running code");
    }
}
