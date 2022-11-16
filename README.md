# SpaceMovementVRExplorations

Working on creating spatial environments in 3D that affect the experience of moving in that environment. 
I am working in Unity 2020.3.31f1 right now (Sept 19, 2022)

This seems to be a focus on volumes and physics. I decided to start with water/ swimming.

9/19:
I first tried this tutorial: https://youtu.be/K8lOEmdZ78o
One issue I had is that if a box is sunken into a plane, it does not have the same trigger effect (of being able to walk through it), so the water script never kicked in. 

I am reading these tutorials now to better understand swimming and physics involved: https://catlikecoding.com/unity/tutorials/movement/swimming/
And am interested in reading the rest of them on movement as well: https://catlikecoding.com/unity/tutorials/movement/

This swimming tutorial focuses on the physics of being in water such as drag and buyoncy, as well as challenges of climbing and jumping. It also mentions "water volumes that move in their entirety because they're animated", where there is another body (of water) to manage. It is also possible to add objects to interact with that respond to player in ways that the water would dictate as well. 

There is this note: "All the water volume objects are on the Water layer, which should be excluded from all layer masks of both the moving sphere and the orbit camera. Even then, in general **the two physics queries that we currently have are meant for regular colliders only, not triggers**. Whether triggers are detected can be configured via the Physics / Queries Hit Triggers project setting. But we never want to detect triggers with the code what we have right now, so let's make that explicit, regardless of the project setting."

9/27: I now tried creating a terrain with water (AQUAS assets) and got the perception neuron suit to work in it. Though I realized that it does not have a way to propel forward. Thinking about how to make that work still. 

9/28: Thinking about how to propel/ transform position on live mocap data. FPS controllers typically use transform.position. I'm looking through some physics scripts that explore water and use a sphere to move, which appears to use ProjectDirectionOnPlane. In void UpdateConnectionState there is connectedBody.transform.TransformPoint(connectionLocalPosition)-connectionWorldPosition;
But there are a lot of other positional things happening in the swim script to account for gravity, drag, in water, jumping, etc. that probably affect a simple positional change. 

*Another thought about spatial interactions: often the eyes are used most. If there is a way to use eye location in VR as a spatial parameter, that could be interesting, but I imagine would also be exhausting to always see eyes as a solid object (i.e. if there was a raycast for example). 10/4: Another thought is that using a slow raycast that bounces back and forth between the eyes and the observed object could be useful, and constant motion of spatial acknowledgement. Also thinking of what body part initiates as a point of spatial "contact" or tangible points. 

10/4: Since the Kinect work is challenging (currently waiting on Unity 5 to open to try and play a demo... not happening), I switched to playing with Raycasting. I followed this tutorial: https://youtu.be/eP4uBtVd68E and added trail renderers to the raycasted objects to see where they travel. I think this could be a useful approach to use and pair with mocap data. 

11/3: I have been working with raycasting, drawline, and trail renderers. With no motion data I have patches working with raycasting to shoot objects that collide with a mouse position and mouse press, getting distance reported with raycasting and detecting a hit, and using the mouse to draw on the screen. I have been working to attach all these items to the kinect handtracking data, with limited success. I have gotten the raycasting detecting a hit to work, as well as putting trail renderers on the hand prefabs. Next I will work on just adding a line renderer from the hand prefab as an origin, out to world positions for drawing lines. Greg is helping by working on a patch that will dissolve objects using raycasting distance as you get closer. I hope to combine these all to make more progress. I need to do some re-envisioning of the project with the limited progress I have made so far, but I hope it moves much faster as I get a few more pieces in place. 

11/10: Greg and I got the azure kinect talking with the swimming in water (+ buoyuoncy and drag) working together and can now move the avatar both with full body tracking and with keystrokes to change the position (by adding a parent to the avatar object that has keystroke position transforms). Greg also has been working on some scripts that use raycasting to morph a wall as you get closer to it, and dissolving an object. I think these could both be very interesting for spatial perception work. 

11/16: A list of the semi/functional scenes so far:
<ul>
        <i>Motion + water with physics: physics can be unpredictable, harder to control. Needs shader work to get effects of moving through water, rather than just swimming on the surface</i>
        <i>Motion + overlay objects/ prefabs: to use with raycasting/ elastics/ springs to connect to spatial objects</i>
        <i>Motion + collider bubbles: used sprites first, but can't see through them in a space so their use needs to be limited. Can still try shader graphs, but for now have a particle system with collision. I would like to write a script to change the seeding/ size/ density based on gestures/ actions.</i>
        <i>Motion + trampoline: working on putting a physics material on a floor plane</i>
        <i>Motion + shader deforms: working on Greg's code to dissolve/ deform an object based on proximity</i>
</ul>
            

<b>Sensors: </b>
Perception Neuron Mocap:
9/21: I got my original Perception Neuron 32 suit working, but it needs a hip socket replacement. 
The V2 suit works perfectly, is easily plug and play. I am currently working on getting a battery pack to worth so it can be used untethered. 
Connecting to Unity is pretty easy using this: https://youtu.be/GPPMXcXvxDQ and this: https://support.neuronmocap.com/hc/en-us/articles/1260805842150-Live-Stream-data-into-Unity. I grabbed a basic mannequin from Mixamo and used that as the avatar: https://www.mixamo.com/#/
More info on PN's github page here: https://github.com/pnmocap/Neuron_Mocap_Live_Unity

11/3: I have the new socket kit for the PN v1 that I will fix soon. 

MYO Sensor Band EMG:
https://github.com/balandinodidonato/MyoToolkit/blob/master/Software%20for%20Thalmic%27s%20Myo%20armband.md
9/21: I got the MYO band working through processing, and can get a printout of data: https://github.com/nok/myo-processing
I found the MYO Connect software here: https://synthiam.com/Support/Skills/Misc/Myo-Gesture-Armband?id=15972
I can visualize the data in processing, and do a println, but there are 8 lines of data and I'm only seeing 1 line (i) in the println.

Kinect 2:
9/28:
I have been working with the Kinect 2 to get this tutorial of popping bubbles with your hands working: https://youtu.be/hKDaI_E7rDg
However, as of 10/4, I have been struggling to get this tutorial to work. I can just open the Kinect files and see the body moving, but when I went to follow the rest of the tutorials (which are very simple), I have a number of errors. A major one is that the tutorial uses some different classes which seem deprecated, so it worked best if I tried to do the minimum on the original kinect files and just deleted the joints I didn't need (and did not make changes to classes or functions). However I have not gotten the bubbles spawning in different locations yet (need to revisit that code more, I'm sure its a unity version/ legacy issue), or popping the bubbles (possibly because the bubbles are all spawning on top of each other, affecting the collision). 
        
I have found a few other resources I am currently diving into to better understand what is happening with the kinect data, but if I don't figure out these other simple things then I might just go back to the PN mocap suit for prototyping. 
        
https://rfilkov.com/2015/01/25/kinect-v2-tips-tricks-examples/comment-page-4/

And I got the Kinect plugins and unity packages downloaded from here: https://learn.microsoft.com/en-us/windows/apps/design/devices/kinect-for-windows

Kinect Azure: This was easy to setup and get working with RF Solution's great Unity demos. There are many great options to work with here such as collisions, rigging, and overlaid objects that will be very helpful to work with. aka.ms/kinectdocs


For my mocap class I will do some research on cleaning up data soon. This will probably require some BVH conversion software, maybe Motionbuilder. 
The perception neuron Axis software has a built in cleanup tools, but also rigging packages such as AutoRigPro for Blender: https://www.blendermarket.com/products/auto-rig-pro


BVH conversion software:
BVH Hacker still seems to be used: https://www.bvhacker.com/


For continued Unity + Space/ Volume explorations, I want to work on a few basic concepts first:
1. Getting basic raycasting on the mocap suit, and putting that inside a volume to see the connections to space
2. Connecting the mocap suit to the character controller in the water patch to see what it feels like to maneuver the physics there
3. Spending some time brainstorming different spatial experiences that could be replicated. This might be worth contacting the environmental psychology student again.
        
        
   
