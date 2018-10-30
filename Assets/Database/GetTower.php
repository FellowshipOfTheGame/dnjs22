<?php
	require 'Connection.php';
	
	$id = (int)mysqli_real_escape_string($conn, $_GET['id']);

	$sql = "SELECT team, unit FROM tower WHERE id = $id;";
	$result = mysqli_query($conn, $sql);

	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			echo($row['team'] ."|" . $row['unit']);
		}
	}
	else{
		echo ('');
	}
?>