Unity - Basic Helicopter Controller
----------------------------------------------------------------------------------

Description:

Create a basic Helicopter Controller for your Unity projects.


Manual Setup Instruction:
-------------------------

* Simply follow the instruction for manual setup found below.

Note: Setup steps coming as soon as further free time allows..... 

-----------------------------------------------------------------------------------

Note: if you already have some sort of a test terrain in place, well then, you
can simple skip the steps: #1, 2 & 3 and go directly to #4.

-----------------------------------------------------------------------------------

Step 1: Create: "Environment" * Added for Nicer Organization

-----------------------------------------------------------------------------------

Create Empty: "Environment"

Position: X: 0 Y: 0 Z: 0 
Rotation: X: 0 Y: 0 Z: 0 
Scale:    X: 1 Y: 1 Z: 1

First since this is just a "holder" added for better organization, let us go
ahead & drag the "Directional Light" into "Environment".

* also if you wanted you could add a "dir" called Environment and opt to place
  your TerrainData inside that in its own Dir "TerrainData", and as such any
  other Environment stuff respectively in as desired the "Environment" dir.
  Just a suggestion.

Also: We don't need the "Main Camera" in Sample Scene, so..., we can go ahead
and delete it.

-----------------------------------------------------------------------------------

Step 2: Create: "Terrain Plane"

-----------------------------------------------------------------------------------

Note: Since we are creating a basic Helicopter Cointroller we need more ground to 
fly over so let us make the test "Terrain Plane" a bit big, ie: 2500 x 2500.

Create New 3D Object: "Plane"

Position: X: 0   Y: -0.03 Z: 0 
Rotation: X: 0   Y: 0     Z: 0 
Scale:    X: 800 Y: 1     Z: 800

Rename to: "Terrain Plane"

We can now opt to clean up for better organization, simply drag the:
"Terrain Plane" into the holder "Environment" we added for just this exact
 purpose!

-----------------------------------------------------------------------------------

Step 3: Create: "Terrain"

-----------------------------------------------------------------------------------

Note: Since we are creating a basic Helicopter Cointroller we need more gorund to 
fly over so let us make the test "Terrain" a bit big, ie: 8000 x 8000.

Create New 3D Object: "Terrain"

Modify via:

"Terrain" Inspector: Terrain Settings

Mesh Resolution (On Terrain Data):

Terrain Width:  8000 
Terrain Length: 8000

Position: X: -4000 Y: 0 Z: -4000 
Rotation: X: 0     Y: 0 Z: 0 
Scale:    X: 1     Y: 1 Z: 1

We can now opt to clean up for better organization, simply drag the:
"Terrain" into the holder "Environment" we added for just this exact purpose!

-----------------------------------------------------------------------------------

Step 4: Create: "HelicopterController"

-----------------------------------------------------------------------------------

Create Empty Game Object: "HelicopterController" *

Position: X: 0 Y: 0 Z: 0 
Rotation: X: 0 Y: 0 Z: 0 
Scale:    X: 1 Y: 1 Z: 1

* Note: We will use such as a "holder" for our helicopter model simply for better
  organizational purposes.

Note: Setup steps coming as soon as further free time allows.....  

-----------------------------------------------------------------------------------

Step 5: Add Input: "Roll"

-----------------------------------------------------------------------------------

Note: Setup steps coming as soon as further free time allows.....

Add Input Axes: "Roll"

Name: Roll
Negative Button: left
Positive Button: right
Alt Negative Button: a
Alt Positive Button: d
Gravity: 3
Dead: 0.001
Sensitivity: 3
Snap: True (checked)
Invert: False (unchecked)
Type: Key or Mouse Button
Axis: X axis
Joy Num: Get Motion from all Joysticks

-----------------------------------------------------------------------------------

Step 6: Add Input: "Pitch"

-----------------------------------------------------------------------------------

Note: Setup steps coming as soon as further free time allows.....

Add Input Axes: "Pitch"

Name: Pitch
Negative Button: down
Positive Button: up
Alt Negative Button: s
Alt Positive Button: w
Gravity: 3
Dead: 0.001
Sensitivity: 3
Snap: True (checked)
Invert: False (unchecked)
Type: Key or Mouse Button
Axis: X axis
Joy Num: Get Motion from all Joysticks

-----------------------------------------------------------------------------------

Step 7: Add Input: "Yaw"

-----------------------------------------------------------------------------------

Note: Setup steps coming as soon as further free time allows.....

Add Input Axes: "Yaw"

Name: Yaw
Negative Button: q
Positive Button: e
Gravity: 3
Dead: 0.001
Sensitivity: 3
Snap: True (checked)
Invert: False (unchecked)
Type: Key or Mouse Button
Axis: X axis
Joy Num: Get Motion from all Joysticks

-----------------------------------------------------------------------------------

Step 8: Add Model: "MD-500"

-----------------------------------------------------------------------------------

Note: Setup steps coming as soon as further free time allows.....


-----------------------------------------------------------------------------------

Step 9: Add: "Camera"

-----------------------------------------------------------------------------------

Note: Setup steps coming as soon as further free time allows.....

-----------------------------------------------------------------------------------

Step 10: Add Script: "HelicopterController.cs"

-----------------------------------------------------------------------------------

Note: Setup steps coming as soon as further free time allows.....


Further Note: If using Unity 2021 LTS, 2021 does not have automaticCenterOfMass 
thus to curb error you would need to comment out respectively like so.

  //_rigidbody.automaticCenterOfMass = false;

-----------------------------------------------------------------------------------

Step 11: Modify Settings for: "HelicopterController (Script)" 

-----------------------------------------------------------------------------------

Note: Setup steps coming as soon as further free time allows.....

-----------------------------------------------------------------------------------

That is it and concludes the basic Helicopter Controller setup steps. You can now 
begin to modify such further for your specific needs.

Best of Luck!
