# Unity Developer Skill Check - Junior Edition

This repository contains solutions for the Unity Developer Skill Check assignments. The project is made with **Unity 6**. Each task focuses on different aspects of Unity development, from scripting to UI and editor tools.

---

## Task 1 - "Auto Look At"

Create a script `AutoLookAt` that makes an object (e.g., a cube) constantly look at a target object.

- **Fields**:
  - `target` (Transform) — the object to look at
  - `rotationSpeed` — speed of rotation
- **Behavior**:
  - Smooth rotation using `Quaternion.Lerp` or `RotateTowards`
- **Bonus**:
  - Add a `lockYAxis` option to rotate only around the vertical axis

---

## Task 2 - "Simple Inventory UI"

Create a simple inventory system using **UI Toolkit** (recommended):

- Inventory items (e.g., buttons with item names)
- UI button: **Add Item**
- Clicking **Add Item** creates a new inventory item with a random name (e.g., "Sword", "Apple", etc.)
- **Bonus**: ability to remove items from the inventory

---

## Task 3 - "Object Spawner"

Create an `ObjectSpawner` script:

- Holds a list of prefabs (`List<GameObject>`)
- Spawns a random prefab every N seconds
- Spawn location determined by a `Transform` (`spawnPoint`)
- **Bonus**: add a parameter to spawn objects within a radius around `spawnPoint`

---

## Task 4 - "Editor Tool: Align to Ground"

Create a simple **Editor script** that adds an **Align to Ground** button in the object inspector:

- On click, it casts a Raycast downwards from the object and moves it to "stand" on the ground
- **Bonus**: adjust rotation to match the slope of the terrain at the position

---

## Task 5 - "Save and Load State"

Create a script to save and load the position of an object to a file (JSON):

- UI or inspector buttons: **Save** and **Load**
- Data stored in `Application.persistentDataPath`
- **Bonus**: support saving multiple objects (e.g., using a `List`)
