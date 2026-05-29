// File: syntax&types.cs
// Brief intro to C# syntax and how it differs from C/C++
// - C# is a managed, object-oriented language running on the .NET CLR (JIT compiled).
// - No header files; types and namespaces are declared once and imported with 'using'.
// - Memory is garbage-collected; manual new/delete is not used. Unsafe code & pointers exist but are opt-in.
// - Default safety: no implicit pointer arithmetic, no unbounded macros, no global functions (top-level statements exist in newer C#).
// - Strongly typed with type inference via 'var' (compile-time), and generics instead of templates.
// - Distinguishing value vs reference types: structs are value types (stack-like semantics), classes are reference types.
// - Properties, events, delegates, LINQ, async/await are idiomatic features not present in C/C++ in the same form.
// - Interop with native code is possible (P/Invoke), but pattern and safety differ.

// Minimal examples illustrating common C# syntax:

using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpIntro
{
    // A simple value type (copied on assignment)
    struct Point
    {
        public int X;
        public int Y;
        public override string ToString() => $"({X},{Y})";
    }

    // A reference type with an auto-property
    class Person
    {
        public string Name { get; set; }  // property (get/set)
        public override string ToString() => Name;
    }

    class Program
    {
        static void Main()
        {
            // Type inference - 'var' is compile-time typed
            var number = 42;
            Console.WriteLine($"number is {number} ({number.GetType()})");

            // Value vs reference semantics
            var a = new Point { X = 1, Y = 2 };
            var b = a; // copies values
            b.X = 9;
            Console.WriteLine($"a: {a}, b: {b}"); // a unchanged

            var p1 = new Person { Name = "Alice" };
            var p2 = p1; // reference copy
            p2.Name = "Bob";
            Console.WriteLine($"p1: {p1}, p2: {p2}"); // both reference same object

            // Collections + LINQ (query-like operations)
            var nums = new List<int> { 1, 2, 3, 4, 5 };
            var evens = nums.Where(n => n % 2 == 0).Select(n => n * n);
            Console.WriteLine("squares of evens: " + string.Join(", ", evens));

            // Nullable handling and null-coalescing
            Person maybe = null;
            Console.WriteLine("Name: " + (maybe?.Name ?? "<unknown>"));

            // 'using' statement for IDisposable resources (deterministic disposal)
            using (var resource = new DisposableDemo())
            {
                resource.DoWork();
            }

            // interop / unsafe: only allowed in unsafe context and with proper project flags
            // C# prefers safe patterns; use unsafe only when necessary.
        }
    }

    class DisposableDemo : IDisposable
    {
        public void DoWork() => Console.WriteLine("Working...");
        public void Dispose() => Console.WriteLine("Disposed");
    }
}