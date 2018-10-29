<?php
	$servername = "localhost";
	$username = "root";
	$password = "";
	$dbName = "dnjs22";

	// Connecting
	$conn = new mysqli($servername, $username, $password, $dbName);

	// Check connection
	if(!$conn){
		echo("Connection failed... ". mysqli_connect_error());
	}
	else{
		//echo("Connection successful!");
	}
?>