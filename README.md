# Unity ObjectSpawner
Simple object spawner tool for unity

![AppVeyor](https://img.shields.io/badge/build-passing-brightgreen)

![image](https://user-images.githubusercontent.com/73479696/165824474-42bc6d21-9142-4182-8928-dc9cd2f582e0.png)
## Info
* [About](#about)
* [Setup](#setup)
* [Usage](#usage)
* [Examples](#examples)
* [License](#license)

## About
This project made for simplification of level creation.
Tested on Unity 2020.3 (Windows).

## Setup
To run this project you need Unity version 2018.4 or higher.
1. Download project code and unpack it.
2. In Unity Editor open Assets folder and create "Editor" folder here.

![image](https://user-images.githubusercontent.com/73479696/165829852-c739bfa2-9253-44ae-8335-612b62ae2640.png)

3. Copy all extracted code to this folder.
4. Rebuld C# project (it might be rebuild automatically).
5. When new toolbar item named "My Tools" appears, this means you did all correct.
![image](https://user-images.githubusercontent.com/73479696/165829309-07cc1827-0344-4a57-b03a-0d3d18bb32b7.png)
6. Click on new toolbar item and open "Object Spawner" tool.
7. Enjoy :)

## Usage
![Object_SpawnerImage](https://user-images.githubusercontent.com/73479696/165831260-7f9990ad-1dbd-4809-84f1-6bd95a66f60c.jpg)

**This tool works extremely easy.**  <br />
**1** - Change name of Parent object (Parent object in this case includes all spawned objects, this makes Hierarchy less filled). <br />
**2** - Drag here parent for spawned objects.  <br />
**3** - Set base objects name. For example "Potato", so first spawned object will have name "Potato0", second "Potato1" and so on. <br />
**4** - Set object current id, this id by default is 0 and every spawned object it increases, so postfix will be 0, 1, 2 etc. <br />
**5** - Set scale for every spawned object.  <br />
**6** - Change size of area objects spawn in. <br />
**7** - Drag here object you whant to spawn. <br />
**8** - Change type of spawn Quad, Circle, Box, etc.  <br />
**9** - Create parent for all objects. It automatically set it in parent object field (2). <br />
**10** - Change how many objects to spawn. <br />
**11** - Objects spawn button. <br />
## Examples 
<br /> QUAD spawn type <br />
![image](https://user-images.githubusercontent.com/73479696/165950291-ba45a6bc-2d15-49dd-a735-3233ae30126e.png)
<br /> CIRCLE spawn type <br />
![image](https://user-images.githubusercontent.com/73479696/165951762-fa166aa6-5c9f-4adb-b58f-b8dfbf662149.png)
<br /> CUBE spawn type <br />
![image](https://user-images.githubusercontent.com/73479696/165951845-717f84c7-9264-496e-934f-03c404e13f50.png)
<br /> SPHERE spawn type <br />
![image](https://user-images.githubusercontent.com/73479696/165951949-b823cc2a-b798-4d40-b147-31d7f9016aa4.png)
## License
Unity ObjectSpawner licensed under the MIT License, see LICENSE for more information.


