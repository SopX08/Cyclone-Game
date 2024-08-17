using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptScript : MonoBehaviour
{
    public GameObject Prompt;
    
    /*public GameObject Prompt2;
    public GameObject Prompt3;
    public GameObject Prompt4;
    public GameObject Prompt5;
    */

    public void ClosePrompt()
    {
        if (Prompt!=null)
        {
            Prompt.SetActive(false);
        }
    }
    /*
    public void ClosePrompt2()
    {
        if (Prompt2 != null)
        {
            Prompt2.SetActive(false);
        }
    }
    public void ClosePrompt3()
    {
        if (Prompt3 != null)
        {
            Prompt3.SetActive(false);
        }
    }
    public void ClosePrompt4()
    {
        if (Prompt4 != null)
        {
            Prompt4.SetActive(false);
        }
    }
    public void ClosePrompt5()
    {
        if (Prompt5 != null)
        {
            Prompt5.SetActive(false);
        }
    }
    */
    public void Period()
    {

    }
}
