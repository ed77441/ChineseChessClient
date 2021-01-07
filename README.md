# ChineseChessClient

This project is developed using `.NET winform`, final project of algorithm class

### Demo Video
https://www.youtube.com/watch?v=z99WDiMR2go

## Description
* Client only focus on the view
* Use `C#` async to get reply from server
* Blind stands for blind chess, Strategic stands for strategic chess

### Login 
* You can only use **alphabet letters** and **number** on name
* Server ip can be configured at server side code

### Lobby
* You issue a chanllenge to others only if they are in idle state
* If someone issue a chanllenge to you, it will be automatically cancel

### Blind chess game
* If there is only one color left, then it is considered to be game over
* If there is no chess piece that isn't taken down in 20 turns, then it is considered to be a draw
* If there is no chess piece can defeat each other, then it is considered to be a draw
* Click forfeit to end the game

### Strategic chess game
* If one of the kind dies, then it is considered to be game over
* If there is no chess piece that isn't taken down in 20 turns, then it is considered to be a draw
* Also you and your opponent's view will be opposite, that means chess board is rotated by 180 degree 
* Click forfeit to end the game
