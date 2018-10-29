<?php
	require 'Connection.php';
	
	$first = (int)mysql_real_escape_string($_GET['first']);
	$second = (int)mysql_real_escape_string($_GET['scnd']);
	$cost = (int)mysql_real_escape_string($_GET['cost']);

	$sql = "INSERT INTO edge(firstSource, secondSource, cost) VALUES ($first, $second, $cost);";

	$result = mysqli_query($conn, $sql);

	if(mysqli_affected_rows() > 0){
		echo ("Success");
	} else{
		echo("Error on DB.");
	}
?>