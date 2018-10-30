<?php
	require 'Connection.php';
	
	$id = (int)mysqli_real_escape_string($conn, $_GET['id']);
	$team = (int)mysqli_real_escape_string($conn, $_GET['team']);
	$unit = (int)mysqli_real_escape_string($conn, $_GET['unit']);

	if($team == -1){
		$team = null;
		//echo("null?");
	}

	if($unit == -1){
		$unit = 0;
		//echo($unit);
	}

	if(is_null($team))
		$sql = "UPDATE tower set team = null, unit = $unit WHERE id = $id;";
	else
		$sql = "UPDATE tower set team = $team, unit = $unit WHERE id = $id;";
	$result = mysqli_query($conn, $sql);

	if(mysqli_affected_rows() > 0){
		echo ("Success");
	} else{
		echo("Error on DB.");
	}
?>