<?php
	require 'Connection.php';

	$userLogin = mysqli_real_escape_string($conn, $_GET['user']);
	$pswd = mysqli_real_escape_string($conn, $_GET['pswd']);
   $money = mysqli_real_escape_string($conn, $_GET['money']);
	$sql = "UPDATE player SET money='$money' where player WHERE user = '$userLogin' AND password = '$pswd';";
	$result = mysqli_query($conn, $sql);

?>