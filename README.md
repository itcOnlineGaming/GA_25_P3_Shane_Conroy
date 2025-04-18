# **Entity Spawn Manager**  

## **Setting Up the Component**  
### Adding the Component via Package Manager
To add the **Entity Spawn Manager**, follow these steps:  
1. Open **Unity** and navigate to the **Window** tab.  
2. Select **Package Manager**.  
3. Click the **"+"** icon and choose **"Add package from git URL..."**.  
4. Enter this link: https://github.com/itcOnlineGaming/GA_25_P3_Shane_Conroy.git?path=/Packages/ie.mypackage.entityspawnmanager#v1.0.3
---  
## Once Installed
- Inside the **"Runtime"** folder, there will be a new folder labelled **"Editor,"** inside will be a script labelled **GridControllerEditor.cs** This script will change the inspector based on where you attach the other script, you wont have to move or
  change this one. **Grid Manager.cs** is the main script, and you will have to attach this to objects in your scene.
- Usually the **Grid Manager.cs** script will be attached to an empty object because this script will be the point at where the grid generates, and the entities spawn.
  
   <img src="https://github.com/user-attachments/assets/6009ab19-3edc-4592-a220-a9311330298f" width="50%" alt="addingScripts">
   
---
## **Brief Description**  
The **Entity Spawn Manager** is a **grid-based** component that allows developers to quickly generate a grid at a desired location and assign specific entities to spawn within each tile. This will give developers an easy method of generating a grid and spawning prefabs before run time.


### **The Features**  
- Users can define **constraints** for entity placement within the grid:
 
- Users can assign the amount of the rows and cols via the inspector
  - Putting these numbers in will result in a grid shown below
  - <img src="https://github.com/user-attachments/assets/83448711-cc62-4004-9cf3-abd604994772" width="50%">

- Users can drag and drop prefabs into the "Entities" list in the inspector. The entities placed in this list can be used for the grid.
  - <img src="https://github.com/user-attachments/assets/075e2b55-cd25-4d55-904d-62ef4615864a" width="50%">
  
- **Minimum number of entities in the grid**
  - The User can define minimums for each Entity. This will spawn the minimum amount on the grid.
  - <img src="https://github.com/user-attachments/assets/4705819e-7f39-4c8b-a1d3-e29c78821b54" width="50%">
  - If no specific rows or columns are defined, entities will spawn randomly.
  - ![image](https://github.com/user-attachments/assets/d077d6db-98c8-4af9-96ed-27f32f2e5c8e)


- **Filling out entire rows**
  -  If the User wishes to, they can fill out entire rows at once with the buttons on the side of the grid
  -  ![image](https://github.com/user-attachments/assets/ee90a67b-0283-4fad-9e6a-82ad5537026a)
  -  A grid like thew one below will result in 2 columns of blue and one row of red
  -  ![image](https://github.com/user-attachments/assets/38a6b7a1-3989-4dd6-9580-af4d00116c22) ------- ![image](https://github.com/user-attachments/assets/7c78aded-2e6b-4f2b-aee7-4f396063503c)
  -  <img src="https://github.com/user-attachments/assets/c17ea437-0fbf-4033-a31e-fd048275c52a" width="50%">

- **Specific tiles for spawning or preventing entity spawns**  
  - If the User wishes to specify where he wants to place specific entities, they can do so by clicking directly on the grid. Each consecutive click will cycle through the grid to the amount of entities the User has placed in the list.
  - <img src="https://github.com/user-attachments/assets/0adc458f-9048-4936-b338-ca3651bd7e05" width="50%">


- **Once you're ready**
  - Once the User has placed all the conditions, the grid can be generated by clicking the "Generate Grid" button
  - ![image](https://github.com/user-attachments/assets/b405de9c-7260-4adf-af8c-c6278e45d07f)




