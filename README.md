# UnReally - Modular Combat System (Damage Architecture)

At the core of my combat system lies a flexible and highly scalable damage management architecture. Instead of passing simple numerical values, I implemented a dedicated "Damage Payload" struct, enabling precise communication between different weapon types and their targets.

## Data Architecture: S_DamageInfo

I designed the `S_DamageInfo` struct to store the complete context of every attack. This approach ensures the framework is well-prepared to handle everything from simple melee strikes and firearms to complex environmental hazards.

### Struct Parameters:
* **Amount (Float):** The base raw damage value.
* **DamageType (Enum):** Categorizes the source of the attack (`Melee`, `Projectile`, `Explosion`, `Environment`).
* **DamageResponse (Enum):** The desired target reaction upon receiving a hit (`HitReaction`, `Stagger`, `Stun`, `Knockback`).
* **Combat States (Booleans):**
    * `ShouldDamageInvincible`: Bypasses invincibility frames (i-frames).
    * `CanBeBlocked` / `CanBeParried`: Defines the interaction with the player's or AI's defensive systems.
    * `ShouldForceInterrupt`: Determines whether the attack should interrupt the target's current action.

## System Abstraction: BPI_Damageable Interface

To ensure maximum modularity and decouple dependencies, I implemented a Blueprint Interface (`BPI_Damageable`). This allows the combat framework to interact with any actor—whether it is a player, an enemy, or a destructible prop—without needing to cast to specific classes.

### Key Interface Functions:

* **`TakeDamage`**: The core function that receives the `S_DamageInfo` struct. The receiving actor uses this data to determine its specific reaction to the incoming attack, taking into account blocking and parrying states.

<img width="1699" height="516" alt="Take Damage Blueprint" src="https://github.com/user-attachments/assets/d132c563-da74-4228-96d0-5e4c809703de" />

* **`Heal`**: A unified method for restoring health points, securely clamped to the entity's maximum health limit.

<img width="1268" height="534" alt="Heal Blueprint" src="https://github.com/user-attachments/assets/0b46f1d0-ee35-47f3-88db-79114cd5a174" />

* **`GetCurrentHealth` / `GetMaxHealth`**: Getter functions that allow external systems, such as AI logic or UI health bars, to safely read the entity's status without directly accessing the underlying component variables.

## AI Behavior & Pathfinding

The framework includes a reactive AI system built using the `AI Perception` component. The NPC’s behavior dynamically shifts based on its current health and target distance, creating more engaging encounters.

### Key AI States:
* **Attack & Pursuit**: Once the player is detected, the AI engages and follows the target.
* **Retreat (Runaway)**: If health drops below a certain threshold (e.g., 10 HP), the AI enters a "Runaway" state to escape the player.
* **Return to Home**: When the player is no longer perceived or the retreat is complete, the AI automatically navigates back to its original spawn point.

<img width="1857" height="731" alt="ai blueprint" src="https://github.com/user-attachments/assets/cef10b65-24df-4f1b-abac-eef5ea71099e" />

## Attack Sequence & Hit Detection

To demonstrate the system in action, the attack sequences for both the Player and NPCs utilize `Sphere Trace For Objects` for accurate hit detection. This method ensures precise hitbox-to-hurtbox registration compared to standard collision overlaps. Upon a successful hit, the logic constructs the `S_DamageInfo` payload and passes it to the target, triggering appropriate visual feedback like particle emitters.

<img width="1785" height="884" alt="Attack sequecne of NPC blueprint" src="https://github.com/user-attachments/assets/6143ea3b-b0d3-4cc2-9128-aa1761b27b3d" />
<img width="2050" height="678" alt="Attack seuqence of Player blueprint" src="https://github.com/user-attachments/assets/ecb2dcf6-14fb-49a5-8cf7-d007d95a0c54" />

## Current Implementation Status

The project was built from the ground up with high scalability and Data-Driven Design in mind. 

**At the current stage:**
* **Core foundations** are fully implemented, allowing seamless integration of the parameters above within Blueprint nodes.
* The active gameplay mechanics primarily utilize the **`Amount` flow**—the system correctly calculates and deducts health points (HP) from targets using a modular Actor Component.
* The remaining parameters (such as parry windows, stagger triggers, or hit reactions) are fully exposed and ready to be hooked up to Animation Notifies and visual effects (VFX). They serve as a robust, future-proof framework for expanding the overall "Game Feel" as development continues.

---
*Tech Stack: Unreal Engine | Blueprints | Actor Components*
