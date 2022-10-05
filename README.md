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

10/4: Since the Kinect work is challenging (currently waiting on Unity 5 to open to try and play a demo... not happening), I switched to playing with Raycasting. I followed this tutorial: https://youtu.be/eP4uBtVd68E and added trail renderers to the raycasted objects to see where they travel. I think this could be a useful approach to use and pair with mocap data. To play with this tomorrow...

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
I have been working with the Kinect 2 to get this tutorial of popping bubbles with your hands working: https://youtu.be/hKDaI_E7rDg
However, as of 10/4, I have been struggling to get this tutorial to work. I can just open the Kinect files and see the body moving, but when I went to follow the rest of the tutorials (which are very simple), I have a number of errors. A major one is that the tutorial uses some different classes which seem deprecated, so it worked best if I tried to do the minimum on the original kinect files and just deleted the joints I didn't need (and did not make changes to classes or functions). However I have not gotten the bubbles spawning in different locations yet (need to revisit that code more, I'm sure its a unity version/ legacy issue), or popping the bubbles (possibly because the bubbles are all spawning on top of each other, affecting the collision). 
        
I have found a few other resources I am currently diving into to better understand what is happening with the kinect data, but if I don't figure out these other simple things then I might just go back to the PN mocap suit for prototyping. 
        
https://rfilkov.com/2015/01/25/kinect-v2-tips-tricks-examples/comment-page-4/
How to get the position of a body joint:

This is demonstrated in KinectScripts/Samples/GetJointPositionDemo-script. You can add it as a component to a game object in your scene to see it       in action. Just select the needed joint and optionally enable saving to a csv-file. Do not forget that to add the KinectManager as component to a       game object in your scene. It is usually a component of the MainCamera in the example scenes. Here is the main part of the demo-script that retrieves   the position of the selected joint:

        KinectInterop.JointType joint = KinectInterop.JointType.HandRight;
        KinectManager manager = KinectManager.Instance;

        if(manager && manager.IsInitialized())
        {
           if(manager.IsUserDetected())
           {
               long userId = manager.GetPrimaryUserID();

               if(manager.IsJointTracked(userId, (int)joint))
                       {
                   Vector3 jointPos = manager.GetJointPosition(userId, (int)joint);
                    // do something with the joint position
                }
            }
        }
        
https://nevzatarman.com/2015/07/13/kinect-hand-cursor-for-unity3d/
        

        
And I got the Kinect plugins and unity packages downloaded from here: https://learn.microsoft.com/en-us/windows/apps/design/devices/kinect-for-windows

For my mocap class I will do some research on cleaning up data soon. This will probably require some BVH conversion software, maybe Motionbuilder. 
The perception neuron Axis software has a built in cleanup tools, but also rigging packages such as AutoRigPro for Blender: https://www.blendermarket.com/products/auto-rig-pro


BVH conversion software:
BVH Hacker still seems to be used: https://www.bvhacker.com/


For continued Unity + Space/ Volume explorations, I want to work on a few basic concepts first:
1. Getting basic raycasting on the mocap suit, and putting that inside a volume to see the connections to space
2. Connecting the mocap suit to the character controller in the water patch to see what it feels like to maneuver the physics there
3. Spending some time brainstorming different spatial experiences that could be replicated. This might be worth contacting the environmental psychology student again.
        
        
        Kinect joints:
                { Kinect.JointType.FootLeft, Kinect.JointType.AnkleLeft },
        { Kinect.JointType.AnkleLeft, Kinect.JointType.KneeLeft },
        { Kinect.JointType.KneeLeft, Kinect.JointType.HipLeft },
        { Kinect.JointType.HipLeft, Kinect.JointType.SpineBase },
        
        { Kinect.JointType.FootRight, Kinect.JointType.AnkleRight },
        { Kinect.JointType.AnkleRight, Kinect.JointType.KneeRight },
        { Kinect.JointType.KneeRight, Kinect.JointType.HipRight },
        { Kinect.JointType.HipRight, Kinect.JointType.SpineBase },
        
        { Kinect.JointType.HandTipLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.ThumbLeft, Kinect.JointType.HandLeft },
        { Kinect.JointType.HandLeft, Kinect.JointType.WristLeft },
        { Kinect.JointType.WristLeft, Kinect.JointType.ElbowLeft },
        { Kinect.JointType.ElbowLeft, Kinect.JointType.ShoulderLeft },
        { Kinect.JointType.ShoulderLeft, Kinect.JointType.SpineShoulder },
        
        { Kinect.JointType.HandTipRight, Kinect.JointType.HandRight },
        { Kinect.JointType.ThumbRight, Kinect.JointType.HandRight },
        { Kinect.JointType.HandRight, Kinect.JointType.WristRight },
        { Kinect.JointType.WristRight, Kinect.JointType.ElbowRight },
        { Kinect.JointType.ElbowRight, Kinect.JointType.ShoulderRight },
        { Kinect.JointType.ShoulderRight, Kinect.JointType.SpineShoulder },
        
        { Kinect.JointType.SpineBase, Kinect.JointType.SpineMid },
        { Kinect.JointType.SpineMid, Kinect.JointType.SpineShoulder },
        { Kinect.JointType.SpineShoulder, Kinect.JointType.Neck },
        { Kinect.JointType.Neck, Kinect.JointType.Head },
