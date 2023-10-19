<?php

    $con = mysqli_connect('localhost', 'root', 'root', 'id21423868_shinanaidedb');

    //check that connection happened
    if (mysqli_connect_errno())
    {
        echo "1: Connection Failed."; //error code #1 = connection failed
        exit();
    }

    $username = $_POST["name"];
    $password = $_POST["password"];

    //check if name/username exists
    $namecheckquery = "SELECT name FROM user WHERE username='" . $username . "';";

    $namecheck = mysqli_query($con, $namecheckquery) or die("2: Name Check query failed."); //error code #2 = name check query failed

    if (mysqli_num_rows($namecheck) > 0)
    {
        echo "3: Name Already Exist"; //error code #3 = name exists (cannot register)
        exit();
    }

    //add user to the table 
    $insertuserquery = "INSERT INTO user (name) VALUES ('" . $username . "');" ;
    mysqli_query($con, $insertuserquery) or die("4: Insert user query failed") //error code #4 inser query failed 

    echo("0");




    
?>