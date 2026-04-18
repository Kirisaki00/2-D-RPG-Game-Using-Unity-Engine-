<div align="center">

<!-- HEADER BANNER -->
<img src="https://capsule-render.vercel.app/api?type=waving&color=0d1117,1a1a2e,16213e,0f3460&height=200&section=header&text=RPG%20Game%202D&fontSize=60&fontColor=c8a951&fontAlignY=38&desc=A%202D%20Action-RPG%20built%20with%20Unity&descAlignY=58&descColor=8ecae6&animation=fadeIn" width="100%"/>

<br/>

![Unity](https://img.shields.io/badge/Unity-2022.x-black?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![Genre](https://img.shields.io/badge/Genre-Action%20RPG-c8a951?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-In%20Development-success?style=for-the-badge)

<br/>

> *A pixel-art action RPG set in a dark gothic world — explore castle ruins, fight undead warriors, and collect gold across multiple handcrafted scenes.*

</div>

---

## ⚔️ Overview

**RPG Game 2D** is a side-scrolling action RPG developed in **Unity** with a gothic, moonlit pixel-art aesthetic. You play as a warrior navigating through castle ramparts, dungeon corridors, and dark cityscapes — slashing through skeleton enemies, collecting loot from treasure chests, and surviving hazardous environments like spike traps and rising water.

---

## 🎮 Gameplay Features

| Feature | Description |
|---|---|
| 🗡️ **Combat System** | Melee attacks with smooth sword-slash animations |
| 💰 **Gold Collection** | Collect coins and loot treasure chests across levels |
| 💀 **Enemy AI** | Skeleton warriors that patrol and engage the player |
| ❤️ **HP System** | Real-time health tracking displayed on the HUD |
| 🧱 **Platform Levels** | Multi-layered platforming across rooftops, bridges & dungeons |
| 🌙 **Pixel Art Visuals** | Gothic night-time atmosphere with a glowing moon background |
| 🔊 **Audio** | Full audio integration including ambient and combat sounds |
| 📦 **Collectibles** | Treasure chests, gold coins, and in-world pickups |

---

## 🖼️ Screenshots

<div align="center">

| Moonlit Rooftops | Castle Dungeons |
|:---:|:---:|
| *Warrior on rooftop under a full moon* | *Skeleton enemies patrol stone corridors* |

| Chest Exploration | Multi-Floor Dungeon |
|:---:|:---:|
| *Discovering loot in the wild* | *Navigating vertical dungeon architecture* |

> 📽️ **Gameplay video available** — see the full demo for combat, movement, and exploration in action.

</div>

---

## 🗂️ Repository Structure

```
RPG_Game_2D/
│
├── 📁 Assets/                  # All game assets
│   ├── Scenes/                 # Unity scene files (multiple levels)
│   ├── Scripts/                # C# gameplay scripts
│   ├── Sprites/                # Pixel art characters & environments
│   ├── Audio/                  # Sound effects & music
│   ├── Prefabs/                # Reusable game objects
│   └── UI/                     # HUD elements (HP, Gold display)
│
├── 📁 GameBuild/               # Compiled Windows build
│   ├── RPG_Game_2D.exe         # Main executable
│   ├── RPG_Game_2D_Data/       # Game data files
│   ├── MonoBleedingEdge/       # Mono runtime
│   ├── D3D12/                  # DirectX 12 support
│   └── UnityPlayer.dll         # Unity player library
│
├── 📁 Packages/                # Unity package dependencies
├── 📁 ProjectSettings/         # Unity project configuration
├── 📁 .vscode/                 # VS Code editor settings
│
├── Assembly-CSharp.csproj      # C# project assembly file
├── RPG_Game_2D.sln             # Visual Studio solution
├── RPG_Game_2D.slnx            # Solution config
├── Warrior_Sheet-Effect.png    # Warrior sprite sheet
└── .gitignore                  # Unity gitignore rules
```

---

## 🚀 Getting Started

### ▶️ Play the Game (Pre-built)

1. Navigate to the `GameBuild/` folder
2. Run `RPG_Game_2D.exe`
3. No installation required — runs on **Windows** out of the box

### 🛠️ Open in Unity (Development)

**Prerequisites:**
- [Unity Hub](https://unity.com/download) with Unity **2022.x** or compatible version
- [Visual Studio](https://visualstudio.microsoft.com/) or VS Code with C# extension

**Steps:**
```bash
# 1. Clone the repository
git clone https://github.com/Kirisaki00/RPG_Game_2D.git

# 2. Open Unity Hub → Add Project → Select the cloned folder

# 3. Open the project and load your desired scene from Assets/Scenes/

# 4. Press ▶ Play in the Unity Editor to test
```

---

## 🎯 Controls

| Key | Action |
|-----|--------|
| `A` / `←` | Move Left |
| `D` / `→` | Move Right |
| `Space` | Jump |
| `Left Click` / `Z` | Attack |
| `E` | Interact / Open Chest |

---

## 🧰 Tech Stack

- **Engine:** Unity 2022.x
- **Language:** C# (.NET)
- **Renderer:** Universal Render Pipeline (URP) / Built-in
- **Graphics API:** DirectX 12 (D3D12)
- **IDE:** Visual Studio / VS Code
- **Version Control:** Git + GitHub
- **Audio:** Unity Audio Mixer
- **Art Style:** Pixel Art (2D Sprites)

---

## 🗺️ Scenes / Levels

| Scene | Description |
|-------|-------------|
| 🌙 **Gothic Rooftop** | Moonlit city rooftops with spike hazards |
| 🏰 **Castle Bridge** | Stone bridge combat over water |
| ⚔️ **Dungeon Corridor** | Interior dungeon with skeleton patrols |
| 🧱 **Castle Interior** | Multi-floor vertical dungeon exploration |

---

## 🔮 Planned Features

- [ ] Boss encounters
- [ ] Inventory & equipment system
- [ ] Save / Load game progress
- [ ] More enemy types (archers, mages)
- [ ] Story / dialogue system
- [ ] More scenes and world areas
- [ ] Mobile build support

---

## 👤 Author

<div align="center">

**Kirisaki00**

[![GitHub](https://img.shields.io/badge/GitHub-Kirisaki00-181717?style=for-the-badge&logo=github)](https://github.com/Kirisaki00)

*Solo developer — designed, coded, and built from scratch.*

</div>

---

## 📄 License

This project is for educational and portfolio purposes. All original code is © Kirisaki00. Third-party assets (sprites, audio) remain property of their respective creators.

---

<div align="center">

<img src="https://capsule-render.vercel.app/api?type=waving&color=0d1117,1a1a2e,16213e,0f3460&height=100&section=footer" width="100%"/>

*Made with ❤️ and Unity*

</div>
