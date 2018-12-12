<?php
    require 'Connection.php';
    
	$sql = "SELECT team from ((select team, count(*) as ct from player group by team) as q) order by ct asc limit 1;";
	$result = mysqli_query($conn, $sql);

	if(mysqli_num_rows($result) > 0){
		while($row = mysqli_fetch_assoc($result)){
			echo($row['team']);
		}
	}
	else{
		echo ('');
	}
?>