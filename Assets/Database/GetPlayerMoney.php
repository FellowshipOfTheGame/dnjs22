<?php
	require 'Connection.php';

	$userLogin = mysqli_real_escape_string($conn, $_GET['user']);
	$pswd = mysqli_real_escape_string($conn, $_GET['pswd']);

	$sql = "SELECT money FROM player WHERE user = '$userLogin' AND password = '$pswd';";
	$result = mysqli_query($conn, $sql);

	
	if(mysqli_num_rows($result) > 0){
		$row = mysqli_fetch_assoc($result);
		echo($row['money']);
	}
	else{
		echo ('');
	}
?>