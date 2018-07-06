<?php

$LoginKey = md5($_POST['key']);

$sqlss = new mysqli("localhost", "MeServer", "MeServer", "dbname");

$result = mysqli_query($sqlss, "SELECT * FROM users WHERE Id='$LoginKey';");
$resultCheck = mysqli_num_rows($result);

if($resultCheck == 0) {
mysqli_query($sqlss, "INSERT INTO users(Id) VALUES('$LoginKey');");
echo 'Success';
}
else
echo 'Existing...';

?>
