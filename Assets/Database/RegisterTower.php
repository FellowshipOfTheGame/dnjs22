<?php
	require 'Connection.php';
	
	$team = (int)mysql_real_escape_string($_GET['team']);
	$unit = (int)mysql_real_escape_string($_GET['unit']);

	if($team == -1){
		$team = null;
		echo("null?");
	}

	if($unit == -1){
		$unit = 0;
		echo($unit);
	}

	if(is_null($team))
		$sql = "INSERT INTO tower(team, unit) VALUES (null, $unit);";
	else
		$sql = "INSERT INTO tower(team, unit) VALUES ($team, $unit);";
	$result = mysqli_query($conn, $sql);

	if(mysqli_affected_rows() > 0){
		echo ("Success");
	} else{
		echo("Error on DB.");
	}
?>