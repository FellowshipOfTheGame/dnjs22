<?php
	require 'Connection.php';

	$userLogin = mysqli_real_escape_string($conn, $_GET['user']);
	$pswd = mysqli_real_escape_string($conn, $_GET['pswd']);

	$sql = "SELECT * FROM player WHERE user = '$userLogin' AND password = '$pswd';";
	$result = mysqli_query($conn, $sql);

	
   if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			echo($row['id'] ."|" . $row['lastLogin'] . "|" . $row['money'] . "|" . $row['password'] . "|" . $row['team'] . "|" . $row['troops']);
		}
	}
	else{
		echo ('');
	}
?>