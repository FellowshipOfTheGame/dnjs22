<?php
	require 'Connection.php';
	
	$userLogin = mysql_real_escape_string($_GET['user']);
	
	$sql = "SELECT * FROM player WHERE user = '$userLogin';";
	$result = mysqli_query($conn, $sql);

	if(mysqli_num_rows($result) > 0){
		echo('True');
	}
	else{
		echo ('False');
	}