<?php
	require 'Connection.php';
	

	$userLogin = mysqli_real_escape_string($conn, $_GET['user']);
	$pswd = mysqli_real_escape_string($conn, $_GET['pswd']);
	$lastLogin = mysqli_real_escape_string($conn, $_GET['lastLogin']);
	$troops = mysqli_real_escape_string($conn, $_GET['troops']);

	$sql = "UPDATE player SET troops = '$troops' WHERE user = '$userLogin' AND password = '$pswd';";
	$result = mysqli_query($conn, $sql);

?>