/*
Introduction to C# Syntax and Types

This file provides a concise introduction to C# syntax and its core type system,
with short examples and notes highlighting how C# differs from C++.

Key points:
- C# is a managed, object-oriented language targeting the .NET runtime (CLR/CLI).
- Memory is managed by a garbage collector; manual delete is not used.
- C# has a unified type system: every type ultimately derives from `object`.
- C# uses namespaces instead of header/source separation; compilation produces
  assemblies (DLL/EXE) rather than native object files by default.
- There is no multiple inheritance for classes (interfaces are used instead).
- Unsafe pointer code exists but is opt-in and rare for typical apps.

Differences from C++ (high level):
- Memory management: C++ uses RAII and manual allocation; C# uses GC.
- Compilation model: C++ compiles to native binaries; C# compiles to IL and runs on the CLR.
- Syntax: both share C-like syntax, but C# has features like properties, events,
  delegates, LINQ, `foreach`, `using` for disposal, and pattern matching.
- Templates vs generics: C++ templates are compile-time and more powerful; C# generics
  are reified at runtime on the CLR and simpler to use for common cases.
- Header files: C++ has headers and separate compilation units; C# organizes code
  with namespaces and source files without header/source split.

Use this file as both a reference and a tiny runnable demo.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Fundamentals.SyntaxAndTypes
{
	// Simple examples to demonstrate basic syntax and common types
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("--- C# Syntax & Types Introduction ---\n");

			// 1. Primitives and type inference
			int integer = 42;               // value type
			double real = 3.14;             // value type
			bool flag = true;               // value type
			char ch = 'Æ';                  // value type
			string text = "Hello, C#";    // reference type (immutable)

			var inferred = 100;             // compiler infers `int`

			Console.WriteLine($"int: {integer}, double: {real}, bool: {flag}, char: {ch}");
			Console.WriteLine($"string: {text}, inferred (var): {inferred}\n");

			// 2. Nullable value types (distinct from reference null)
			int? maybe = null; // Nullable<int>
			Console.WriteLine($"Nullable int has value: {maybe.HasValue}");
			maybe = 7;
			Console.WriteLine($"Nullable int now: {maybe.Value}\n");

			// 3. Arrays, lists, tuples
			int[] numbersArray = { 1, 2, 3 };
			var list = new List<string> { "a", "b", "c" };
			(int, string) pair = (1, "one");

			Console.WriteLine($"Array length: {numbersArray.Length}, List[1]: {list[1]}, Tuple: {pair}");
			Console.WriteLine();

			// 4. Classes, structs, enums
			var p = new Person("Alice", 30);
			var pt = new Point { X = 3, Y = 4 }; // struct (value type)
			Console.WriteLine(p);
			Console.WriteLine($"Point magnitude: {pt.Magnitude():F2}\n");

			// 5. Properties and object initializers
			var book = new Book { Title = "C# in Practice", Pages = 320 };
			Console.WriteLine(book);

			// 6. Delegates and lambda (comparison to function pointers in C++)
			Func<int, int, int> add = (a, b) => a + b;
			Console.WriteLine($"add(2,3) using delegate/lambda: {add(2, 3)}\n");

			// 7. LINQ (language-integrated queries) - convenient collection processing
			var evens = numbersArray.Where(n => n % 2 == 0).ToArray();
			Console.WriteLine($"Evens from array: {string.Join(",", evens)}\n");

			// 8. Pattern matching (modern C# feature)
			object maybeNumber = 123;
			if (maybeNumber is int value)
			{
				Console.WriteLine($"Pattern matched int: {value}\n");
			}

			// 9. Unsafe pointers exist but require `unsafe` and special project settings.
			Console.WriteLine("Note: Unsafe pointer code is allowed in C# but rarely needed.");

			Console.WriteLine("\n--- Quick differences vs C++ ---");
			Console.WriteLine("- Garbage collected vs manual memory management (RAII/explicit delete)");
			Console.WriteLine("- No header/source separation; single compilation to IL assemblies");
			Console.WriteLine("- No multiple inheritance for classes (use interfaces)");
			Console.WriteLine("- Rich runtime features: reflection, runtime type info, LINQ, async/await");
			Console.WriteLine("- Safer default: bounds-checked arrays, no implicit pointer arithmetic");

			Console.WriteLine("\nRun small examples or inspect the types above to learn more.");
		}
	}

	class Person
	{
		public string Name { get; }
		public int Age { get; }

		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}

		public override string ToString() => $"Person(Name={Name}, Age={Age})";
	}

	struct Point
	{
		public double X { get; set; }
		public double Y { get; set; }

		public double Magnitude() => Math.Sqrt(X * X + Y * Y);
	}

	enum Suit { Clubs, Diamonds, Hearts, Spades }

	class Book
	{
		public string Title { get; set; }
		public int Pages { get; set; }
		public override string ToString() => $"Book: {Title} ({Pages} pages)";
	}
}

