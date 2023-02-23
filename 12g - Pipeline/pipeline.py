# -*- coding: utf-8 -*-
"""
Created on Sat Jan 14 04:22:01 2023

@author: olive
"""

##Opgave A
import operator
import csv


class addConst:
    """Add input together with c. Using 45 as input and 3 as c:"""
    
    def __init__(self,c):
        self.c = c
    
    def apply(self,n):
        self.n = n
        return self.c+n
    
    def description(self):
        return f"add {self.c} with {self.n}"

class Repeater:
    """create a list with num elements
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
    """Using a binary associative operator the step will return the sum.
    Apply input must be iterable -> [1,2,3,4]"""

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


#potato = GeneralSum(1,operator.mul)
#print(potato.apply([1,2,3,4,5]))
#potato = GeneralSum(0,operator.add)
#print(potato.apply([1,2,3,4,5]))

class SumNum(GeneralSum):
    """Directly inherting from GeneralSum this step will sum up all the numbers
    apply requires that the input is iterable"""
    def __init__(self):
        super().__init__(0,operator.add)

    def descriptuon(self):
        return "adds all the numbers together using the + operator"

class ProductNum(GeneralSum):
    """Directly inherting from GeneralSum this step will give you sum
    simmilarily to the factorial function"""
    def __init__(self):
        super().__init__(1,operator.mul)

    def description(self):
        return "sums up all the elements similarily to the factorial function,using the * operator"

#Opgave B

class Map:
    """Will map the given function over alle elements in the list (must be iterable)
    """

    def __init__(self,x):
        self.x = x

    def apply(self,i):
        return [self.x.apply(j) for j in i]

    def description(self):
        return f"map {self.x} over all elements"



##Opgave C

class Pipeline:
    """Use this step to put all of our previous functions into one list
    """
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



#Opgave D

class Csvreader:
    """this step will take a csv file as input and return it as a python dictionary"""
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
    and return a new dictionary with the frequencies of each colour"""
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
    where * is the frequency"""
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






#opgave E

class Cube:
    """Cubes the input"""
    def __init__(self,x):
        self.x = x

    def apply(self):
        return self.x**self.x

    def description(self):
        return f"cubes {self.x}"


class Readme:
    """reads a file and returns it in the console"""
    def __init__(self,text):
        self.text = text

    def apply(self):
        with open (self.text) as file:
            lines = file.readlines()
        return lines

    def description(self):
        return f"Returns {self.text}"

