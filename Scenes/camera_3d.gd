extends Camera3D
var camera_2d: Camera2D
var player: CharacterBody2D # or RigidBody2D / Node2D

@export var scale_factor: float = 100.0  # Divides 2D pixels into 3D meters
@export var height_offset: float = 10.0  # Keeps the 3D camera hovering above
# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	var root = get_tree().root
	var scenemanager = root.get_node("SceneManager")
	var mainscene = scenemanager.get_node("main scene")
	player = mainscene.get_node("Player")
	camera_2d = player.get_node("Camera2D")
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	if camera_2d:
		# Use global_position to get the actual coordinates in the game world
		var global_2d = camera_2d.global_position
		
		# Map 2D X to 3D X, and 2D Y to 3D Z (depth)
		global_position.x = global_2d.y / scale_factor*-2
	
		global_position.z = global_2d.x / scale_factor*+2
		
		# Keep Y at a constant height so it points downward properly
		global_position.y = height_offset
