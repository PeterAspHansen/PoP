# -*- coding: utf-8 -*-
"""
Created on Sat Jan 14 04:35:35 2023

@author: olive
"""
import csv
import operator

class addConst:
    """Add input together with c. Using 45 as input and 3 as c:
    >>> addConst(45).apply(3)
    48
    >>> addConst(3).apply(-3)
    0
    >>> addConst("Works?).apply(-3)
    TypeError: can only concatenate str (not "int") to str"""
    
    def __init__(self,c):
        self.c = c
    
    def apply(self,n):
        self.n = n
        return self.c+n
    
    def description(self):
        return f"add {self.c} with {self.n}"
    


class Repeater:
    """create a list with num elements
    >>> Repeater(5).apply(20)
    [20, 20, 20, 20, 20]
    """
    def __init__(self,num):
        self.num = num
        self.element = None
        
    def apply(self,element):
        self.element = element
        return [element] * self.num

    def description(self):
        return f"make a list with {self.element}, {self.num} times"
  



class GeneralSum:
    """Using a binary associative operator the function will return the sum.
    Apply input must be iterable [1,2,3,4]
    >>> GeneralSum(1,operator.mul).apply[1,2,3,4,5]
    120
    >>> GeneralSum(0,operator.add).apply[1,2,3,4,5]
    15
    """

    def __init__(self, neutral, op):
        self.neutral = neutral
        self.op = op

    def apply(self, applier):
        result = self.neutral
        for element in applier:
            result = self.op(result, element)
        return result

    def description(self):
        return f"Sums up all the elements using either the factorial function or +. Current operator is : {self.op}"


class SumNum(GeneralSum):
    """Directly inherting from GeneralSum this function will sum up all the numbers
    apply requires that the input is iterable
    >>> SumNum().apply[1,2,3,4,5]
    15"""
    def __init__(self):
        super().__init__(0,operator.add)

    def descriptuon(self):
        return "adds all the numbers together using the + operator"


class ProductNum(GeneralSum):
    """Directly inherting from GeneralSum this function will give you sum
    simmilarily to the factorial function
    >>> SumNum().apply[1,2,3,4,5]
    15"""
    def __init__(self):
        super().__init__(1,operator.mul)

    def description(self):
        return "sums up all the elements similarily to the factorial function,using the * operator"


class Map:
    """Will map the given function over alle elements in the list (must be iterable)
    >>> Map(addConst(-3)).apply([1,2,3,4,5])
    [-2, -1, 0, 1, 2]
    """

    def __init__(self,x):
        self.x = x

    def apply(self,i):
        return [self.x.apply(j) for j in i]

    def description(self):
        return f"map {self.x} over all elements"


class Pipeline:
    """Use this function to put all of our previous functions into one list
    >>> Pipeline([addConst(45),Repeater(3),Map(addConst(5))]).apply([1])
    [51, 51, 51]"""
    def __init__(self,x):
        self.x = x

    def apply(self,y):
        for x in self.x:
            y = x.apply(y)
        return y

    def description(self):
        des = ""
        for x in self.x:
            des += x.description() +", "
        return des


class Csvreader:
    """this step will take a csv file as input and return it as a python dictionary
    >>> Csvreader("critters.csv).apply()
    [{'Name': 'Poppy', 'Colour': 'peru', 'Hit Points': '2'}, {'Name': 'Aggie', 'Colour': 'gold', 'Hit Points': '6'}, {'Name': 'Ben', 'Colour': 'tomato', 'Hit Points': '10'"""
            
    data =[]
    def __init__(self,file):
        self.file = file

    def apply(self):
        with open(self.file, newline='') as csvfile:
            csv_read = csv.DictReader(csvfile)
            for row in csv_read:
                self.data = self.data + [row]
            return self.data



class Csvstats:
    """this step will take a dictionary as input 
    and return a new dictionary with the frequencies of each colour
    >>> Csvstats(Csvreader("critters.csv").apply())
    {'peru': 5, 'gold': 2, 'tomato': 1, 'pink': 3, 'red': 3, 'oldlace': 3, 'cyan': 6, 'bisque': 1, 'purple': 3, 'azure': 3, 'grey': 6, 'skyblue': 2, 'blue': 4, 'ivory': 3, 'khaki': 5, 'navy': 5, 'linen': 2, 'dimgrey': 5, 'plum': 2, 'salmon': 3,
     etc"""
    def __init__(self,critters):
            self.critters = critters

    def apply(self):
        colourdict = {}
        for i in self.critters:
            colourstat = i['Colour']
            if colourstat in colourdict:
                colourdict[colourstat] += 1
            else:
                colourdict[colourstat] = 1
        return colourdict
    
    
    
    
class ShowAsciiBarchart:
    """this step will take a dictionary as input and return a new dictionary with the frequencies of each colour
    where * is the frequency
    >>> ShowAsciiBarchart(Csvreader("critters.csv").apply())
    peru : *****
gold : **
tomato : *
pink : ***
red : ***
etc"""
    def __init__(self,critters):
        self.critters = critters

    def apply(self):
        ascdict= {}
        for i in self.critters:
            asciistat = i['Colour']
            if asciistat in ascdict:
                ascdict[asciistat] += '*'
            else:
                ascdict[asciistat] = '*'
        for colour,asci in ascdict.items():
            print (f"{colour} : {asci}")
            
            
            
            

    
class Cube:
    """Cubes the input
    >>>Cube(3).apply
    27"""
    def __init__(self,x):
        self.x = x

    def apply(self):
        return self.x**self.x

    def description(self):
        return f"cubes {self.x}"


class Readme:
    """reads a file and returns it in the console
    >>>Readme("README.txt").apply()
    "info in the next file"
    """
    def __init__(self,text):
        self.text = text

    def apply(self):
        with open (self.text) as file:
            lines = file.readlines()
        return lines

    def description(self):
        return f"Returns {self.text}"




if __name__ == "__main__":
    import doctest
    doctest.testmod()
