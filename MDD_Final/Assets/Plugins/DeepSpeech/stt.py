from deepspeech import Model
import argparse
import wave
import numpy as np


def main(model_path, audio_path):
    ds = Model(model_path)
    fin = wave.open(audio_path, "rb")
    audio = np.frombuffer(fin.readframes(fin.getnframes()), np.int16)
    fin.close()
    text = ds.stt(audio)
    print(text)


if __name__ == '__main__':
    parser = argparse.ArgumentParser()
    parser.add_argument('model_path', type=str, help='Model Path')
    parser.add_argument('audio_path', type=str, help='Audio Path')
    args = parser.parse_args()
    main(args.model_path, args.audio_path)
