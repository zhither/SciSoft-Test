# SciSoft-Test

## Overview

SciSoft-Test is a C# application that performs parking slot calculations, draws various shapes, and refactors code. The application is containerized using Docker, enabling it to run seamlessly both within Docker and locally.

## Table of Contents

- [SciSoft-Test](#scisoft-test)
  - [Overview](#overview)
  - [Table of Contents](#table-of-contents)
  - [Prerequisites](#prerequisites)
  - [Project Structure](#project-structure)
  - [Building the Docker Image](#building-the-docker-image)
  - [Running the Application in Docker](#running-the-application-in-docker)
  - [Running the Application Locally](#running-the-application-locally)

---

## Prerequisites

Ensure you have the following installed:

- **.NET SDK (8.0 or higher):**  
  [Download .NET SDK](https://dotnet.microsoft.com/download)

- **Docker Desktop:**  
  [Download Docker Desktop](https://www.docker.com/products/docker-desktop)  
  Make sure Docker is running.

---

## Project Structure


---

## Building the Docker Image

1. **Navigate to Project Directory:**

    ```powershell
    cd D:\projects\SciSoft-test
    ```

2. **Build the Docker Image:**

    ```powershell
    docker build -t csharptest-app .
    ```

    - `-t csharptest-app`: Tags the image as `csharptest-app`.
    - `.`: Uses the current directory as the build context.

---

## Running the Application in Docker

1. **Ensure the `output` Directory Exists:**

    ```powershell
    mkdir D:\projects\SciSoft-test\output
    ```

2. **Run the Docker Container:**

    ```powershell
    docker run --rm -v D:/projects/SciSoft-test/output:/app/output csharptest-app
    ```

    - `--rm`: Automatically removes the container after it exits.
    - `-v D:/projects/SciSoft-test/output:/app/output`: Maps the host's `output` directory to the container's `/app/output` directory.
    - `csharptest-app`: The Docker image name.

3. **Verify Output:**

    Check `D:\projects\SciSoft-test\output` for generated `.txt` files (`bitmap_shapes.txt`, `shapes.txt`).

---

## Running the Application Locally

1. **Ensure the `output` Directory Exists:**

    ```powershell
    mkdir D:\projects\SciSoft-test\output
    ```

2. **Modify `BitmapCanvas.cs` for Relative Paths:**

    Ensure `BitmapCanvas.cs` uses relative paths to write to the `output` directory.

    ```csharp
    // src/Shapes/BitmapCanvas.cs
    using System;
    using System.IO;

    namespace CSharpTest.Shapes
    {
        public class BitmapCanvas : ICanvas
        {
            private readonly string _outputFilePath;

            public BitmapCanvas(string outputDirectory = "output", string outputFileName = "bitmap_shapes.txt")
            {
                string baseDirectory = Directory.GetCurrentDirectory();
                string fullOutputDirectory = Path.Combine(baseDirectory, outputDirectory);
                _outputFilePath = Path.Combine(fullOutputDirectory, outputFileName);

                if (!Directory.Exists(fullOutputDirectory))
                {
                    Directory.CreateDirectory(fullOutputDirectory);
                }
            }

            // ... (Draw methods)

            private void ExportShapeDetails(string shapeName, string[] details)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(_outputFilePath, append: true))
                    {
                        writer.WriteLine($"{shapeName}:");
                        foreach (var detail in details)
                        {
                            writer.WriteLine($"  {detail}");
                        }
                        writer.WriteLine();
                    }
                    Console.WriteLine($"Exported {shapeName} details to {_outputFilePath}.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to {_outputFilePath}: {ex.Message}");
                }
            }
        }
    }
    ```

3. **Build and Run Locally:**

    ```powershell
    cd D:\projects\SciSoft-test\src
    dotnet build
    dotnet run
    ```

4. **Verify Output:**

    Check `D:\projects\SciSoft-test\output` for the generated `.txt` files.

---

