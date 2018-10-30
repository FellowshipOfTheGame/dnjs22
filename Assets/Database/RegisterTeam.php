<?php
	require 'Connection.php';
	
	$name = mysqli_real_escape_string($conn, $_GET['name']);
	$color = mysqli_real_escape_string($conn, $_GET['color']);

	$sql = "INSERT INTO team(name, color) VALUES ('$name', '$color');";
	$result = mysqli_query($conn, $sql);

	if(mysqli_affected_rows() > 0){
		echo ("Success");
	} else{
		echo("Error on DB.");
	}
?>