using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class TTSRunner : MonoBehaviour
{
    private PlayDirector _playDirector; // PlayDirector 클래스
    private SkeletonHandler _skeletonHandler; // 스켈레톤 클래스
    private string _outputWavFilePath; // 생성한 발화 오디오 경로

    private void Awake()
    {
        this._playDirector = FindObjectOfType<PlayDirector>();
        this._skeletonHandler = FindObjectOfType<SkeletonHandler>();
    }

    /**
     * TTS 실행.
     */
    public void RunTts(string outputText)
    {
        Debug.Log("TTS 시작");
        
        try
        {
            // 프로세스 정보
            var command = Path.Combine(Application.dataPath, @"Plugins\CoquiTTS\dist\tts.exe");
            var ttsModelPath = Path.Combine(Application.dataPath, @"Plugins\CoquiTTS\tts_model.pth");
            var ttsConfigPath = Path.Combine(Application.dataPath, @"Plugins\CoquiTTS\tts_config.json");
            var vocoderModelPath = Path.Combine(Application.dataPath, @"Plugins\CoquiTTS\vocoder_model.pth");
            var vocoderConfigPath = Path.Combine(Application.dataPath, @"Plugins\CoquiTTS\vocoder_config.json");
            var outputFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "tts.wav";
            this._outputWavFilePath = Path.Combine(Application.persistentDataPath, outputFileName);
            var args = "\"" + ttsModelPath + "\" \"" + ttsConfigPath + "\" \"" + vocoderModelPath + "\" \""
                       + vocoderConfigPath + "\" \" " + outputText + "\" \"" + this._outputWavFilePath + "\"";
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

        Debug.Log("TTS 끝");
            
        // 아바타 실행
        this._skeletonHandler.RunSkeleton(outputText, this._outputWavFilePath);
    }
}
