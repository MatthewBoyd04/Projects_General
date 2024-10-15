#----------Header----------
# Project: Grid
# Class: Main
# Creation Date: 06/10/2024
# Last Update: 06/10/24
# Author: Matthew Boyd
# Language: Python
#--------------------------

from graphics import * 



class GameBoard: 
    def __init__ (self):
        winHeight = 900
        winWidth = 1200
        self.window = GraphWin("Chess", winWidth, winHeight)

        self.drawBoard()

    def drawBoard(self): 
        #----------------------Properties----------------------
        BorderDefault = 50
        self.BorderTop = BorderDefault
        self.BorderLeft = BorderDefault
        self.BorderRight = 350
        self.BorderBottom = BorderDefault

        xSquares = 8
        ySquares = 8

        self.GridColor1 = "#fbf5de" #Light
        self.GridColor2 = "#f8e7bb" #Dark
        #----------------------Properties----------------------
        
        GridSizeX = self.window.width - (self.BorderLeft + self.BorderRight)
        GridSizeY = self.window.height - (self.BorderTop + self.BorderBottom)

        self.SquareSizeX = GridSizeX / xSquares
        self.SquareSizeY = GridSizeY / ySquares


        for x in range(xSquares):
            for y in range(ySquares):

                p1 = self.pointCalculator(x,y)
                p2 = self.pointCalculator(x+1,y+1)
                gridSquare = Rectangle(p1,p2)

                gridSquare.setFill(self.determineSquareColor(x,y)) 
                gridSquare.draw(self.window)

    def pointCalculator(self,x,y):
        xPoint = self.BorderLeft + (self.SquareSizeX * x)
        yPoint = self.BorderTop + (self.SquareSizeY * y)
        point = Point(xPoint, yPoint)
        return point
    
    def determineSquareColor(self,x,y):
        if x % 2 == 0: 
            if y % 2 == 0:
                color = self.GridColor1
            else:
                color = self.GridColor2
        if x % 2 == 1: 
            if y % 2 == 0:
                color = self.GridColor2  
            else:         
                color = self.GridColor1  
        return color
