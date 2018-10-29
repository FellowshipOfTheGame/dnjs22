<?php
	require 'Connection.php';
	
	$name = mysql_real_escape_string($_GET['name']);
	$color = mysql_real_escape_string($_GET['color']);

	$sql = "INSERT INTO team(name, color) VALUES ('$name', '$color');";
	$result = mysqli_query($conn, $sql);

	if(mysqli_affected_rows() > 0){
		echo ("Success");
	} else{
		echo("Error on DB.");
	}
?>