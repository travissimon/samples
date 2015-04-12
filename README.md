# At-home interview questions from various job interviews

These are simple C# projects that include the code from various at-home tests administered during job interviews.

Because of this, the requirements and resulting code are both quite simple. However, if you want to see if I can
fizz-buzz in C#, this project might be a good place to look.

The questions asked were:

Collections
-----------

- Find the fifth-last element in a linked list of integers

I called this YAGNI collections to show that I wouldn't write code that wasn't needed. In this case, I wrote a linked list implemenetation that only supported integers, rather than using generics.

I think I wrote the list to always track the fifth last element, as that was all that was asked for in the interview. In the realy worlds, you would use List<T> for such things.

Glosasary
---------

This appears to be a Silverlight application. I don't remember what the question was.

Test Driver
-----------

Runs the test cases. Useful if you don't have XUnit installed.

Triangles
---------

This was a fun little question: Given the lengths of the three sides of a triangle, determine if the triangle is equilateral, isoscolese or scalene.

Utilities
---------

Write a utility to reverse the words in a sentance. I went a little overboard here and coded in certain assumptions, such as 'don't include the trailing punctuation'. I probably wouldn't have bothered, except that I already had the string parser class from something else.
