## Unity의 기능 정리
개요 : TeamRocket에서 피드백한 코드들을 모아둡니다.

### Component
- RopeCreate\
![해답](https://user-images.githubusercontent.com/93506849/197138318-10b8793a-9dbc-4a1c-86fa-6283d9dc5208.JPG)\
-Start()에서 LineRenderer을 추가해 준다.\
-Nodes에 시작점을 넣어주고, HingeJoint2D를 생성해주면서 Nodes에 업데이트 해준다.\
-Update()에서 RenderLine()함수를 생성해 주고 계속 업데이트 해준다.\
![KakaoTalk_20221021_163401491](https://user-images.githubusercontent.com/93506849/197139444-6bcea221-98c0-466a-b7bb-5ba74f7fa19e.gif)
