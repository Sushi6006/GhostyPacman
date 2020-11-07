# Shader

## Toon Shader

​	While we have weak light elements in our game, so we choose Toon shader, which is basically unaffected by light. Another reason is Toon shader makes object adorable,  suitable with our Pacman theme.

​	Toon shader is genrated by 4 parts: ambient + specular + rim: the ambient and specular is not impacted a lot by light, we can manipulate the size of specular, color of ambient manually. 

​	The directional light give our shader a basic distinction between dark plane and light plane.

​	In ambient, we soften the edge between light and dark to remove the jaggedness, **smoothstep()** supports it. 

​	Specular part is very similar with Phong shader in lab, we also soften the specular spot's edge.

​	The "rim" of an object will be defined as surfaces that are facing away from the camera, we calculate the rim by taking the dot product of the normal and the view direction, and inverting it. 

​	

## Transparent Shader

​	Transparent shader is used for shield.

​	We designed transparent shader with texture firstly, but we did not use the texture later, Texture parameter is kept in the shader.

​	We **turn off the depth writes(ZWrite)** to keep further object's rendering and turn on **Blending(Blend SrcAlpha OneMinusSrcAlpha)** for the transparent result.

​	We add ambient and diffuse in the shader to make our shield more powerful. 

​	The blending method makes better shield  than the depth test method.



# Manipulate

## Pacman and Ghost

​	We use CharacterController to manipulate our characters, it will ignore the physical engine and bring smooth operation experience. We designed two system for manipulation, the 'turn around effect' in classic mode is made for smooth reflection(really hard part). 

​	The chasing system on Ghost is finished by navigation in unity, every ghost is an agent.  At first, we have stairs in our map, so the pacman is added gravity calculation though the stairs were removed at last. The ghost can floating.

## Camera

​	We design two version of view, the first person and third person, with switching camera's position. The camera is set as pacman's child object to following the pacman. 

​	We add ray between camera and pacman to avoid camera going through walls, the ray will detect the obstacle and zoom the camera.

## Pacdot and props

​	All pacdots and props can respawn after a certain time, the script make them float also. 



### 





