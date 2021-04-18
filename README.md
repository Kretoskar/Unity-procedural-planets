# Procedural planet generation

Process:
1. Generate icosahedron from precalculated vertices data.
2. Generate icosphere by subdividing faces of icosahedron.
3. Apply multiple layers of noise to vertices distance from center of the mesh and recalculate their positions.
4. Calculate UVs by triplanar shader.
5. Apply different textures and normal maps depending on noise value and lerp through them.
6. Create water waves by applying 2 different normal maps for water with UV scrolling in opposite directions.

![alt text](https://s4.gifyu.com/images/final_607c2c7cde7bd9005be463f3_217627.gif)
![alt text](https://s4.gifyu.com/images/final_607c36909687f000a1cfae50_856045.gif)
![alt text](https://i.imgur.com/YgYw65I.png)
