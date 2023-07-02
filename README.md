# MDDFinal
- Unity Version : 2021.3.6f1
- 용량 문제로 클라우드에 업로드함(아래 링크).
- 프로젝트 내 사용 인공신경망
  - GPT-2
  - Gesticulator
  - DeepSpeech(STT)
  - Coqui TTS
- 파이썬 패키지 충돌로 DeepSpeech와 Coqui STT는 pyinstaller를 사용하여 exe 파일로 패키징하여 실행함.


## 프로젝트 다운로드
- [다운로드 링크](http://naver.me/xr6kzEyS)

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
