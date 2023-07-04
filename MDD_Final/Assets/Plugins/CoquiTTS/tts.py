from TTS.api import TTS
import argparse


def main(tts_model_path, tts_config_path, vocoder_model_path, vocoder_config_path, text, save_path):
    tts = TTS()
    tts.load_tts_model_by_path(
        tts_model_path,
        tts_config_path,
        vocoder_model_path,
        vocoder_config_path,
        False
    )
    tts.tts_to_file(text=text, file_path=save_path)


if __name__ == '__main__':
    parser = argparse.ArgumentParser()
    parser.add_argument('tts_model_path', type=str, help='TTS Model Path')
    parser.add_argument('tts_config_path', type=str, help='TTS Config Path')
    parser.add_argument('vocoder_model_path', type=str, help='Vocoder Model Path')
    parser.add_argument('vocoder_config_path', type=str, help='Vocoder Config Path')
    parser.add_argument('text', type=str, help='Text')
    parser.add_argument('save_path', type=str, help='Save Path')
    args = parser.parse_args()
    main(args.tts_model_path, args.tts_config_path, args.vocoder_model_path, args.vocoder_config_path, args.text, args.save_path)
