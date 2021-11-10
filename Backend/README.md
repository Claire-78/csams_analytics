# How to do Unit Testing

## Testdata

The testdata for this project is found at Test-Framework/TestData/TestData.cs
If the testdata does not contain everything you need, you will need to add more data to it.

## How to create a test

In Test-Framework, either find a folder you find approperiate for the tests you want to add, or create a new folder for it.
Create a new file in this folder for the tests you want to run.

Ensure that the new class is public and has [TestClass] as a classifier
Create the expected data you mean should be returned by the function in the folder and make them readonly.
Create your testfunctions with [TestMethod] and make them public.
Add an Assert in the function which will assert what you expect the function you're testing to return.

## How to run the tests

Simply right-click any file while the program is not running, and then click on "Run Tests"