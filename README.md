Fruit War (水果大作战)
=======

# Introduction

A cartoon-style 2D breakout game using Unity and its native 2D technology. 
Built with Unity 4.6 Beta on Windows 7 64-bit.

一款卡通风格的2D打砖块类游戏。游戏以动物和水果味主要角色。玩家操纵动物形状的档板和球，击打水果形状的砖块，获得分数奖励。画面卡通可爱，玩法轻松有趣但也有一定难度。

## 游戏简介：
可爱的小动物们发现了一个到处都是水果的神秘花园，这可把他们乐坏了。不过，要想吃到水果可没那么容易，快来帮帮他们吧。

## 操作指南：
左右方向键移动下面的小动物。
鼠标单击发射上面的小动物或发射子弹。
不断移动接住掉落的水果，吃到道具也会有相应的变化。
达到目标分后，吃掉五星即可过关。

# Download Links
- ~~应用宝：http://android.myapp.com/myapp/detail.htm?apkName=com.andong777.fruitwar~~
- ~~百度手机助手：http://shouji.baidu.com/game/item?docid=6950567~~

# To-dos

# Release Notes

## 12/23
- refactor SaveLoad and move the highscore list to SAE.
- implement client side functionality.
- hide the property when eaten.

## 12/19
- add filter of sensitive words. 
- add hint when the ball moves vertically.
- add blink effect when star appears.
- fix the bug that a property can be caught twice.
- modify the size of some sprites.

## 12/15
- fix the bug that text field can't type in.
- change the size of properties.
- beautify the end scene.

## 12/13
- fix a brick-counting bug due to tag defination.
- add hint text when player loses. 
- resolve missing sprites.
- add text description of properties.

## 12/12
- port this project from Unity 4.6 beta to 4.6 final.
- re-design UI layout based on new comprehension of uGUI.
- hide exit button and the corresponding code when built for web.
- fix the bug that life number display is different from the internal number.

## 9/3
- fix brick couting bug introduced in v1.4.
- fix mini ad banner bug.
- release version 1.5.

## 9/2
- fix several bugs about score:
	1. score is added twice when player quits.
	2. score doesn't run.
	3. total score doesn't clear when creating another game.
	4. prev button works incorrectly.
- improvement:
	1. eating skull should die.
	2. eating fruit plays audio.
	3. remove annoying audio of rank scene.
- release version 1.4.

## 9/1
- test on Meizu MX 2 and modify UI.
- add youmi advertisement.
- add introduction and redesign logo.
- add exit button.

## 8/31 A.M.
- add hint bar.
- release version 1.3.

## 8/30 P.M.
- add shoot direction rotating functionality, to let player control shoot direction.
- release version 1.2.
- fix bug of appearing white line between two pictures when scrolling background.

## 8/30 A.M.
- prev and next buttons can hide when no more content.
- improve help scene UI design to better support different resolutions.
- fix end scene's bug of treating place holder as player's name when player directly hits enter button.
- now even if player doesn't complete a stage, the score earned in this stage can also be added up to total score.
- fix rank scene bug: need to click prev button to show result.
- modify several properties to make them easier to distinguish and catch.

## 8/29 P.M.
- add pause button.
- release version 1.1.

## 8/29 A.M.
- fix name input bugs.
- release version 1.0.

## 8/28 P.M.
- design title and logo.
- add help pictures.
- redesign audio management.
- complete help scene.
- add support for different resolutions.
- fix bugs: 
	1. respawning bricks doesn't remove old bricks.
	2. fireball fx doesn't work.
	3. clicking reset button triggers ball shoot.
	4. spawning bricks out of screen.
	5. next button doesn't work.
	6. switching stage bugs.

## 8/28 A.M.
- add more partical effects.

## 8/27 P.M.
- add custom fonts.
- optimize paddle collider shape.
- adding ui audio effects.
- reorganise the project.

## 8/26 P.M.
- add music and fx.

## 8/25 P.M.
- stretch several background pictures to fit for mobile screens.
- use final game art.
- complete UI part.

## 8/25 A.M.
- complete UI.
- modify the functionality to spawn bricks.

## 8/24 P.M.
- implement score and rank functionality.
- add drunk ball mode.

## 8/23 P.M.
- rebuild game manager.

## 8/20 P.M.
- Added textures and some animations.

## 8/18 P.M.
- Rebuild fireball.
- Implement rope.
- Add very naive textures.

## 8/18 A.M.
- Finished fireball.

## 8/17 P.M.
- Implementing fireball functionality.
- Modify ball speed control.
- Fix bug that check lose when not.

## 8/17 A.M.
- Implement gun property and fire gun functionality.
- Add no-bricks lose condition.

## 8/16 P.M.
- Implement several properties.

## 8/16 A.M.
- Improve brick generating method.
- Make target score change as brick number change.
- Add target score display.

## 8/15 P.M.
- project begins here.