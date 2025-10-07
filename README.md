UnityDeveloperSkillCheckJuniorEdition
Greetings. This is a test assignment for the C# Unity3d position for the project
https://store.steampowered.com/app/3858260/Nothing_But_Road/
Since this is a test assignment for Junior/Trainee students, the tasks are optional. So, if you can't complete something, just skip it and describe the ones you couldn't do when you provide a link to the repository with the completed test. You can use any assets/models/objects/colors/etc.; any unspecified details are free to complete at your own discretion (this is a test assignment to test overall understanding, not a task that must be completed strictly according to the full description). 🙂
Submission format: public git project (github/gitlab/etc.).
Unity3D version: 6000.0.48f1 preferred (but a different version is acceptable).
Format: One Unity project, several small tasks in different areas.
Last test submission date: 10/10/2025
Each task should be completed in a separate scene named "Task_01," "Task_02," and so on.
The task must be completed in Unity 6.




Task 1 - "Turn toward target"
Create an AutoLookAt script that forces an object (e.g., a cube)
to constantly look at the target (another object).
● Has a target (Transform) field.
● Has a rotationSpeed ​​field.
● Smooth rotation (Quaternion.Lerp or RotateTowards).
💡 Bonus: Add the lockYAxis checkbox to ensure rotation occurs only around the vertical axis.




Task 2 - "Simple Inventory in the UI"
Create a simple inventory (preferably using the UI Toolkit):
● An inventory item (e.g., a button with text).
● An "Add Item" button in the UI.
● Clicking "Add Item" creates a new item in the palette with a random name ("Sword," "Apple," etc.).
💡 Bonus: Ability to delete items.




Task 3 - "Object Spawner"
Create an ObjectSpawner:
● Has a list of prefabs (List<GameObject>).
● Execute one random prefab every N seconds.
● Determines the spawn location based on the Transform spawnPoint.
💡 Bonus: Create a spawn parameter within a specified radius from the spawnPoint.




You need to complete a task in Unity 6.
Task 4 - "Editor Tool: Align to Ground"
Create a simple Editor script that adds an "Align to Ground" button to the object's inspectors.
When clicked, it casts a raycast downwards from the object's position and moves it so it's "standing" on the ground.
💡 Bonus: Maintain tilt according to the terrain's current slope.




Task 5 - "Saving State"
Create a script that saves and loads an object's position to a file (JSON).
● Save and Load buttons in the UI or in the inspector.
● Data can be written to persistentDataPath.
💡 Bonus: Saving for multiple objects (e.g., via a List).


