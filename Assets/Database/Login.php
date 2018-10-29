<?php
	require 'Connection.php';
	

	$userLogin = mysql_real_escape_string($_GET['user']);
	$pswd = mysql_real_escape_string($_GET['pswd']);
	//$userLogin = "Gabriel";
	//$pswd = "123";

	$sql = "SELECT * FROM player WHERE user = '$userLogin' AND password = '$pswd';";
	$result = mysqli_query($conn, $sql);

	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			echo($row['id'] ."|" . $row['lastLogin'] . "|" . $row['money'] . "|" . $row['password'] . "|" . $row['team'] . "|" . $row['user']);
		}
	}
	else{
		echo ('');
	}
?>