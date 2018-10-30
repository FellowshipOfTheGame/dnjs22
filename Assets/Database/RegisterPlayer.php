<?php
	require 'Connection.php';
	
	$userLogin = mysqli_real_escape_string($conn, $_GET['user']);
	$pswd = mysqli_real_escape_string($conn, $_GET['pswd']);
	$lastLogin = mysqli_real_escape_string($conn, $_GET['lastLogin']);
	$team = 1;

	echo($lastLogin);

	$sql = "INSERT INTO player(user, password, team, lastLogin) VALUES ('$userLogin', '$pswd', $team, '$lastLogin');";
	$result = mysqli_query($conn, $sql);

	if(mysqli_affected_rows() > 0){
		echo ("Success");
	} else{
		echo("Error on DB.");
	}
?>