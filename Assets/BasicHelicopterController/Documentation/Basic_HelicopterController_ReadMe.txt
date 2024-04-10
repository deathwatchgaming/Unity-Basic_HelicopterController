Unity - Basic Helicopter Controller
----------------------------------------------------------------------------------

Description:

Create a basic Helicopter Controller for your Unity projects.

Controls: 

Roll: A & D
Pich: S & W
Yaw:  Q & E

-Throttle: LeftShift
+Throttle: LeftControl


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

-----------------------------------------------------------------------------------

Step 5: Add Input: "Roll"

-----------------------------------------------------------------------------------

In Edit -> Project Settings -> Input Manager:

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

Note: this is using the old input system and while yes, you could modify the script
for new input system usage, currently that is not covered in the scope of this 
setup at this time.

-----------------------------------------------------------------------------------

Step 6: Add Input: "Pitch"

-----------------------------------------------------------------------------------

In Edit -> Project Settings -> Input Manager:

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

Note: this is using the old input system and while yes, you could modify the script
for new input system usage, currently that is not covered in the scope of this 
setup at this time.

-----------------------------------------------------------------------------------

Step 7: Add Input: "Yaw"

-----------------------------------------------------------------------------------

In Edit -> Project Settings -> Input Manager:

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

Note: this is using the old input system and while yes, you could modify the script
for new input system usage, currently that is not covered in the scope of this 
setup at this time.

-----------------------------------------------------------------------------------

Step 8: Add Model: "MD-500"

-----------------------------------------------------------------------------------

Visit in "BasicHelicopterController/Models/md-500-defender-helicopter"...
the model MD-500.fbx -> MD-500 Import Settings -> Materials -> Textures 

Click "Extract Textures"

extract to "textures"

You should now notice the model changed colors from defaults materials and should 
now look correct.

mkay, one last detail just to clean up on that as there are already textures in 
the "textures" directory, you may see some duplicates, mkay only delete the first 
in order of any such duplicates as the second of each should be what you extracted 
and used. Thus if you are a mildly a bit ocd, this will tidy up things for your 
mind if that makes sense, haha! ;P

ok, you can now add the model prefab: MD-500 "(MD-500.fbx) to your scene"

Position: X: 0    Y: 0    Z: 0 
Rotation: X: 0    Y: 0    Z: 0 
Scale:    X: 0.01 Y: 0.01 Z: 0.01

Lastly, place the "MD-500 object" inside the "holder": HelicopterController

-----------------------------------------------------------------------------------

Step 9: Add: "Camera" to model "MD-500" object

-----------------------------------------------------------------------------------

As a child of "MD-500" object...

First, add a camera named: "Cockpit Camera" *

Position: X: 0 Y: 269 Z: 96 
Rotation: X: 0 Y: 0   Z: 0 
Scale:    X: 1 Y: 1   Z: 1

* Disable the bool in Inspector as this camera is currently just added as an 
optional example and is not currently used, but you could opt for either or a 
future switch method or what not, hence why such is added as an example of two 
diff views.

Secondly, add a camera named: "Rear Camera" *

* Keep this camera Active as this is the camera we will use.

Position: X: 0 Y: 350 Z: -1350 
Rotation: X: 0 Y: 0   Z: 0 
Scale:    X: 1 Y: 1   Z: 1

Note: you will notice the numbers are larger that what you would expect and that 
is because the model is scaled at 0.01, thus this must be factored.

-----------------------------------------------------------------------------------

Step 10: Add Script: "HelicopterController.cs" to model "MD-500" object

-----------------------------------------------------------------------------------

On the "MD-500 object"...

Add Component: HelicopterController (BasicHelicopterController)


Further Note: If using Unity 2021 LTS, 2021 does not have automaticCenterOfMass 
thus to curb error that will display you would need to comment out respectively 
like so.

  //_rigidbody.automaticCenterOfMass = false;

-----------------------------------------------------------------------------------

Step 11: Modify Settings for: "HelicopterController (Script)" 

-----------------------------------------------------------------------------------

Note: While the script will work fine and fill most of these settings by itself on 
Awake() as intended say as long as you say set the bare minimum for example rotor 
sound & transforms, hmm, let us just for good measure set all up in inspector 
instead. So, in saying such, your settings should simply look like such:

Script: HelicopterController

Rigid:
------

Rigidbody: MD-500 (Rigidbody)

Collider:
---------

Mesh Collider: MD-500 (Mesh Collider)

Audio:
------

Audio Source: MD-500 (Audio Source)
Rotor Sound: Helicopeter_Rotor

Amounts:
--------

Sensitivity: 500
Throttle Amount: 25
Max Thrust: 5
Rotor speed Modifier: 10


Transforms:
-----------

Rotors Transform Top: Top_rotor (Transform)
Rotors Transform Tail: Tail_Rotor (Transform)

-----------------------------------------------------------------------------------

Step 12: Modify Settings for: "Rigidbody (Component)" 

-----------------------------------------------------------------------------------

Note: While the script will work fine and fill these particular settings by itself 
on Awake() as intended hmm, let us just for good measure set such up in inspector 
instead. So, in saying such, your specific settings should simply look like such:

Mass: 360

Automatic Center Of Mass: False (Bool unchecked)

-----------------------------------------------------------------------------------

Step 13: Modify Settings for: "Mesh Collider (Component)" 

-----------------------------------------------------------------------------------

Note: While the script will work fine and fill this particular setting by itself 
on Awake() as intended hmm, let us just for good measure set such up in inspector 
instead. So, in saying such, your specific setting should simply look like such:

Convex: True (Bool checked)

-----------------------------------------------------------------------------------

That is it and concludes the basic Helicopter Controller manual setup steps. You 
can now begin to modify such further for your specific needs.

Best of Luck!
