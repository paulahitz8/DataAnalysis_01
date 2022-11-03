<?php
$servername = "localhost";
$username = "paulahm";
$password = "Q3XqC6eBG6";
$dataBase = "paulahm";

$PlayerID = $_GET["PlayerID"];
$SessionID = $_GET["SessionID"];
$ItemID = $_GET["ItemID"];
$BuyDate = $_GET["BuyDate"];

// Create connection
$conn = mysqli_connect($servername, $username, $password, $dataBase);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "INSERT INTO Purchases (PlayerID, SessionID, ItemID, BuyDate)
VALUES ('$PlayerID', '$SessionID', '$ItemID', '$BuyDate')";

if ($conn->query($sql) === TRUE) {
   $last_id = $conn->insert_id;
  echo "" . $last_id;
} else {
  echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();
?>