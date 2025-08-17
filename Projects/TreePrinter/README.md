# TreePrinter

A C# console application to visualize binary trees from user input arrays.

## Features
- Accepts user input as a list of integers (space, comma, or semicolon separated)
- Builds a binary tree using array-to-binary-tree mapping (heap style)
- Pretty-prints the tree in a structured, readable format in the console

## Usage
1. Run the application:
   ```sh
   dotnet run
   ```
2. Enter numbers separated by spaces (e.g. `1 2 3 4 5 6 7 8 9`)
3. The program will print a visual representation of the binary tree

## Example Output
```
            1           
    ┌───────┴───────┐   
    2               3   
 ┌──┴──┐         ┌──┴──┐
 4    5         6     7
```

## Project Structure
- `Program.cs` — Main entry point, handles user input
- `TreePrinter.cs` — Contains logic for building and printing the tree

## License
MIT
