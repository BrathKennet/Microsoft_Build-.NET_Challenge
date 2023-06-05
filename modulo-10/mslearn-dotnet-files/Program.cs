using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


// Exercise 1

Console.WriteLine("\nExercise 1\n");

var salesFiles = FindFiles("stores");

foreach (var file in salesFiles)
{
  Console.WriteLine(file);
}

IEnumerable<string> FindFiles(string folderName)
{
  List<string> salesFiles = new List<string>();

  var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

  foreach (var file in foundFiles)
  {
    if (file.EndsWith("sales.json"))
    {
      salesFiles.Add(file);
    }
  }

  return salesFiles;
}


//Exercise 2

Console.WriteLine("\nExercise 2\n");

var currentDirectory = Directory.GetCurrentDirectory();

var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesFiles2 = FindFiles2(storesDirectory);

foreach (var file in salesFiles2)
{
  Console.WriteLine(file);
}

IEnumerable<string> FindFiles2(string folderName)
{
  List<string> salesFiles = new List<string>();

  var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

  foreach (var file in foundFiles)
  {
    var extension = Path.GetExtension(file);
    if (extension == ".json")
    {
      salesFiles.Add(file);
    }
  }

  return salesFiles;
}


//Exercise 3

Console.WriteLine("\nExercise 3\n");

var currentDirectory3 = Directory.GetCurrentDirectory();

var storesDirectory3 = Path.Combine(currentDirectory3, "stores");

var salesTotalDir3 = Path.Combine(currentDirectory3, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir3);

var salesFiles3 = FindFiles3(storesDirectory3);

//File.WriteAllText(Path.Combine(salesTotalDir3, "totals.txt"), String.Empty);

foreach (var file in salesFiles3)
{
  Console.WriteLine(file);
}

IEnumerable<string> FindFiles3(string folderName)
{
  List<string> salesFiles = new List<string>();

  var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

  foreach (var file in foundFiles)
  {
    var extension = Path.GetExtension(file);
    if (extension == ".json")
    {
      salesFiles.Add(file);
    }
  }

  return salesFiles;
}


//Exercise 4

Console.WriteLine("\nExercise 4\n");

var currentDirectory4 = Directory.GetCurrentDirectory();
var storesDir4 = Path.Combine(currentDirectory4, "stores");

var salesTotalDir4 = Path.Combine(currentDirectory4, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir4);

var salesFiles4 = FindFiles4(storesDir4);

var salesTotal4 = CalculateSalesTotal(salesFiles4);

File.AppendAllText(Path.Combine(salesTotalDir4, "totals.txt"), $"{salesTotal4}{Environment.NewLine}");

foreach (var file in salesFiles3)
{
  Console.WriteLine(file);
}

IEnumerable<string> FindFiles4(string folderName)
{
  List<string> salesFiles = new List<string>();

  var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

  foreach (var file in foundFiles)
  {
    var extension = Path.GetExtension(file);
    if (extension == ".json")
    {
      salesFiles.Add(file);
    }
  }

  return salesFiles;
}


double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
  double salesTotal = 0;

  // Loop over each file path in salesFiles
  foreach (var file in salesFiles)
  {
    // Read the contents of the file
    string salesJson = File.ReadAllText(file);

    // Parse the contents as JSON
    SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

    // Add the amount found in the Total field to the salesTotal variable
    salesTotal += data?.Total ?? 0;
  }

  return salesTotal;
}

record SalesData (double Total);