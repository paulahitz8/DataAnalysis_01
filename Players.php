<?php
$servername = "localhost";
$username = "paulahm";
$password = "Q3XqC6eBG6";
$dataBase = "paulahm";

// Create connection
$conn = mysqli_connect($servername, $username, $password, $dataBase);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$Name = mysqli_real_escape_string($conn,$_GET["Name"]);
$Country = $_GET["Country"];
$Date = $_GET["Date"];

$sql = "INSERT INTO Players (Name, Country, Date)
VALUES ('$Name', '$Country', '$Date')";

if ($conn->query($sql) === TRUE) {
   $last_id = $conn->insert_id;
  echo "" . $last_id;
} else {
  echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();
?>
