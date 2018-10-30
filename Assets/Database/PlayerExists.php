<?php
	require 'Connection.php';
	
	$userLogin = mysqli_real_escape_string($conn, $_GET['user']);
	
	$sql = "SELECT * FROM player WHERE user = '$userLogin';";
	$result = mysqli_query($conn, $sql);

	if(mysqli_num_rows($result) > 0){
		echo('True');
	}
	else{
		echo ('False');
	}