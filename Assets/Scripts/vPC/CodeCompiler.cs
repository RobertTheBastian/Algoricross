using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeCompiler : MonoBehaviour
{

    CodeEditor codeEditor;
    string code;


    void Start()
    {
        codeEditor = GetComponent<CodeEditor>();  
    }



    void CompileCode()
    {
        code = codeEditor.codeString;

        if(string.IsNullOrEmpty(code))
        {
            Debug.Log("no code");
        }
        else
        {
            GenerateLines();
        }
    }



    /// <summary>
    /// Code example:
    ///
    /// var x = 4;
    /// var y = 0;
    ///
    /// loop(100)
    /// {
    ///     x +=1;
    /// }
    ///
    /// if(x<100)
    /// {
    ///     
    /// } else if(x>100 && x<200)
    /// {
    ///
    /// } else
    /// {
    ///
    /// }
    /// </summary>
     //go through the code and generate a procedural code
    void GenerateLines()
    {
      

        //seperate statements into their own lines
        

        foreach(string line in code.Split('\n'))
        {
            //Remove white space
            if(!string.IsNullOrWhiteSpace(line))
            {

            }
        }

       

        

    }


    /// <summary>
    /// Things to implement:
    ///
    /// Handle variable definition
    /// handle variable assignments
    /// handle Loops
    /// Handle conditions (if,elseif, else)
    /// Handle 
    /// </summary>

    void CreateImage()
    {

    }

    void RunImage()
    {

    }
  
}


public struct ProgramGrid
{
    int width;
    int height;

}
