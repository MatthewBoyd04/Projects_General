# -*- coding: utf-8 -*-
"""
Created on Sun Jan  7 23:01:10 2024

@author: chunk
"""

from graphics import *
import random
import time

def generateList(length):
    myList = []
    
    for i in range(length):
        check = False
        while check == False:
            x = random.randint(1, length * 2)
            if x not in myList:
                myList.append(x)
                check = True
    return myList

def clear_graph(win):
    # Iterate through all items in the window and undraw them
    for item in win.items[:]:
        item.undraw()

def DrawGraph(myList, win):
    clear_graph(win)
    i = 0
    for number in myList:
        x1 = 104+(i*10)
        x2 = 96 + (i*10) 
        y1 = 900
        y2 = 900 - (number * 4)
        p1 = Point(x1, y1)
        p2 = Point(x2, y2)
        rect = Rectangle(p1,p2)
        rect.draw(win)
        i = i + 1
    time.sleep(0.1)
        
def bubble_sort(arr,win):
    
    n = len(arr) 
    # Traverse through all array elements
    for i in range(n):
        # Last i elements are already in place, so we don't need to check them
        for j in range(0, n - i - 1):
            # Swap if the element found is greater than the next element
            if arr[j] > arr[j + 1]:
                arr[j], arr[j + 1] = arr[j + 1], arr[j]
            DrawGraph(arr, win)
            print(arr)
    return arr

def selection_sort(arr,win):
    n = len(arr)
    
    for i in range(n - 1):
        # Find the minimum element in the unsorted part of the array
        min_index = i
        for j in range(i + 1, n):
            if arr[j] < arr[min_index]:
                min_index = j
        # Swap the found minimum element with the first element
        arr[i], arr[min_index] = arr[min_index], arr[i]
        DrawGraph(arr, win)
        print(arr)
    return arr

def insertion_sort(arr,win):

    n = len(arr)
    
    for i in range(1, n):
        key = arr[i]
        j = i - 1
        
        # Move elements of arr[0..i-1] that are greater than key to one position ahead of their current position
        while j >= 0 and key < arr[j]:
            arr[j + 1] = arr[j]
            j -= 1
        arr[j + 1] = key
        DrawGraph(arr, win)
        print(arr)
    return arr    

def counting_sort(arr,win):

    # Find the maximum value in the array
    max_val = max(arr)
    
    # Create a count array to store the count of each element
    count = [0] * (max_val + 1)

    # Count the occurrences of each element
    for num in arr:
        count[num] += 1

    # Reconstruct the sorted array
    sorted_arr = []
    for i in range(max_val + 1):
        sorted_arr.extend([i] * count[i])
        print(sorted_arr)
        DrawGraph(sorted_arr, win)
    return sorted_arr
def radix_sort_with_pass_output(arr, win):
    max_num = max(arr)
    exp = 1

    while max_num // exp > 0:
        counting_sort_by_digit_with_pass_output(arr, exp,win)
        exp *= 10


def counting_sort_by_digit_with_pass_output(arr, exp, win):
    n = len(arr)
    output = [0] * n
    count = [0] * 10

    # Count the occurrences of each digit at the current place value
    for i in range(n):
        index = arr[i] // exp
        count[index % 10] += 1

    # Update the count array to store the actual position of each digit
    for i in range(1, 10):
        count[i] += count[i - 1]

    # Build the output array by placing elements in their correct positions
    i = n - 1
    while i >= 0:
        index = arr[i] // exp
        output[count[index % 10] - 1] = arr[i]
        count[index % 10] -= 1
        i -= 1

    # Update the original array with the sorted elements
    for i in range(n):
        arr[i] = output[i]

        # Print the state of the array after each pass
        print("Pass:", arr) 
        DrawGraph(arr, win)



def GraphicsMain(Algorithm):
    win = GraphWin('My Graphics', 2000, 1000)
    myList = generateList(100)
    print(myList)
    if Algorithm == 1:
        myList = bubble_sort(myList, win)
    elif Algorithm == 2: 
        myList = selection_sort(myList, win)
    elif Algorithm == 3: 
        myList = insertion_sort(myList, win)
    elif Algorithm == 4: 
        myList = counting_sort(myList, win)
    elif Algorithm == 5: 
        myList = radix_sort_with_pass_output(myList, win)
    print(myList) 
    win.getMouse()
    win.close()
    return win

def GetAlgorithmChoice():
    check = False
    while check == False: 
        print("(1) for Bubble Sort")
        print("(2) for Selection Sort")
        print("(3) for insertion Sort")
        print("(4) for Counting Sort")
        print("(5) for Radix Sort")
        x = int(input("Enter Number for selection: "))
        if x > 0 and x < 6:
            check = True
    return x

UserInput = GetAlgorithmChoice()

GraphicsMain(UserInput)

