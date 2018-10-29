<?php
	require 'Connection.php';
	
	$userLogin = mysql_real_escape_string($_GET['user']);
	$pswd = mysql_real_escape_string($_GET['pswd']);
	$lastLogin = mysql_real_escape_string($_GET['lastLogin']);
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