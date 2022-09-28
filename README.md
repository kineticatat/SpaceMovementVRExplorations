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

*Another thought about spatial interactions: often the eyes are used most. If there is a way to use eye location in VR as a spatial parameter, that could be interesting, but I imagine would also be exhausting to always see eyes as a solid object (i.e. if there was a raycast for example). 

<b>Sensors: </b>
Perception Neuron Mocap:
9/21: I got my original Perception Neuron 32 suit working, but it needs a hip socket replacement. 
The V2 suit works perfectly, is easily plug and play. I am currently working on getting a battery pack to worth so it can be used untethered. 
Connecting to Unity is pretty easy using this: https://youtu.be/GPPMXcXvxDQ and this: https://support.neuronmocap.com/hc/en-us/articles/1260805842150-Live-Stream-data-into-Unity. I grabbed a basic mannequin from Mixamo and used that as the avatar: https://www.mixamo.com/#/
More info on PN's github page here: https://github.com/pnmocap/Neuron_Mocap_Live_Unity

MYO Sensor Band EMG:
https://github.com/balandinodidonato/MyoToolkit/blob/master/Software%20for%20Thalmic%27s%20Myo%20armband.md
9/21: I got the MYO band working through processing, and can get a printout of data: https://github.com/nok/myo-processing
I found the MYO Connect software here: https://synthiam.com/Support/Skills/Misc/Myo-Gesture-Armband?id=15972
I can visualize the data in processing, and do a println, but there are 8 lines of data and I'm only seeing 1 line (i) in the println.

Kinect 2:
9/28:
Soon I am going to work on getting the Kinect 2 working in Unity, as soon as the adapter comes in the mail. I have already written two scripts for popping bubbles with the hands following this tutorial: https://youtu.be/hKDaI_E7rDg

And I got the Kinect plugins and unity packages downloaded from here: https://learn.microsoft.com/en-us/windows/apps/design/devices/kinect-for-windows

For my mocap class I will do some research on cleaning up data soon. This will probably require some BVH conversion software, maybe Motionbuilder. 
The perception neuron Axis software has a built in cleanup tools, but also rigging packages such as AutoRigPro for Blender: https://www.blendermarket.com/products/auto-rig-pro


BVH conversion software:
BVH Hacker still seems to be used: https://www.bvhacker.com/


For continued Unity + Space/ Volume explorations, I want to work on a few basic concepts first:
1. Getting basic raycasting on the mocap suit, and putting that inside a volume to see the connections to space
2. Connecting the mocap suit to the character controller in the water patch to see what it feels like to maneuver the physics there
3. Spending some time brainstorming different spatial experiences that could be replicated. This might be worth contacting the environmental psychology student again. 
