# Unity Flappy Bird Team Project

## 프로젝트 개요
이 프로젝트는 **5인 협동 Unity 실습용 Flappy Bird 게임**입니다.  
기본적인 플레이 기능을 구현하고, Git을 통한 협업 과정을 연습하는 것을 목표로 합니다.

---

## 게임 설명
플레이어는 화면을 클릭(또는 스페이스바 입력)하여 새를 위로 날게 하고,  
파이프 사이를 통과하면서 점수를 얻습니다.  
파이프나 바닥에 닿으면 게임 오버가 됩니다.

---

## 팀 구성 및 역할

| 이름 | 역할 | 주요 담당 |
|------|------|-----------|
| 팀장: 이소민| Repo 관리, 코드 리뷰, 통합 | 프로젝트 관리 및 병합 |
| Player 담당: 차태완 | 새의 점프 및 충돌 로직 | PlayerController.cs |
| Pipe 담당: 이진송 | 파이프 생성 및 이동 | PipeSpawner.cs, PipeMovement.cs |
| UI 담당: 신태환 | 점수 표시, 게임오버 UI | UIManager.cs |
| 디자인 담당: 이소민 | 배경, 스프라이트, 프리팹 제작 | Sprites/, Prefabs/ |

---

## 프로젝트 구조
```
Assets/
 ├─ Scenes/
 │   └─ MainScene.unity
 ├─ Scripts/
 │   ├─ PlayerController.cs
 │   ├─ PipeSpawner.cs
 │   ├─ PipeMovement.cs
 │   ├─ GameManager.cs
 │   └─ UIManager.cs
 ├─ Prefabs/
 │   ├─ Player.prefab
 │   ├─ Pipe.prefab
 │   └─ Ground.prefab
 ├─ Sprites/
 │   ├─ Bird.png
 │   ├─ Pipe.png
 │   ├─ Background.png
 │   └─ Ground.png
 └─ UI/
     ├─ Canvas.prefab
     ├─ ScoreText.prefab
     └─ GameOverPanel.prefab
```

---

## Git 브랜치 전략
- **main**: 완성된 안정 버전  
- **develop**: 통합 개발용 브랜치  
- **feature/***: 개인 작업용 브랜치  
  - 예시:
    - feature/player
    - feature/pipe
    - feature/ui
    - feature/design
    - feature/game-manager

작업 순서 예시:
```bash
git checkout develop
git pull
git checkout -b feature/player
# 코드 작업 후
git add .
git commit -m "Add player jump logic"
git push origin feature/player
# → PR 생성 후 팀장 리뷰 후 병합
```

---

## 주요 스크립트 요약

### PlayerController.cs
- 클릭 시 점프 (AddForce)
- 파이프/땅과 충돌 시 GameOver 호출

### PipeSpawner.cs
- 일정 시간 간격으로 파이프 생성
- Y 좌표 랜덤

### PipeMovement.cs
- 파이프를 왼쪽으로 이동
- 화면 밖으로 나가면 제거

### GameManager.cs
- 게임 오버 및 재시작 로직
- 싱글톤 구조 (GameManager.instance)

### UIManager.cs
- 점수 UI 갱신, 게임오버 패널 표시

---

## 사용 에셋
- 자유 사용 가능한 스프라이트  (https://github.com/samuelcust/flappy-bird-assets)
- 배경, 파이프, 새, 땅 이미지 필요  

---

## 실행 방법
1. Unity 2022.3.x LTS 버전 사용  
2. MainScene.unity 열기  
3. ▶️ Play 버튼 클릭  

---

## 추가 아이디어
- 난이도 증가 (시간에 따라 파이프 속도 상승)
- 점수 저장 (PlayerPrefs 사용)
- 사운드 효과 추가

