<?php
  
$action = $_POST['action'];
$LoginKey = md5($_POST['key']);
$hwidUser = md5($_POST['hwid']);

$sqlss = new mysqli("localhost", "MeServer", "MeServer", "dbname");

$result = mysqli_query($sqlss, "SELECT * FROM users WHERE Id='$LoginKey';");
$resultCheck = mysqli_num_rows($result);

if($action == "resethwid")
{
  if($resultCheck > 0) {
    while($row = mysqli_fetch_assoc($result)){
      mysqli_query($sqlss, "UPDATE users SET hwid = '$hwidUser' WHERE Id = '$LoginKey';");
	  $newTime = $row['ActivationTime'] - 3600;
      mysqli_query($sqlss, "UPDATE users SET ActivationTime = '$newTime' WHERE Id = '$LoginKey';");
      echo "Cipher153";
    }
  }
  else
   {
    echo "Cipher312";
   }
}
if($action == "activate")
{
  if($resultCheck > 0) {
    while($row = mysqli_fetch_assoc($result)){
      if($row['ActivationTime'] == NULL)
      {
        mysqli_query($sqlss, "UPDATE users SET hwid = '$hwidUser' WHERE Id = '$LoginKey';");
        mysqli_query($sqlss, "UPDATE users SET ActivationTime = UNIX_TIMESTAMP() WHERE Id = '$LoginKey';");
        echo "Cipher495";
      }
      else
      {
        echo "Cipher214";
      }
    }
  }
  else
  {
    echo "Cipher312";
  }
}
if($action == "login")
{
  if($resultCheck > 0) {
    while($row = mysqli_fetch_assoc($result)){
      if($row['hwid'] == $hwidUser){
        $timeRegistered = $row['ActivationTime'];
        $nowtime = time();
        $delta = round(abs($nowtime - $timeRegistered) / 60,2);
        
        if($delta < 1440.00){
          echo "Cipher666";
        }
        else
        {
          echo "Cipher888";
        }
      }
      else
      {
        echo "Cipher999";
      }
    }
  }
  else
  {
    echo "Cipher312";
  }
}

function secondsToTime($seconds) {
    $dtF = new \DateTime('@0');
    $dtT = new \DateTime("@$seconds");
    return $dtF->diff($dtT)->format('%a days, %h hours, %i minutes and %s seconds');
}
if($action == "getTime")
{
	if($resultCheck > 0) {
		while($row = mysqli_fetch_assoc($result)){
			if($row['hwid'] == $hwidUser){
			$timeRegistered = $row['ActivationTime'];
			$nowtime = time();
			if($nowtime - $timeRegistered <= 1440.0)
				{
			
			$delta = round(abs($nowtime - $timeRegistered),0);
			echo secondsToTime(86400 - $delta);
}
			else
				echo "Cipher888";
			}
			else
			{
				echo "Cipher999";
			}
		}
	}
	else
	{
		echo "Cipher312";
	}
}

?>
