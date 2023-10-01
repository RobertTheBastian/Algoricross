using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodeEditor : MonoBehaviour
{

    public TMPro.TMP_Text codeTextUI;
    public TMPro.TMP_Text lineNumberUI;

    public string codeString;
    string validGlyphs = "abcdefghijklmnopqrstuvwxyz 1234567890 +=-*/(){}!\n";
    int cursorLocation;
    int cursorLineNumber;
    int cursorColumnNumber;


    private void Start()
    {
        cursorLocation = 0;
        cursorLineNumber = 1;
        cursorColumnNumber = 1;
        codeString = "";

    }

    private void Update()
    {
        HandleControlKeys();
        HandleNavigationkeys();
        HandleTypingKeys();

        codeTextUI.text = codeString;

        HandleLineNumbers();
        HandleCursor();
       
    }

    private void HandleTypingKeys()
    {
        foreach(char c in Input.inputString)
        {

            //Handle backspace.
            if (c == '\b')
            {
                if(codeString.Length !=0)
                {
                    cursorLocation--;
                    codeString = codeString.Substring(0, codeString.Length - 1);
                }
            }

            else if(validGlyphs.Contains(c.ToString()))
            {

                if(cursorColumnNumber == 48 && c != '\n')
                {
                    codeString += '\n';
                    cursorLocation++;
                }

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

    private void HandleControlKeys()
    {
        //probably wont need this for now
    }

    private void HandleNavigationkeys()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
          if(cursorLocation >0)
            {
                cursorLocation--;
            }
        }
    }

    private void HandleLineNumbers()
    {
        string n = "";
        int lines = codeString.Split('\n').Length;
        for (int i = 0; i < lines; i++)
        {
            n += (i + 1) + "\n";
        }

        lineNumberUI.text = n;
    }


    //monospaced font should, in theory, make this fairly easy.
    private void HandleCursor()
    {
        //get the line number the cursor is on.
        string codeToCursor = codeString.Substring(0, cursorLocation);
        string[] splitByLine = codeToCursor.Split('\n');
        cursorLineNumber = splitByLine.Length;

       

        //get the character number the cursor is on.
        cursorColumnNumber = splitByLine[cursorLineNumber-1].Length+1;

        Debug.Log("cursor is on:  l" + cursorLineNumber.ToString() + "c" + cursorColumnNumber.ToString());

        //Set cursor location
        ///get max character width of window, divide window rect by that
        ///get max lines displayed on window, divide window rect height by that

  

    }

    public void RunCode()
    {
        Debug.Log("running code");
    }
}
