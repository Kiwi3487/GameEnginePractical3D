# GameEnginePractical3D

State pattern

The player behaves depending on their current situation. The PlayerMovement script acts as the main controller (called the context) that holds a reference to the current state. When the game starts, the player enters the MoveState, which allows movement along the X-axis based on player input. This state listens for actions such as hitting an enemy and when that happens, the player transitions into the HitState. In the HitState, movement input is disabled, and a coroutine runs for one second before automatically switching back to MoveState.

Observer
I had no time for the observer but how I would do it is the Observer Pattern would be used to let different parts of the game automatically react when something happens like when the player collects fuel. The Player acts as the observer, which detects events such as collisions with a fuel object. When this happens, the player sends a notification to any observers that are listening like the UI, UIManager then responds by updating on screen elements like the score or fuel text.

