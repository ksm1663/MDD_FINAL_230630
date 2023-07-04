using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class STTRunner : MonoBehaviour
{
    private PlayDirector _playDirector; // PlayDirector 클래스
    private GPTRunner _gptRunner; // GPT 클래스
    private TTSRunner _ttsRunner; // TTS 클래스
    private string _inputText; // STT 결과

    private void Awake()
    {
        this._playDirector = FindObjectOfType<PlayDirector>();
        this._gptRunner = FindObjectOfType<GPTRunner>();
        this._ttsRunner = FindObjectOfType<TTSRunner>();
    }

    /**
     * STT 실행.
     */
    public void RunStt(AudioClip inputAudioClip)
    {
        Debug.Log("STT 시작");
        
        // 오디오 클립을 wav 파일로 저장
        var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        var inputWavFileName = timestamp + "stt.wav";
        SavWav.Save(inputWavFileName, inputAudioClip);

        try
        {
            // 프로세스 정보
            var command = Path.Combine(Application.dataPath, @"Plugins\DeepSpeech\dist\stt.exe");
            var inputWavFilePath = Path.Combine(Application.persistentDataPath, inputWavFileName);
            var modelPath = Path.Combine(Application.dataPath, @"Plugins\DeepSpeech\deepspeech-0.9.3-models.pbmm");
            var args = "\"" + modelPath + "\" \"" + inputWavFilePath + "\"";
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = command;
            startInfo.Arguments = args;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            
            // 프로세스 시작
            var process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            
            // 결과값 출력
            this._inputText = process.StandardOutput.ReadToEnd();
            Debug.Log("STT Result : " + this._inputText);
            
            // 프로세스 종료
            process.WaitForExit();
            process.Close();
        }
        catch (Exception e)
        {
            Debug.LogError(e.ToString());
            this._playDirector.SetPlaying(false);
            return;
        }
        
        Debug.Log("STT 끝");
            
        // GPT 실행
        var outputText = this._gptRunner.RunGpt(this._inputText);
             
        // // TTS 실행
        if (outputText != null) this._ttsRunner.RunTts(outputText);
        else this._playDirector.SetPlaying(false);
    }
}
