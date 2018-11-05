<?php
	require 'Connection.php';

	$userLogin = mysqli_real_escape_string($conn, $_GET['user']);
	$pswd = mysqli_real_escape_string($conn, $_GET['pswd']);
	$lastLogin = mysqli_real_escape_string($conn, $_GET['lastLogin']);

	$sql = "UPDATE player SET lastLogin = '$lastLogin' WHERE user = '$userLogin' AND password = '$pswd';";
	$result = mysqli_query($conn, $sql);

?>