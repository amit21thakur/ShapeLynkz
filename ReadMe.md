### Sample Queries

Draw an isosceles triangle with a height of 200 and a width of 100

Draw a square with a side length of 200

Draw a scalene triangle with a width of 200 and a height of 200 and a side length of 300.

Draw a Parallelogram  with a width of 300 and a height of 150 and a side length of 250.

Draw an Equilateral Triangle with a side length of 300.

Draw an Pentagon with a side length of 200

Draw a rectangle with a width of 250 and a height of 400

Draw an Hexagon with a side length of 200

Draw an Heptagon with a side length of 200

Draw an Octagon with a side length of 200

Draw a circle with a radius of 100

Draw an Oval with a height of 200 and a width of 100

### Expression Syntax
![Expression Syntax Logic](https://github.com/amit21thakur/ShapeLynkz/blob/master/Expression_Logic.jpg)

The expression is saved as a linked list, where each node corresponds to a single word in the query sentence.

Each node contains an implementation of IDataReader interface - which reads word as either key or value or just ignores it.

Each node contains an implementation of ISyntaxValidator interface, which validates wherether its a correct syntax.
