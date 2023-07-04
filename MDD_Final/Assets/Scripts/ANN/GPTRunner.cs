using System;
using UnityEngine;
using Python.Runtime;

public class GPTRunner : MonoBehaviour
{
    private string _outputText; // GPT 실행 결과

    /**
     * GPT 실행.
     */
    public string RunGpt(string inputText)
    {
        Debug.Log("GPT 시작");

        try
        {
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                dynamic gpt = Py.Import("gpt");
                dynamic outputText = gpt.main(inputText);
                this._outputText = (string) outputText;
                Debug.Log("GPT Result : " + this._outputText);
            }
            PythonEngine.Shutdown();
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return null;
        }

        Debug.Log("GPT 끝");
        
        return this._outputText;
    }
}
