# 🎮 Game Design Document (GDD) — _Circle Jump_

## 1. Game Overview

**Title:** Circle Jump  
**Engine/Version:** Unity 6.2 (6000.2.1f1)  
**Genre:** 3D Arcade Platformer (Physics-based)  
**Platforms:** Steam (Windows/Mac), WebGL (Browser)  
**Core Concept:**  
Players control a bouncing ball constrained to the circumference of a transparent cylinder. The ball travels around the ring, bouncing on blocks, avoiding hazards, and collecting points. The challenge escalates as speed and difficulty increase.

---

## 2. Gameplay & Mechanics

- **Movement:**
  - Ball constrained to a fixed radius from cylinder center.
  - `theta` angle controls horizontal position.
  - Vertical motion (`y`) handled by Rigidbody physics (gravity, jumps, bounces).
- **Controls:**
  - Left/Right (A/D, Arrow Keys, or Gamepad Stick) → move around cylinder.
  - Jump (Space / A button) → upward impulse.
  - Boost/Dash (Shift / Trigger) → speed burst (optional).
- **Bouncing:**
  - Ball bounces naturally via physics.
  - Special bounce pads give extra vertical impulse.
  - Hazards stop or damage the player.
- **Camera:**
  - Orbiting 3rd-person follow (Cinemachine or custom).
  - Positioned outside cylinder for “see-through” effect.

---

## 3. World & Level Design

- **Cylinder World:**
  - Transparent cylinder mesh (visual only).
  - Blocks spawn along circumference at different `theta` positions.
- **Block Types:**
  - **Standard Blocks**: Regular bounce.
  - **Bounce Pads**: Extra vertical force.
  - **Hazards**: Spikes, gaps, or moving traps.
  - **Power-Ups**: Slow motion, shield, double jump, etc.
- **Difficulty Scaling:**
  - Increasing speed of player movement.
  - More hazards, fewer safe blocks.
  - Faster spawn cycles, moving obstacles.

---

## 4. Scoring & Progression

- Score increments with:
  - Time survived.
  - Successful block bounces.
  - Combos (consecutive bounces).
- High scores stored locally (WebGL) and via Steam leaderboards.
- Possible **Endless Mode** loop, with increasing difficulty over time.

---

## 5. Visuals & Audio

- **Art Style:** Minimalist neon/tech aesthetic.
- **Cylinder:** Transparent URP material with scrolling grid shader.
- **Ball:** Simple glowing material with optional particle trail.
- **Blocks:** Emissive cubes, some animated.
- **Audio:**
  - Background electronic track.
  - Bounce/impact SFX.
  - Warning tones for hazards.

---

## 6. Technical Implementation

- **Physics:** Unity Rigidbody for vertical motion, with constraints on radius.
- **Coordinate System:** Cylindrical (theta + y), avoids complex curved colliders.
- **Spawner:** Script generates blocks around ring by converting angle → world position.
- **Camera:** Cinemachine or custom orbit camera following player’s theta position.
- **Input:** Unity Input System, mapped for keyboard + controller + Web.

---

## 7. Monetization / Distribution

- **Steam:**
  - One-time purchase, possibly cheap ($2.99–$4.99).
  - Steam Achievements + Leaderboards.
- **WebGL:**
  - Free playable demo on Itch.io or personal site.
  - Drives visibility and traffic to Steam release.

---

# 🛠 Project Outline (Step-by-Step Build Plan)

### **Phase 1 — Foundations**

1. Create new Unity 6.2 URP project.
2. Set up **layers** (`Player`, `Blocks`, `Hazards`, `Ground`).
3. Implement cylindrical coordinate system for player movement (`theta`, `y`).
4. Create **ball prefab** with Rigidbody + constraints.
5. Add invisible collider ring for grounding detection.

---

### **Phase 2 — Core Gameplay**

6. Implement jump + bounce logic (blocks give impulses).
7. Add block prefabs (standard, bounce pad, hazard).
8. Write block spawner (`RingSpawner.cs`) to position by angle.
9. Add scoring system (time + bounce combos).
10. Build simple UI HUD (score, lives, pause).

---

### **Phase 3 — Camera & Controls**

11. Set up Cinemachine orbit camera, smooth follow on theta.
12. Fine-tune input system (keyboard/gamepad).
13. Add configurable movement speeds, friction, and boosts.

---

### **Phase 4 — Presentation**

14. Design URP materials: glowing blocks, transparent cylinder with grid shader.
15. Add basic VFX: ball trail, particle bursts on bounce.
16. Add music + placeholder SFX.

---

### **Phase 5 — Progression**

17. Implement difficulty ramp (spawn rate, speed, hazards).
18. Add power-ups (slow-mo, shield, double jump).
19. Add lives/health system.

---

### **Phase 6 — Polishing & Release Prep**

20. Optimize for WebGL (texture sizes, pooled effects).
21. Add Steamworks integration (achievements, leaderboards).
22. Implement rebindable controls & settings menu.
23. Playtest, tweak balance, fix bugs.
24. Create builds for WebGL (itch.io) + Steam release.
