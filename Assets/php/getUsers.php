<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unityshinanaide";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "Connected successfully. bakit not showinggg";

$sql = "SELECT username, gambas, wins FROM user";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo "username: " . $row["username"]. " - gambas: " . $row["gambas"]. "wins: " . $row["wins"]. "<br>";
  }
} else {
  echo "0 results";
}
$conn->close();

?>