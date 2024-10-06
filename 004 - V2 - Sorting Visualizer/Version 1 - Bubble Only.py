from graphics import *
import random
import time

def generateList(length):
    myList = []
    
    for i in range(length):
        check = False
        while check == False:
            x = random.randint(1, length)
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
        y2 = 900 - (number * 8)
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
 
def GraphicsMain():
    win = GraphWin('My Graphics', 2000, 1000)
    myList = generateList(10)
    print(myList)
    myList = bubble_sort(myList, win)
    print(myList) 
    win.getMouse()
    win.close()
    return win

GraphicsMain()


