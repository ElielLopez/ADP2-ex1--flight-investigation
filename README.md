# Flight Simulator
## Desktop application for flight data review


#### Instructions
1. open Flight Gear application.
2. Go to Settings -> Additional Settings
3. enter command: 
  * --generic=socket,in,10,127.0.0.1,5400,tcp,playback_small
  * --fdm=null
4. Fly!
5. Click on Open XML and choose the correct xml file you want to upload.
6. Click Open File and choose the correct CSV file you want to upload.
7. The flight will begin immidiatlly.

#### Media Player
* Play - continue playing video.
* Pause - stop playing video.
* Farward - skip 10 second farward.
* Backward - go back 10 second farward.
* Speed Up - speed up playback video by 0.1.
* Speed Down - speed down playback video by 0.1.

#### Features
- JoyStick - according to the Elevator and Aileron values the joystick will update its location.
- Dashboard - display of the values such as Air Speed and Pitch roll degree.
- Throttle - the slider will move according the throttle values between -1 and 1.
- Rudder - the slider will move according the rudder values between -1 and 1.
- Time - will display the current time of the video (time from start).

#### UML Diagram
![WhatsApp Image 2021-04-14 at 19 34 25](https://user-images.githubusercontent.com/58383829/114746823-d0299100-9d58-11eb-8c9a-00a5b1860508.jpeg)

### Notes
WPF .net Frakework project.

