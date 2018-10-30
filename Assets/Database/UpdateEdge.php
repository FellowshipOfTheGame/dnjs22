<?php
	require 'Connection.php';
	
	$first = (int)mysqli_real_escape_string($conn, $_GET['first']);
	$second = (int)mysqli_real_escape_string($conn, $_GET['scnd']);
	$cost = (int)mysqli_real_escape_string($conn, $_GET['cost']);

	$sql = "UPDATE edge SET cost = $cost WHERE (firstSource = $first AND secondSource = $second) OR (firstSource = $second AND secondSource = $first)";

	$result = mysqli_query($conn, $sql);

	if(mysqli_affected_rows() > 0){
		echo ("Success");
	} else{
		echo("Error on DB.");
	}
?>