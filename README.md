# MDDFinal
- Unity Version : 2021.3.6f1

## 프로젝트 데모 영상/다운로드
- [데모영상 링크](https://vimeo.com/841713865?share=copy)

## 프로젝트 실행 전 필수 압축해제 파일 (Git LFS 무료 용량 초과로 인한 분할압축 해제 필요)
- Assets/Plugins/CoquiTTS/tts_model.zip 파일의 압축 해제 후 zip 파일 및 분할 압축 파일 제거
- Assets/Plugins/CoquiTTS/build/tts/tts.zip 파일의 압축 해제 후 zip 파일 및 분할 압축 파일 제거
- Assets/Plugins/CoquiTTS/dist/tts.zip 파일의 압축 해제 후 zip 파일 및 분할 압축 파일 제거
- Assets/Plugins/DeepSpeech/deepspeech-0.9.3-models.zip 파일의 압축 해제 후 zip 파일 및 분할 압축 파일 제거

## 설치
- 아나콘다 설치
  - [설치 링크](https://www.anaconda.com/download)
- 파이썬 가상환경 생성/활성화
```sh
$> conda create -n {가상환경 이름} python=3.8
$> conda activate {가상환경 이름}
```
- 파이썬 의존성 설치
```sh
(가상환경 이름) $> cd {유니티 프로젝트 경로}
(가상환경 이름) $> pip isntall -r Assets/requirements.txt
```
- 유니티에 가상환경 경로 입력
  - {유니티 프로젝트 경로}/Assets/pathinfo.txt 에 설치한 가상환경 경로 입력

## 실행
- 유니티 에디터에서 플레이 버튼 클릭
- 영어만 인식 가능

## 인공신경망 원본
- https://github.com/mozilla/DeepSpeech
- https://github.com/coqui-ai/TTS
- https://github.com/Svito-zar/gesticulator
