VR/AR 게임제작 기초 수업시간에 제작한 AppleCatch 게임입니다.<br/><br/>
![AppleCatch](https://github.com/J-WooHyeok/AppleCatch/assets/114277865/2494bf8f-d3fc-49ac-bccd-a67cbbe1eab3)

# 구현된 기능 <br/>
* Apple과 Basket, Bomb에 Ray와 RayCastHit를 사용하여 클릭한 지점으로 Basket이 이동하고, 충돌을 감지
* Random값을 이용하여 0~2까지는 Bomb, 3~10까지는 Apple이 떨어지도록 구현
* 떨어지는 위치 역시 Random.Range를 이용하여 x좌표와 y좌료를 -1, 0, 1중에 하나가 되도록 구현
* Apple에 속도 변수를 생성하여 시간이 지날수록 속도가 점점 빨라지게 구현
* Restart버튼 구현
