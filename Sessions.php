<?php
$servername = "localhost";
$username = "paulahm";
$password = "Q3XqC6eBG6";
$dataBase = "paulahm";

$onNewSession = $_REQUEST["onNewSession"];

// Create connection
$conn = mysqli_connect($servername, $username, $password, $dataBase);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

if ($onNewSession) {
  $PlayerID = $_GET["PlayerID"];
  $SessionStart = $_GET["SessionStart"];
  $sql = "INSERT INTO Sessions (PlayerID, SessionStart)
  VALUES ('$PlayerID', '$SessionStart', '$SessionEnd')";
}
else {
  $SessionID = $_GET["SessionID"];
  $SessionEnd = $_GET["SessionEnd"];
  $sql = "UPDATE Sessions SET SessionEnd='$SessionEnd' 
  WHERE SessionID='$SessionID' and PlayerID='$PlayerID'";
}

if ($conn->query($sql) === TRUE) {
  if ($onNewSession) {
    $last_id = $conn->insert_id;
    echo "" . $last_id;
  }
} 
else {
  echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();
?>