# Be Kind, Rewind - NUnit
C# automated testing of a VHS movie rental class library (OOP & NUnit)<br>

[attributes](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/attributes/),
[dotnet](https://learn.microsoft.com/en-us/dotnet/api/?view=net-6.0),
[nunit](https://docs.nunit.org/articles/nunit/writing-tests/assertions/assertions.html),
[oop](https://www.w3schools.com/cs/cs_oop.php)<br>

## To run automated tests
`dotnet test`

## Test cases with specific test data
| ID  | Category | Title | Pre | Input | Action | Expected |
| --- | -------- | ----- | --- | ----- | ------ | -------- |
| #01 | Smoke | Base sanity check | Constructed with name "Hello" | n/a | Get name | "Hello" |
| #02 | Smoke | Member sanity check | Constructed with name "Hello"<br>and membership number 7 | n/a | Get membership id | "#000007" |
| #03 | Smoke | Movie sanity check | Constructed with name "Hello World",<br> genre "Horror"<br>and year 1974 | n/a | i. Get id length<br>ii. Get name<br>iii. Get genre<br>iv. Get year | i. 36<br>ii. "Hello World"<br>iii. "Horror"<br>iv. "1974" |
| ... | etc... |

# Test cases generic of test data
| ID  | Category | Title | Pre | Input | Action | Expected |
| --- | -------- | ----- | --- | ----- | ------ | -------- |
| #01 | Smoke | Base sanity check | Constructed with a typical name | n/a | Get name | Same name as constructed |
| #02 | Smoke | Member sanity check | Constructed with any name<br>and a reasonable integer | n/a | Get membership id | Same integer as constructed,<br>padded with 0's to six digits<br>and with a leading "#" |
| ... | etc... |

## .NET solution commands
These commands were used during project construction:<br>
`dotnet new gitignore`<br>
`dotnet new classlib --output src/Rewind`<br>
`dotnet new nunit --output test/Rewind.Tests`<br>
`dotnet add test/Rewind.Tests reference src/Rewind/Rewind.csproj`<br>
`dotnet new sln`<br>
`dotnet sln add src/Rewind/Rewind.csproj`<br>
`dotnet sln add test/Rewind.Tests/Rewind.Tests.csproj`<br>
