<?php
	require 'Connection.php';
	
	$first = (int)mysqli_real_escape_string($conn, $_GET['first']);
	$second = (int)mysqli_real_escape_string($conn, $_GET['scnd']);
	$cost = (int)mysqli_real_escape_string($conn, $_GET['cost']);

	$sql = "INSERT INTO edge(firstSource, secondSource, cost) VALUES ($first, $second, $cost);";

	$result = mysqli_query($conn, $sql);

	if(mysqli_affected_rows() > 0){
		echo ("Success");
	} else{
		echo("Error on DB.");
	}
?>