# Circle Jump - Unity Naming Conventions

This document defines the **code, file, and asset naming standards** for the Circle Jump project (Unity 6.2). Consistency helps readability, maintainability, and teamwork.

---

## 1. C# / .NET Code Conventions

### Classes, Structs, Enums, Methods, Properties
- **PascalCase**
```csharp
public class PlayerController { }
public struct PlayerStats { }
public enum GameState { MainMenu, Playing, Paused }
public void TakeDamage(int amount) { }
```

### Interfaces
- `I` + **PascalCase**
```csharp
public interface IDamageable { }
```

### Fields
- **Private fields:** `_camelCase`
- **Serialized private fields:** `[SerializeField] private` + `_camelCase`
```csharp
[SerializeField] private float _jumpForce = 6f;
private int _health;
```

### Constants
- **ALL_CAPS_WITH_UNDERSCORES**
```csharp
private const int MAX_HEALTH = 100;
```

### Parameters & Locals
- **camelCase**
```csharp
void MovePlayer(float moveSpeed) { int currentHealth = _health; }
```

### Unity Lifecycle Methods
- Use Unity’s exact casing: `Awake`, `Start`, `Update`, `FixedUpdate`, `OnTriggerEnter`, etc.

---

## 2. Project & Folder Structure

### Top-Level Unity Folders
All Unity content **must** be inside the `Assets/` folder to be recognized by the engine.

```
CircleJump/
  Assets/
    Animations/
    Audio/
    Materials/
    Prefabs/
    Scenes/
    Scripts/
    ScriptableObjects/
    Shaders/
    Textures/
    UI/
    FX/
    Environment/
    Documentation/   <- Unity can import .md/.txt here
  ProjectSettings/
  Packages/
  README.md
```

### Subfolders
- **PascalCase**: `Enemies/`, `Weapons/`, `HUD/`, `Menus/`
- Keep hierarchy shallow; avoid more than 3 levels deep.

---

## 3. Asset & File Naming Conventions

### General Rule
**Prefix_Category_Object_Variant_Suffix** (omit when unnecessary)

### Common Prefixes
- **Scenes:** `SCN_`
- **Prefabs:** `PFB_`
- **Materials:** `MAT_`
- **Textures:** `T_`
- **Sprites:** `SPR_`
- **Shaders:** `SHD_` (HLSL), `SG_` (Shader Graph)
- **Animations:** `ANIM_` (Clips), `AC_` (Animator Controller), `AOC_` (Animator Override Controller)
- **ScriptableObjects:** `SO_`
- **Audio:** `SFX_`, `MUS_`, `VO_`
- **VFX Graph:** `VFX_`
- **Timeline:** `TL_`
- **Physics Materials:** `PMAT_`
- **Atlases:** `ATLAS_`
- **UI Assets:** `UI_`

### Examples
#### Scenes
- `SCN_MainMenu`
- `SCN_Gameplay_Desert_01`

#### Prefabs
- `PFB_PlayerCharacter`
- `PFB_Enemy_Zombie_T1`

#### Materials
- `MAT_Env_Rock_CliffA`
- `MAT_UI_ButtonPrimary_Dark`

#### Shaders
- `SHD_Char_SkinnedPBR`
- `SG_UI_UnlitRoundedRect`

#### Textures (PBR Metal/Rough)
- `T_Env_RockA_Albedo`
- `T_Env_RockA_Normal`
- `T_Env_RockA_Roughness`
- `T_Env_RockA_Metallic`
- `T_Env_RockA_AO`
- `T_Env_RockA_Emissive`

#### Animations
- Clips: `ANIM_Player_Run`, `ANIM_Zombie_AttackA`
- Animator Controller: `AC_Player`
- Override Controller: `AOC_Player_HolidayEvent`

#### ScriptableObjects
- `SO_WeaponConfig_Rifle_M4`

#### Audio
- `MUS_MainTheme_120BPM`
- `SFX_UI_Click_01`
- `VO_Tutorial_Intro_EN_US_001`

#### VFX & Timelines
- `VFX_Explosion_Small`
- `TL_Cinematic_Intro_01`

#### Physics Materials / Atlases
- `PMAT_Metal_Slippery`
- `ATLAS_UI_Common`

---

## 4. UI & GameObjects
- GameObjects: `PascalCase` → `PlayerRoot`, `MainCamera`, `EnemySpawner`
- UI Elements: `UI_Panel_Pause`, `UI_Btn_Start`, `UI_Txt_Score`

---

## 5. Variants / LODs / Versions
- Variants: `_A`, `_B`, `_V1`
- LODs: `_LOD0`, `_LOD1`, `_LOD2`
- Resolutions: `_2K`, `_4K`

Examples:
- `PFB_Enemy_Zombie_T1_V2`
- `T_Env_RockA_Albedo_4K`
- `PFB_Tree_Oak_LOD0`

---

## 6. DOs & DON’Ts

**DO:**
- Keep consistent prefixes and casing.
- Use nouns for assets, verbs for animation clips.
- Group logically: `Env`, `Char`, `UI`, `FX`, `Weapon`, etc.

**DON’T:**
- Use spaces or special characters.
- Mix different texture suffix schemes in the same project.
- Leave default names like `Material (1)` or `New Prefab`.

---

## 7. Placement in Project
- All assets inside `Assets/`.
- Documentation and style guides inside `Assets/Documentation/`.

---

✅ Following these rules will keep Circle Jump consistent, organized, and easy to scale.
