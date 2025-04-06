# **Entity Spawn Manager**  

## **Setting Up the Component**  
### Adding the Component via Package Manager
To add the **Entity Spawn Manager**, follow these steps:  
1. Open **Unity** and navigate to the **Window** tab.  
2. Select **Package Manager**.  
3. Click the **"+"** icon and choose **"Add package from git URL..."**.  
4. Enter this [link](https://www.youtube.com/watch?v=HeyC9o3Q9wA) (*Temporary link*).  

---  

## **Brief Description**  
The **Entity Spawn Manager** is a **grid-based** component that allows developers to quickly generate a grid at a desired location and assign specific entities to spawn within each tile. This will give developers an easy method of generating a grid and spawning prefabs before run time.

### **Key Features**  
- Users can define **constraints** for entity placement within the grid:
 
- Users can assign the amount of the rows and cols via the inspector
  - Putting these numbers in will result in a grid shown below
  - ![image](https://github.com/user-attachments/assets/e55300fa-85eb-4a62-a46b-ae32013a1627)
  - ![image](https://github.com/user-attachments/assets/12c6287b-2a2b-42c3-994d-d6ab9804e201)

- Users can drag and drop prefabs into the "Entities" list in the inspector. The entities placed in this list can be used for the grid.
  - ![image](https://github.com/user-attachments/assets/defbc259-ecb3-4c58-b73d-73bacb2cd759)


- **Minimum number of entities in the grid**
  - The User can define minimums for each Entity. This will spawn the minimum amount on the grid.
  - ![image](https://github.com/user-attachments/assets/bf5f56fb-e974-4333-a863-de8bbdedf895)
  - If no specific rows or columns are defined, entities will spawn randomly.
  - ![image](https://github.com/user-attachments/assets/d077d6db-98c8-4af9-96ed-27f32f2e5c8e)


- **Filling out entire rows**
  -  If the User wishes to, they can fill out entire rows at once with the buttons on the side of the grid
  -  ![image](https://github.com/user-attachments/assets/ee90a67b-0283-4fad-9e6a-82ad5537026a)
  -  A grid like thew one below will result in 2 columns of blue and one row of red
  -  ![image](https://github.com/user-attachments/assets/38a6b7a1-3989-4dd6-9580-af4d00116c22) ------- ![image](https://github.com/user-attachments/assets/7c78aded-2e6b-4f2b-aee7-4f396063503c)



  
  - **Specific tiles for spawning or preventing entity spawns**  
    - <img src="https://github.com/user-attachments/assets/f857a04f-705f-4f03-ad6b-3939d2083ed1" width="50%">  

- The **grid size** is fully adjustable to fit user requirements.  

---  

## **Setting Up the Component**  


