Unity - Basic Helicopter Controller With Entry
----------------------------------------------------------------------------------

Description:
------------

Create a "Basic Helicopter Controller" with entry for your Unity projects.


NOTE: This currently uses the New Input System (ie: Unity 6 variant provided),
so as such depending on what version of Unity you may be using it may be
necessary to make sure such or both is enabled in project settings.


Helicopter Controls: 
--------------------

Roll: A & D [Keyboard] / Left Stick [Gamepad]
Pitch: S & W [Keyboard] / Left Stick [Gamepad] 
Yaw:  Q & E [Keyboard] / Right Stick [Gamepad]
Decrease throttle: Shift [Keyboard] / D-Pad Down [Gamepad]
Increase throttle: Control [Keyboard] / D-Pad Up [Gamepad] 
Change Cameras: V [Keyboard] / D-Pad Left [Gamepad] * 

* (ie: Rear Camera, Belly Camera & Cockpit Camera) 


Helicopter Entry Controls:
--------------------------

Enter Vehicle:      E [Keyboard] / Button North [Gamepad] 
Exit Vehicle:       F [Keyboard] / Button South [Gamepad] 


Player Controls:
----------------

Player Forward:   W [Keyboard] / Left Stick [Gamepad]
Player Reverse:   S [Keyboard] / Left Stick [Gamepad]
Player Left:      A [Keyboard] / Left Stick [Gamepad]
Player Right:     D [Keyboard] / Left Stick [Gamepad]
Player Jump:      Space [Keyboard] / Button South [Gamepad] 
Player Sprint:    Shift [Keyboard] / Left Shoulder [Gamepad]
Player Look:      Delta [Mouse] / Right Stick [Gamepad]


Manual Setup Instruction:
-------------------------

* Simply follow the instruction for manual setup found below.


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


Note: Since we are creating a basic Helicopter Controller we need more ground to 
fly over so let us make the test "Terrain Plane" a bit big, ie: 8000 x 8000.

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

Step 5: Add Model(s): "Helicopter Land" & "MD-500"

-----------------------------------------------------------------------------------


Visit in "BasicHelicopterController/Models/Helicopter-Land-Helipad/Source"...
the model Helicopter Land.fbx

Drag such into your scene and unpack the prefab so that we can edit it.

Rename to: "HeliPad"

Position: X: 0.1       Y: 1.46       Z: 0.7 
Rotation: X: -89.98    Y: 0          Z: 0 
Scale:    X: 424.3228  Y: 424.3228   Z: 424.3228

Add: Mesh Collider

Convex: True

Next, let us visit
in "BasicHelicopterController/Models/md-500-defender-helicopter"... the model
MD-500.fbx -> MD-500 Import Settings -> Materials -> Textures 

Click "Extract Textures"

extract to "textures"

You should now notice the model changed colors from defaults materials and should 
now look correct.

mkay, one last detail just to clean up on that as there are already textures in 
the "textures" directory, you may see some duplicates, mkay only delete the first 
in order of any such duplicates as the second of each should be what you extracted 
and used. Thus if you are mildly a bit OCD, this will just simply tidy up things 
for your mind if that makes sense, though one is sure such does, haha! ;P

ok, you can now add the model prefab: MD-500 "(MD-500.fbx) to your scene"

Position: X: 0    Y: 0    Z: 0 
Rotation: X: 0    Y: 0    Z: 0 
Scale:    X: 0.01 Y: 0.01 Z: 0.01

Lastly, place the "MD-500 object" inside the "holder": HelicopterController


Then let us modify the MD-500 object to compensate for the fact that we added
the helipad and want to have the helicopter on top of such

ie: MD-500

Position: X: 0.0005347086    Y: 0.2104118    Z: -0.0009975433
Rotation: X: 0               Y: 0            Z: 0 
Scale:    X: 0.01            Y: 0.01         Z: 0.01

So, now your heirarchy expanded should look like so:

ie:

Environment
-- Directional Light
-- Terrain
-- Terrain Plane
HelicopterController
- MD-500
-- Cockpit
-- Glass
-- Tail_Rotor
-- Top_rotor
HeliPad

One last thing for good measure is to simply check to make sure there are mesh
colliders on things if any such are not so for example add to such:

ie:

-- Cockpit
-- Glass
-- Tail_Rotor
-- Top_rotor

+ mesh collider 
convex: true


-----------------------------------------------------------------------------------

Step 6: Add: "Camera(s)" to model "MD-500" object

-----------------------------------------------------------------------------------


As a child of "MD-500" object...

First, add a camera named: "Cockpit Camera" *

Position: X: 0 Y: 269 Z: 96 
Rotation: X: 0 Y: 0   Z: 0 
Scale:    X: 1 Y: 1   Z: 1

* Disable the bool in Inspector as this camera is currently just added as an 
optional example and is not currently used, but you could opt for either or a 
future switch method or what not, hence why such is added as an example of three 
diff views.

Secondly, add a camera named: "Belly Camera" *

Position: X: 0 Y: 84 Z: 92
Rotation: X: 0 Y: 0   Z: 0 
Scale:    X: 1 Y: 1   Z: 1

* Disable the bool in Inspector as this camera is currently just added as an 
optional example and is not currently used, but you could opt for either or a 
future switch method or what not, hence why such is added as an example of three 
diff views.

Lastly, add a camera named: "Rear Camera" *

* Keep this camera Active as this is the camera we will use (for now).

Position: X: 0 Y: 350 Z: -1350 
Rotation: X: 0 Y: 0   Z: 0 
Scale:    X: 1 Y: 1   Z: 1

Note: you will notice the numbers are larger that what you would expect and that 
is because the model is scaled at 0.01, thus this must be factored.

Now we can opt to move both cameras into an "empty"... *

* Note: We will use such as a "holder" for our cameras simply for better
  organizational purposes.  

As a child of "MD-500" object... create an "empty" called: "View"

Position: X: 0 Y: 0  Z: 0
Rotation: X: 0 Y: 0  Z: 0 
Scale:    X: 1 Y: 1  Z: 1

Next, you can then (drag into / add) the three cameras into the "empty": "View"


So, now overall your heirarchy expanded should look like so:

ie:

Environment
-- Directional Light
-- Terrain
-- Terrain Plane
HelicopterController
- MD-500
-- Cockpit
-- Glass
-- Tail_Rotor
-- Top_rotor
-- View
--- Cockpit Camera
--- Belly Camera
--- Rear Camera
HeliPad


-----------------------------------------------------------------------------------

Step 7: Add Script: "HelicopterController.cs" to model "MD-500" object

-----------------------------------------------------------------------------------


On the "MD-500 object"...

Add Component: HelicopterController (BasicHelicopterController)


-----------------------------------------------------------------------------------

Step 8: Modify Settings for: "HelicopterController (Script)" 

-----------------------------------------------------------------------------------


Note: While the script will work fine and fill most of these settings by itself on 
Awake() as intended say as long as you say set the bare minimum for example rotor 
sound & transforms, hmm, let us just for good measure set all up in inspector 
instead. So, in saying such, your settings should simply look like such:

Script: HelicopterController


Components:
-----------

Rigidbody: MD-500 (Rigidbody)
Mesh Collider: MD-500 (Mesh Collider)

Rb Adjustments:
---------------

Rigibody Mass: 360
Center Of Mass Offset: X: 0 Y: 0.7 Z: 1

Transforms:
-----------

Rotors Transform Top: Top_rotor (Transform)
Rotors Transform Tail: Tail_Rotor (Transform)

Amounts:
--------

Sensitivity: 500
Throttle Amount: 25
Max Thrust: 5
Rotor speed Modifier: 10

Airspeed:
---------

Airspeed Type: Mph *

* or Kmh depending on your desired choice

Max Airspeed: 152 *

* 152 is max suggested for Mph else say 244 for Kmh for example if such was
  selected

HUD:
----

Heli HUD: Helicopter_HUD * 

* This will need to be returned to and to then be selected
once you set the interface text mesh pro hud item up in the later step as
described.

Audio:
------

Audio Source: MD-500 (Audio Source)
Rotor Sound: Helicopter_Rotor


Input Actions:
--------------


Helicopter Controls: HelicopterControls (Input Action Asset)


-----------------------------------------------------------------------------------

Step 9: Modify Settings for: "Rigidbody (Component)" 

-----------------------------------------------------------------------------------


Note: While the script will work fine and fill these particular settings by itself 
on Awake() as intended hmm, let us just for good measure set such up in inspector 
instead. So, in saying such, your specific settings should simply look like such:

Mass: 360


-----------------------------------------------------------------------------------

Step 10: Modify Settings for: "Mesh Collider (Component)" 

-----------------------------------------------------------------------------------


Note: While the script will work fine and fill this particular setting by itself 
on Awake() as intended hmm, let us just for good measure set such up in inspector 
instead. So, in saying such, your specific setting should simply look like such:

Convex: True (Bool checked)


-----------------------------------------------------------------------------------

Step 11: Outside of HelicopterController: Create Empty Game Object: "Interface"

-----------------------------------------------------------------------------------


Position: X: 0 Y: 0 Z: 0 
Rotation: X: 0 Y: 0 Z: 0 
Scale:    X: 1 Y: 1 Z: 1

Layer: UI

Next: In "Interface": add as child: "Canvas"

Layer: UI


-----------------------------------------------------------------------------------

Step 12: In "Canvas": add as child: An Empty called: "VehiclesHUD"

-----------------------------------------------------------------------------------


Position: X: 0 Y: 0 Z: 0 
Rotation: X: 0 Y: 0 Z: 0 
Scale:    X: 1 Y: 1 Z: 1

Layer: UI

Rect Transform:

Bottom Left

Pos X: 0 Y : 0 Z: 0

Width: 300 
Height: 300


-----------------------------------------------------------------------------------

Step 13: In "VehiclesHUD": add child: (UI > Text-TMPro) called: "Helicopter_HUD"

-----------------------------------------------------------------------------------


Layer: UI

Rect Transform:
---------------

Middle Center

Pos X: 160
Pos Y: 60

Width: 300
Height: 300

Text Input:
-----------

* Say if you selected speed type Kmh then such:

Throttle: 0 %
AirSpeed: 0 kmh
Altitude: 0 m

* Say if you selected speed type Mph then such:

Throttle: 0 %
AirSpeed: 0 mph
Altitude: 0 ft

* Note: that either or of the above can be added as placeholder as such will
  be overwritten on awake


Text Size: 25

Alignment: Left & Middle


So, now overall your heirarchy expanded should look like so:

ie:

Environment
-- Directional Light
-- Terrain
-- Terrain Plane
HelicopterController
- MD-500
-- Cockpit
-- Glass
-- Tail_Rotor
-- Top_rotor
-- View
--- Cockpit Camera
--- Belly Camera
--- Rear Camera
HeliPad
Interface
- Canvas
-- VehiclesHUD
--- Helicopter_HUD
EventSystem


Note: Mkay, now you should deactivate the object "Helicopter_HUD" because we
don't want it displayed before play mode is awake or start if that makes
sense... dont worry, as the entry script has a find inactive wrapper that will
sort that out on start


-----------------------------------------------------------------------------------

Step 14: Exit "Interface" & Add Script: "CameraSwitcher.cs" to "MD-500" object

-----------------------------------------------------------------------------------


On the "MD-500 object"...

Add Component: CameraSwitcher (Script)

Then re-enable the previously disabled camera named: "Cockpit Camera"
Then re-enable the previously disabled camera named: "Belly Camera"


-----------------------------------------------------------------------------------

Step 15: Modify Settings for: "Camera Switcher (Script)" 

-----------------------------------------------------------------------------------


Cameras: 3

Element 0: Cockpit Camera
Element 1: Belly Camera
Element 2: Rear Camera


Input Actions:
--------------

Helicopter Controls: HelicopterControls (Input Action Asset)


-----------------------------------------------------------------------------------

Step 16: In "Canvas": add as child: An Empty called: "VehiclesEntry"

-----------------------------------------------------------------------------------


Rect Transform:
---------------

Bottom Center

Pos: X: 0 Y: 50 Z: 0
Width: 100
Height: 100


-----------------------------------------------------------------------------------

Step 17: In "VehiclesEntry": add child: (Text-TMPro) called: "Helicopter_EntryKey" 

-----------------------------------------------------------------------------------

Layer: UI

Rect Transform:
---------------

Top Center

Pos X: 0
Pos Y: -50

Width: 100
Height: 100

Text Input:
-----------

Pilot [E]


Font Size:: 36

Alignment: Center & Middle


So, now overall your heirarchy expanded should look like so:

ie:

Environment
-- Directional Light
-- Terrain
-- Terrain Plane
HelicopterController
- MD-500
-- Cockpit
-- Glass
-- Tail_Rotor
-- Top_rotor
-- View
--- Cockpit Camera
--- Belly Camera
--- Rear Camera
HeliPad
Interface
- Canvas
-- VehiclesHUD
--- Helicopter_HUD
-- VehiclesEntry
--- Helicopter_EntryKey
EventSystem


Note: Mkay, now you should deactivate the object "Helicopter_EntryKey" because we
don't want it displayed before play mode is awake or start if that makes
sense... dont worry, as the entry script has a find inactive wrapper that will
sort that out on start


-----------------------------------------------------------------------------------

Step 18: Exit "Interface" & Add Script: "HelicopterEntry.cs" to "MD-500" object

-----------------------------------------------------------------------------------


On the "MD-500 object"...

Add Component: HelicopterEntry (Script)


Script: HelicopterEntry


Game Objects:
-------------

Helicopter: MD-500

Player: Player

Interface Text Object: Helicopter_EntryKey

Interface HUD Object: Helicopter_HUD


Cameras: (3)
------------

Element 0: Cockpit Camera

Element 1: Belly Camera

Element 2: Rear Camera


Input Actions:
--------------

Helicopter Controls: HelicopterControls (Input Action Asset)


-----------------------------------------------------------------------------------

Step 19: Edit component: "Box Collider"

-----------------------------------------------------------------------------------


Is Trigger: True

Center: X:  Y: 177.82  Z: 172.4728

Size: X: 538.356 Y: 304.3953  Z: 226.408


Note: these values are simply provided as an example and may need to be
tweaked further to your likings.


-----------------------------------------------------------------------------------

Step 20: Create: object "Player":

-----------------------------------------------------------------------------------


Create empty object and name such: "Player"

Transform: 
----------

Position: X: 0 Y: 0.9799998 Z: -15 
Rotation: X: 0 Y: 0  Z: 0 
Scale:    X: 1 Y: 1  Z: 1

Add Tag: "Player"


-----------------------------------------------------------------------------------

Step 21: Add: empty object "View":

-----------------------------------------------------------------------------------


In "Player" object, create a child of the "Player" object and name
such: "View"

Transform Position: X: 0 Y: 0 Z: 0


-----------------------------------------------------------------------------------

Step 22: Add: "Camera":

-----------------------------------------------------------------------------------


In "Player" object, add a Camera component as child of "View" and name
such: "Camera"

Transform: 
----------

Position: X: 0 Y: 0.6 Z: 0 
Rotation: X: 0 Y: 0   Z: 0 
Scale:    X: 1 Y: 1   Z: 1

Depth: "1" 

Add Tag: "MainCamera"


-----------------------------------------------------------------------------------

Step 23: Add Component: "First Person Controller (Script)"

-----------------------------------------------------------------------------------


Add: "FirstPersonController.cs" script to object: "Player"


Input Actions:
--------------

Player Controls: PlayerControls (Input Action Asset)


-----------------------------------------------------------------------------------

Step 24: Edit: the "CharacterController" component:

-----------------------------------------------------------------------------------


In "Player" object, edit the "CharacterController" component:

Height: "1.8"


-----------------------------------------------------------------------------------

Step 25: Setup: Audio Source and Footstep Sounds Audio Clips:

-----------------------------------------------------------------------------------


In "Player" object edit: the "First Person Controller (Script)"

Footstep Source: Player (AudioSource)

Footstep Sounds: "4"

Element 0: "Footstep01"
Element 1: "Footstep02"
Element 2: "Footstep03"
Element 3: "Footstep04"


-----------------------------------------------------------------------------------

Note: Lastly, you need to next follow the Player and Helicopter Compass setup
steps to finalize the setup steps!

Ok, hopefully I covered everything. After completion of those steps you should
then be able to run around your scene with your player and then enter / exit
and fly your helicopter around and see your direction by player and vehicle
compass.

-----------------------------------------------------------------------------------

Entry Script Note: the provided entry script is provided "as is" simply as a
starting point as there are some further things that will need to be touched
upon as you will find when you start tinkering with such. So note the
starting point provided was the intention to then allow you the user to
continue to expand upon this script further.

-----------------------------------------------------------------------------------


Ok, that is it and concludes the basic Helicopter Controller with entry manual
setup steps. You can now begin to modify such further for your specific
needs.

Best of Luck!
