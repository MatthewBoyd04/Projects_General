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
        BorderDefault = 50
        BorderTop = BorderDefault
        BorderLeft = BorderDefault
        BorderRight = 350
        BorderBottom = BorderDefault

        xSquares = 8
        ySquares = 8

        GridColor1 = "#fbf5de" #Light
        GridColor2 = "#f8e7bb" #Dark

        GridSizeX = self.window.width - (BorderLeft + BorderRight)
        GridSizeY = self.window.height - (BorderTop + BorderBottom)

        SquareSizeX = GridSizeX / xSquares
        SquareSizeY = GridSizeY / ySquares

        for x in range(xSquares):
            for y in range(ySquares):
                p1x = BorderLeft + (SquareSizeX * x)
                p1y = BorderTop + (SquareSizeY * y)
                p2x = BorderLeft + (SquareSizeX * (x + 1))
                p2y = BorderTop + (SquareSizeY * (y + 1))

                p1 = Point(p1x, p1y)
                p2 = Point(p2x, p2y)

                gridSquare = Rectangle(p1,p2)

                if x % 2 == 0: 
                    if y % 2 == 0:
                        gridSquare.setFill(GridColor1)
                    else:
                        gridSquare.setFill(GridColor2)
                if x % 2 == 1: 
                    if y % 2 == 0:
                        gridSquare.setFill(GridColor2)    
                    else:         
                        gridSquare.setFill(GridColor1)    
                
                gridSquare.draw(self.window)
